using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin4CSharp.Model;

namespace Termin4CSharp.DataAccessLayer {
    class DAL {

        public void Add(IModel model) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.ADD, model);
            using (cmd.Connection = Connector.getConnection()) {
                cmd.ExecuteNonQuery();
            }
        }

        public void Remove(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.REMOVE, model, whereParams, tableName, optWhereCondition);
            using (cmd.Connection = Connector.getConnection()) {
                cmd.ExecuteNonQuery();
            }
        }

        public void Get(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.GET, model, whereParams, tableName, optWhereCondition);
            SqlDataReader dr = null;
            using (cmd.Connection = Connector.getConnection()) {
                dr = cmd.ExecuteReader();
                while (dr.HasRows) {
                    var a = Utils.GetAttributeInfo(model).Select(x => x.Key);
                    foreach (var aa in a)
                        Console.WriteLine(dr[aa]);
                }
            }
        }

        public void Update(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.UPDATE, model, whereParams, tableName, optWhereCondition);
            using (cmd.Connection = Connector.getConnection()) {
                cmd.ExecuteNonQuery();
            }
        }

    }
}
