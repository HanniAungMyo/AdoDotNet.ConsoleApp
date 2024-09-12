using AdoDotNet.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.EFCoreExample
{
    public class EFCoreExample
    {
        AppDbContext db = new AppDbContext();
        public void Read()
        {
            List<StudentModel> lst = db.Students.ToList();

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
            StudentModel? item = db.Students.FirstOrDefault(item => item.Id == Id);
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

        public void Create(string StuName, string FatherName, string StuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = StuName,
                FatherName = FatherName,
                StuContent = StuContent
            };
            db.Students.Add(student);
            int result = db.SaveChanges();
            string message = result > 0 ? "Create Successful" : "Failed";
            Console.Write(message);
        }

        public void Update(int Id, string StuName, string FatherName, string StuContent)
        {
            StudentModel? item = db.Students.FirstOrDefault(item => item.Id == Id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }

            item.StuName = StuName;
            item.FatherName = FatherName;
            item.StuContent = StuContent;
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Failed";
            Console.Write(message);
        }

        public void Delete(int Id)
        {
            StudentModel? item = db.Students.FirstOrDefault(item => item.Id == Id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            db.Students.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Failed";
            Console.Write(message);
        }
    }
}