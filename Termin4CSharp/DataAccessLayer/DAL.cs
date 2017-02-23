using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Termin4CSharp.Model;
using Termin4CSharp.Model.DbHelpers;
using static System.Windows.Forms.CheckedListBox;

namespace Termin4CSharp.DataAccessLayer
{
    class DAL
    {

        public IController Controller { get; set; }

        //public DAL() { }

        public DAL(IController controller)
        {
            this.Controller = controller;
        }

        public IModel GetIModel(IModel model)
        {

            IModel returnModel = null;
            Type modelType = model.GetType();
            var modelIdAtt = model.GetIdentifyingAttributes().First();
            string modelIdAttName = modelIdAtt.Key, modelIdAttValue = (string)modelIdAtt.Value;
            var whereParams = new Dictionary<string, object>();
            // BUILDING
            if (modelType == typeof(Building))
            {
                Building b = new Building();
                b.Name = modelIdAttValue;
                b = this.Get(b).First() as Building;
                whereParams["bName"] = modelIdAttValue;
                b.Rooms = this.Get(new Room(), whereParams).Cast<Room>().ToList();
                returnModel = b;
            }
            // ROOM
            else if (modelType == typeof(Room))
            {
                Room r = new Room();
                r.Id = modelIdAttValue;
                r = this.Get(r).First() as Room;
                whereParams["name"] = r.BName;
                r.Building = this.Get(new Building(), whereParams).First() as Building;
                returnModel = r;
            }
            // ELSE 
            else
            {
                return this.Get(model).First();
            }
            return returnModel;
        }

        public int ConnectOrNullReferencedIModelsToIModelToQuery(List<IModel> referencedIModels, IModel targetModel, bool connect)
        {
            SqlCommand cmd = Utils.ConnectOrNullReferencedIModelsToIModelToQuery(referencedIModels, targetModel, connect);
            return this.PerformNonQuery(targetModel, cmd);
        }


        // Finds all bookings for one date. Keys are RoomID and List<Booking> is the bookings for that room on the 
        // specified date given in the parameter
        public Dictionary<string, List<Booking>> FindAllBookingsOnDate(DateTime dateToSearch)
        {
            Dictionary<string, List<Booking>> roomBookings = new Dictionary<string, List<Booking>>();

            SqlCommand cmd = Utils.IModelToQuery(QueryType.GET, new Booking(), selectAll: true, bookingSearchOnDate: dateToSearch);

            SqlDataReader dr = null;
            var resultList = new List<Booking>();
            cmd.Connection = Connector.GetConnection();
            try
            {
                IModel model = new Booking();
                dr = cmd.ExecuteReader();
                string key = null;
                while (dr.Read())
                {
                    Booking parsedBooking = Utils.ParseDataReaderToIModel(new Booking(), dr) as Booking;
                    key = parsedBooking.RoomId;
                    if (!roomBookings.ContainsKey(key))
                        roomBookings[key] = new List<Booking>();
                    roomBookings[key].Add(parsedBooking);
                }
            }
            catch (SqlException sqle)
            {
                this.HandleSqlException(new Booking(), sqle);
            }
            finally
            {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }

            return roomBookings;
        }

        public bool IsRoomBookableOnDate(string roomId, DateTime onDate, DateTime toDate)
        {
            string sql = @"select 
                                 isnull(
                                    (select
                                        case
                                            when start_time >= @startTimeWhen and end_time <= @endTimeWhen then 0
		                                    else 1
                                        end
                                    from Booking
                                    where roomID = @roomid
                                    and start_time >= @startTimeWhere and end_time <= @endTimeWhere)
                                  , 1)";
            SqlCommand cmd = new SqlCommand(sql, Connector.GetConnection());
            cmd.Parameters.Add("@startTimeWhen", SqlDbType.DateTime).Value = onDate;
            cmd.Parameters.Add("@endTimeWhen", SqlDbType.DateTime).Value = toDate;
            cmd.Parameters.Add("@startTimeWhere", SqlDbType.DateTime).Value = onDate;
            cmd.Parameters.Add("@endTimeWhere", SqlDbType.DateTime).Value = toDate;
            cmd.Parameters.Add("@roomid", SqlDbType.VarChar).Value = roomId;

            bool isBookable = default(bool);
            SqlDataReader dr = null;
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    isBookable = dr.GetInt32(0) == 1;
                    //isBookable = dr.GetBoolean(0);
                    var a = dr[0];
                    Console.WriteLine();
                }
                    
            } catch (SqlException sqle)
            {
                this.HandleSqlException(new Booking(), sqle);
            } finally
            {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }

