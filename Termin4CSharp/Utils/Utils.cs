using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;
using Termin4CSharp.View.CustomControls;
using static System.Windows.Forms.CheckedListBox;

namespace Termin4CSharp
{
    class Utils
    {

        public enum MembersOptimizedFor
        {
            QUERIES, EDITVIEW
        }

        /// <summary>
        /// Gets the attributes of an IModel/object with the use of reflection and regex
        /// </summary>
        /// <param name="paramObj">The IModel to get attributes from</param>
        /// <param name="memOptFor">If the members should be optimized for QUERIES = no IModels or List of IModels</param>
        /// <returns>A dictionary with key = attributename, value = that attributes value, or null/default</returns>
        public static Dictionary<string, object> GetAttributeInfo(Object paramObj, MembersOptimizedFor memOptFor = MembersOptimizedFor.QUERIES)
        {
            Dictionary<string, object> attributeValues = new Dictionary<string, object>();
            Type t = paramObj.GetType();
            string excludePattern = "([g|s]et|ToString|Equals|GetHashCode|GetType|.ctor|GetIdentifyingAttribute|GetReferencedModels|RoomStateOnHour";
            if (memOptFor == MembersOptimizedFor.QUERIES)
                excludePattern += "|\\bRooms\\b|\\bBuilding\\b|\\bBookings\\b|\\bRoom\\b|\\bPerson\\b|\\bRoomType\\b|\\bRole\\b|\\bResources\\b";
            else if (memOptFor == MembersOptimizedFor.EDITVIEW)
                excludePattern += "|\\bBName\\b|\\bRType\\b|\\bRoleName\\b|\\bPersonId\\b|\\bRoomId\\b|\\bPersonId\\b";
            excludePattern += ")";
            var names = t.GetMembers()
                        .Select(x => x.Name)
                        .Where(x => !Regex.IsMatch(x, excludePattern));
            var properties = t.GetProperties();
            foreach (string attName in names)
            {
                object value = null;
                if (paramObj is IModel)
                {
                    var refModels = ((IModel)paramObj).GetReferencedModels();
                    if (memOptFor == MembersOptimizedFor.EDITVIEW && refModels.ContainsKey(attName))
                    {
                        // Create IModel
                        if (refModels[attName] is IModel)
                        {
                            Type ttt = Type.GetType("Termin4CSharp.Model." + attName);
                            value = Activator.CreateInstance(ttt);
                            // Create List<IModel>
                        }
                        else if (refModels[attName].GetType().IsGenericType)
                        {
                            Type typeThatListHolds = refModels[attName].GetType().GetGenericArguments()[0];
                            value = (IList)typeof(List<>)
                                .MakeGenericType(typeThatListHolds)
                                .GetConstructor(Type.EmptyTypes)
                                .Invoke(null);
                        }
                        else
                            throw new Exception("unhandled");

                        attributeValues[attName] = value;
                    }
                    else
                    {
                        PropertyInfo pi = t.GetProperty(attName);
                        Type methodRetType = pi.GetMethod.ReturnType;
                        var a = pi.GetValue(paramObj, null);
                        attributeValues[attName] = pi == null ? "" : pi.GetValue(paramObj, null);
                    }
                }
            }
            return attributeValues;
        }

        /// <summary>
        /// Parses a SqlDataReader to the specified IModel. 
        /// </summary>
        /// <param name="model">IModel that has been fetched</param>
        /// <param name="dr">The reader that contains the results for the fetching</param>
        /// <returns>Returns an IModel from the values in the SqlDataReader</returns>
        public static IModel ParseDataReaderToIModel(IModel model, SqlDataReader dr)
        {
            var attributeInfo = Utils.GetAttributeInfo(model);
            object instance = Utils.GetInstanceFromIModel(model);

            foreach (string attributeName in attributeInfo.Keys)
            {
                var value = dr[attributeName] == DBNull.Value ? null : dr[attributeName];
                instance.GetType().GetProperty(attributeName).SetValue(instance, value, null);
            }
            dynamic castedInstance = Convert.ChangeType(instance, model.GetType());
            return castedInstance;
        }

