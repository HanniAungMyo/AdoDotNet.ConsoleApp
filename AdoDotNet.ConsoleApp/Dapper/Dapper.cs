using AdoDotNet.ConsoleApp.Models;
using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.DapperEx
{
    internal class DapperEx
    {
        private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
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
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
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
                Id = id
            };
            string query = @"SELECT [Id],
            [StuName],
            [FatherName],
            [StuContent]
            FROM [dbo].[Tbl_Stu] WHERE Id=@Id";
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            StudentModel? item = db.Query<StudentModel>(query, student).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }

            Console.WriteLine(item?.StuName);
            Console.WriteLine(item?.FatherName);
            Console.WriteLine(item?.StuContent);
        }
        public void Create(string StuName, string FatherName, string StuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = StuName,
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
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, student);
            string message = result > 0 ? "Create Successful" : "Failed";
            Console.WriteLine(message);
        }
        public void Update(int id, string StuName, string FatherName, string StuContent)
        {
            StudentModel student = new StudentModel()
            {
                Id = id,
                StuName = StuName,
                FatherName = FatherName,
                StuContent = StuContent
            };
            string query = @"UPDATE [dbo].[Tbl_Stu]
             SET [StuName] = @StuName
            ,[FatherName] = @FatherName
            ,[StuContent] = @StuContent
             WHERE Id=@Id";
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, student);
            string message = result > 0 ? "Update Successful" : "Failed";
        }
        public void Delete(int id)
        {
            StudentModel student = new StudentModel()
            {
                Id = id
            };
            string query = @"DELETE FROM [dbo].[Tbl_Stu]
                            WHERE @Id=Id";
            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, student);
            string message = result > 0 ? "Delete Successful" : "Failed";
            Console.WriteLine(message);
        }
    }
}
