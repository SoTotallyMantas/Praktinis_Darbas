using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Projektinis_darbas_akademine_is.sql
{
    internal class sql_class
    {
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _username;
        private string _password;
        private string _port;
        public sql_class(string server, string database, string username, string password, string port)
        {
            _server = server;
            _database = database;
            _username = username;
            _password = password;
            _port = port;
            _connection = new MySqlConnection();
            _connection.ConnectionString = $"server={_server};database={_database};username={_username};password={_password};port={_port}";
        }
        public void Open()
        {
            try
            {
                _connection.Open();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                
            }
        }
        public void Close()
        {
            try
            {
                _connection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                
            }
        }
        public void ModifyDataSet(string procedureName, Dictionary<string, object> parameters)
        {
  
            MySqlDataAdapter adapter = new MySqlDataAdapter(procedureName, _connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in parameters)
            {
                MySqlParameter param = new MySqlParameter(parameter.Key, parameter.Value);
                adapter.SelectCommand.Parameters.Add(param);
            }
           
                adapter.SelectCommand.ExecuteNonQuery();
            
            
            

            
        }

        public DataTable FillDataSet(string procedureName, Dictionary<string, object> parameters)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(procedureName, _connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            foreach (var parameter in parameters)
            {
                MySqlParameter param = new MySqlParameter(parameter.Key, parameter.Value);
                adapter.SelectCommand.Parameters.Add(param);
            }

            DataSet dataSet1 = new DataSet();
            adapter.Fill(dataSet1);
            DataTable datatable = dataSet1.Tables[0];
            return datatable;
        }
        public DataTable FillDataSet(string procedureName)
        {
            return FillDataSet(procedureName, new Dictionary<string, object>());

        }   

        
       
    }
}

 
   