        /// <summary>
        /// Parses the controls in the EditView to IModel
        /// </summary>
        /// <param name="model">The IModel that has been edited</param>
        /// <param name="controlValues">The controls in the EditView</param>
        /// <param name="queryType">If the IModels ID is auto incrementing in database, skip inserting an ID-value in the query</param>
        /// <returns>A parsed IModel from the specified controls</returns>
        public static IModel ParseWinFormsToIModel(IModel model, Dictionary<string, object> controlValues, QueryType queryType)
        {
            var attributeInfo = Utils.GetAttributeInfo(model, MembersOptimizedFor.QUERIES);
            if (queryType != QueryType.REMOVE && Utils.IdIsAutoIncrementInDb(model))
                attributeInfo.Remove(model.GetIdentifyingAttributes().First().Key);

            object instance = Utils.GetInstanceFromIModel(model);

            string propertyName = null;
            foreach (string key in attributeInfo.Keys)
            {
                if (controlValues.ContainsKey(key) == false)
                {
                    propertyName = Utils.ConvertReferencedIModelToColumnName(model, key);
                }
                else
                {
                    propertyName = key;
                }
                var value = controlValues[propertyName];
                instance.GetType().GetProperty(key).SetValue(instance, value, null);
            }
            dynamic castedInstance = Convert.ChangeType(instance, model.GetType());
            return castedInstance;
        }

        /// <summary>
        /// Creates a dynamic instance from an IModel
        /// </summary>
        /// <param name="model">The IModel to create an instance for</param>
        /// <returns>Returns an empty IModel</returns>
        private static object GetInstanceFromIModel(IModel model)
        {
            Type modelType = model.GetType();
            var attributeInfo = Utils.GetAttributeInfo(model);
            ConstructorInfo constructorInfo = modelType.GetConstructor(Type.EmptyTypes);
            object instance = constructorInfo.Invoke(Type.EmptyTypes);
            return instance;
        }

        /// <summary>
        /// Connects or nulls the reference to the targetModel for all the items in the referencedIModels based on the param connect
        /// </summary>
        /// <param name="referencedIModels">The list of IModels to be added or nulled</param>
        /// <param name="targetModel">The target IModel that references or dereferences the list of IModels</param>
        /// <param name="connect">If the list of IModels should be added or nulled</param>
        /// <returns></returns>
        public static SqlCommand ConnectOrNullReferencedIModelsToIModelToQuery(List<IModel> referencedIModels, IModel targetModel, bool connect)
        {
            string tableName = Utils.IModelTableName(referencedIModels.First());

            StringBuilder sqlBuilder = new StringBuilder();

            string foreignKeyAtt = null, foreignKeyVal = null;
            if (referencedIModels.First() is Room && targetModel is Building)
            {
                foreignKeyAtt = "BName";
                if (connect)
                    foreignKeyVal = ((Building)targetModel).Name;
            }

            Dictionary<string, object> fkAttributes = new Dictionary<string, object>();
            sqlBuilder.Append(string.Format("update {0} set {1} = @{1}", tableName, foreignKeyAtt));
            fkAttributes[foreignKeyAtt] = foreignKeyVal;

            Dictionary<string, object> whereParams = new Dictionary<string, object>();

            string idAttName = referencedIModels.First().GetIdentifyingAttributes().First().Key;
            object idAttValue = null;
            sqlBuilder.Append(string.Format(" where {0} in (", idAttName));
            int indexCounter = 0;
            foreach (IModel model in referencedIModels)
            {
                idAttValue = model.GetIdentifyingAttributes().First().Value;
                sqlBuilder.Append(string.Format("@@{0}, ", idAttName + "" + indexCounter));
                whereParams[idAttName + "" + indexCounter++] = idAttValue;
            }
            sqlBuilder.Remove(sqlBuilder.Length - 2, 2);
            sqlBuilder.Append(")");

            SqlCommand cmd = new SqlCommand(sqlBuilder.ToString());
            Utils.FillSqlCmd(cmd, fkAttributes);
            Utils.FillSqlCmd(cmd, whereParams, isWhereParams: true);
            return cmd;
        }

