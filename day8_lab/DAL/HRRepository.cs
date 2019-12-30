
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BOL;


namespace DAL
{
    public static class EmployeeDAL
    {
        public static List<Employee> GetAll()
        {
            /*
             * 
             * 1.Create  emty  List of Employees collection
             * 2. Define Connection string to provide database related informtion
             * 3. Define Command Text (SQL)  for querying data from Database Table
             * 4. Create a Connection instance using SqlConnection class
             * 5. Associate Connection string with connection instance
             * 6. Create a Command instance using Constructor Dependency Injection
             * 7. Define try ,cath and finally block
             * 8. Open Connection 
             * 9. Execute Command using Command instance with the help of ExecuteReader method
             * 10 Collect fetched records from database in DataReader insance.
             * 11.Iterate Data Reader till end of records of DataReader
             * 12.Create new instance of Employee from reader
             * 13.Add newly created instance of Employee BOL in employees list
             * 14.Close DataReader 
             * 15. Close Connection
             * 16.return List
             */



            List<Employee> employees = new List<Employee>();
            string cmdText = "SELECT * FROM Employees";  // command Text defines Query 

            /*Connection string : used to establish connection with database file*/
            //contains 1. locadb type, 2. provider name ,
            //3. database path, 4. Security mode
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TFLGreenhouse.mdf;Integrated Security=True";
            // Database Connectivity
            IDbConnection con = new SqlConnection();
            con.ConnectionString = conString;
            IDbCommand cmd = new SqlCommand(cmdText,con as SqlConnection);
            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader(); // Fire  Command
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = int.Parse(reader["Id"].ToString());
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.ContactNumber= reader["ContactNumber"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.City = reader["City"].ToString();

                    employees.Add(emp);
                }

                reader.Close();

            }
            catch(SqlException exp)
            {
                throw exp;  //throw generated exception to next layer to handle
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
               
            }

            return employees;
        }
        public static List<Employee> GetAllObjects()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, FirstName = "Manoj", LastName = "Tambade", City = "Nagpur", ContactNumber = "9881735806", Email = "manoj.tambade@transflower.in" });
            employees.Add(new Employee { Id = 1, FirstName = "Manisha", LastName = "Jadhav", City = "Delhi", ContactNumber = "9881735861", Email = "manisha.jadhav@transflower.in" });
            employees.Add(new Employee { Id = 2, FirstName = "Ravi", LastName = "Pant", City = "Mumbai", ContactNumber = "9881735441", Email = "ravi.pant@transflower.in" });
            employees.Add(new Employee { Id = 3, FirstName = "Rajiv", LastName = "Gore", City = "Mumbai", ContactNumber = "9881735856", Email = "rajiv.gore@transflower.in" });
            employees.Add(new Employee { Id = 4, FirstName = "Gokul", LastName = "Varma", City = "Kanpur", ContactNumber = "9881735236", Email = "gokul.varma@transflower.in" });
            employees.Add(new Employee { Id = 5, FirstName = "sheetal", LastName = "Kulkarni", City = "Nashik", ContactNumber = "9881735765", Email = "sheetal.kulkarni@transflower.in" });
            employees.Add(new Employee { Id = 6, FirstName = "Amarn", LastName = "Sharma", City = "Delhi", ContactNumber = "9881733761", Email = "amar.sharma@transflower.in" });
            employees.Add(new Employee { Id = 7, FirstName = "Sarang", LastName = "Agarwal", City = "Pune", ContactNumber = "9881735871", Email = "sarang.Agarwal@transflower.in" });
            return employees;

        }
        public static Employee Get(int id)
        {
            Employee  emp = new Employee();

            string cmdText = "SELECT * FROM Employees WHERE Id="+ id;  // command Text defines Query 

            /*Connection string : used to establish connection with database file*/
            //contains 1. locadb type, 2. provider name ,
            //3. database path, 4. Security mode
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\RaviT\DAC_Course\DAC\DAC_Acts_Aug19\IndianCitizenPortalSolution\TransflowerOnline\App_Data\TFLGreenhouse.mdf;Integrated Security=True";
            // Database Connectivity
            IDbConnection con = new SqlConnection();
            con.ConnectionString = conString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);
            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader(); // Fire  Command
                if (reader.Read())
                {
                    
                    emp.Id = int.Parse(reader["Id"].ToString());
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.ContactNumber = reader["ContactNumber"].ToString();
                    emp.Email = reader["Email"].ToString();
                    emp.City = reader["City"].ToString();

                  
                }

                reader.Close();

            }
            catch (SqlException exp)
            {

            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

            return emp;
        }


        //We will perform CRUD Operations today in evening session

        public static bool Insert(Employee emp)
        {

            bool status = false;
            ////Inserting new employee to collection
            ///Invoke  ADO.NET code to add employee inside table
            ///
            return status;

        }

        public static bool Update(Employee emp)
        {

            bool status = false;
            ////Inserting new employee to collection
            ///Invoke  ADO.NET code to update existing employee inside table
            ///
            return status;

        }

        public static bool Delete(int id)
        {
            bool status = false;
            //
            return status;

        }
    }
}