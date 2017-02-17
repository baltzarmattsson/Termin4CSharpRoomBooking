﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Termin4CSharp.Model;
using static System.Windows.Forms.CheckedListBox;

namespace Termin4CSharp.DataAccessLayer {
    class DAL {

        public IController Controller { get; set; }

        //public DAL() { }

        public DAL(IController controller) {
            this.Controller = controller;
        }

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

        public List<Room> FindRoomsWithFilters(List<string> buildingNames, List<string> roomIDs, List<string> resourceNames, string freeText = null) {

            SqlCommand cmd = Utils.FindRoomsWithFilters(buildingNames, roomIDs, resourceNames, freeText);
            SqlDataReader dr = null;
            var resultList = new List<Room>();
            cmd.Connection = Connector.GetConnection();
            try {
                IModel model = new Room();
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    Room parsedRoom = Utils.ParseDataReaderToIModel(model, dr) as Room;
                    resultList.Add(parsedRoom);
                }
            } catch (SqlException sqle) {
                this.HandleSqlException(new Room(), sqle);
            } finally {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }
            return resultList;
        }

        public List<IModel> Get(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL, bool selectAll = false) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.GET, model, whereParams, tableName, optWhereCondition, selectAll);
            SqlDataReader dr = null;
            var resultList = new List<IModel>();
            cmd.Connection = Connector.GetConnection();
            try {
                dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    IModel parsedModel = Utils.ParseDataReaderToIModel(model, dr);
                    resultList.Add(parsedModel);
                }
            } catch (SqlException sqle) {
                this.HandleSqlException(model, sqle);
            } finally {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }
            return resultList;
        }

        public int Add(IModel model) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.ADD, model);
            return this.PerformNonQuery(model, cmd);
        }

        public int Remove(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.REMOVE, model, whereParams, tableName, optWhereCondition);
            return this.PerformNonQuery(model, cmd);
        }

        public int Update(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL) {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.UPDATE, model, whereParams, tableName, optWhereCondition);
            return this.PerformNonQuery(model, cmd);
        }

        private int PerformNonQuery(IModel model, SqlCommand cmd) {
            int affectedRows = -1;
            cmd.Connection = Connector.GetConnection();
            try {
                affectedRows = cmd.ExecuteNonQuery();
            } catch (SqlException sqle) {
                this.HandleSqlException(model, sqle);
            } finally {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }
            return affectedRows;
        }

        private void HandleSqlException(IModel model, SqlException sqle) {
            string message = null;
            Console.WriteLine();
            switch (sqle.Number) {
                case SqlCodes.PrimaryKey:
                    var regmatch = Regex.Match(sqle.Message, "(?<=\\()(.*?)(?=\\))").Groups[0]; //finds (Names within paranthesis)
                    string duplicateValue = regmatch.Captures[0].ToString();
                    var listOfIdentifyingKeys = new List<string>();
                    foreach (var id in model.GetIdentifyingAttributes().Keys)
                        listOfIdentifyingKeys.Add(Utils.ConvertAttributeNameToDisplayName(model, id));
                    message = string.Format("Det finns redan {0} med {1} \"{2}\", vänligen välj ett annat", Utils.ConvertAttributeNameToDisplayName(model, "modeleqv"), string.Join(" eller ", listOfIdentifyingKeys), duplicateValue);
                    break;
                case SqlCodes.ForeignKey:
                    //Getting tablename
                    var tableRegmatch = Regex.Match(sqle.Message, "(?<=table \\\")(.*?)(?=\\\")").Groups[0]; //find tablename within \" \", like \"dbo.Person\"
                    string table = tableRegmatch.Captures[0].ToString();
                    int indexOfLastDot = table.LastIndexOf('.');
                    if (indexOfLastDot != -1)
                        table = table.Substring(indexOfLastDot+1, (table.Length - 1) - indexOfLastDot); //Extracts only tablename: dbo.Person -> Person
                    table = Utils.GenericDbValuesToDisplayValue(table);

                    //Getting column name
                    var columnRegmatch = Regex.Match(sqle.Message, "(?<=column ')(.*?)(?=')"); //finds columnname, like name or bName
                    string column = columnRegmatch.Captures[0].ToString();
                    column = Utils.GenericDbValuesToDisplayValue(column);
                    message = string.Format("Kunde inte hitta {0} med {1}, vänligen försök igen", table, column);
                    Console.WriteLine(sqle.Message);
                    break;
                case SqlCodes.DataWouldBeTruncated:
                    message = "Ett värde är för långt, vänligen försök igen";
                    break;
                default:
                    throw sqle;
            }


            this.Controller.NotifyExceptionToView(message);
        }
    }
}
