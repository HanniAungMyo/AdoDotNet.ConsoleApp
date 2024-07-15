// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = "LAPTOP\\SQLSERVER";
sqlConnectionStringBuilder.InitialCatalog = "Student";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sa@123";

SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
Console.WriteLine(sqlConnectionStringBuilder.ConnectionString);
Console.WriteLine("Opening Connection");

sqlConnection.Open();
Console.WriteLine("Open Connection");

//Console.WriteLine("Connection Open");
string query = @"SELECT [Id],
[StuName],
[FatherName],
[StuContent]
FROM [dbo].[Tbl_Stu]";
SqlCommand cmd = new SqlCommand(query,sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);

Console.WriteLine("Closing Connection");

sqlConnection.Close();
Console.WriteLine("Close Connection");
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Student Id =>" + dr["Id"]);
    Console.WriteLine("Student Name =>" + dr["StuName"]);
    Console.WriteLine("Father Name =>" + dr["FatherName"]);
    Console.WriteLine("Student Content =>" + dr["StuContent"]);
    Console.WriteLine("-------------------------------------------------------------------------------------------");


}

