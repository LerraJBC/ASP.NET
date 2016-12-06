using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using System.Data;
using StudentsCRUD.Models;

namespace StudentsCRUD.Controllers
{
    public class StudentAPIController : ApiController
    {

        static IStudentRepository repository = new StudentRepository();

        public IEnumerable<Student> GetAllStudents()
        {
            return repository.GetAll();
        }


        public Student Get(int studentID)
        {
            Student student = repository.Get(studentID);
            if (student == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return student;
        }

        public HttpResponseMessage PostStudent(Student item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Student>(HttpStatusCode.Created, item);

            string uri = Url.Link("InsertApi", new { studentName = item.firstname });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void DeleteStudent(int studentID)
        {
            Student student = repository.Get(studentID);
            if (student == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.DeleteStudent(studentID);
        }


        public String Put(int id, Student item)
        {
            item.id = id;
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            string returnStatus = repository.Update(item).ToString();
            return "Status: "+returnStatus;
        }

    }
}
