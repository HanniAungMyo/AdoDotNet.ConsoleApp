using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.WebApi.Models

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

    //public class JsonPlaceholder
    //{
    //    public int userId { get; set; }
    //    public int id { get; set; }
    //    public string title { get; set; }
    //    public string body { get; set; }
    //}

}