using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sisir
{
    public class DatabaseAdapter
    {
        public DatabaseAdapter() { }

        NpgsqlConnection conn = null;

        public NpgsqlConnection ConnectToDb()
        {
            try
            {
                var connectionString = "Host=localhost;Username='postgres';Password='1234';Database=sisir";
                var dataSource = NpgsqlDataSource.Create(connectionString);
                var conn = dataSource.OpenConnection();
                this.conn = conn;
                return conn;
            }
            catch
            {
                var a = MessageBox.Show("Не удалось подключиться к базе данных. Попробуйте открыть справочкик еще раз.");
                return null;
            }
        }

        private void CloseConnection(NpgsqlConnection conn)
        {
            conn.Close();
        }

        public List<Dictionary<string, string>> ExecuteCommand(string _command)
        {
            if (this.conn == null)
            {
                var conn = ConnectToDb();
            }
            else if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }


            var command = new NpgsqlCommand(_command, conn);
            var reader = command.ExecuteReader();

            var data = new List<Dictionary<string, string>>();
            while (reader.Read())
            {
                Console.WriteLine(reader.Rows.ToString());
                for (ulong i = 0; i <= reader.Rows; i++)
                {
                    var dData = new Dictionary<string, string>();
                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        dData.Add(reader.GetName(j), reader[j].ToString());
                    }
                    data.Add(dData);
                }
            }

            CloseConnection(conn);

            return data;
        }

        public void ExecuteCommandNoReturn(string _command)
        {
            if (this.conn == null)
            {
                var conn = ConnectToDb();
            }
            else if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }

            var command = new NpgsqlCommand(_command, conn);
            command.ExecuteNonQuery();

            CloseConnection(conn);
        }

        public DataSet GetDataSet(string command)
        {

            DataSet ds = new DataSet();
            if (this.conn == null)
            {
                var conn = ConnectToDb();
            }
            else if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }

            if (conn != null)
            {
                var adapter = new NpgsqlDataAdapter(command, conn);
                adapter.Fill(ds);
                CloseConnection(conn);
            }


            return ds;
        }

        public void UpdateDataSet(DataTable dataTable, string command)
        {
            if (this.conn == null)
            {
                var conn = ConnectToDb();
            }
            else if (this.conn.State == ConnectionState.Closed)
            {
                this.conn.Open();
            }

            if (conn != null)
            {
                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(command, conn);
                npgsqlDataAdapter.Update(dataTable);
                CloseConnection(conn);
            }
        }

    }
}
