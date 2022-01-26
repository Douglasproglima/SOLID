using System.Data.SqlClient;

namespace solid_pratical._5_DIP.Ok
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            using (var connection = new SqlConnection())
            {
                var command = new SqlCommand
                {
                    CommandText = "INSERT INTO produto(Code, Description) VALUES(@code, @description) "
                };

                command.Parameters.AddWithValue("code", product.Code);
                command.Parameters.AddWithValue("description", product.Description);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
