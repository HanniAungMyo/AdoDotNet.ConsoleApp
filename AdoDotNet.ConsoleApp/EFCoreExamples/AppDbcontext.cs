using Microsoft.EntityFrameworkCore; 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoDotNet.ConsoleApp.Models;
using Microsoft.Data.SqlClient;

namespace AdoDotNet.ConsoleApp.EFCoreExamples
{
    public class AppDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP\\SQLSERVER",
                InitialCatalog = "Student",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<StudentModel>Student{ get; set; }
    }
}