        /// <summary>
        /// Creates a query based on the IModel and the other parameters
        /// </summary>
        /// <param name="queryType">If the query is an UPDATE, GET, DELETE or ADD</param>
        /// <param name="model">The IModel to be modified</param>
        /// <param name="optWhereParams">Optional where parameters, key = columnname, value = columnvalue</param>
        /// <param name="optTableName">Optional tablename</param>
        /// <param name="optWhereCondition">Specifies if the where should search with equals (=) or LIKE</param>
        /// <param name="selectAll">Specifies if all values from the IModels-table should be selected</param>
        /// <param name="bookingSearchOnDate">When searching for bookings on a date, this specifies which date to be search on</param>
        /// <returns>A filled SQL command ready to be inserted into a database</returns>
        public static SqlCommand IModelToQuery(QueryType queryType, IModel model, Dictionary<string, object> optWhereParams = null, string optTableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL, bool selectAll = false, DateTime bookingSearchOnDate = default(DateTime))
        {
            string tableName = optTableName != null ? optTableName : Utils.IModelTableName(model);

            if (tableName == null)
                throw new Exception(String.Format("Table could not be found! IModel: {0} optTableName: {1}", model.GetType(), optTableName));

            if (selectAll && queryType != QueryType.GET)
                throw new Exception("Can't do query without where-params if it's not a get-query!");

            StringBuilder sqlBuilder = new StringBuilder();
            Dictionary<string, object> modelAttributes = Utils.GetAttributeInfo(model);

            string modelKeys = "", modelValues = "";
            foreach (string key in modelAttributes.Keys)
            {

                // For non-GET-queries, if the id is autoincrementing, we're skipping inserting/updating this value
                if (queryType != QueryType.GET && key.Equals("id", StringComparison.InvariantCultureIgnoreCase) && Utils.IdIsAutoIncrementInDb(model))
                    continue;

                // If it's an UPDATE the key/values must be next to eacother, i.e. key1 = value1, key2 = value2
                if (queryType == QueryType.UPDATE)
                {
                    modelKeys += key.ToLower() + " = @" + key + ", ";
                    // Else they can be added to the end of the query: i.e. insert into tbl [keys] values [values]
                }
                else
                {
                    modelKeys += key.ToLower() + ", ";
                    modelValues += "@" + key + ", ";
                }
            }
            if (modelKeys.Length > 2)
                modelKeys = modelKeys.Substring(0, modelKeys.Length - 2); //removing ", "
            if (modelValues.Length > 2)
                modelValues = modelValues.Substring(0, modelValues.Length - 2); //removing ", "

            switch (queryType)
            {
                case QueryType.ADD:
                    sqlBuilder.Append(string.Format("insert into {0} ({1}) values ({2})", tableName, modelKeys, modelValues));
                    break;
                case QueryType.GET:
                    sqlBuilder.Append(string.Format("select {0} from {1}", modelKeys, tableName));
                    break;
                case QueryType.REMOVE:
                    sqlBuilder.Append(string.Format("delete from {0}", tableName));
                    break;
                case QueryType.UPDATE:
                    sqlBuilder.Append(string.Format("update {0} set {1}", tableName, modelKeys));
                    break;
            }

            // Unless we have specified we want to select all from the IModel-table, add where-conditions, else do query without where
            if (selectAll == false)
            {
                // Adding where conditions if there's any values in the optWhereParams -- OR -- adding the IModels identifying attribute if it's an UPDATE or REMOVE-query
                if ((optWhereParams != null && optWhereParams.Count > 0) || (queryType == QueryType.REMOVE || queryType == QueryType.UPDATE || queryType == QueryType.GET))
                {
                    string eqOperator = Utils.WhereConditionToString(optWhereCondition);
                    sqlBuilder.Append(" where ");

                    // If its an UPDATE, REMOVE or GET-query, change the optWhereParams-dict to the identifying attributes of IModel
                    if ((optWhereParams == null || optWhereParams.Count == 0) && (queryType == QueryType.REMOVE || queryType == QueryType.UPDATE || queryType == QueryType.GET))
                        optWhereParams = model.GetIdentifyingAttributes();

                    foreach (KeyValuePair<string, object> whereKV in optWhereParams)
                    {
                        string key = whereKV.Key.ToLower();
                        string val = "@@" + whereKV.Key;
                        sqlBuilder.Append(key + " " + eqOperator + " " + val);
                        sqlBuilder.Append(" and ");
                    }
                    sqlBuilder.Remove(sqlBuilder.Length - 5, 5); //Removes " and "
                }
            }

            SqlCommand cmd = new SqlCommand(sqlBuilder.ToString());
            if (queryType != QueryType.GET)
                Utils.FillSqlCmd(cmd, modelAttributes);
            if (optWhereParams != null && optWhereParams.Count > 0)
                Utils.FillSqlCmd(cmd, optWhereParams, true);
            if (bookingSearchOnDate != default(DateTime) && !cmd.CommandText.Contains("where"))
            {
                cmd.CommandText += " where start_time >= @@@start and end_time <= @@@end";
                cmd.Parameters.Add("@@@start", SqlDbType.DateTime).Value = (DateTime)bookingSearchOnDate.Date;
                cmd.Parameters.Add("@@@end", SqlDbType.DateTime).Value = (DateTime)bookingSearchOnDate.Date.AddDays(1);
            }
            return cmd;
        }

