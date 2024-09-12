using AdoDotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AdoDotNet.ConsoleApp.HTTPClient
{
    internal class HTTPClients
    {
        public async Task Run()
        {
            await delete(28);
            //await create("EE","FF","gg");
        }

        public async Task read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7280/api/Student");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<StudentModel>? lst = JsonConvert.DeserializeObject<List<StudentModel>>(jsonStr);
                foreach (StudentModel item in lst)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.StuName);
                    Console.WriteLine(item.FatherName);
                    Console.WriteLine(item.StuContent);
                }

            }

        }

        public async Task edit(int id)
        {
            string url = "https://localhost:7280/api/Student";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                StudentModel? item = JsonConvert.DeserializeObject<StudentModel>(jsonStr);
                Console.WriteLine(item.Id);
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }
        }

        public async Task create(string stuName, string fatherName, string stuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = stuName,
                FatherName = fatherName,
                StuContent = stuContent
            };
            string jsonStudent = JsonConvert.SerializeObject(student);
            HttpContent httpContent = new StringContent(jsonStudent, Encoding.UTF8, MediaTypeNames.Application.Json);

            string url = "https://localhost:7280/api/Student";
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

            }
            else
            {
                Console.WriteLine(response.StatusCode);

            }
        }

        public async Task update(int id, string stuName, string fatherName, string stuContent)
        {
            StudentModel student = new StudentModel()
            {
                Id = id,
                StuName = stuName,
                FatherName = fatherName,
                StuContent = stuContent
            };
            string jsonStudent = JsonConvert.SerializeObject(student);
            HttpContent content = new StringContent(jsonStudent, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7280/api/Student/{id}";
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.PutAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                Console.WriteLine(jsonStr);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task delete(int id)
        {
            string url = $"https://localhost:7280/api/Student/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
