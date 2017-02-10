using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;

namespace Termin4CSharp {
    class Utils {

        public static Dictionary<string, object> GetAttributeInfo(Object paramObj) {
            Dictionary<string, object> attributeValues = new Dictionary<string, object>();
            Type t = paramObj.GetType();
            var names = t.GetMembers()
                        .Select(x => x.Name)
                        .Where(x => !Regex.IsMatch(x, "([g|s]et)|(ToString|Equals|GetHashCode|GetType|.ctor)"));
            //Console.WriteLine(string.Join(", ", names));

            foreach (string attName in names) {
                PropertyInfo pi = t.GetProperty(attName);
                attributeValues[attName] = pi == null ? "" : pi.GetValue(paramObj, null);
            }
            return attributeValues;
        }

        public static string IModelToQuery(SqlCommand sqlCommand, QueryType queryType, IModel model, Dictionary<string, string> whereParams, string optTableName = null) {
            string tableName = optTableName != null ? optTableName : Utils.IModelTableName(model);

            if (tableName == null) 
                throw new Exception(String.Format("Table could not be found! IModel: {0} optTableName: {1}", model.GetType(), optTableName));
            
            StringBuilder sqlBuilder = new StringBuilder();
            Dictionary<string, object> modelAttributes = Utils.GetAttributeInfo(model);

            string modelKeys = "", modelValues = "";
            foreach (KeyValuePair<string, object> attKeyVal in modelAttributes) {
                modelKeys += attKeyVal.Key + ", ";
                modelValues += "@" + attKeyVal.Key + ", ";
            }
            modelKeys = modelKeys.Substring(0, modelKeys.Length - 2); //removing ", "
            modelValues = modelValues.Substring(0, modelValues.Length - 2); //removing ", "

            switch (queryType) {
                case QueryType.ADD:
                    sqlBuilder.Append(string.Format("insert into {0} ({1}) values ({2})", tableName, modelKeys, modelValues));
                    break;
                case QueryType.GET:
                    sqlBuilder.Append("select ");
                    break;
                case QueryType.REMOVE:
                    sqlBuilder.Append("delete ");
                    break;
                case QueryType.UPDATE:
                    sqlBuilder.Append("update ");
                    break;
            }
            using (SqlCommand cmd = new SqlCommand(sqlBuilder.ToString(), Connector.getConnection())) {
                Console.WriteLine("test");
                foreach (KeyValuePair<string, object> attKV in modelAttributes) {
                    string key = "@" + attKV.Key.ToLower();
                    object val = attKV.Value;

                    /**     TEXT        **/
                    if (val is string)
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

                    Console.WriteLine(val.GetType() + " " + val.ToString());
                }
                Console.Write("");
                cmd.ExecuteNonQuery();
            }

            //Console.WriteLine(sb.ToString());
            return null;
        }

        private static string[] IModelToQueryParams(SqlCommand sqlCommand, IModel model) {
            Dictionary<string, object> modelAttributes = Utils.GetAttributeInfo(model);
            foreach (KeyValuePair<string, object> attPair in modelAttributes) {

            }

            return null;
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
            
            return retTable;
        }
    }
}
