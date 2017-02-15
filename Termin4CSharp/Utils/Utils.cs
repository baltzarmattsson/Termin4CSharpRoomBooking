﻿using System;
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
using Termin4CSharp.Model.DbHelpers;
using Termin4CSharp.View.CustomControls;
using static System.Windows.Forms.CheckedListBox;

namespace Termin4CSharp {
    class Utils {

        public static Dictionary<string, object> GetAttributeInfo(Object paramObj) {
            Dictionary<string, object> attributeValues = new Dictionary<string, object>();
            Type t = paramObj.GetType();
            var names = t.GetMembers()
                        .Select(x => x.Name)
                        .Where(x => !Regex.IsMatch(x, "([g|s]et|ToString|Equals|GetHashCode|GetType|.ctor|GetIdentifyingAttribute|Rooms|Building|Bookings)"));

            foreach (string attName in names) {
                PropertyInfo pi = t.GetProperty(attName);
                Type methodRetType = pi.GetMethod.ReturnType;
                var a = pi.GetValue(paramObj, null);
                attributeValues[attName] = pi == null ? "" : pi.GetValue(paramObj, null);
            }
            return attributeValues;
        }
        public static IModel ParseDataReaderToIModel(IModel model, SqlDataReader dr, bool findResursiveIModels = true) {
            var attributeInfo = Utils.GetAttributeInfo(model);
            object instance = Utils.GetInstanceFromIModel(model);

            foreach (string attributeName in attributeInfo.Keys) {
                var value = dr[attributeName] == DBNull.Value ? null : dr[attributeName];
                instance.GetType().GetProperty(attributeName).SetValue(instance, value, null);
            }
            dynamic castedInstance = Convert.ChangeType(instance, model.GetType());
            return castedInstance;
        }

        public static IModel CreateDynamicIModel(IModel model, string identifyingAttributeKey, object identifyingAttributeValue) {
            var attributeInfo = Utils.GetAttributeInfo(model);
            object instance = Utils.GetInstanceFromIModel(model);

            instance.GetType().GetProperty(identifyingAttributeKey).SetValue(instance, identifyingAttributeValue, null);
        
            dynamic castedInstance = Convert.ChangeType(instance, model.GetType());
            return castedInstance;
        }

        public static IModel ParseWinFormsToIModel(IModel model, Dictionary<string, object> controlValues) {
            var attributeInfo = Utils.GetAttributeInfo(model);
            object instance = Utils.GetInstanceFromIModel(model);

            foreach (string key in attributeInfo.Keys) {
                var value = controlValues[key];
                instance.GetType().GetProperty(key).SetValue(instance, value, null);
            }            
            dynamic castedInstance = Convert.ChangeType(instance, model.GetType());
            return castedInstance;
        }

        private static object GetInstanceFromIModel(IModel model) {
            Type modelType = model.GetType();
            var attributeInfo = Utils.GetAttributeInfo(model);
            ConstructorInfo constructorInfo = modelType.GetConstructor(Type.EmptyTypes);
            object instance = constructorInfo.Invoke(Type.EmptyTypes);
            return instance;
        }

        public static bool DateCompare(DateTime dOne, DateTime dTwo) {
            return dOne.Hour == dTwo.Hour && dOne.Minute == dTwo.Minute && dOne.Second == dTwo.Second;
        }

