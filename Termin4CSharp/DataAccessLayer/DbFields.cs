using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer {
    
    public abstract class DbFields {

        public const string PersonRoleTable = "Role";
        public const string RoomTypeTable = "RoomType";
        public const string PersonTable = "Person";
        public const string RoomTable = "Room";
        public const string BuildingTable = "Building";
        public const string BookingTable = "Booking";
        public const string InstitutionTable = "Institution";
        public const string ResourceTable = "Resource";
        public const string InstBuildTable = "Institution_Building";
        public const string RoomResourceTable = "Room_Resource";
        public const string LoginTable = "Login";

    }

    public abstract class SqlCodes {
        public const int PrimaryKey = 2627;
        public const int ForeignKey = 547;
    }


}
