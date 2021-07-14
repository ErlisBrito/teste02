using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace teste02.Util
{
    public class DAL
    {
        private static readonly string serve = "localhost";
        private static readonly string database = "Teste_Net";
        private static readonly string user = "root";
        private static readonly string password = "root";
        private readonly string connectionString = $"Server={serve};Database={database};Uid={user};Pwd={password};";
        private readonly MySqlConnection connection;

        public DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        //executa selects
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter ad = new MySqlDataAdapter(command);
            ad.Fill(dataTable);
            return dataTable;
        }

        // Executa INSERTs, UPDATEs, DELETEs
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
