using MatthewCOP4834.Models;
using System.Data.SqlClient;

namespace MatthewCOP4834.Services
{
    public class UsersDAO
    {
        string connectionString = @"Data Source=mattcop4834.database.windows.net;Initial Catalog = Test; User ID = MattNSB; Password=Matt1322!;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return success;

            // return true if found in db

        }
    }
}