        /// <summary>
        /// Finds rooms with the specified optional filters on a specified date. If a freetext is specified the other filters wont be included.
        /// </summary>
        /// <param name="onDate">The date to search for bookings on</param>
        /// <param name="buildingNames">The building names the rooms should be connected to</param>
        /// <param name="roomIDs">The room ids the room should have</param>
        /// <param name="resourceNames">The resources the rooms should be having</param>
        /// <param name="freeText">A freetext that searches for buildingname, roomid and resourcename</param>
        /// <param name="minCapacity">The minimum capacity the room should have</param>
        /// <returns>A list filtered rooms based on the parameters</returns>
        public static SqlCommand FindRoomsWithFilters(HashSet<string> buildingNames, HashSet<string> roomIDs, HashSet<string> resourceNames, string freeText = null, int minCapacity = 0)
        {

            StringBuilder sqlBuilder = new StringBuilder();
            var modelAttributes = Utils.GetAttributeInfo(new Room());
            string columns = "ro." + string.Join(", ro.", modelAttributes.Keys);
            columns += ", b.avail_start as 'opening', b.avail_end as 'closing'";
            sqlBuilder.Append(string.Format("select distinct {0} from {1} ro ", columns, DbFields.RoomTable));

            var whereParams = new Dictionary<string, object>();
            bool whereAdded = false;
            int indexCounter = 0;

            WhereCondition whereCondition = WhereCondition.EQUAL;

            sqlBuilder.Append(" inner join Building b on b.name = ro.bname " +
                              "left join Room_Resource rr " +
                              "on rr.roomID = ro.id " +
                              "left join Resource re " +
                              "on rr.resID = re.id ");

            if (freeText != null)
            {
                sqlBuilder.Append(" where ro.bname like @@freeText0 " +
                " or ro.id like @@freeText1 " +
                " or re.id like (select innerRes.id from Resource innerRes where type in (@@freeText3)) " +
                " or ro.floor like @@freeText4 " + 
                " or ro.rtype like @@freeText5");
                for (int i = 0; i < 6; i++)
                    whereParams["freeText" + i] = freeText;
                whereCondition = WhereCondition.LIKE;
            }
            else if (buildingNames != null || roomIDs != null || resourceNames != null)
            {
                // Adding building filters
                if (buildingNames != null && buildingNames.Any())
                {
                    sqlBuilder.Append("where ro.bname in (");
                    string key = "";
                    foreach (string buildName in buildingNames)
                    {
                        key = "index" + indexCounter++;
                        sqlBuilder.Append("@@" + key + ", ");
                        whereParams[key] = buildName;
                    }
                    whereAdded = true;
                    sqlBuilder.Remove(sqlBuilder.Length - 2, 2); //Removes ", "
                    sqlBuilder.Append(")");
                }
                // Adding roomid filters
                if (roomIDs != null && roomIDs.Any())
                {
                    if (whereAdded)
                    {
                        sqlBuilder.Append(" and ");
                    }
                    else
                    {
                        sqlBuilder.Append(" where ");
                        whereAdded = true;
                    }
                    sqlBuilder.Append("ro.id in (");
                    string key = "";
                    foreach (string roomID in roomIDs)
                    {
                        key = "index" + indexCounter++;
                        sqlBuilder.Append("@@" + key + ", ");
                        whereParams[key] = roomID;
                    }
                    sqlBuilder.Remove(sqlBuilder.Length - 2, 2); //Removes ", "
                    sqlBuilder.Append(")");
                }
                // Adding resource filters
                if (resourceNames != null && resourceNames.Any())
                {
                    if (whereAdded)
                        sqlBuilder.Append(" and ");
                    else
                    {
                        sqlBuilder.Append(" where ");
                        whereAdded = true;
                    }
                    sqlBuilder.Append("re.id in (select innerRes.id from Resource innerRes where type in (");
                    string key = "";
                    foreach (string resID in resourceNames)
                    {
                        key = "index" + indexCounter++;
                        sqlBuilder.Append("@@" + key + ", ");
                        whereParams[key] = resID;
                    }
                    sqlBuilder.Remove(sqlBuilder.Length - 2, 2); //Removes ", "
                    sqlBuilder.Append("))");

                }

                // Adding minimum capacity filter
                if (whereAdded)
                    sqlBuilder.Append(" and ");
                else
                    sqlBuilder.Append(" where ");
                sqlBuilder.Append(" ro.capacity >= " + minCapacity);
            }
            SqlCommand cmd = new SqlCommand(sqlBuilder.ToString());
            Utils.FillSqlCmd(cmd, whereParams, isWhereParams: true, whereCondition: whereCondition);

            return cmd;
        }

