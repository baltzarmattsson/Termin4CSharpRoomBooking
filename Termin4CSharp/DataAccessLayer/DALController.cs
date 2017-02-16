using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class DALController
    {

        DALCronus  dal = new DALCronus();

        public string GetFileContent(string filename)
        {
            return DALCronus.GetFileContent(filename);
        }

        public DataTable GetEmployee()
        {
            return DALCronus.GetEmployee();
        }

        public DataTable GetRelatives()
        {
            return DALCronus.GetRelatives();
        }

        public DataTable GetEmployeeAbsence()
        {
            return DALCronus.GetEmployeeAbsence();
        }

        public DataTable GetSickestEmployee()
        {
            return DALCronus.GetSickestEmployee();
        }

        public DataTable GetKeys()
        {
            return DALCronus.GetKeys();
        }

        public DataTable GetIndexes()
        {
            return DALCronus.GetIndexes();
        }

        public DataTable GetConstraints()
        {
            return DALCronus.GetConstraints();
        }

        public DataTable GetAllTables()
        {
            return DALCronus.GetAllTables();
        }

        public DataTable GetAllTables2()
        {
            return DALCronus.GetAllTables2();
        }

        public DataTable GetMetaEmployees()
        {
            return DALCronus.GetMetaEmployees();
        }

        public DataTable GetMetaEmployees2()
        {
            return DALCronus.GetMetaEmployees2 ();
        }
    }
}
