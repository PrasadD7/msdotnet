using System.Collections.Generic;
using System.Linq;
using BOL;
using DAL;
namespace BLL
{
  public  class TrainingManager
    {
        public static IEnumerable<Student> GetStudents()
        {
            List<Student> students = TrainingRepository.GetAll() ;
            //Analytical Query against students 
           
            var filteredStudents = from cust in students
                                   where cust.Age < 30
                                   select cust;
            return filteredStudents;
        }
    }
}
