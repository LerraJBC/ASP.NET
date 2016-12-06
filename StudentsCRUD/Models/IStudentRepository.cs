using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCRUD.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Get(int studentID);
        Student Add(Student item);
        void DeleteStudent(int studentID);
        bool Update(Student item);
       
    }
}
