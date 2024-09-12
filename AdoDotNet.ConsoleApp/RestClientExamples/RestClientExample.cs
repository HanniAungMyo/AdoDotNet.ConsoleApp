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
        //    private readonly string _apiUrl = "https://localhost:7288/api/Student";
        //    public async Task Run()
        //    {
        //        await Delete(7);
        //    }

        //    private async Task Read()
        //    {
        //        RestRequest request = new RestRequest(_apiUrl, Method.Get);
        //        RestClient client = new RestClient();
        //        RestResponse response = await client.ExecuteAsync(request);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string json = response.Content!;
        //            List<StudentModel> lst = JsonConvert.DeserializeObject<List<StudentModel>>(json)!;
        //            foreach (StudentModel item in lst)
        //            {
        //                Console.WriteLine(item.Id);
        //                Console.WriteLine(item.StuName);
        //                Console.WriteLine(item.FatherName);
        //                Console.WriteLine(item.StuContent);
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine(response.Content!);
        //        }
        //    }

        //    public async Task Edit(int id)
        //    {
        //        string url = $"{_apiUrl}/{id}";
        //        RestRequest request = new RestRequest(url, Method.Get);
        //        RestClient client = new RestClient();
        //        RestResponse response = await client.ExecuteAsync(request);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string json = response.Content!;
        //            StudentModel item = JsonConvert.DeserializeObject<StudentModel>(json)!;
        //            Console.WriteLine(item.StuName);
        //            Console.WriteLine(item.FatherName);
        //            Console.WriteLine(item.StuContent);
        //        }
        //        else
        //        {
        //            Console.WriteLine(response.Content!);
        //        }
        //    }

        //    public async Task Create(string StuName, string FatherName, string stuContent)
        //    {
        //        StudentModel student = new StudentModel()
        //        {
        //            StuName = StuName,
        //            FatherName = FatherName,
        //            StuContent = stuContent
        //        };
        //        RestRequest request = new RestRequest(_apiUrl, Method.Post);
        //        request.AddJsonBody(student);
        //        RestClient client = new RestClient();
        //        RestResponse response = await client.ExecuteAsync(request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine(response.Content!);
        //        }
        //        else
        //        {
        //            Console.WriteLine(response.Content!);

        //        }
        //    }

        //    public async Task Update(int id, string StuName, string FatherName, string stuContent)
        //    {
        //        StudentModel student = new StudentModel()
        //        {
        //            StuName = StuName,
        //            FatherName = FatherName,
        //            StuContent = stuContent
        //        };

        //        string url = $"{_apiUrl}/{id}";
        //        RestRequest request = new RestRequest(url, Method.Put);
        //        request.AddJsonBody(student);
        //        RestClient client = new RestClient();
        //        RestResponse response = await client.ExecuteAsync(request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine(response.Content!);
        //        }
        //        else
        //        {
        //            Console.WriteLine(response.Content!);
        //        }
        //    }

        //    public async Task Delete(int id)
        //    {
        //        string url = $"{_apiUrl}/{id}";
        //        RestRequest request = new RestRequest(url, Method.Delete);
        //        RestClient client = new RestClient();
        //        RestResponse response = await client.ExecuteAsync(request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string message = response.Content!;
        //            Console.WriteLine(message);
        //        }
        //        else
        //        {
        //            string message = response.Content!;

        //            Console.WriteLine(message);
        //        }
        //    }

        //private readonly string _url = "https://localhost:7288/api/Student";
        //public async Task Run()
        //{
        //    await Delete(18);
        //}
        //private async Task Read()
        //{
        //    RestRequest request = new RestRequest(_url, Method.Get);
        //    RestClient client = new RestClient();
        //    RestResponse response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string json = response.Content!;
        //        List<StudentModel> lst = JsonConvert.DeserializeObject<List<StudentModel>>(json)!;
        //        foreach (StudentModel item in lst)
        //        {
        //            Console.WriteLine(item.Id);
        //            Console.WriteLine(item.StuName);
        //            Console.WriteLine(item.FatherName);
        //            Console.WriteLine(item.StuContent);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(response.Content!);
        //    }
        //}

        //public async Task Edit(int id)
        //{
        //    string _apiUrl = $"{_url}/{id}";
        //    RestRequest request = new RestRequest(_apiUrl, Method.Get);
        //    RestClient client = new RestClient();
        //    RestResponse response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string json = response.Content!;
        //        StudentModel item = JsonConvert.DeserializeObject<StudentModel>(json)!;
        //        Console.WriteLine(item.Id);
        //        Console.WriteLine(item.StuName);
        //        Console.WriteLine(item.FatherName);
        //        Console.WriteLine(item.StuContent);
        //    }
        //    else
        //    {
        //        Console.WriteLine(response.Content!);
        //    }
        //}

        //public async Task Create(string StuName, string FatherName, string StuContent)
        //{
        //    StudentModel student = new StudentModel()
        //    {
        //        StuName = StuName,
        //        FatherName = FatherName,
        //        StuContent = StuContent
        //    };
        //    RestRequest request = new RestRequest(_url, Method.Post);
        //    request.AddJsonBody(student);
        //    RestClient client = new RestClient();
        //    RestResponse response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(response.Content!);
        //    }
        //    else
        //    {
        //        Console.WriteLine(response.Content!);
        //    }

        //}

        //public async Task Update(int id, string StuName, string FatherName, string StuContent)
        //{
        //    string _apiUrl = $"{url}/{id}";
        //    StudentModel student = new StudentModel()
        //    {
        //        StuName = StuName,
        //        FatherName = FatherName,
        //        StuContent = StuContent
        //    };
        //    RestRequest request = new RestRequest(_apiUrl, Method.Put);
        //    RestClient client = new RestClient();
        //    RestResponse response = await client.ExecuteAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.WriteLine(response.Content!);
        //    }
        //    else
        //    {
        //        Console.WriteLine(response.Content!);

        //    }
        //}

        //public async Task Delete(int id)
        //{
        //    string _apiUrl = $"{_url}/{id}";
        //    RestRequest request = new RestRequest(_apiUrl, Method.Delete);
        //    RestClient client = new RestClient();
        //    RestResponse response = await client.ExecuteAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string message = response.Content!;
        //        Console.WriteLine(message);
        //    }
        //    else
        //    {
        //        string message = response.Content!;

        //        Console.WriteLine(message);
        //    }
        //}

        private readonly string url = "https://localhost:7280/api/student";

        public async Task run()
        {
            await Update(3,"Pyae Pyae","U Khin Maung","She is MST Student");
        }
        public async Task Read()
        {
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<StudentModel> lst = JsonConvert.DeserializeObject<List<StudentModel>>(jsonStr)!;
                foreach (StudentModel student in lst)
                {
                    Console.WriteLine(student.Id);
                    Console.WriteLine(student.StuName);
                    Console.WriteLine(student.FatherName);
                    Console.WriteLine(student.StuContent);
                }
            }
        }

        public async Task Edit(int id)
        {
            string _apiUrl = $"{url}/{id}";
            RestRequest request = new RestRequest(_apiUrl, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                StudentModel item = JsonConvert.DeserializeObject<StudentModel>(jsonStr)!;
                
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.StuName);
                    Console.WriteLine(item.FatherName);
                    Console.WriteLine(item.StuContent);
                

            }
            else
            {
                Console.WriteLine(response.Content!);

            }
        }

        public async Task Create(string name, string fatherName, string content)
        {
            StudentModel student = new StudentModel()
            {
                StuName = name,
                FatherName = fatherName,
                StuContent = content
            };
            RestRequest request = new RestRequest(url, Method.Post);
            request.AddJsonBody(student);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr);
            }
            else
            {
                Console.WriteLine(response.Content!);

            }
        }

        public async Task Update(int id, string name, string fatherName, string content)
        {
            StudentModel student = new StudentModel()
            {
                StuName = name,
                FatherName = fatherName,
                StuContent = content
            };
            string apiUrl = $"{url}/{id}";
            RestRequest request = new RestRequest(apiUrl, Method.Put);
            request.AddJsonBody(student);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }

        }

        public async Task Delete(int id)
        {
            string apiUrl = $"{url}/{id}";
            RestRequest request=new RestRequest(apiUrl, Method.Delete);
            RestClient client=new RestClient();
            RestResponse response=await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode) 
            {
                string jsonStr = response.Content!;
                Console.WriteLine(jsonStr);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
    }
}

