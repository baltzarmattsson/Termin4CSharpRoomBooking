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

        public DAL(IController controller)
        {
            this.Controller = controller;
        }

        /// <summary>
        /// Gets a specified IModel of type Building or Room, based on its identifying attribute. Used for easier fetching of Buildings and Rooms since it automatically finds the referenced models
        /// </summary>
        /// <param name="model">The IModel with an identifying attribute whose values will be fetched</param>
        /// <returns>An IModel of the same type as the param IModel, filled with values from the database</returns>
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

        /// <summary>
        /// Connects or nulls the reference to the targetModel for all the items in the referencedIModels based on the param connect
        /// </summary>
        /// <param name="referencedIModels">The list of IModels to be added or nulled</param>
        /// <param name="targetModel">The target IModel that references or dereferences the list of IModels</param>
        /// <param name="connect">If the list of IModels should be added or nulled</param>
        /// <returns></returns>
        public int ConnectOrNullReferencedIModelsToIModelToQuery(List<IModel> referencedIModels, IModel targetModel, bool connect)
        {
            SqlCommand cmd = Utils.ConnectOrNullReferencedIModelsToIModelToQuery(referencedIModels, targetModel, connect);
            return this.PerformNonQuery(targetModel, cmd);
        }

        /// <summary>
        /// Finds all bookings for one date. Keys are RoomID and the list of bookings are the bookings for that room on the specified date given in the parameter
        /// </summary>
        /// <param name="dateToSearch">The date to search for bookings on</param>
        /// <returns>Key = roomID, value = list of all bookings on the specified date</returns>
        // 
        private Dictionary<string, List<Booking>> FindAllBookingsOnDate(DateTime dateToSearch)
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

        /// <summary>
        /// Returns if the room is bookable on the date and time
        /// </summary>
        /// <param name="roomId">The room that will be checked</param>
        /// <param name="onDate">The starting time of the booking</param>
        /// <param name="toDate">The ending time of the booking</param>
        /// <returns>If the room is bookable</returns>
        public bool IsRoomBookableOnDate(string roomId, DateTime onDate, DateTime toDate)
        {

            toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, toDate.Hour, 0, 0);
            onDate = new DateTime(onDate.Year, onDate.Month, onDate.Day, onDate.Hour, 0, 0);

            string sql = "select " +
                                " isnull( " +
                                   " (select " +
                                       " case " +
                                           " when start_time >= @startTimeWhen and end_time <= @endTimeWhen then 0 " +
		                                   " else 1 " +
                                       " end " +
                                  "  from Booking " +
                                  "  where roomID = @roomid " +
                                  "  and start_time >= @startTimeWhere and end_time <= @endTimeWhere) " +
                                  ", 1)";
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
                    break;
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

        /// <summary>
        /// Connects a list of rooms with its bookable times on a specified date. The bookable times are stored in the rooms RoomStateOnHour, based on what time the building opens and closes, and if there's
        /// any bookings on the specified date
        /// </summary>
        /// <param name="rooms">The list of RoomAndOpeningHoursHolder that has connected each room with their buildings open and closing time, with the RoomID as key</param>
        /// <param name="onDate">The specified date to search for bookings on</param>
        /// <returns>A list of rooms whose RoomStateOnHour has been set</returns>
        private List<Room> ConnectListOfRoomsWithTheirBookableTimes(Dictionary<string, RoomAndOpeningHoursHolder> rooms, DateTime onDate)
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
        public List<Room> FindRoomsWithOptionalFiltersOnDate(DateTime onDate, HashSet<string> buildingNames = null, HashSet<string> roomIDs = null, HashSet<string> resourceNames = null, string freeText = null, int minCapacity = 0)
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
                    fetchedRoom = Utils.ParseDataReaderToIModel(new Room(), dr) as Room;
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

        /// <summary>
        /// Gets a single model based on the identifying attribute in the IModel, or selects all types of this IModel if the selectAll is true
        /// </summary>
        /// <param name="model">The IModel or type of IModel to be fetched</param>
        /// <param name="whereParams">Optional where parameters. Key = columnname, value = that column names value</param>
        /// <param name="tableName">Optional tablename</param>
        /// <param name="optWhereCondition">If the WhereCondition should be an equal sign (=) or LIKE</param>
        /// <param name="selectAll">Specifies if it should find all the IModels in the table or not</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds an IModel to the database
        /// </summary>
        /// <param name="model">IModel to be added</param>
        /// <returns>Affected rows in the database</returns>
        public int Add(IModel model)
        {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.ADD, model);
            return this.PerformNonQuery(model, cmd);
        }

        /// <summary>
        /// Removes an IModel to the database
        /// </summary>
        /// <param name="model">IModel to be removed</param>
        /// <returns>Affected rows in the database</returns>
        public int Remove(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL)
        {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.REMOVE, model, whereParams, tableName, optWhereCondition);
            return this.PerformNonQuery(model, cmd);
        }

        /// <summary>
        /// Updates an IModel to the database
        /// </summary>
        /// <param name="model">IModel to be updated</param>
        /// <returns>Affected rows in the database</returns>
        public int Update(IModel model, Dictionary<string, object> whereParams = null, string tableName = null, WhereCondition optWhereCondition = WhereCondition.EQUAL)
        {
            SqlCommand cmd = Utils.IModelToQuery(QueryType.UPDATE, model, whereParams, tableName, optWhereCondition);
            return this.PerformNonQuery(model, cmd);
        }
        /// <summary>
        /// Performs a NonQuery of an IModel
        /// </summary>
        /// <param name="model">IModel to be modified</param>
        /// <returns>Affected rows in the database</returns>
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

        /// <summary>
        /// Handles the SQL exceptions when using the methods in this class. Updates the calling controllers responselabel with the regex-parsed message.
        /// </summary>
        /// <param name="model">The type of IModel that has been attempted to be modified</param>
        /// <param name="sqle">The caught exception</param>
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
                    message = string.Format("Det finns redan {0} med {1} \"{2}\", vänligen välj ett annat", Utils.ConvertAttributeNameToDisplayName(model, "modeleqv").ToLower(), string.Join(" eller ", listOfIdentifyingKeys).ToLower(), duplicateValue);
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
                    message = string.Format("Kunde inte hitta {0} med {1}, vänligen försök igen", table.ToLower(), column.ToLower());
                    break;
                case SqlCodes.DataWouldBeTruncated:
                    message = "Ett värde är för långt, vänligen försök igen";
                    break;
                case SqlCodes.SomethingIsNull:
                    columnRegmatch = Regex.Match(sqle.Message, "(?<=column ')(.*?)(?=')");
                    column = columnRegmatch.Captures[0].ToString();
                    column = Utils.ConvertAttributeNameToDisplayName(model, column);
                    message = String.Format("Fältet \"{0}\" fält är tomt, vänligen fyll i fältet och försök igen", column);
                    break;
                default:
                    throw sqle;
            }
            this.Controller.NotifyExceptionToView(message);
        }
    }
}
