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
        DALCronus dal = new DALCronus();
        
        public string GetEmployees()
        {
            return dal.GetEmployees();
        }

        public string GetRelatives()
        {
            return dal.GetRelatives();
        }

        //public string GetEmployeeAbsence()
        //{
        //    //return dal.GetEmployeeAbsence();
        //}

        public string GetSickestEmployee()
        {
            return dal.GetSickestEmployee();
        }

        public string GetKeys()
        {
            return dal.GetKeys();
        }

        public string GetIndexes()
        {
            return dal.GetIndexes();
        }

        public string GetConstraints()
        {
            return dal.GetConstraints();
        }

        //public string GetAllTables()
        //{
        //    //return dal.GetAllTables();
        //}

        //public string GetAllTables2()
        //{
        //    //return dal.GetAllTables2();
        //}

        public string GetMetaEmployees()
        {
            return dal.GetMetaEmployees();
        }

        public string GetMetaEmployees2()
        {
            return dal.GetMetaEmployees2 ();
        } 
    }
}
