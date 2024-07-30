using AdoDotNet.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await Read();
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



    }
}