            return isBookable;
        }

        public List<Room> ConnectListOfRoomsWithTheirBookableTimes(Dictionary<string, RoomAndOpeningHoursHolder> rooms, DateTime onDate)
        {
            DAL dal = new DAL(null);
            Dictionary<string, List<Booking>> allBookingsForRoomOnDate = dal.FindAllBookingsOnDate(onDate);

            List<Room> resultList = new List<Room>();

            string roomId = null;
            DateTime opening = default(DateTime), closing = default(DateTime);
            Room loopedRoom = null;
            RoomState[] roomStateOnHour = null;
            foreach (var idAndHolder in rooms)
            {
                roomId = idAndHolder.Key;
                loopedRoom = idAndHolder.Value.Room;
                opening = idAndHolder.Value.OpeningHour;
                closing = idAndHolder.Value.ClosingHour;

                roomStateOnHour = new RoomState[24];
                int i = 0;
                for (; i < opening.Hour; i++)
                    roomStateOnHour[i] = RoomState.BUILDING_CLOSED;
                for (; i < closing.Hour; i++)
                    roomStateOnHour[i] = RoomState.AVAILABLE;
                for (; i < 24; i++)
                    roomStateOnHour[i] = RoomState.BUILDING_CLOSED;

                if (allBookingsForRoomOnDate.ContainsKey(roomId) && allBookingsForRoomOnDate[roomId].Any())
                {
                    List<Booking> bookingsForLoopedRoom = allBookingsForRoomOnDate[roomId];
                    foreach (Booking booking in bookingsForLoopedRoom)
                        roomStateOnHour[booking.Start_time.Hour] = RoomState.BOOKED;
                }
                loopedRoom.RoomStateOnHour = roomStateOnHour;
                resultList.Add(loopedRoom);
            }

            return resultList;
        }


        public List<Room> FindRoomsWithOptionalFiltersOnDate(DateTime onDate, List<string> buildingNames = null, List<string> roomIDs = null, List<string> resourceNames = null, string freeText = null, int minCapacity = 0)
        {

            SqlCommand cmd = Utils.FindRoomsWithFilters(buildingNames, roomIDs, resourceNames, freeText, minCapacity);
            SqlDataReader dr = null;
            var resultList = new Dictionary<string, RoomAndOpeningHoursHolder>();
            cmd.Connection = Connector.GetConnection();
            try
            {
                RoomAndOpeningHoursHolder holder = null;
                Room fetchedRoom = null;
                DateTime openingHour = default(DateTime);
                DateTime closingHour = default(DateTime);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fetchedRoom = Utils.ParseDataReaderToIModel(new Room(), dr, false) as Room;
                    openingHour = (DateTime)dr["opening"];
                    closingHour = (DateTime)dr["closing"];
                    holder = new RoomAndOpeningHoursHolder(fetchedRoom, openingHour, closingHour);
                    resultList[fetchedRoom.Id] = holder;
                }
            }
            catch (SqlException sqle)
            {
                this.HandleSqlException(new Room(), sqle);
            }
            finally
            {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }

            List<Room> returnRooms = this.ConnectListOfRoomsWithTheirBookableTimes(resultList, onDate);

            return returnRooms;
        }

        public List<IModel> Get(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL, bool selectAll = false)
        {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.GET, model, whereParams, tableName, optWhereCondition, selectAll);
            SqlDataReader dr = null;
            var resultList = new List<IModel>();
            cmd.Connection = Connector.GetConnection();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IModel parsedModel = Utils.ParseDataReaderToIModel(model, dr);
                    resultList.Add(parsedModel);
                }
            }
            catch (SqlException sqle)
            {
                this.HandleSqlException(model, sqle);
            }
            finally
            {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }
            return resultList;
        }

        public int Add(IModel model)
        {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.ADD, model);
            return this.PerformNonQuery(model, cmd);
        }

        public int Remove(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL)
        {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.REMOVE, model, whereParams, tableName, optWhereCondition);
            return this.PerformNonQuery(model, cmd);
        }

        public int Update(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL)
        {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.UPDATE, model, whereParams, tableName, optWhereCondition);
            return this.PerformNonQuery(model, cmd);
        }

        private int PerformNonQuery(IModel model, SqlCommand cmd)
        {
            int affectedRows = -1;
            cmd.Connection = Connector.GetConnection();
            try
            {
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                this.HandleSqlException(model, sqle);
            }
            finally
            {
                try { if (cmd.Connection != null) cmd.Connection.Close(); } catch { }
            }
            return affectedRows;
        }

        private void HandleSqlException(IModel model, SqlException sqle)
        {
            string message = null;
            switch (sqle.Number)
            {
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
                    var tableRegmatch = Regex.Match(sqle.Message, "(?<=table \\\")(.*?)(?=\\\")").Groups[0]; //Finds tablename within \" \", like \"dbo.Person\"
                    string table = tableRegmatch.Captures[0].ToString();
                    int indexOfLastDot = table.LastIndexOf('.');
                    if (indexOfLastDot != -1)
                        table = table.Substring(indexOfLastDot + 1, (table.Length - 1) - indexOfLastDot); //Extracts tablename: dbo.Person -> Person
                    table = Utils.GenericDbValuesToDisplayValue(table);

                    //Getting column name
                    var columnRegmatch = Regex.Match(sqle.Message, "(?<=column ')(.*?)(?=')"); //Finds columnname within ' ', like 'name' or 'bName'
                    string column = columnRegmatch.Captures[0].ToString();
                    column = Utils.GenericDbValuesToDisplayValue(column);
                    message = string.Format("Kunde inte hitta {0} med {1}, vänligen försök igen", table, column);
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
