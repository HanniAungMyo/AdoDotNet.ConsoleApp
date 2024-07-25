using AdoDotNet.ConsoleApp.EFCoreExamples;
using AdoDotNet.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.EfcoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbcontext db = new AppDbcontext();
            //List<Models.StudentModel> lst = db.Student.ToList();
            List<StudentModel> lst = db.Student.ToList();
            foreach (StudentModel item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }
        }

        public void Edit(int Id)
        {
            AppDbcontext db = new AppDbcontext();
            StudentModel item = db.Student.FirstOrDefault(item => item.Id == Id);
            if (item != null)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }
            else
            {
                Console.WriteLine("No Data Found");
            }
        }

        public void Create(string stuName, string fatherName, string stuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = stuName,
                FatherName = fatherName,
                StuContent = stuContent
            };
            AppDbcontext db = new AppDbcontext();
            db.Student.Add(student);
            int result = db.SaveChanges();
            string message = result > 0 ? "Save Successful" : "Fail";
            db.SaveChanges();
            Console.WriteLine(message);
        }

        public void Update(int Id, string stuName, string fatherName, string stuContent)
        {
            AppDbcontext db = new AppDbcontext();
            StudentModel item = db.Student.FirstOrDefault(item => item.Id == Id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            item.StuName = stuName;
            item.FatherName = fatherName;
            item.StuContent = stuContent;

            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Fail";
            Console.WriteLine(message);
        }

        public void Delete(int Id)
        {
            AppDbcontext db = new AppDbcontext();
            StudentModel item = db.Student.FirstOrDefault(item => item.Id == Id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            db.Student.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Fail";
            Console.WriteLine(message);
        }


    }
}
