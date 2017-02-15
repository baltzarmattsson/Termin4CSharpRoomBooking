using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class DALCronus
    {
        private Connection connect;

        public DALCronus()
        {
            try
            {
                Class.forName("");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is: " + e);
            }
        }
        private SqlConnection getConnection()
        {
            if (connect == null)
            {
                connect = DriverManager.getConnection("");
            }
            return connect;
        }
        public ResultSet GetEmployee()
        {
            String sql = "SELECT * FROM [CRONUS Sverige AB$Employee]"; //Innehållet och metadata i Employee (Personal) och relaterade tabeller: 
            EmployeeStatement = getConnected().createStatement();
            return EmployeeStatement.executeQuery(sql);
        }
        public ResultSet GetRelatives() //Information om Personal och deras släktingar (Personalanhörig): 
        {
            String sql = "SELECT * FROM [CRONUS Sverige AB$Employee Relative]";
            RelativesStatement = getConnected().createStatement();
            return RelativesStatement.executeQuery(sql);
        }
        public ResultSet GetEmployeeAbscence() //Information om anställda som har varit borta pga sjukdom år 2004 
        {
            String sql = "SELECT * FROM [CRONUS Sverige AB$Employee Absence] WHERE OrderDate='2004";
            EmployeeAbsStatement = getConnected().createStatement();
            return employeeAbsStatement.executeQuery(sql);
        }
        public ResultSet GetSickestEmployee()  //First name på anställda som har varit mest sjuka
        {
            String sql = "SELECT [First Name] FROM [CRONUS Sverige AB$Employee] (SELECT MAX(Employee Absence) FROM [CRONUS Sverige AB$Employee] )" //osäker
            SickestEmployeeStatement = getConnected().createStatement();
            return GetSickestEmployee.executeQuery(sql);
        }
        public ResultSet GetDepartment()  //Information om Employee och deras Department
        {
            String sql = ""
            DepartmentStatement = getConnected().createStatement();
            return GetDepartment.executeQuery(sql);
        }
        public ResultSet GetHighestSalary() //Information om Employee som har högst lön
        {
            String sql = "SELECT  SELECT MAX(Salary) FROM [CRONUS Sverige AB$Employee]
            HighestSalaryStatement = getConnected().createStatement();
            return HighestSalaryStatement.executeQuery(sql);
        }
        public ResultSet public GetKeys() //Alla nycklar 
        {
            String sql = "SELECT * FROM sys.key_constraints;
            KeysStatement = getConnected().createStatement();
            return KeysStatement.executeQuery(sql);
        }
    public ResultSet public GetIndexes() //Alla indexes 
        {
            string sql = "SELECT * FROM sys.indexes;
            IndexStatement = getConnected().createStatement();
            return IndexStatement.executeQuery(sql);
        }
    public ResultSet public GetConstraints()
        {
            string sql = "SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS";
            ConstraintsStatement = getConnected().createStatement();
            return ConstraintStatement.executeQuery(sql);
        }
     public ResultSet public GetTables() // Alla table_constraints 
        {
            string sql = "SELECT * FROM sys.tables";
            TablesStatement = getConnected().createStatement();
            return TablesStatement.executeQuery(sql);
        }
    public ResultSet public GetTables2() //Alla table_constraints 
        {
            string sql = "SELECT * sysobjects WHERE xtype = 'U
            Tables2Statement = getConnected().createStatement();
            return Tables2Statement.executeQuery(sql);
        }
    public ResultSet public GetMetaEmployee() //Alla kolumner i tabellen Employee 
        {
            string sql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'CRONUS Sverige AB$Employee'";
            MetaEmployeeStatement = getConnected().createStatement();
            return MetaEmployeeStatement.executeQuery(sql);
        }
     public ResultSet public GetMetaEmployee2() throw SQLException //Alla kolumner i tabellen Employee version2. 
        {
            string sql = "SELECT* FROM sys.columns c INNER JOIN sys.tables t ON c.object_id = t.object_id WHERE t.name = '[CRONUS Sverige AB$Employee]'";
            MetaEmployee2Statement = getConnected().createStatement();
            return MetaEmployee2Statement.executeQuery(sql); 
        }
}
