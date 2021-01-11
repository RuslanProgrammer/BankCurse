using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BankCurse
{
    public class ConnectionToDB
    {
        private static string server = "localhost";
        private static string database = "bankcurse";
        private static string uid = "root";
        private static string password = "Rus1programmer";
        private MySqlConnection _connection;
        private static ConnectionToDB _instance;

        private ConnectionToDB()
        {
            Initialize();
        }

        public bool IsOpen()
        {
            try
            {
                _connection.Open();
                _connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static ConnectionToDB GetConnection(params string[] arr)
        {
            if (arr.Length != 0)
            {
                server = arr[0];
                database = arr[1];
                uid = arr[2];
                password = arr[3];
            }
            if (_instance?._connection != null && _instance._connection.State == ConnectionState.Open)
                return _instance;
            return _instance = new ConnectionToDB();
        }

        private void Initialize()
        {
            var connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                                   database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Convert Zero Datetime=True;";
            _connection = new MySqlConnection(connectionString);
        }

        public List<List<string>> LoadTable(string query)
        {
            var res = new List<List<string>>();
            try
            {
                _connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Помилка пiдключення до базы даних.");
            }

            MySqlCommand command;
            try
            {
                command = new MySqlCommand(query, _connection);
            }
            catch (Exception)
            {
                throw new Exception("Невiрно сформованний запит.");
            }
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var lst = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++) lst.Add(reader[i].ToString());

                res.Add(lst);
            }
            _connection.Close();
            return res;
        }

        public void PushQuery(string query)
        {
            try
            {
                _connection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Помилка пiдключення до базы даних.");
            }

            MySqlCommand command;
            try
            {
                command = new MySqlCommand(query, _connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Невiрно сформованний запит.");
            }
            _connection.Close();
        }
    }
}
