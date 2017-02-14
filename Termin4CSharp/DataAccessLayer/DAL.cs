using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin4CSharp.Model;

namespace Termin4CSharp.DataAccessLayer {
    class DAL {

        public IController Controller { get; set; }

        public int Add(IModel model) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.ADD, model);
            using (cmd.Connection = Connector.GetConnection()) {
                return cmd.ExecuteNonQuery();
            }
        }

        public int Remove(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.REMOVE, model, whereParams, tableName, optWhereCondition);
            using (cmd.Connection = Connector.GetConnection()) {
                return cmd.ExecuteNonQuery();
            }
        }

        public List<IModel> Get(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.GET, model, whereParams, tableName, optWhereCondition);
            SqlDataReader dr = null;
            var resultList = new List<IModel>();
            using (cmd.Connection = Connector.GetConnection()) {
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    IModel parsedModel = Utils.ParseDataReaderToIModel(model, dr);
                    resultList.Add(parsedModel);
                }
            }
            return resultList;
        }

        public int Update(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.UPDATE, model, whereParams, tableName, optWhereCondition);
            using (cmd.Connection = Connector.GetConnection()) {
                return cmd.ExecuteNonQuery();
            }
        }

        //private void HandleSqlException(SqlException sqle) {

        //    //if (sqle.ErrorCode == )

        //    //handling DbFields.SqlCode

        //    //if (this.Controller != null)
        //    //    this.Controller.NotifyExceptionToView();
        //}

    }
}
