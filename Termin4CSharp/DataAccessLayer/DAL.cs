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
            cmd.Connection = Connector.getConnection();
            try {
                cmd.ExecuteNonQuery();
            } finally {
                cmd.Connection.Close();
            }
        }

        public void Remove(IModel model, Dictionary<string, object> whereParams, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.REMOVE, model, whereParams, tableName, optWhereCondition);
            cmd.Connection = Connector.getConnection();
            try {
                cmd.ExecuteNonQuery();
            } finally {
                cmd.Connection.Close();
            }
        }

        public void Get(IModel model, Dictionary<string, object> whereParams, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.GET, model, whereParams, tableName, optWhereCondition);
            cmd.Connection = Connector.getConnection();
            try {
                cmd.ExecuteNonQuery();
            } finally {
                cmd.Connection.Close();
            }
        }

        public void Update(IModel model, Dictionary<string, object> whereParams, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.UPDATE, model, whereParams, tableName, optWhereCondition);
            cmd.Connection = Connector.getConnection();
            try {
                cmd.ExecuteNonQuery();
            } finally {
                cmd.Connection.Close();
            }
        }

    }
}
