using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class StockingMagazzinoModel
    {
        public string codiceArticolo { get; set; }
        public string codiceMovimento { get; set; }
        public string codiceFornitore { get; set; }
        public string dimensioni { get; set; }
        public int quantita { get; set; }
        public int numeroPacchi { get; set; }
        public int volumeTot { get; set; }
        private HashSet<string> locazioniLibereGeneriche = new HashSet<string>();
        private HashSet<string> locazioniLibereFornitori = new HashSet<string>();

        public HashSet<string> GetLocazioniLibereGeneriche()
        {
            return this.locazioniLibereGeneriche;
        }

        public HashSet<string> GetLocazioniLibereFornitori()
        {
            return this.locazioniLibereFornitori;
        }

        public bool ConfermaInserimento(string area, string scaffale, string colonna, string piano)
        {
            using (var database = new Database())
            {
                OdbcTransaction transaction = null;

                try
                {
                    using (var connection = new OdbcConnection(DatabaseSettings.ConnectionString))
                    {
                        connection.Open();

                        // Inizia la transazione
                        transaction = connection.BeginTransaction();
                        int valoreDimensione;
                        string insertQuery = "";
                        string updateQuery = "";
                        switch (dimensioni)
                        {
                            case "Piccolo":
                                valoreDimensione = Dimensioni.piccolo;
                                break;
                            case "Medio":
                                valoreDimensione = Dimensioni.medio;
                                break;
                            case "Grande":
                                valoreDimensione = Dimensioni.grande;
                                break;
                            default:
                                valoreDimensione = 0;
                                break;

                        }

                        // Supponiamo che numPacchi sia il numero di iterazioni desiderate
                        for (int i = 0; i < numeroPacchi; i++)
                        {
                        
                            insertQuery += $@"
INSERT INTO wms_items (id_art, id_mov, fornitore, area, scaffale, colonna, piano, qta,  dimensione) 
VALUES ('{codiceArticolo}', '{codiceMovimento}' , '{codiceFornitore}','{area}', '{scaffale}','{colonna}', '{piano}', {quantita}, '{dimensioni}');
";
                            insertQuery += $@"UPDATE wms_scaffali SET volume_libero = volume_libero - {valoreDimensione} WHERE area = '{area}' AND scaffale = '{scaffale}' AND colonna = '{colonna}' AND piano = '{piano}';";

                        }
                        
                        // Esegui l'aggiornamento nel database all'interno della transazione
                        if (database.AggiornaDatabase(insertQuery, connection, transaction))
                        {
                            // Conferma la transazione
                            transaction.Commit();
                            
                            return true;
                        }

                        // Se si verifica un errore, esegui il rollback della transazione
                        transaction.Rollback();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // Se si verifica un errore, esegui il rollback della transazione
                    if (transaction != null)
                        transaction.Rollback();

                    throw new Exception($"Inserimento fallito: {ex.Message}");
                    return false;
                }
            }
        }

       
        

        public void ControllaSpaziCompatibili()
        {
            using (var database = new Database())
            {
                
                    // Connessione al database
                    try
                    {
                        database.Connect();
                        // Esegui la query desiderata
                        string query = $"SELECT * FROM wms_scaffali ";
                        using (var reader = database.EseguiQuery(query))
                        {
                            // Estrapola i dati dal reader e aggiungi a HashSet
                            while (reader.Read())
                            {
                                int volumeScaffaleDisponibile = reader.GetInt32(reader.GetOrdinal("volume_libero"));
                                Shelf shelf = new Shelf(volumeScaffaleDisponibile);
                                Box box = new Box(volumeTot);
                                if (shelf.CanFit(box))
                                {
                                    string area = reader.GetString(reader.GetOrdinal("area"));
                                    string scaffale = reader.GetString(reader.GetOrdinal("scaffale"));
                                    string colonna = reader.GetString(reader.GetOrdinal("colonna"));
                                    string piano = reader.GetString(reader.GetOrdinal("piano"));
                                    string nome = $"{area}{scaffale}{colonna}{piano}";
                                    // Control[] controls = this.Controls.Find(nome, true);
                                    if (reader["fornitore_preferito"].ToString().Equals(codiceFornitore))
                                    {
                                        locazioniLibereFornitori.Add(nome);
                                    }
                                    else
                                    {
                                        locazioniLibereGeneriche.Add(nome);

                                    }

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Impossibile ricavare spazi disponibili compatibili: {ex.Message}");
                    }
                
               
            }
        }
    }
}
