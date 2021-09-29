using System;
using System.Data;
using System.Data.SqlClient;


namespace BicycleOrderingService.Data
{
    class ApplicationContext : IDisposable
    {
        private readonly SqlConnection _connection = new SqlConnection(
            @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename='|DataDirectory|\Data\LocalDataB.mdf';Integrated Security = True;");

        public void Dispose()
        {
            ((IDisposable)_connection).Dispose();
        }

        public void openConnection()
        {
            if (_connection.State == ConnectionState.Closed) _connection.Open();
        }

        public void closeConnection()
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }

        public SqlConnection getConnection()
        {
            return _connection;
        }
    }
}
