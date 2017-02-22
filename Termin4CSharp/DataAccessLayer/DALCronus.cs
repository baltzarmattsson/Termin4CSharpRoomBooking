using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer {
    class DALCronus {
        private SqlCommand cmd;
        private string sql;

        public string GetEmployees() //Innehållet och metadata i Employee (Personal) och relaterade tabeller: 
        {
            String sql = "SELECT * FROM [CRONUS Sverige AB$Employee]";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0].ToString());
            }
            //EmployeeStatement = Connector.GetConnection();
            return null;
        }

        public string GetRelatives() //Information om Personal och deras släktingar (Personalanhörig): 
        {
            String sql = "SELECT * FROM [CRONUS Sverige AB$Employee Relative]";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //RekativesStatement = Connector.GetConnection();
            return null;
        }
        public string GetEmployeeAbsence() //Information om anställda som har varit borta pga sjukdom år 2004 
        {
            String sql = "SELECT * FROM[CRONUS Sverige AB$Employee Absence] WHERE[From Date] between '2004-01-01' AND '2004-12-31' AND[Description] = 'Sjuk'";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //EmployeeAbsenceStatement = Connector.GetConnection();
            return null;

        }
        public string GetSickestEmployee()  //First name på anställda som har varit mest sjuka
        {
            //String sql = "SELECT [First Name] FROM [CRONUS Sverige AB$Employee] (SELECT MAX(Employee Absence) FROM [CRONUS Sverige AB$Employee] )" //osäker
            String sql = "SELECT e.[First Name] FROM[CRONUS Sverige AB$Employee] e INNER JOIN [CRONUS Sverige AB$Employee Absence] a on e.No_ = a.[Employee No_] and a.[Cause of Absence Code] = 'SJUK' group by e.[First Name] order by count(*) desc";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Connection = CRONUSConnector.GetConnection();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0]);
            }
            //SickestEmployeeStatement = Connector.GetConnection();
            return null;
        }
        public string GetKeys() //Alla nycklar 
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
        public string GetIndexes() //Alla indexes 
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
        public string GetConstraints() // Alla table_constraints 
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
        public string GetTables() // Alla tabeller
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
        public string GetTables2() //Alla tabeller
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
        public string GetMetaEmployees() //Alla kolumner i tabellen Employee 
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
        public string GetMetaEmployees2() //Alla kolumner i tabellen Employee version2. 
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
    }
}