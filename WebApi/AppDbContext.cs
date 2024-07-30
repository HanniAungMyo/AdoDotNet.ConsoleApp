using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EFCoreExample
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP\\SQLSERVER",
                InitialCatalog = "Student",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<StudentModel> Students { get; set; }
    }
}
