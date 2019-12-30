using System.Collections.Generic;
using BOL;
namespace DAL
{
    public class TrainingRepository
    {
        public static List<Student> GetAll()
        {
            var students = new List<Student>{
                            new Student() { StudentId = 1, StudentName = "Raj", Age = 18 } ,
                            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentId = 4, StudentName = "Reena" , Age = 20 } ,
                            new Student() { StudentId = 5, StudentName = "Smith" , Age = 31 } ,
                            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentId = 4, StudentName = "Ravi" , Age = 44 }
                        };
            //  Next Time ,get the students from the database in the real application
         
            return students;
        }

        }
    }
