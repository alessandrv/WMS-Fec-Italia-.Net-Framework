using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using WMS_Fec_Italia_MVC;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class ResiOrdineModel
    {
       

        public string octTipo { get; set; }
        public string octCode { get; set; }
        public int totalItems { get; set; }
        public DataTable DatabaseData { get; set; }

        /// <summary>
        /// Carica i dati dalla tabella del database in base ai filtri impostati.
        /// </summary>
        public void LoadData()
        {

            string tableName = "ocordic";
            string condition = $"occ_code = '{octCode}' AND occ_tipo='{octTipo}' AND occ_arti IS NOT NULL AND occ_arti <> ''";
            Database database = new Database();
            //carica datatable con una condizione
            DatabaseData = database.LoadData(tableName, condition);
            DatabaseData.Columns.Add("occ_desc1", typeof(string), "occ_desc + ' ' + occ_des2");
            DatabaseData.Columns["occ_desc1"].SetOrdinal(2);
            DatabaseData.Columns["occ_arti"].SetOrdinal(1);
            totalItems = DatabaseData.Rows.Count;

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
                   
                       

                            string updateQuery = $"UPDATE ocordit SET oct_actz = CURDATE() where oct_code = '{octCode}' and oct_tipo = '{octTipo}'";
                            database.AggiornaDatabase(updateQuery);
                            


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
                        $"SELECT COUNT(*) FROM ofordic WHERE ofc_inarrivo = '{statoDaContare}' AND ofc_code = '{octCode}' AND ofc_tipo ='{octTipo}'";

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
                    string updateQuery = $"UPDATE ofordit SET oft_stat = '{stato}' WHERE oft_tipo = '{octTipo}' AND oft_code = '{octCode}'";
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
                        $"SELECT COUNT(*) FROM ofordic WHERE (ofc_stato = '{statoDaContare}' OR ofc_stato = '{statoDaContare2}') AND ofc_code = '{octCode}' AND ofc_tipo = '{octTipo}'";

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
