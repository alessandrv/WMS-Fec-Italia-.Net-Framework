using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_Fec_Italia_MVC
{
    public class RiparazioniModel
    {
        public void InsertRiparazione(string ticketNumber, string cliente)
        {
            using (Database database = new Database())
            {
                try
                {
                    database.Connect();

                    // Utilizza un parametro per il numero del biglietto
                    // e un parametro per il nome del cliente
                    string updateQuery = @"INSERT INTO wms_riparazioni (ticket, codice_cliente, ragione_sociale)
                                   VALUES (?, 
                                           (SELECT cod_clifor
                                            FROM agclifor
                                            WHERE des_clifor = ? AND cli_for = 'C'), ?)";

                    // Crea il comando SQL con i parametri
                    OdbcCommand command = new OdbcCommand(updateQuery, database.OdbcConnection);
                    command.Parameters.AddWithValue("ticketNumber", ticketNumber);
                    command.Parameters.AddWithValue("cliente", cliente);
                    command.Parameters.AddWithValue("cliente2", cliente); // Aggiungi una seconda volta per il terzo parametro

                    // Esegui il comando
                    database.AggiornaDatabase(command);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore durante l'aggiornamento nel database: {ex.Message}");
                }
            }
        }

        public List<string> LoadClienti()
        {
            List<string> clienti = new List<string>();

            using (var database = new Database())
            {
                database.Connect();

                string query =
                    $@"SELECT des_clifor
                FROM agclifor
                WHERE cli_for = 'C'
                ORDER BY des_clifor";

                using (OdbcCommand odbcCommand = new OdbcCommand(query, database.OdbcConnection))
                {
                    using (OdbcDataReader reader = odbcCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            
                                string Nome = reader["des_clifor"].ToString().Trim();
                            

                            clienti.Add(Nome);
                        }
                    }
                }
            }

            return clienti;
        }
    }
}