        /// <summary>
        /// Fills an SQL command based on the queryParams with the correct .NET to MSSQL datatype
        /// </summary>
        /// <param name="cmd">The command with @keys for attributes, and @@keys for where parameters</param>
        /// <param name="queryParams">The query parameters</param>
        /// <param name="isWhereParams">Specifies if the queryParams are where parameters or attribute setters</param>
        /// <param name="whereCondition">Specifies if the optional WHERE should be searched with equal (=) or LIKE</param>
        /// <param name="bookingSearchOnDate">When searching for bookings on a date, this specifies which date to be search on</param>
        private static void FillSqlCmd(SqlCommand cmd, Dictionary<string, object> queryParams, bool isWhereParams = false, WhereCondition whereCondition = WhereCondition.EQUAL, DateTime bookingSearchOnDate = default(DateTime))
        {

            if (queryParams != null)
            {
                foreach (KeyValuePair<string, object> attKV in queryParams)
                {

                    string key = (isWhereParams ? "@@" : "@") + attKV.Key; //One @ for params, two @@ for whereConditions
                    object val = attKV.Value;

                    if (val is IModel)
                        val = ((IModel)val).GetIdentifyingAttributes().First().Value;

                    /*      NULL        **/
                    if (val == null)
                        cmd.Parameters.AddWithValue(key, DBNull.Value);
                    /**     TEXT        **/
                    else if (val is string)
                    {
                        if (whereCondition == WhereCondition.LIKE)
                            val = "%" + val + "%";
                        cmd.Parameters.Add(key, SqlDbType.VarChar).Value = val as string;
                    }
                    /**     NUMBERS     **/
                    else if (val is Int32)
                        cmd.Parameters.Add(key, SqlDbType.Int).Value = (Int32)val;
                    else if (val is Int64)
                        cmd.Parameters.Add(key, SqlDbType.BigInt).Value = (Int64)val;
                    else if (val is double)
                        cmd.Parameters.Add(key, SqlDbType.Float).Value = (double)val;
                    else if (val is decimal)
                        cmd.Parameters.Add(key, SqlDbType.Decimal).Value = (decimal)val;
                    /**     DATETIME    **/
                    else if (val is DateTime)
                        cmd.Parameters.Add(key, SqlDbType.DateTime).Value = (DateTime)val;
                    /**     BOOL        **/
                    else if (val is bool)
                        cmd.Parameters.Add(key, SqlDbType.Bit).Value = (bool)val;

                    else
                        throw new Exception("Type not implemented: " + val.GetType());
                }
            }
        }

