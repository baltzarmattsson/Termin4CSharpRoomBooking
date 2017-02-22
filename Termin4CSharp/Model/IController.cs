using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termin4CSharp.DataAccessLayer;

namespace Termin4CSharp.Model
{
    interface IController
    {

        void NotifyExceptionToView(string message);
    }
}
