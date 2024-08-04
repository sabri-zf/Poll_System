using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClsDataAccessLayer
{
    public class ClsDataAccessPoll_Answers
    {
        public static bool FindPoll_AnsID(int Poll_AnsID, ref string Text, ref int Poll_ID)
        {
            if (Poll_AnsID >= 0) return false;


            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsConnectionDB.ConnectionString);
            string query = "select * from Poll_Answers where Poll_AnsID = @Poll_AnsID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue(@"Poll_AnsID", Poll_AnsID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Text = (string)reader["Text"];
                    Poll_ID = (int)reader["Poll_ID"];
                    IsFound = true;
                }
                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool FindText(ref int Poll_AnsID, string Text, ref int Poll_ID)
        {
            if (string.IsNullOrEmpty(Text)) return false;

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsConnectionDB.ConnectionString);
            string query = "select * from Poll_Answers where Text = '@Text'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue(@"Text", Text);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Poll_AnsID = (int)reader["Poll_AnsID"];
                    Poll_ID = (int)reader["Poll_ID"];
                    IsFound = true;
                }
                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        //--------------------------------------

        public static int AddNewPoll_Answers(string Text, int Poll_ID)
        {

            int CreateID = -1;
            SqlConnection Connection = new SqlConnection(clsConnectionDB.ConnectionString);
            string query = @"Insert into Poll_Answers values('@Text',@Poll_ID)
                            scope_identity();";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue(@"Text", Text);
            Command.Parameters.AddWithValue(@"Poll_ID", Poll_ID);

            try
            {
                Connection.Open();
                object value = Command.ExecuteScalar();
                if (value != null && int.TryParse(value.ToString(), out int result))
                {
                    CreateID = result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                CreateID = -1;
            }
            finally
            {
                Connection.Close();
            }
            return CreateID;
        }

        //--------------------------------------

        public static bool UpdatePoll_Answers(int Poll_AnsID, string Text, int Poll_ID)
        {

            if (Poll_AnsID <= 0) return false;

            SqlConnection Connection = new SqlConnection(clsConnectionDB.ConnectionString);

            string query = @"Update Poll_Answers
                            set Text = '@Text',
                            Poll_ID = @Poll_ID 
                            Where Poll_AnsID=@Poll_AnsID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue(@"Poll_AnsID", Poll_AnsID);
            Command.Parameters.AddWithValue(@"Text", Text);
            Command.Parameters.AddWithValue(@"Poll_ID", Poll_ID);
            int Roweffected = 0;

            try
            {
                Connection.Open();
                Roweffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return (Roweffected > 0);
        }

        //--------------------------------------

        public static bool DeletePoll_Answers(int Poll_AnsID)
        {

            if (Poll_AnsID <= 0) return false;

            SqlConnection Connection = new SqlConnection(clsConnectionDB.ConnectionString);

            string query = @"delete Poll_Answers where Poll_AnsID = @Poll_AnsID"
            ;
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue(@"Poll_AnsID", Poll_AnsID);
            int Roweffected = 0;

            try
            {

                Connection.Open();
                Roweffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return (Roweffected > 0);
        }

        //--------------------------------------

        public static bool IsExistsPoll_Answers(int Poll_AnsID)
        {
            if (Poll_AnsID >= 0) return false;
            SqlConnection Connection = new SqlConnection(clsConnectionDB.ConnectionString);
            string query = @"Select Find = 1 from Poll_Answers where ID = @Poll_AnsID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue(@"Poll_AnsID", Poll_AnsID);

            bool IsAvailable = false;

            try
            {

                Connection.Open();

                object value = Command.ExecuteScalar();
                if (value != null)
                {
                    IsAvailable = true;
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsAvailable = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsAvailable;

        }

        public static DataTable GetAllPoll_Answers()
        {

            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsConnectionDB.ConnectionString);

            string query = "Select * from Poll_Answers";

            SqlCommand Command = new SqlCommand(query, Connection);

            try {

                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows) {

                    dt.Load(reader);
                }

                reader.Close();
            }

            catch {

            }
            finally {
                Connection.Close();
            }

            return dt; }


    }
}
