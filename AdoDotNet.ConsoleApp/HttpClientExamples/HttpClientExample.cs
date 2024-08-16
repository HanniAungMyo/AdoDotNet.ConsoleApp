using AdoDotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await Delete(1);
            //await Create("Aye Aye", "Min Thein", "Aye Aye is Electronic Student");
            //await Read();
            //await Update(22, "Su Su", "Tin Aye", "Su Su is English Student");



        }

        private async Task Read()

        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.GetAsync("https://localhost:7288/api/Student");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonString);

                List<StudentModel> lst = JsonConvert.DeserializeObject<List<StudentModel>>(jsonString)!;
                foreach (StudentModel student in lst)
                {
                    Console.WriteLine(student.Id);
                    Console.WriteLine(student.StuName);
                    Console.WriteLine(student.FatherName);
                    Console.WriteLine(student.StuContent);
                    Console.WriteLine("________________________________________________");
                }
            }
        }

        public async Task Edit(int id)
        {
            string url = $"https://localhost:7288/api/Student/{id}";
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                StudentModel student = JsonConvert.DeserializeObject<StudentModel>(jsonStr)!;
                Console.WriteLine(student.Id);
                Console.WriteLine(student.StuName);
                Console.WriteLine(student.FatherName);
                Console.WriteLine(student.StuContent);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Create(string stuName, string fatherName, string stuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = stuName,
                FatherName = fatherName,
                StuContent = stuContent
            };
            string jsonStudent = JsonConvert.SerializeObject(student);
            HttpContent httpContent = new StringContent(jsonStudent, Encoding.UTF8, MediaTypeNames.Application.Json);

            string url = "https://localhost:7288/api/Student";
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

            }
        }

        public async Task Update(int id, string stuName, string fatherName, string stuContent)
        {
            StudentModel student = new StudentModel()
            {
                Id = id,
                StuName = stuName,
                FatherName = fatherName,
                StuContent = stuContent
            };
            string jsonStudent = JsonConvert.SerializeObject(student);
            HttpContent httpContent = new StringContent(jsonStudent, Encoding.UTF8, MediaTypeNames.Application.Json);

            string url = $"https://localhost:7288/api/Student/{id}";
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }

        }

        public async Task Delete(int id)
        {
            string url = $"https://localhost:7288/api/Student/{id}";
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());

            }
        }

    }
}
