using AdoDotNet.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet.ConsoleApp.RefitExamples
{
    public interface IStudentApi
    {
        //[Get("/api/Student")]
        //Task<List<StudentModel>> GetStudent();

        //[Get("/api/Student/{id}")]
        //Task<StudentModel> GetStudent(int id);

        //[Post("/api/Student")]
        //Task<string> CreateStudent(StudentModel student);

        //[Put("/api/Student/{id}")]        
        //Task <string> UpdateStudent(int id,StudentModel student);

        //[Delete("/api/Student/{id}")]
        //Task<string> DeleteStudent(int id);


        //[Get("/api/Student")]
        //Task<List<StudentModel>>GetStudents();

        //[Get("/api/Student/{id}")]
        //Task<StudentModel>GetStudent(int id);

        //[Post("/api/Student")]
        //Task<string>CreateStudent(StudentModel student);

        //[Put("/api/Student/{id}")]
        //Task<string>UpdateStudent(int id,StudentModel student);

        //[Delete ("/api/Student/{id}")]
        //Task<string>DeleteStudent(int id);

        [Get("/api/Student")]
        Task<List<StudentModel>> GetStudent();

        [Get("/api/Student/{id}")]
        Task<StudentModel> GetStudentById(int id);

        [Post("/api/Student")]
        Task<string>CreateStudent(StudentModel student);

        [Put("/api/Student/{id}")]
        Task<string> UpdateStudent(int id,StudentModel student);

        [Delete ("/api/Student/{id}")]
        Task<string> DeleteStudent(int id);
    }
}
