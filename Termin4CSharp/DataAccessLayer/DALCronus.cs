using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class DALCronus
    {
        private SqlCommand cmd;
        private string sql;

        public Dictionary<int, string[]> GetEmployees() //Innehållet och metadata i Employee (Personal) och relaterade tabeller: 
        {
            return this.GetResultFromSQLString("SELECT * FROM [CRONUS Sverige AB$Employee]");
        }



        public Dictionary<int, string[]> GetRelatives() //Information om Personal och deras släktingar (Personalanhörig): 
        {
            return this.GetResultFromSQLString("SELECT * FROM [CRONUS Sverige AB$Employee Relative]");
        }

        private Dictionary<int, string[]> GetResultFromSQLString(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, CRONUSConnector.GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();
            return this.ParseDataReaderToColumnsAndValues(dr);
        }
        private Dictionary<int, string[]> ParseDataReaderToColumnsAndValues(SqlDataReader dr)
        {
            int rowIndexCounter = 1;
            var results = new Dictionary<int, string[]>();
            
            bool columnsAdded = false;
            while (dr.Read())
            {
                if (columnsAdded == false)
                {
                    List<string> columns = Enumerable.Range(0, dr.FieldCount).Select(dr.GetName).ToList();
                    results[0] = columns.ToArray();
                    columnsAdded = true;
                }
                List<string> holder = new List<string>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    object o = dr.GetValue(i);
                    if (o is byte[])
                        holder.Add(string.Join("", ((byte[])o)));
                    else
                        holder.Add(o.ToString());
                }
                results[rowIndexCounter++] = holder.ToArray();
                holder.Clear();
            }

            return results;
        }


        public Dictionary<int, string[]> GetEmployeeAbsence() //Information om anställda som har varit borta pga sjukdom år 2004 
        {
            string sql = "SELECT* FROM[CRONUS Sverige AB$Employee Absence] WHERE[From Date] between '2004-01-01' AND '2004-12-31' AND[Description] = 'Sjuk'";
            return this.GetResultFromSQLString(sql);

        }
        public Dictionary<int, string[]> GetSickestEmployee()  //First name på anställda som har varit mest sjuka
        {
            string sql = "SELECT [First Name] FROM [CRONUS Sverige AB$Employee] (SELECT MAX(Employee Absence) FROM [CRONUS Sverige AB$Employee] )";
            return this.GetResultFromSQLString(sql);

        }
        public List<string> GetKeys() //Alla nycklar 
        {

            String sql = "SELECT * FROM sys.key_constraints";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //KeysStatement = Connector.GetConnection();
            return null;
        }
        public List<string> GetIndexes() //Alla indexes 
        {
            string sql = "SELECT * FROM sys.indexes";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //IndexesStatement = Connector.GetConnection();
            return null;
        }
        public List<string> GetConstraints() // Alla table_constraints 
        {
            string sql = "SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //ConstraintsStatement = Connector.GetConnection();
            return null;
        }
        public List<string> GetTables() // Alla tabeller
        {
            string sql = "SELECT * FROM sys.tables";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //TablesStatement = Connector.GetConnection();
            return null;
        }
        public List<string> GetTables2() //Alla tabeller
        {
            string sql = "SELECT * FROM sysobjects WHERE xtype = 'U'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //Tables2Statement = Connector.GetConnection();
            return null;
        }
        public List<string> GetMetaEmployees() //Alla kolumner i tabellen Employee 
        {
            string sql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CRONUS Sverige AB$Employee'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //MetaEmployeesStatement = Connector.GetConnection();
            return null;
        }
        public List<string> GetMetaEmployees2() //Alla kolumner i tabellen Employee version2. 
        {

            string sql = "SELECT * FROM sys.columns c INNER JOIN sys.tables t ON c.object_id = t.object_id WHERE t.name = 'CRONUS Sverige AB$Employee'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //MetaEmployees2Statement = Connector.GetConnection();
            return null;
        }
        //insert(add?), update, delete from Employee
        //public void AddEmployee(string id, string firstName) { 
        //    "CRONUS Sverige AB$Employee".Add(id, firstName); 
        //}
        //public void UpdateEmployee(string id, string firstName){
        //    "CRONUS Sverige AB$Employee".Update(id, firstName);
        //}
        //public void deleteEmployee(string id)
        //    "CRONUS Sverige AB$Employee".Delete(id); {

        //}
    }
}





