using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNet.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {


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
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
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
            Console.WriteLine("Read");
        }

        public void Edit(int Id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP\\SQLSERVER";
            sqlConnectionStringBuilder.InitialCatalog = "Student";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"SELECT [Id],
            [StuName],
            [FatherName],
            [StuContent]
            FROM [dbo].[Tbl_Stu] WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            sqlConnection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found....");
            }
            DataRow dr = dt.Rows[0];
            Console.WriteLine("Student_Name=>" + dr["StuName"]);
            Console.WriteLine("Father_Name=>" + dr["FatherName"]);
            Console.WriteLine("Student_Content=>" + dr["StuContent"]);
            Console.WriteLine("---------------------------------------");
        }

        public void Create(string StudendName, string FatherName, string StuContent)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP\\SQLSERVER";
            sqlConnectionStringBuilder.InitialCatalog = "Student";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Stu]
            ([StuName]
            ,[FatherName]          
            ,[StuContent])               
        VALUES
            (@StuName                  
            ,@FatherName                   
            ,@StuContent)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@StuName", StudendName);
            sqlCommand.Parameters.AddWithValue("@FatherName", FatherName);
            sqlCommand.Parameters.AddWithValue("@StuContent", StuContent);
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            string message = result > 0 ? "Save Successful" : "Save Failed";

            Console.Write(message);
        }

        public void Update(int Id, string StudendName, string FatherName, string StuContent)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP\\SQLSERVER";
            sqlConnectionStringBuilder.InitialCatalog = "Student";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"UPDATE [dbo].[Tbl_Stu]
             SET [StuName] = @StuName
            ,[FatherName] = @FatherName
            ,[StuContent] = @StuContent
             WHERE Id=@Id";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", Id);
            sqlCommand.Parameters.AddWithValue("@StuName", StudendName);
            sqlCommand.Parameters.AddWithValue("@FatherName", FatherName);
            sqlCommand.Parameters.AddWithValue("@StuContent", StuContent);
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result> 0 ? "Update Successful" : "Update Fill";
            Console.WriteLine(message);


        }

        public void Delete(int Id) 
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder= new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP\\SQLSERVER";
            sqlConnectionStringBuilder.InitialCatalog = "Student";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sa@123";
            SqlConnection sqlConnection = new SqlConnection( sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Stu]
                            WHERE @Id=Id";
            SqlCommand sqlCommand = new SqlCommand( query, sqlConnection ); 
            sqlCommand.Parameters.AddWithValue("@Id",Id);
            int result= sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            string message = result > 0 ? "Delete Successful" : "Dalete Failed";
            Console.WriteLine(message);
        }
    }
}

;