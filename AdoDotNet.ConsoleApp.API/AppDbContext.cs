using AdoDotNet.ConsoleApp.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace AdoDotNet.ConsoleApp.API
{
    public class AppDbContext : DbContext
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
        public DbSet<StudentModel> Students { get; set; }
    }
}
