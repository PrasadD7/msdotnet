using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Configuration;
using System.Data.SqlClient;
using BOL;
using System.Data;

namespace DAL
{
    public class AccountRepository
    {
        static string connString = string.Empty;

        static AccountRepository ()
        {
            connString = ConfigurationManager.ConnectionStrings["TFLOnline"].ConnectionString;
        }

        public static bool Validate(string username,string password)
        {
            bool status=false;
            string cmdText = "SELECT * FROM Accounts where Username=@Username and Password=@Password";
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);
            cmd.Parameters.Add(new SqlParameter("@Username", username));
            cmd.Parameters.Add(new SqlParameter("@Password", password));

            try
            {
                con.Open();
                IDataReader reader =  cmd.ExecuteReader();
                if (reader.Read())
                {
                    status = true;
                }
                }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return status;
        }


    }
}
