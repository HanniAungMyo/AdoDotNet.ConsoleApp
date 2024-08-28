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
        AppDbContext _db = new AppDbContext();
        public void Read()
        {

            List<StudentModel> lst = _db.Students.ToList();
            foreach (StudentModel item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);

            };
        }

        public void Edit(int id)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Foung");
            }
            Console.WriteLine(item?.StuName);
            Console.WriteLine(item?.FatherName);
            Console.WriteLine(item?.StuContent);
        }

        public void Create(string StuName, string FatherName, string StuContent)
        {
            StudentModel item = new StudentModel()
            {
                StuName = StuName,
                FatherName =FatherName,
                StuContent = StuContent
            };
            _db.Students.Add(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Create Successful" : "Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string StuName, string FatherName, string StuContent)
        {
            StudentModel? item = _db.Students.FirstOrDefault(item => item.Id == id);

            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            item.StuName =StuName;
            item.FatherName = FatherName;
            item.StuContent =StuContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Failed";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
            }
            _db.Students.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Failed";
            Console.WriteLine(message);

        }
    }
}
