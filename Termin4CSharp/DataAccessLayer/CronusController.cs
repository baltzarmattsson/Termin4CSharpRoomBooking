using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class CronusController
    {

        DALCronus  dal = new DALCronus();
        
        public string GetEmployees()
        {
            return DALCronus.GetEmployees();
        }

        public string GetRelatives()
        {
            return DALCronus.GetRelatives();
        }

        public string GetEmployeeAbsence()
        {
            return DALCronus.GetEmployeeAbsence();
        }

        public string GetSickestEmployee()
        {
            return DALCronus.GetSickestEmployee();
        }

        public string GetKeys()
        {
            return DALCronus.GetKeys();
        }

        public string GetIndexes()
        {
            return DALCronus.GetIndexes();
        }

        public string GetConstraints()
        {
            return DALCronus.GetConstraints();
        }

        public string GetAllTables()
        {
            return DALCronus.GetAllTables();
        }

        public string GetAllTables2()
        {
            return DALCronus.GetAllTables2();
        }

        public string GetMetaEmployees()
        {
            return DALCronus.GetMetaEmployees();
        }

        public string GetMetaEmployees2()
        {
            return DALCronus.GetMetaEmployees2 ();
        } 
    }
}
