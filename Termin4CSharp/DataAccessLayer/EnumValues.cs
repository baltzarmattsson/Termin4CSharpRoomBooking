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
        EQUAL, LIKE
    }

    enum SqlExceptionCode {
        PK_RESTRAINT, FK_RESTRAINT
    }
}
