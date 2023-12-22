using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_Fec_Italia_MVC
{
    public class AnalisiMagazzinoModel
    {
        public DataTable DatabaseData { get; set; }
        public DataTable CompressedDatabaseData { get; set; }
        public void LoadTable(string tableName)
        {
            // Qui inserisci la logica per caricare i dati nel DataTable
            // Ad esempio, puoi utilizzare il tuo oggetto Database per ottenere i dati
            Database database = new Database();
            DatabaseData = database.LoadData(tableName);
        }
        public DataTable LoadDataTable(string tableName)
        {

            Database database = new Database();
            DatabaseData = database.LoadData(tableName);

            if (DatabaseData is DataTable dt)
            {
                // Utilizzare LINQ per raggruppare e sommare i valori sulla colonna "qta" posso anche sostituire con query specifica
                var result = from row in dt.AsEnumerable()
                             where !row.IsNull("id_art") && !row.IsNull("fornitore")
                             group row by new
                             {
                                 IdArt = row.Field<string>("id_art"),
                                 Fornitore = row.Field<string>("fornitore")
                             } into grouped
                             select new
                             {
                                 IdArt = grouped.Key.IdArt,
                                 Fornitore = grouped.Key.Fornitore,
                                 QtaTotale = grouped.Sum(r => r.Field<int>("qta"))
                             };

                // Creare un nuovo DataTable con i risultati della query LINQ
                DataTable CompressedDatabaseData = new DataTable();
                CompressedDatabaseData.Columns.Add("id_art", typeof(string));
                CompressedDatabaseData.Columns.Add("fornitore", typeof(string));
                CompressedDatabaseData.Columns.Add("qta_totale", typeof(int));

                foreach (var item in result)
                {
                    CompressedDatabaseData.Rows.Add(item.IdArt, item.Fornitore, item.QtaTotale);
                }
                this.CompressedDatabaseData = CompressedDatabaseData;
                // Applicare il filtro alla vista della DataGridView
                return CompressedDatabaseData;

            }
            return null;
            //this.DatabaseData.DefaultView.Sort = "locat";

        }

        public DataTable LoadLocazioniArticolo(string idArticolo, string fornitore)
        {
            // Ottieni i valori della cella selezionata
            // string idArt = GetSelectedRowColumnValue(dataGridViewListaArticoli, "id_art");
            //string fornitore = GetSelectedRowColumnValue(dataGridViewListaArticoli, "fornitore");

            // Verifica se la tabella contiene dati
            try
            {

                if (DatabaseData is DataTable dt)
                {
                    // Utilizza LINQ per filtrare i risultati in base a id_art e fornitore
                    var result = from row in dt.AsEnumerable()
                                 where row.Field<string>("id_art") == idArticolo &&
                                       row.Field<string>("fornitore") == fornitore
                                 select row;

                    // Creare un nuovo DataTable con i risultati della query LINQ
                    DataTable newDt = result.CopyToDataTable();

                    // Visualizza i risultati nel DataGridView specifico
                    return newDt;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