        /// <summary>
        /// Converts an IModels attribute name to a display friendly name
        /// </summary>
        /// <param name="model">The target IModel who has the attribute</param>
        /// <param name="key">The attributename</param>
        /// <returns>A display friendly name</returns>
        public static string ConvertAttributeNameToDisplayName(IModel model, string attributeName)
        {

            if (model == null || attributeName == null)
                return null;
            string retName = attributeName;

            if (model is Person)
            {
                switch (attributeName.ToLower())
                {
                    case "person":
                        retName = "person";
                        break;
                    case "modeleqv":
                        retName = "En person";
                        break;
                    case "name":
                        retName = "Namn";
                        break;
                    case "id":
                        retName = "ID";
                        break;
                    case "phonenbr":
                        retName = "Telefonnummer";
                        break;
                    case "email":
                        break;
                    case "role":
                        retName = "Behörighetsroll";
                        break;
                }
            }
            else if (model is Room)
            {
                switch (attributeName.ToLower())
                {
                    case "room":
                        retName = "rum";
                        break;
                    case "modeleqv":
                        retName = "Ett rum";
                        break;
                    case "bname":
                        retName = "Byggnadsnamn";
                        break;
                    case "capacity":
                        retName = "Antal platser";
                        break;
                    case "floor":
                        retName = "Våning";
                        break;
                    case "id":
                        retName = "ID";
                        break;
                    case "roomtype":
                        retName = "Rumtyp";
                        break;
                    case "resources":
                        retName = "Tillgängliga resurser";
                        break;
                    case "rtype":
                        retName = "Rumtyp";
                        break;
                }
            }
            else if (model is Building)
            {
                switch (attributeName.ToLower())
                {
                    case "building":
                        retName = "byggnad";
                        break;
                    case "modeleqv":
                        retName = "En byggnad";
                        break;
                    case "address":
                        retName = "Adress";
                        break;
                    case "avail_end":
                        retName = "Stängningstid";
                        break;
                    case "avail_start":
                        retName = "Öppningstid";
                        break;
                    case "name":
                        retName = "Namn";
                        break;
                    case "rooms":
                        retName = "Rum";
                        break;
                }
            }
            else if (model is Booking)
            {
                switch (attributeName.ToLower())
                {
                    case "booking":
                        retName = "bokning";
                        break;
                    case "modeleqv":
                        retName = "En bokning";
                        break;
                    case "timestamp":
                        retName = "Skapad";
                        break;
                    case "id":
                        retName = "ID";
                        break;
                    case "personid":
                        retName = "Person (ID)";
                        break;
                    case "purpose":
                        retName = "Syfte";
                        break;
                    case "roomid":
                        retName = "Rum (ID)";
                        break;
                    case "start_time":
                        retName = "Starttid";
                        break;
                    case "end_time":
                        retName = "Sluttid";
                        break;
                    case "room":
                        retName = "Rum";
                        break;
                    case "rtype":
                        retName = "Rumtyp";
                        break;
                }
            }
            else if (model is Resource)
            {
                switch (attributeName.ToLower())
                {
                    case "resource":
                        retName = "resurs";
                        break;
                    case "modeleqv":
                        retName = "En resurs";
                        break;
                    case "type":
                        retName = "Resursnamn";
                        break;
                }
            }
            else if (model is Room_Resource)
            {
                switch (attributeName.ToLower())
                {
                    case "modeleqv":
                        break;
                    case "resid":
                        break;
                    case "roomid":
                        break;
                }
            }
            else if (model is Role)
            {
                switch (attributeName.ToLower())
                {
                    case "role":
                        retName = "roll";
                        break;
                    case "modeleqv":
                        retName = "en roll";
                        break;
                    case "id":
                        retName = "ID";
                        break;
                    case "name":
                        retName = "Rollnamn";
                        break;
                }
            }
            else if (model is Login)
            {
                switch (attributeName.ToLower())
                {
                    case "login":
                        retName = "inloggning";
                        break;
                    case "modeleqv":
                        retName = "ett inlogg";
                        break;
                    case "password":
                        retName = "Lösenord";
                        break;
                    case "personid":
                        retName = "Person (ID)";
                        break;
                }
            }
            else if (model is RoomType)
            {
                switch (attributeName.ToLower())
                {
                    case "roomtype":
                        retName = "rumtyp";
                        break;
                    case "modeleqv":
                        retName = "En rumstyp";
                        break;
                    case "id":
                        retName = "ID";
                        break;
                    case "type":
                        retName = "Rumtyp";
                        break;
                }
            }
            return retName;
        }

