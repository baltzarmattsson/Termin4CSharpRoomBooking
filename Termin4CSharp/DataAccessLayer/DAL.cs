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

        public IModel GetIModel(IModel model) {

            IModel returnModel = null;
            Type modelType = model.GetType();
            var modelIdAtt = model.GetIdentifyingAttributes().First();
            string modelIdAttName = modelIdAtt.Key, modelIdAttValue = (string)modelIdAtt.Value;
            var whereParams = new Dictionary<string, object>();
            // BUILDING
            if (modelType == typeof(Building)) {
                Building b = new Building();
                b.Name = modelIdAttValue;
                b = this.Get(b).First() as Building;
                whereParams["bName"] = modelIdAttValue;
                b.Rooms = this.Get(new Room(), whereParams).Cast<Room>().ToList();
                returnModel = b;
            }
            // ROOM
            else if (modelType == typeof(Room)) {
                Room r = new Room();
                r.Id = modelIdAttValue;
                r = this.Get(r).First() as Room;
                whereParams["name"] = r.BName;
                r.Building = this.Get(new Building(), whereParams).First() as Building;
                returnModel = r;
            }
            // ELSE 
            else {
                return this.Get(model).First();
            }
            return returnModel;
        }





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

        public List<IModel> Get(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL, bool findResursiveIModels = true) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.GET, model, whereParams, tableName, optWhereCondition);
            SqlDataReader dr = null;
            var resultList = new List<IModel>();
            using (cmd.Connection = Connector.GetConnection()) {
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    IModel parsedModel = Utils.ParseDataReaderToIModel(model, dr, findResursiveIModels);
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
    }
}
