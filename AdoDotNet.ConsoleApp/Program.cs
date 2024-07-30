// See https://aka.ms/new-console-template for more information
using AdoDotNet.ConsoleApp.AdoDotNetExamples;
using AdoDotNet.ConsoleApp.DapperExamples;
using AdoDotNet.ConsoleApp.EFCoreExample;
using AdoDotNet.ConsoleApp.HttpClientExamples;

//DapperExample dapperExample = new DapperExample();
//adoDotNetExample.Create("Myint Myint","U Mya Aye","Myint Myint is Eco Student");
//dapperExample.Create("Hnin Hnin","Thaung Myint","Hnin Hnin is Myanmar Student");
//dapperExample.Delete(9);
//dapperExample.Read();

//EFCoreExample eFCoreExample=new EFCoreExample();
//eFCoreExample.Create("Hanni","U Aung Myo","Hanni is BackendStudent");

Console.WriteLine("Waiting For Api...");
    Console.ReadKey();

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.Run();
Console.ReadKey();

//



