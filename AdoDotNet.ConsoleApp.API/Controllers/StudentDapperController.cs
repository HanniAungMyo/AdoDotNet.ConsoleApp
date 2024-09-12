using AdoDotNet.ConsoleApp.API.Model;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace AdoDotNet.ConsoleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDapperController : ControllerBase
    {
        private readonly System.Data.SqlClient.SqlConnectionStringBuilder sqlConnectionStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder()
        {
            DataSource = "LAPTOP\\SQLSERVER",
            InitialCatalog = "Student",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,
        };

        [HttpGet]
        public IActionResult Get()
        {
            string query = @"SELECT [Id],
            [StuName],
            [FatherName],
            [StuContent]
            FROM [dbo].[Tbl_Stu]";
            using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            List<StudentModel> lst = db.Query<StudentModel>(query).ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
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
            using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            StudentModel? item = db.Query<StudentModel>(query, student).FirstOrDefault();
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            StudentModel model = new StudentModel()
            {
                Id = student.Id,
                StuName = student.StuName,
                FatherName = student.FatherName,
                StuContent = student.StuContent,
            };
            string query = @"INSERT INTO [dbo].[Tbl_Stu]
            ([StuName]
            ,[FatherName]          
            ,[StuContent])               
        VALUES
            (@StuName                  
            ,@FatherName                   
            ,@StuContent)";
            using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, model);
            string message = result > 0 ? "Create Successful" : "Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentModel student)
        {
            StudentModel model = new StudentModel()
            {
                Id = id,
                StuName = student.StuName,
                FatherName = student.FatherName,
                StuContent = student.StuContent,
            };
            string query = @"UPDATE [dbo].[Tbl_Stu]
             SET [StuName] = @StuName
            ,[FatherName] = @FatherName
            ,[StuContent] = @StuContent
             WHERE Id=@Id";
            using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, model);
            string message = result > 0 ? "Update Successful" : "Failed";
            return Ok(message);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            StudentModel student = new StudentModel()
            {
                Id = id
            };
            string query = @"DELETE FROM [dbo].[Tbl_Stu]
                            WHERE @Id=Id";
            using IDbConnection db = new System.Data.SqlClient.SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, student);
            string message = result > 0 ? "Delete Successful" : "Failed";
            return Ok(message);
        }
    }
}
