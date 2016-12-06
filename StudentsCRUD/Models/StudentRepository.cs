using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Http;

namespace StudentsCRUD.Models
{
    public class StudentRepository : IStudentRepository
    {
        [HttpGet]
        [ActionName("GetAllStudents")]
        public IEnumerable<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            MySqlDataReader reader = null;
            MySqlConnection myConnection = new MySqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=students;Uid=root;Pwd=;";

            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from information";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Student student = null;

            while (reader.Read())
                    {
                        student = new Student();
                        student.id = Convert.ToInt32(reader.GetValue(0));
                        student.firstname = reader.GetString(1);
                        student.lastname = reader.GetString(2);
                        student.age = Convert.ToInt32(reader.GetValue(3));
                        student.course = reader.GetString(4);
                        student.major = reader.GetString(5);
                        student.contact = reader.GetString(6);
                        student.address = reader.GetString(7);


                        students.Add(student);
                    }

            return students.ToArray();
        }

        [HttpGet]
        public Student Get(int studentID)
        {
            MySqlDataReader reader = null;
            MySqlConnection myConnection = new MySqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=students;Uid=root;Pwd=;";

            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from information where id=" +studentID+"";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Student student = null;
            while (reader.Read())
            {
                student = new Student();
                student.id = Convert.ToInt32(reader.GetValue(0));
                student.firstname = reader.GetString(1);
                student.lastname = reader.GetString(2);
                student.age = Convert.ToInt32(reader.GetValue(3));
                student.course = reader.GetString(4);
                student.major = reader.GetString(5);
                student.contact = reader.GetString(6);
                student.address = reader.GetString(7);

            }
            return student;
            myConnection.Close();

        }

        [HttpPost]
        public Student Add(Student item)
        {
            
                MySqlConnection myConnection = new MySqlConnection();
                myConnection.ConnectionString = @"Server=localhost;Database=students;Uid=root;Pwd=;";

                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO information (firstname,lastname,age,course,major,contact,address) Values (@firstname,@lastname,@age,@course,@major,@contact,@address)";
                sqlCmd.Connection = myConnection;

                sqlCmd.Parameters.AddWithValue("@firstname", item.firstname);
                sqlCmd.Parameters.AddWithValue("@lastname", item.lastname);
                sqlCmd.Parameters.AddWithValue("@age", item.age);
                sqlCmd.Parameters.AddWithValue("@course", item.course);
                sqlCmd.Parameters.AddWithValue("@major", item.major);
                sqlCmd.Parameters.AddWithValue("@contact", item.contact);
                sqlCmd.Parameters.AddWithValue("@address", item.address);

                myConnection.Open();
                int rowInserted = sqlCmd.ExecuteNonQuery();
                myConnection.Close();

               
           
            return item;
        }

        [HttpDelete]
        public void DeleteStudent(int studentID)
        {
            MySqlConnection myConnection = new MySqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=students;Uid=root;Pwd=;";

            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from information where id=" + studentID + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        [AcceptVerbs("Put")]
        public bool Update(Student item)
        {
            
            MySqlConnection myConnection = new MySqlConnection();
            myConnection.ConnectionString = @"Server=localhost;Database=students;Uid=root;Pwd=;";

            MySqlCommand sqlCmd = new MySqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE information SET id=@id,firstname=@firstname, lastname=@lastname, age=@age, course=@course, major=@major, contact=@contact, address=@address WHERE id=@id";
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@id", item.id);
            sqlCmd.Parameters.AddWithValue("@firstname", item.firstname);
            sqlCmd.Parameters.AddWithValue("@lastname", item.lastname);
            sqlCmd.Parameters.AddWithValue("@age", item.age);
            sqlCmd.Parameters.AddWithValue("@course", item.course);
            sqlCmd.Parameters.AddWithValue("@major", item.major);
            sqlCmd.Parameters.AddWithValue("@contact", item.contact);
            sqlCmd.Parameters.AddWithValue("@address", item.address);
           


            myConnection.Open();
            int rowUpdated = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
            if (rowUpdated >= 1)
            {
                bool status = true;
                return status;
            }
           else
            {
                bool status = false;
                return status;
            }

 
        }


        }
}