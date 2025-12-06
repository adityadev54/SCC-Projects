using System.Data.SqlClient;

namespace _3Sports.Sport_Services
{
    public class UserDb
    {
        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\CPT-206-GroupProject-1-BitByBit\\Users.mdf;Integrated Security=True;Connect Timeout=30";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