        public static SqlCommand IModelToQuery(QueryType queryType, IModel model, Dictionary<string, object> optWhereParams = null, string optTableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            string tableName = optTableName != null ? optTableName : Utils.IModelTableName(model);

            if (tableName == null)
                throw new Exception(String.Format("Table could not be found! IModel: {0} optTableName: {1}", model.GetType(), optTableName));
            
            StringBuilder sqlBuilder = new StringBuilder();
            Dictionary<string, object> modelAttributes = Utils.GetAttributeInfo(model);

            string modelKeys = "", modelValues = "";
            foreach (string key in modelAttributes.Keys) {

                // For non-GET-queries, if the id is autoincrementing, we're skipping inserting/updating this value
                if (queryType != QueryType.GET && key.Equals("id", StringComparison.InvariantCultureIgnoreCase) && Utils.IdIsAutoIncrementInDb(model))
                    continue;
                
                // If it's an UPDATE the key/values must be next to eacother, i.e. key1 = value1, key2 = value2
                if (queryType == QueryType.UPDATE) {
                    modelKeys += key.ToLower() + " = @" + key + ", ";
                    // Else they can be added to the end of the query: i.e. insert into tbl [keys] values [values]
                } else {
                    modelKeys += key.ToLower() + ", ";
                    modelValues += "@" + key + ", ";
                }
            }
            modelKeys = modelKeys.Substring(0, modelKeys.Length - 2); //removing ", "
            if (modelValues.Length > 2)
                modelValues = modelValues.Substring(0, modelValues.Length - 2); //removing ", "

            switch (queryType) {
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

            // Adding where conditions if there's any values in the optWhereParams -- OR -- adding the IModels identifying attribute if it's an UPDATE or REMOVE-query
            if ((optWhereParams != null && optWhereParams.Count > 0) || (queryType == QueryType.REMOVE || queryType == QueryType.UPDATE || queryType == QueryType.GET)) {
                string eqOperator = Utils.WhereConditionToString(optWhereCondition);
                sqlBuilder.Append(" where ");

                // If its an UPDATE, REMOVE or GET-query, change the optWhereParams-dict to the identifying attributes of IModel
                if ((optWhereParams == null || optWhereParams.Count == 0) && (queryType == QueryType.REMOVE || queryType == QueryType.UPDATE || queryType == QueryType.GET))
                    optWhereParams = model.GetIdentifyingAttributes();

                foreach (KeyValuePair<string, object> whereKV in optWhereParams) {
                    string key = whereKV.Key.ToLower();
                    string val = "@@" + whereKV.Key;
                    sqlBuilder.Append(key + " " + eqOperator + " " + val);
                    sqlBuilder.Append(" and ");
                }
                sqlBuilder.Remove(sqlBuilder.Length - 5, 5); //Removes " and "

            }

            
            //Console.WriteLine(sqlBuilder.ToString());
            SqlCommand cmd = new SqlCommand(sqlBuilder.ToString());
            if (queryType != QueryType.GET)
                Utils.FillSqlCmd(cmd, modelAttributes);
            if (optWhereParams != null && optWhereParams.Count > 0)
                Utils.FillSqlCmd(cmd, optWhereParams, true);

            Console.WriteLine(sqlBuilder.ToString());
            return cmd;
        }

        //public static SqlCommand FindRoomsWithFilters(List<string> buildingNames, List<string> roomIDs, List<string> resourceNames) {
        public static SqlCommand FindRoomsWithFilters(CheckedItemCollection buildingNames, CheckedItemCollection roomIDs, CheckedItemCollection resourceNames) {

            StringBuilder sqlBuilder = new StringBuilder();
            var modelAttributes = Utils.GetAttributeInfo(new Room());
            string modelKeys = string.Join(", ", modelAttributes.Keys);
            sqlBuilder.Append(string.Format("select {0} from {1} r", modelKeys, DbFields.RoomTable));


            var whereParams = new Dictionary<string, object>();
            bool whereAdded = false;
            int indexCounter = 0;

            //foreach (var list in listOfLists) {
            if (buildingNames.Count > 0) {
                sqlBuilder.Append("where r.bname in (");
                string key = "";
                foreach (string buildName in buildingNames) {
                    key = "index" + indexCounter++;
                    sqlBuilder.Append("@@" + key + ", ");
                    whereParams[key] = buildName;
                }
                sqlBuilder.Remove(sqlBuilder.Length - 2, 2); //Removes ", "
                sqlBuilder.Append(")");
                whereAdded = true;
            }
            if (roomIDs.Count > 0) {
                if (whereAdded) {
                    sqlBuilder.Append(" and ");
                } else {
                    sqlBuilder.Append(" where ");
                    whereAdded = true;
                }
                sqlBuilder.Append(" r.id in (@@{0}");
                string key = "";
                foreach (string roomID in roomIDs) {
                    key = "index" + indexCounter++;
                    sqlBuilder.Append("@@" + key + ", ");
                    whereParams[key] = roomID;
                }
                sqlBuilder.Remove(sqlBuilder.Length - 2, 2); //Removes ", "
                sqlBuilder.Append(")");
            }
            if (resourceNames.Count > 0) {
                if (whereAdded)
                    sqlBuilder.Append(" and ");
                else
                    sqlBuilder.Append(" where ");
                sqlBuilder.Append(" r.id in (select roomID from " + DbFields.RoomResourceTable + " where resID in (");
                string key = "";
                foreach (string resourceName in resourceNames) {
                    key = "index" + indexCounter++;
                    sqlBuilder.Append("@@" + key + ", ");
                    whereParams[key] = resourceName;
                }
                sqlBuilder.Remove(sqlBuilder.Length - 2, 2); //Removes ", "
                sqlBuilder.Append("))");
            }
            SqlCommand cmd = new SqlCommand(sqlBuilder.ToString());
            Utils.FillSqlCmd(cmd, whereParams, isWhereParams: true);
            
            return cmd; 
        }

        private static void FillSqlCmd(SqlCommand cmd, Dictionary<string, object> queryParams, bool isWhereParams = false) {
            foreach (KeyValuePair<string, object> attKV in queryParams) {

                string key = (isWhereParams ? "@@" : "@") + attKV.Key; //One @ for params, two @@ for whereConditions
                object val = attKV.Value;
                if (val is List<IModel>)
                    continue; //TODO ta bort dessa
                if (val is IModel)
                    val = ((IModel)val).GetIdentifyingAttributes().First().Value;

                /*      NULL        **/
                if (val == null)
                    cmd.Parameters.AddWithValue(key, DBNull.Value);
                /**     TEXT        **/
                else if (val is string)
                    cmd.Parameters.Add(key, SqlDbType.VarChar).Value = val as string;
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

                Console.Write("{0} {1}\t", key, val == null ? null : val.ToString());
            }
            Console.WriteLine();
        }

        public static string ConvertAttributeNameToDisplayName(IModel model, string key) {

            if (model == null)
                return null;
            string retName = key;

            if (model is Person) {
                switch (key.ToLower()) {
                    case "name":
                        break;
                    case "id":
                        break;
                    case "phonenbr":
                        break;
                    case "email":
                        break;
                }
            } else if (model is Room) {
                switch (key.ToLower()) {
                    case "bname":
                        break;
                    case "capacity":
                        break;
                    case "floor":
                        break;
                    case "id":
                        break;
                }
            } else if (model is Building) { 
                switch (key.ToLower()) {
                    case "address":
                        break;
                    case "avail_end":
                        break;
                    case "avail_start":
                        break;
                    case "name":
                        break;
                }
            } else if (model is Booking) {
                switch (key.ToLower()) {
                    case "id":
                        break;
                    case "personid":
                        break;
                    case "purpose":
                        break;
                    case "roomid":
                        break;
                    case "start_time":
                        break;
                    case "end_time":
                        break;
                }
            }
            else if (model is Institution) {
                switch (key.ToLower()) {
                    case "name":
                        break;
                }
            } else if (model is Resource) {
                switch (key.ToLower()) {
                    case "type":
                        break;
                }
            } else if (model is Institution_Building) {
                switch (key.ToLower()) {
                    case "bname":
                        break;
                    case "iname":
                        break;
                }
            } else if (model is Room_Resource) {
                switch (key.ToLower()) {
                    case "resid":
                        break;
                    case "roomid":
                        break;
                }
            } else if (model is Role) {
                switch (key.ToLower()) {
                    case "id":
                        break;
                }
            } else if (model is Login) {
                switch (key.ToLower()) {
                    case "password":
                        break;
                    case "personid":
                        break;
                }
            } else if (model is RoomType) {
                switch (key.ToLower()) {
                    case "id":
                        break;
                    case "type":
                        break;
                }
            }

            return retName;
        }

        private static bool IdIsAutoIncrementInDb(IModel model) {
            bool isAuto = false;
            if (model is Booking)
                isAuto = true;
            return isAuto;
        }

      private static string IModelTableName(IModel model) {
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
            else if (model is Institution)
                retTable = DbFields.InstitutionTable;
            else if (model is Resource)
                retTable = DbFields.ResourceTable;
            else if (model is Institution_Building)
                retTable = DbFields.InstBuildTable;
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

        private static string WhereConditionToString(WhereCondition whereCondition) {
            string op = "=";
            switch (whereCondition) {
                case WhereCondition.EQUAL:
                    op = "=";
                    break;
                case WhereCondition.LIKE:
                    op = "like";
                    break;
            }
            return op;
        }

        public static bool CompareLists(List<IModel> first, List<IModel> second) {
            var firstNotSecond = first.Except(second).ToList();
            var secondNotFirst = second.Except(first).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}
