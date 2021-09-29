using BicycleOrderingService.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BicycleOrderingService.Data
{
    public static class DataManager
    {
        public static class User
        {
            public static bool Create(UserModel user)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Users (Login, Password, Name, " +
                                                        "Surname, IsAdmin) VALUES (@Login, @Password, @Name, " +
                                                        "@Surname, @IsAdmin)", db.getConnection());

                    command.Parameters.Add("@Login", SqlDbType.VarChar).Value = user.Login;
                    command.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = user.Name;
                    command.Parameters.Add("@Surname", SqlDbType.VarChar).Value = user.Surname;
                    command.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = user.IsAdmin;

                    db.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                    {
                        db.closeConnection();
                        return true;
                    }
                    else
                    {
                        db.closeConnection();
                        return false;
                    }
                }
            }

            public static IEnumerable<UserModel> GetAll()
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Users", db.getConnection());

                    db.openConnection();

                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (true)
                        {
                            if (read.Read() == false) break;

                            UserModel outData = new UserModel()
                            {
                                Id = (int)read["Id"],
                                Name = (string)read["Name"],
                                Surname = (string)read["Surname"],
                                Login = (string)read["Login"],
                                Password = (string)read["Password"],
                                IsAdmin = (bool)read["IsAdmin"],
                            };

                            yield return outData;
                        }
                    }

                    db.closeConnection();
                }
            }

            public static UserModel GetByLoginAndPassword(string login, string password)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Login = @Login AND Password = @Password", db.getConnection());
                    cmd.Parameters.Add("@Login", SqlDbType.VarChar).Value = login;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    db.openConnection();

                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.Read() == false) { }

                        UserModel outData = new UserModel()
                        {
                            Id = (int)read["Id"],
                            Name = (string)read["Name"],
                            Surname = (string)read["Surname"],
                            Login= (string)read["Login"],
                            Password = (string)read["Password"],
                            IsAdmin = (bool)read["IsAdmin"],
                        };
                        db.closeConnection();
                        return outData;
                    }
                }
            }

        }
        
        public static class Product
        {
            public static IEnumerable<ProductModel> GetAll()
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Products", db.getConnection());

                    db.openConnection();

                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        while (true)
                        {
                            if (read.Read() == false) break;

                            ProductModel outData = new ProductModel()
                            {
                                Id = (int)read["Id"],
                                Name = (string)read["Name"],
                                Cost = (string)read["Cost"],
                            };

                            yield return outData;
                        }
                    }

                    db.closeConnection();
                }
            }
        }
    }
}
