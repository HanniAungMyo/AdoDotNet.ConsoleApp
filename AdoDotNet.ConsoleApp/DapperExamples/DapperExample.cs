using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using AdoDotNet.ConsoleApp.Models;

namespace AdoDotNet.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "LAPTOP\\SQLSERVER",
            InitialCatalog = "Student",
            UserID = "sa",
            Password = "sa@123"
        };
        public void Read()
        {
            string query = @"SELECT [Id],
            [StuName],
            [FatherName],
            [StuContent]
            FROM [dbo].[Tbl_Stu]";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<StudentModel> lst = db.Query<StudentModel>(query).ToList();

            foreach (StudentModel item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }

            Console.WriteLine("Read");
        }

        public void Edit(int id)
        {
            StudentModel student = new StudentModel()
            {
                Id = id,
            };
            string query = @"SELECT [Id],
            [StuName],
            [FatherName],
            [StuContent]
            FROM [dbo].[Tbl_Stu] WHERE Id=@Id";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<StudentModel>(query,student).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine(item.Id);
            Console.WriteLine(item.StuName);
            Console.WriteLine(item.FatherName);
            Console.WriteLine(item.StuContent);

        }

        public void Create(string StudendName, string FatherName, string StuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = StudendName,
                FatherName = FatherName,
                StuContent = StuContent
            };
            string query = @"INSERT INTO [dbo].[Tbl_Stu]
            ([StuName]
            ,[FatherName]          
            ,[StuContent])               
        VALUES
            (@StuName                  
            ,@FatherName                   
            ,@StuContent)";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, student);

            string message = result > 0 ? "Save Successful" : "Save Failed";

            Console.Write(message);
        }

        public void Update(int Id, string StudendName, string FatherName, string StuContent)
        {
            StudentModel student = new StudentModel()
            {
                Id = Id,
                StuName = StudendName,
                FatherName = FatherName,
                StuContent = StuContent
            };
            string query = @"UPDATE [dbo].[Tbl_Stu]
             SET [StuName] = @StuName
            ,[FatherName] = @FatherName
            ,[StuContent] = @StuContent
             WHERE Id=@Id";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, student);
            string message = result > 0 ? "Update Successful" : "Update Fill";
            Console.WriteLine(message);


        }

        public void Delete(int Id)
        {
            StudentModel student = new StudentModel()
            {
                Id = Id,
            };
            string query = @"DELETE FROM [dbo].[Tbl_Stu]
                            WHERE @Id=Id";
            using IDbConnection db=new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result= db.Execute(query, student);
            string message = result > 0 ? "Delete Successful" : "Dalete Failed";
            Console.WriteLine(message);
        }
    }
}

