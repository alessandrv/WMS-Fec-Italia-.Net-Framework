using System;
using System.Data;
using System.Data.Odbc;

namespace WMS_Fec_Italia_MVC
{
    internal class Database : IDisposable
    {
        public OdbcConnection OdbcConnection;

        public Database()
        {
            OdbcConnection = new OdbcConnection(DatabaseSettings.ConnectionString);
        }

        public void Connect()
        {
            try
            {
                OdbcConnection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante la connessione al database: {ex.Message}");
            }
        }

        public void Close()
        {
            OdbcConnection.Close();
        }

        public void Dispose()
        {
            OdbcConnection.Dispose();
        }
        public bool AggiornaDatabase(string query, OdbcConnection connection, OdbcTransaction transaction)
        {
            try
            {
                using (var updateCommand = new OdbcCommand(query, connection, transaction))
                {
                    updateCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore durante l'aggiornamento nel database: {ex.Message}");
                return false;
            }
        }
        public bool AggiornaDatabase(OdbcCommand command)
        {
            using (var connection = new OdbcConnection(DatabaseSettings.ConnectionString))
            {
                connection.Open();
                command.Connection = connection;

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore durante l'aggiornamento nel database: {ex.Message}");
                }
            }
        }

        public bool AggiornaDatabase(string query)
        {
            using (var connection = new OdbcConnection(DatabaseSettings.ConnectionString))
            {
                connection.Open();
                using (var updateCommand = new OdbcCommand(query, connection))
                {
                    updateCommand.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public DataTable GetDataTableFromQuery(string query)
        {
            using (var database = new Database())
            {
                database.Connect();
                OdbcCommand odbcCommand = new OdbcCommand(query);
                odbcCommand.Connection = database.OdbcConnection;
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = odbcCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public OdbcDataReader EseguiQuery(string query)
        {
            var connection = new OdbcConnection(DatabaseSettings.ConnectionString);
            connection.Open();

            var selectCommand = new OdbcCommand(query, connection);
            return selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public object EstrapolaCampo(OdbcDataReader reader, string campoRichiesto)
        {
            object risultato = null;

            if (reader.HasRows && reader.Read())
            {
                if (reader.GetOrdinal(campoRichiesto) != -1)
                {
                    risultato = reader[campoRichiesto];
                }
            }

            if (!reader.IsClosed)
            {
                reader.Close();
            }
            return risultato;
        }

        public DataTable LoadData(string tableName, string condition, string joinClause = "")
        {
            using (var database = new Database())
            {
                database.Connect();

                string query = $"SELECT * FROM {tableName}";

                if (!string.IsNullOrEmpty(joinClause))
                {
                    query += $" {joinClause}";
                }

                if (!string.IsNullOrEmpty(condition))
                {
                    query += $" WHERE {condition}";
                }

                OdbcCommand odbcCommand = new OdbcCommand(query);
                odbcCommand.Connection = database.OdbcConnection;
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = odbcCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public DataTable LoadData(string tableName, string condition)
        {
            using (var database = new Database())
            {
                database.Connect();

                string query = $"SELECT * FROM {tableName} WHERE {condition}";

                OdbcCommand odbcCommand = new OdbcCommand(query);
                odbcCommand.Connection = database.OdbcConnection;
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = odbcCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public DataTable LoadData(string tableName)
        {
            using (var database = new Database())
            {
                database.Connect();

                string query = $"SELECT * FROM {tableName}";
                OdbcCommand odbcCommand = new OdbcCommand(query);
                odbcCommand.Connection = database.OdbcConnection;
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = odbcCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (tableName == "ofordic")
                {
                    dt.Columns.Add("ofc_desc1", typeof(string), "ofc_desc + ' ' + ofc_des2");
                    dt.Columns["ofc_desc1"].SetOrdinal(2);
                    dt.Columns["ofc_arti"].SetOrdinal(1);
                }

                return dt;
            }
        }
    }
}
