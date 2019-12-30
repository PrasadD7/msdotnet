using System;
using System.Data;                                                          
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Configuration;
using System.Data.SqlClient;


namespace DAL
{
    public static class FlowerRepository
    {
        static string connString = string.Empty;

        static FlowerRepository()
        {
            connString = ConfigurationManager.ConnectionStrings["TFLOnline"].ConnectionString;
        }

        public static List<Flower> getAll()
        {

            List<Flower> flowers = new List<Flower>();
            string cmdText = "SELECT * FROM Flowers";
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dtflowers = ds.Tables[0];
                DataRowCollection rows = dtflowers.Rows;

                foreach (DataRow  row in rows)
                {
                    Flower f = new Flower();
                    f.Id = Convert.ToInt16(row["Id"]);
                    f.Name = Convert.ToString(row["Name"]);
                    f.Color = Convert.ToString(row["Color"]);
                    f.Origin = Convert.ToString(row["Origin"]);
                    flowers.Add(f);

                }
                return flowers;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Flower Get(int id)
        {
            Flower flower = new Flower();
            string cmdText = "SELECT * FROM Flowers where Id=@Id";
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);
            cmd.Parameters.Add(id);


            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader(); // Fire  Command
                if (reader.Read())
                {
                    flower.Id = Convert.ToInt16(reader["Id"]);
                    flower.Name = Convert.ToString(reader["Name"]);
                    flower.Color = Convert.ToString(reader["Color"]);
                    flower.Origin = Convert.ToString(reader["Origin"]);
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

            return flower;

        }

        public static bool Add(Flower f)
        {
            bool status = false;

            string cmdText = "INSERT INTO Flowers (Id,Name,Color,Origin) VALUES(@Id,@Name,@Color,@Origin)";
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);
            cmd.Parameters.Add(new SqlParameter("@Id", f.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", f.Name));
            cmd.Parameters.Add(new SqlParameter("@Color", f.Color));
            cmd.Parameters.Add(new SqlParameter("@Origin", f.Origin));

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException exp)
            {
                throw exp;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return status;
        }

        public static bool Remove(int Id)
        {
            bool status = false;

            string cmdText = "DELETE FROM Flowers where Id = @Id";
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException exp)
            {
                throw exp;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return status;
        }

    }
}
