using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termin4CSharp.DataAccessLayer
{
    class DALCronus
    {

    }
    public ResultSet GetEmployee()throws SQLException
    {
        String sql = "SELECT * FROM [CRONUS Sverige AB$Employee]";
        Statement EmployeeStatement = getConnected().createStatement();
			return EmployeeStatement.executeQuery(sql);
    }
    public ResultSet GetRelatives() throws SQLException
    {
        String sql = "SELECT * FROM [CRONUS Sverige AB$Employee Relative]";
        Statement RelativesStatement = getConnected().createStatement(); 
            return RelativesStatement.executeQuery(sql);
    }
    public ResultSet GetEmployeeAbscence()throws SQLException
    {
        String sql = "SELECT * FROM [CRONUS Sverige AB$Employee Absence]";
        Statement employeeAbsStatement = getConnected().createStatement();
			return employeeAbsStatement.executeQuery(sql);
    }
    public ResultSet GetSickestEmployee() throws SQLException //annat metodnamn? 
    {
        String sql = "SELECT [First Name] FROM [CRONUS Sverige AB$Employee] WHERE" // lägg in rätt query
    }
    public ResultSet GetHighestSalary() throws SQLException
    {
        String sql = "SELECT  SELECT MAX(Salary) FROM [CRONUS Sverige AB$Employee]
        Statement HighestSalaryStatement = getConnected().createStatement();
			return HighestSalaryStatement.executeQuery(sql);
    {
    public ResultSet public GetKeys()throws SQLException
    {
        String sql = "SELECT * FROM sys.key_constraints;
        Statement KeysStatement = getConnected().createStatement();
			return KeysStatement.executeQuery(sql);
    {
    public ResultSet public GetIndexes()throws SQLException
    { 
        string sql = "SELECT * FROM sys.indexes;
        Statement IndexStatement = getConnected().createStatement();
            return IndexStatement.executeQuery(sql);
    {
    public ResultSet public GetConstraints() throws SQLException
    { 
        string sql = "SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS; 
        Statement ConstraintsStatement = getConnected().createStatement();
            return ConstraintStatement.executeQuery(sql);
    { 
     public ResultSet public GetTables() throws SQLException // ytterligare en query ska skrivas, som returnerar samma sak
    { 
        string sql = "SELECT * FROM sys.tables";
        Statement TablesStatement = getConnected().createStatement();
            return TablesStatement.executeQuery(sql1);
    { 
    public ResultSet public GetMetaEmployees() throw SQLException
    {
        string sql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'CRONUS Sverige AB$Employee'";
        Statement MetaEmployeesStatement = getConnected().createStatement();