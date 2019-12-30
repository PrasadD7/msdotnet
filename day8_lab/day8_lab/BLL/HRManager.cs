using System.Collections.Generic;
using BOL;
using DAL;
namespace BLL
{
    public class HRManager
    {
        public static  List<Employee> GetEmployees()
        {
            List<Employee> employees = EmployeeDAL.GetAll();
            //Analytical Query against employees 
            // Which will give me Top 10 emplyees

            //var emps = employees.Take<Employee>(3);
          
            return employees;

            
        }
        public static  Employee  GetEmployee(int id)
        {
          Employee employee = EmployeeDAL.Get(id);
            //Analytical Query against employees  
            // Which will give me Top 10 emplyees
            //In future we will use LINQ Query
            return employee;
        }
    }
}