using AdoDotNet.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.EfCore
{
    internal class EfCore1
    {
        AppDbContext db = new AppDbContext();
        public void Read()
        {
            List<StudentModel> lst = db.Students.ToList();
            foreach (StudentModel item in lst)
            {
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }
        }
        public void Edit(int id)
        {
            StudentModel? item = db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            Console.WriteLine(item?.Id);
            Console.WriteLine(item?.StuName);
            Console.WriteLine(item?.FatherName);
            Console.WriteLine(item?.StuContent);

        }
        public void Create(string name, string fatherName, string content)
        {
            StudentModel student = new StudentModel()
            {
                StuName = name,
                FatherName = fatherName,
                StuContent = content
            };
            db.Students.Add(student);
            int result = db.SaveChanges();
            string message = result > 0 ? "Create Successful" : "Failed";
            Console.WriteLine(message);
        }
        public void Update(int id, string name, string fatherName, string content)
        {
            StudentModel? item = db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            item!.Id = id;
            item.StuName = name;
            item.FatherName = fatherName;
            item.StuContent = content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Failed";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            StudentModel? item = db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            db.Students.Remove(item!);
            int result = db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Failed";
            Console.WriteLine(message);
        }
    }
}
