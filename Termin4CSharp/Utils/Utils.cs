using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Termin4CSharp.DataAccessLayer;
using Termin4CSharp.Model;

namespace Termin4CSharp.Utils {
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

            if (tableName == null) {
                throw new Exception(String.Format("Table could not be found! IModel: {0} optTableName: {1}", model.GetType(), optTableName));
                return null;
            }

            StringBuilder sb = new StringBuilder();
            Dictionary<string, object> modelAttributes = Utils.GetAttributeInfo(model);
            string modelKeys = string.Join(", ", modelAttributes.Keys);
            string modelValues = "@" + string.Join(", @", modelAttributes.Values);
            switch (queryType) {
                case QueryType.ADD:
                    sb.Append(string.Format("insert into {0} ({1}) values ()", tableName, modelKeys, modelValues));
                    break;
                case QueryType.GET:
                    sb.Append("select ");
                    break;
                case QueryType.REMOVE:
                    sb.Append("delete ");
                    break;
                case QueryType.UPDATE:
                    sb.Append("update ");
                    break;
            }

            Console.WriteLine(sb.ToString());
            return null;
        }

        private static string IModelToQueryParams(SqlCommand sqlCommand, IModel model) {
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
