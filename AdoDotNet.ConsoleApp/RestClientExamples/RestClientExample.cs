using AdoDotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private readonly string _apiUrl = "https://localhost:7288/api/Student";
        public async Task Run()
        {

            // await Update(28,"Su Su","Maung Thein","Su Su Aye is Eco Student");
            //await Create("Aye Aye", "U Maung Maung", "Aye Aye is MyanmarStudent");
            //await Create("Hla Hla", "U Aung Min", "Hla Hla is English student");
            //await Create("Su Su", "U Hla Aung", "Su Su is Math student");
           // await Update(4,"Mu Mu", "U Khin Maung", "Mu Mu is IT student");
            //await Create("Mya Mya", "U Maung Maung", "Mya Mya  is Eco student");

            // await Read();

           // await Create( "title 2", "author 3", "content 4");
            //await Read();

           await Delete(7);
        }

        private async Task Read()
        {
            RestRequest request = new RestRequest(_apiUrl, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                List<StudentModel> lst = JsonConvert.DeserializeObject<List<StudentModel>>(json)!;
                foreach (StudentModel item in lst)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.StuName);
                    Console.WriteLine(item.FatherName);
                    Console.WriteLine(item.StuContent);
                }
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Edit(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                StudentModel item = JsonConvert.DeserializeObject<StudentModel>(json)!;
                Console.WriteLine(item.StuName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.StuContent);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Create(string StuName, string FatherName, string stuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = StuName,
                FatherName = FatherName,
                StuContent = stuContent
            };
            RestRequest request = new RestRequest(_apiUrl, Method.Post);
            request.AddJsonBody(student);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.Write(response.Content!);
            }
            else
            {
                Console.Write(response.Content!);

            }
        }

        public async Task Update(int id, string StuName, string FatherName, string stuContent)
        {
            StudentModel student = new StudentModel()
            {
                StuName = StuName,
                FatherName = FatherName,
                StuContent = stuContent
            };

            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Put);
            request.AddJsonBody(student);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        public async Task Delete(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Delete);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string message =response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;

                Console.WriteLine(message);
            }
        }
    }
}
