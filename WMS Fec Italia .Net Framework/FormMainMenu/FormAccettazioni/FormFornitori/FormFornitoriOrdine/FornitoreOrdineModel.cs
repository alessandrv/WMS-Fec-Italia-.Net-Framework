using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using WMS_Fec_Italia_MVC;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class FornitoreOrdineModel
    {
        public string ofcTipo { get; set; }
        public string ofcCode { get; set; }
        public int totalItems { get; set; }
        public DataTable DatabaseData { get; set; }

        /// <summary>
        /// Carica i dati dalla tabella del database in base ai filtri impostati.
        /// </summary>
        public void LoadData()
        {

            using (var database = new Database())
            {
                database.Connect();
             
                // Utilizza un alias per semplificare la sintassi della query
                string query =
                    $@"SELECT ofc_arti, ofc_desc, ofc_des2, ofc_qord, ofc_dtco, ofc_stato, ofc_qtarrivata, ofc_inarrivo
FROM ofordic
WHERE ofc_tipo = '{ofcTipo}' AND ofc_code = {ofcCode} AND ofc_arti IS NOT NULL AND ofc_arti != ''";




                OdbcCommand odbcCommand = new OdbcCommand(query);
                odbcCommand.Connection = database.OdbcConnection;
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = odbcCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DatabaseData = dt;

                DatabaseData.Columns.Add("ofc_desc1", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull("ofc_des2"))
                    {
                        row["ofc_desc1"] = row["ofc_desc"] + " " + row["ofc_des2"];
                    }
                    else
                    {
                        row["ofc_desc1"] = row["ofc_desc"];
                    }
                }

                // Aggiungi la colonna risultante a DatabaseData
                
                DatabaseData.Columns["ofc_desc1"].SetOrdinal(2);
                DatabaseData.Columns["ofc_arti"].SetOrdinal(1);
                totalItems = DatabaseData.Rows.Count;
            }
        }

        /// <summary>
        /// Aggiorna il database in base alle modifiche effettuate nella DataGridView.
        /// </summary>
        /// <param name="dataGridView">DataGridView contenente i dati dell'ordine.</param>
        public void UpdateDatabase(DataGridView dataGridView)
        {
            using (Database database = new Database())
            {

                try
                {
                    database.Connect();
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        bool isModified = Convert.ToBoolean(row.Cells["checkColumn"].Value);
                        bool inArrivo = Convert.ToBoolean(row.Cells["inArrivoColumn"].Value);
                        string oggettoID = row.Cells["ofc_arti"].Value.ToString();

                        if (isModified)
                        {
                            int nuovaQtArrivata = Convert.ToInt32(row.Cells["ofc_qtarrivata"].Value);
                            string nuovoStato = row.Cells["ofc_stato"].Value.ToString();

                            string updateQuery = $"UPDATE ofordic SET ofc_qtarrivata = {nuovaQtArrivata}, ofc_stato = '{nuovoStato}' WHERE ofc_arti = '{oggettoID}' AND ofc_code = '{ofcCode}' AND ofc_tipo = '{ofcTipo}'";
                            database.AggiornaDatabase(updateQuery);
                        }

                        string inArrivoStatus = inArrivo && !isModified ? "S" : "N";
                        string updateQueryInArrivo = $"UPDATE ofordic SET ofc_inarrivo = '{inArrivoStatus}' WHERE ofc_arti = '{oggettoID}' AND ofc_code = '{ofcCode}' AND ofc_tipo = '{ofcTipo}'";
                        database.AggiornaDatabase(updateQueryInArrivo);
                    }

                    string statoArrivato = CheckArrivatiOrdineLocale(dataGridView) ? CheckArrivatiOrdineDB() ? "C" : "A" : "A";
                    CambiaStatoOrdine(statoArrivato);

                    string statoArrivo = ordineInArrivo() ? "S" : "N";
                    string query = $"UPDATE ofordit SET oft_inarrivo = '{statoArrivo}' WHERE oft_tipo = '{ofcTipo}' AND oft_code = '{ofcCode}'";
                    database.AggiornaDatabase(query);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore durante l'aggiornamento nel database: {ex.Message}");
                }
            }
        }


        /// <summary>
        /// Verifica se l'ordine è in arrivo.
        /// </summary>
        /// <returns>True se l'ordine è in arrivo, altrimenti false.</returns>
        private bool ordineInArrivo()
        {
            using (var database = new Database())
            {

                try
                {
                    database.Connect();
                    string statoDaContare = "S";

                    // Query SQL con COUNT
                    string countQuery =
                        $"SELECT COUNT(*) FROM ofordic WHERE ofc_inarrivo = '{statoDaContare}' AND ofc_code = '{ofcCode}' AND ofc_tipo ='{ofcTipo}'";

                    OdbcCommand countCommand = new OdbcCommand(countQuery, database.OdbcConnection);

                    // Esegui la query
                    int countResult = Convert.ToInt32(countCommand.ExecuteScalar());

                    if (countResult > 0)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Impossibile ottenere lo stato di arrivo dell'ordine: {ex.Message}");


                }
            }
        }

        /// <summary>
        /// Cambia lo stato dell'ordine nel database.
        /// </summary>
        /// <param name="stato">Nuovo stato dell'ordine.</param>
        public void CambiaStatoOrdine(string stato)
        {
            using (var database = new Database())
            {

                try
                {
                    database.Connect();
                    string updateQuery = $"UPDATE ofordit SET oft_stat = '{stato}', oft_actz = CURDATE() WHERE oft_tipo = '{ofcTipo}' AND oft_code = '{ofcCode}'";
                    OdbcCommand updateCommand = new OdbcCommand(updateQuery, database.OdbcConnection);
                    updateCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //Da sostituire con una eccezione

                    throw new Exception($"Errore durante l'esecuzione della query per cambiare lo stato dell'ordine: {ex.Message}");
                }
                finally
                {
                    database.Close();
                }


            }
        }

        /// <summary>
        /// Verifica se tutti gli oggetti dell'ordine sono arrivati nel database.
        /// </summary>
        /// <returns>True se tutti gli oggetti sono arrivati, altrimenti false.</returns>
        public bool CheckArrivatiOrdineDB()
        {
            using (var database = new Database())
            {

                try
                {
                    database.Connect();
                    string statoDaContare = "Arrivato";
                    string statoDaContare2 = "Extra";

                    string countQuery =
                        $"SELECT COUNT(*) FROM ofordic WHERE (ofc_stato = '{statoDaContare}' OR ofc_stato = '{statoDaContare2}') AND ofc_code = '{ofcCode}' AND ofc_tipo = '{ofcTipo}'";

                    OdbcCommand countCommand = new OdbcCommand(countQuery, database.OdbcConnection);

                    int countResult = Convert.ToInt32(countCommand.ExecuteScalar());
                    return countResult == totalItems;
                }
                catch (Exception ex)
                {
                    //Da sostituire con una eccezione

                    throw new Exception(
                        $"Errore durante l'esecuzione della query COUNT per verificare arrivi nell'ordine: {ex.Message}");
                }

            }

        }


        public bool CheckArrivatiOrdineLocale(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string statoCorrente = row.Cells["ofc_stato"].Value.ToString();
                if (statoCorrente == "Parziale")
                {
                    return false; // Se almeno un valore non è "Arrivato", esci dal ciclo
                }
            }

            return true;
        }
    }

}
