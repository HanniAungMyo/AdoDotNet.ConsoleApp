using AdoDotNet.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IStudentApi refitApi = RestService.For<IStudentApi>("https://localhost:7288");

        public async Task Run()
        {
            //await Read();
            //await Edit(0);
            //await Edit(0);
            //await Create("Mya Mya", "U Aye", "Mya Mya is Bio Student");
            //await Update(10,"Mya Mya", "U Aye", "Mya Mya is Physics Student");
            await Delete(10);

        }
        private async Task Read()
        {
            var lst = await refitApi.GetStudent();

            foreach (StudentModel item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }
        }
       
        private async Task Edit(int id)
        {
            try
            {
                var item = await refitApi.GetStudent(id);
                Console.WriteLine(item.Id);
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
       
        public async Task Create(string StuName, string FatherName, string StuContent)
        {
           
            try
            {
                StudentModel student = new StudentModel()
                {
                    StuName = StuName,
                    FatherName = FatherName,
                    StuContent = StuContent
                };
                string message = await refitApi.CreateStudent(student);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
      
        public async Task Update(int id, string StuName, string FatherName, string StuContent)
        {
            try
            {
                StudentModel student = new StudentModel()
                {
                  StuName= StuName,
                  FatherName= FatherName,
                  StuContent = StuContent
                };
                string message=await refitApi.UpdateStudent(id,student);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex) 
            {
                Console.WriteLine(ex.Content);
            }
        }
       
        public async Task Delete(int id)
        {
            try
            {
                string message= await refitApi.DeleteStudent(id);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
