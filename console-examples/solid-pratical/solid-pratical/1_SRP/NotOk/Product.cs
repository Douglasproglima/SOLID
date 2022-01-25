using System;
using System.Data.SqlClient;
using System.IO;

namespace solid_pratical._1_SRP.NotOk
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public void Add()
        {
            try
            {
                if (string.IsNullOrEmpty(Code)) throw new ArgumentNullException(Code);
                if (string.IsNullOrEmpty(Description)) throw new ArgumentNullException(Description);

                using (var connection = new SqlConnection())
                {
                    var command = new SqlCommand
                    {
                        CommandText = "INSERT INTO produto(Code, Description) VALUES(@code, @description) "
                    };

                    command.Parameters.AddWithValue("code", Code);
                    command.Parameters.AddWithValue("description", Description);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception error)
            {
                File.WriteAllText(@"C:\Error.txt", error.ToString());
                throw error;
            }
        }
    }
}
