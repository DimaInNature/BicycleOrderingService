using System.Data;
using System.Data.SqlClient;
using BicycleOrderingService.Data;

namespace BicycleOrderingService.Services
{
    public static class ValidationService
    {
        public static bool Validation(string login, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Login = @Login AND Password = @Password", db.getConnection());
                command.Parameters.Add("@Login", SqlDbType.VarChar).Value = login;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