        /// <summary>
        /// Converts a referenced IModel to their corresponding column name
        /// </summary>
        /// <param name="model"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ConvertReferencedIModelToColumnName(IModel model, string key)
        {
            string keyEqv = null;
            key = key.ToLower();
            //Room
            if (model is Room)
            {
                if (key.Equals("building"))
                    keyEqv = "BName";
                else if (key.Equals("bname"))
                    keyEqv = "Building";
                else if (key.Equals("roomtype"))
                    keyEqv = "RType";
                else if (key.Equals("rtype"))
                    keyEqv = "RoomType";
            }
            // Booking
            else if (model is Booking)
            {
                if (key.Equals("person"))
                    keyEqv = "PersonId";
                else if (key.Equals("personid"))
                    keyEqv = "Person";
                else if (key.Equals("room"))
                    keyEqv = "RoomId";
                else if (key.Equals("roomid"))
                    keyEqv = "Room";
            }
            // Login
            else if (model is Login)
            {
                if (key.Equals("person"))
                    keyEqv = "PersonId";
                else if (key.Equals("personid"))
                    keyEqv = "Person";
            }
            // Person
            else if (model is Person && key.Equals("role") || key.Equals("rolename"))
            {
                keyEqv = "Role";
            }
            if (keyEqv == null)
                throw new Exception("keyEqv is null");
            return keyEqv;
        }

        /// <summary>
        /// Returns true if the IModel has an auto incrementing ID in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool IdIsAutoIncrementInDb(IModel model)
        {
            bool isAuto = false;
            if (model is Booking || model is Resource)
                isAuto = true;
            return isAuto;
        }

        /// <summary>
        /// Returns the correct tablename for each IModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static string IModelTableName(IModel model)
        {
            if (model == null)
                return null;
            string retTable = null;

            if (model is Person)
                retTable = DbFields.PersonTable;
            else if (model is Room)
                retTable = DbFields.RoomTable;
            else if (model is Building)
                retTable = DbFields.BuildingTable;
            else if (model is Booking)
                retTable = DbFields.BookingTable;
            else if (model is Resource)
                retTable = DbFields.ResourceTable;
            else if (model is Room_Resource)
                retTable = DbFields.RoomResourceTable;
            else if (model is Role)
                retTable = DbFields.PersonRoleTable;
            else if (model is Login)
                retTable = DbFields.LoginTable;
            else if (model is RoomType)
                retTable = DbFields.RoomTypeTable;

            return retTable;
        }

        /// <summary>
        /// Converts database names (such as columns or tablenames) to display friendly values
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        public static string GenericDbValuesToDisplayValue(string dbValue)
        {
            string display = dbValue;

            switch (dbValue)
            {
                case DbFields.PersonTable:
                    display = "Person";
                    break;
                case DbFields.RoomTable:
                    display = "Rum";
                    break;
                case DbFields.BuildingTable:
                    display = "Byggnad";
                    break;
                case DbFields.ResourceTable:
                    display = "Resurs";
                    break;
                case DbFields.BookingTable:
                    display = "Bokning";
                    break;
                case DbFields.LoginTable:
                    display = "Inloggning";
                    break;
                case "name":
                    display = "Det namnet";
                    break;
                case "id":
                    display = "Det ID:t";
                    break;
                case "rolename":
                case "role":
                    display = "Den rollen";
                    break;
                case "type":
                    display = "Den typen";
                    break;
            }
            return display;
        }

        private static string WhereConditionToString(WhereCondition whereCondition)
        {
            string op = "=";
            switch (whereCondition)
            {
                case WhereCondition.EQUAL:
                    op = "=";
                    break;
                case WhereCondition.LIKE:
                    op = "like";
                    break;
            }
            return op;
        }
    }
}
