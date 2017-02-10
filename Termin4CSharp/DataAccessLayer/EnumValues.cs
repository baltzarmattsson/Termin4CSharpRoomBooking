using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer {


    enum QueryType {
        ADD, REMOVE, UPDATE, GET
    }

    enum WhereCondition {
        EQUAL, LIKE, PERCENTAGE
    }

    //public class QueryType {
    //    public const string Add = "insert";
    //    public const string Remove = "delete";
    //    public const string Update = "update";
    //    public const string Get = "select";

    //}
}
