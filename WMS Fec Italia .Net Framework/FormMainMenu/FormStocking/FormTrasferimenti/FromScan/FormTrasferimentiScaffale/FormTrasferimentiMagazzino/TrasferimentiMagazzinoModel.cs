using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_Fec_Italia_MVC
{
    public class TrasferimentiMagazzinoModel
    {
        public int spostamentoDiVolume { get; set; }
        public List<int> idPacchi { get; set; }
        public string fornitore { get; set; }
        public string scaffaleProvenienza { get; set; }
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

        public void ControllaSpaziCompatibili()
        {
            using (var database = new Database())
            {
                try
                {
                    // Connessione al database
                    database.Connect();
                    // Esegui la query desiderata
                    string query = "SELECT * FROM wms_scaffali";
                    using (var reader = database.EseguiQuery(query))
                    {
                        // Estrapola i dati dal reader e aggiungi a HashSet
                        while (reader.Read())
                        {
                            int volumeScaffaleDisponibile = reader.GetInt32(reader.GetOrdinal("volume_libero"));
                            Shelf shelf = new Shelf(volumeScaffaleDisponibile);
                            Box box = new Box(spostamentoDiVolume);
                            if (shelf.CanFit(box))
                            {
                                string area = reader.GetString(reader.GetOrdinal("area"));
                                string scaffale = reader.GetString(reader.GetOrdinal("scaffale"));
                                string colonna = reader.GetString(reader.GetOrdinal("colonna"));
                                string piano = reader.GetString(reader.GetOrdinal("piano"));
                                string nome = $"{area}{scaffale}{colonna}{piano}";
                                // Control[] controls = this.Controls.Find(nome, true);
                                if (reader["fornitore_preferito"].ToString().Equals(fornitore))
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
                    //Da sostituire con una eccezione

                    throw new Exception($"Errore nella verifica degli spazi disponibili compatibili: {ex.Message}");
                }
            }
        }
        public bool ConfermaInserimento(string area, string scaffale, string colonna, string piano)
        {

            using (var database = new Database())
            {
                try
                {
                    // Inizializza la stringa di query all'inizio della transazione
                    string updateQuery = "BEGIN; -- Inizio della transazione\n";

                    // Aggiungi gli aggiornamenti degli oggetti per ogni id_pacco
                    foreach (int id in idPacchi)
                    {

                        updateQuery += $@"UPDATE wms_items 
                          SET area = '{area}' , scaffale='{scaffale}' , colonna='{colonna}' , piano = '{piano}' 
                          WHERE id_pacco = {id};";
                    }

                    // Aggiungi il COMMIT alla fine della transazione
                    updateQuery += "COMMIT; -- Fine della transazione, conferma i cambiamenti\n";

                    // Esegui l'aggiornamento nel database
                    if (database.AggiornaDatabase(updateQuery))
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore nell'inserimento dell'oggetto nel database: {ex.Message}");
                }
            }
        }

    }

}
