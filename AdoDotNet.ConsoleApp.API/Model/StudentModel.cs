using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoDotNet.ConsoleApp.API.Model
{
    [Table("Tbl_Stu")]
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }
        public string? StuName { get; set; }
        public string? FatherName { get; set; }
        public string? StuContent { get; set; }
    }
}
