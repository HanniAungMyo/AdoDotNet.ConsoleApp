﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.MVC.Models
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
    public class studentResMessageModel
    {
        public bool? IsSuccess { get; set; }
        public string? Message {  get; set; }    
    }

}