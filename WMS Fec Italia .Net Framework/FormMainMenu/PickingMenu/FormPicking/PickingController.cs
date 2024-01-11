using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace WMS_Fec_Italia_MVC
{
    public class PickingController
    {
        private readonly PickingModel model;
        private readonly PickingView view;

        public PickingController(PickingModel model, PickingView view)
        {
            this.model = model;
            this.view = view;
            view.onSearchButton += onSearchButtonOrdine;
            view.onArticoloSearch += onSearchButtonArticolo;
            view.onArticoloScannerizzato += onArticoloScannerizzato;
            view.effettuaPicking += EffettuaPicking;
            view.AttachController(this);
        }

        private void EffettuaPicking(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in view.GetDataGridView().Rows)
            {

                string codiceArticolo = row.Cells["codice_art"].Value.ToString();
                string codiceMovimento = row.Cells["movimento"].Value.ToString();
                string location = row.Cells["locat"].Value.ToString().Replace("-", "");
                string area = location.Substring(0, 1);
                string scaffale = location.Substring(1, 1);
                string colonna = location.Substring(2, 2);
                string piano = location.Substring(4, 1);
                int qtaDaPrelevare = Convert.ToInt32(row.Cells["qta_perlocazione"].Value);
                try
                {
                    model.EffettuaPicking(codiceArticolo, codiceMovimento, area, scaffale, colonna, piano,
                        qtaDaPrelevare);
                   
                }
                catch (Exception ex)
                {
                    view.DisplayErrorBox(ex.Message);
                }

                //righeVerdi.Add(row);
            }
            view.DisplayMessageBox("Picking effettuato", "Successo!");
            view.Close();
        }

       


        private void IniziaPickingCompleto(object sender, EventArgs e)
        {

        }
        private void onArticoloScannerizzato(object sender, EventArgs e)
        {
            string locazione = view.GetLocazioneScannerizzataTextBox().Text.Replace("-", "");
            if (model.locatCounts.ContainsKey(locazione))
            {

                if (model.locatCounts[locazione] > 1)
                {
                    // Se ci sono più di una occorrenza, decrementa il conteggio
                    model.locatCounts[locazione]--;
                }
                else
                {
                    // Se c'è solo un'occorrenza, rimuovi completamente la chiave

                    Label labelDaCambiare = view.Controls.Find(locazione, true).FirstOrDefault() as Label;

                    // Verifica se il controllo è stato trovato
                    if (labelDaCambiare != null)
                    {
                        // Imposta il colore di sfondo del Label
                        labelDaCambiare.BackColor = Color.White; // Sostituisci con il colore desiderato
                    }
                    model.locatCounts.Remove(locazione);
                }
            }
        }

        private void onSearchButtonArticolo(object sender, EventArgs e)
        {
            try
            {


                view.PulisciLocazioni(model.locatCounts);

                DataTable dt = model.EffettuaRicercaArticolo(view.GetArticoloSearchTextBox().Text);
                if (dt.Rows.Count > 0)
                {
                    int quantitaRichiesta = Convert.ToInt32(view.GetNumericUpDown().Value);
                    DataTable articoliTable = TrovaArticolo(dt, quantitaRichiesta);
                    view.GetDataGridView().DataSource = articoliTable;

                    foreach (DataGridViewRow row in view.GetDataGridView().Rows)
                    {

                        //
                        view.TrovaEColoraLocazione(row);
                        // Cerca il controllo Label nel form utilizzando il nome



                    }

                }
                else
                {
                    view.DisplayErrorBox("Nessun risultato trovato.");
                }
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message );
            }
        }

        private DataTable TrovaArticolo(DataTable table, int quantitaRichiesta)
        {
            try
            {
                int quantitaDaAllocare = quantitaRichiesta;
                DataTable newTable = new DataTable();
                newTable.Columns.Add("codice_art", typeof(string));
                newTable.Columns.Add("descrizione", typeof(string));
                newTable.Columns.Add("movimento", typeof(string));

                newTable.Columns.Add("locat", typeof(string));
                newTable.Columns.Add("qta_perlocazione", typeof(int)); // Ca

                string idArt = "";
                string artDesc = "";
                foreach (DataRow row in table.Rows)
                {
                    int quantitaPresente = Convert.ToInt32(row["qta"]);
                    idArt = row["id_art"].ToString();
                    artDesc = row["amg_dest"].ToString();
                    string locat = row["locat"].ToString();
                    string filteredLocat = locat.Replace("-", "");
                    if (model.locatCounts.ContainsKey(filteredLocat))
                    {
                        // Se la chiave è già presente, incrementa il conteggio
                        model.locatCounts[filteredLocat]++;
                    }
                    else
                    {
                        // Altrimenti, aggiungi la chiave con un conteggio iniziale di 1
                        model.locatCounts.Add(filteredLocat, 1);
                    }

                    if (quantitaDaAllocare <= quantitaPresente)
                    {

                        newTable.Rows.Add(idArt, artDesc, row["id_mov"], locat, quantitaDaAllocare);
                        return newTable;
                    }
                    else
                    {
                        newTable.Rows.Add(idArt, artDesc, row["id_mov"], locat, quantitaPresente);
                        quantitaDaAllocare = quantitaDaAllocare - quantitaPresente;
                    }
                    //Nel caso non uscissi dalla funzione nell'if allora significa che la mia quantita nella locazione non è sufficiente a soddisfare quella totale
                    //Quindi aggiungo una riga dicendo quanta prelevarne da quella li specifica (che corrispondera al totale dello scaffale)
                    //newTable.Rows.Add(codiceArt, descrizione, mov, locat, qtaPerLocazione);


                    //       quantitaRichiesta -= qtaPerLocazione;




                }

                newTable.Rows.Add(idArt, artDesc, null, "MANCANTE", quantitaDaAllocare);


                return newTable;

            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
                return null;
            }
        }


        private void onSearchButtonOrdine(object sender, EventArgs e)
        {
            try
            {

                //Rimuovo le locazioni gia colorate da eventuali ricerche precedenti effettuate nella stessa sessione
                view.PulisciLocazioni(model.locatCounts);

                view.SetProgressBarStyle(ProgressBarStyle.Marquee);

                string occ_code = view.GetCodiceOrdineTextBox().Text;
                string occ_tipo = view.GetTipoOrdineTextBox().Text;
                DataTable risultatoRicerca = model.EffettuaRicercaPicking(occ_code, occ_tipo);
                DataTable totaleComponentiPicking = new DataTable();
                
                if (risultatoRicerca != null && risultatoRicerca.Rows.Count > 0)
                {
                    //Controllo e eventualmente creo l'ordine picking, per salvare gli articoli che verranno scannerizzati.



                    List<string> occ_artiList = new List<string>();

                    foreach (DataRow row in risultatoRicerca.Rows)
                    {
                        occ_artiList.Add(row["occ_arti"].ToString());
                    }

                    totaleComponentiPicking = model.OttieniQuantitaOggettiComposti(occ_artiList);

                    
                    totaleComponentiPicking.Merge(model.OttieniQuantitaOggettiSemplici(occ_code, occ_tipo));
                   


                    //trovo tutti gli articolo non composti e li aggiungo alla tabella
                    //rimuovo la colonna padre in quanto inutile all'operatore.
                    totaleComponentiPicking.Columns.Remove("mpl_padre");
                    //Sommo i duplicati per renderli una riga unica.
                    totaleComponentiPicking = MergeAndSumDuplicates(totaleComponentiPicking, "occ_arti", "mpl_coimp");
                    //Se non esiste la colonna descrizione la creo.
                    
                    if (!totaleComponentiPicking.Columns.Contains("descrizione"))
                    {
                        totaleComponentiPicking.Columns.Add("descrizione", typeof(string));
                    }
                   
                    //Dopo aver rimosso i duplicati posso cercare per ogni riga ottenuta la descrizione.
                  
                        model.GetDescrizioni(totaleComponentiPicking);
                    
                    
                    //Devo controllare se gli articoli sono disponibili in una singola locazione o se dovrò andare a prenderli da piu scaffali
                    //Non posso effettuare operazioni sul datatable mentre itero lo stesso datatable, devo quindi crearne una copia su cui lavorare
                    DataTable totaleComponentiConLocazioni = new DataTable();
             
                    

                        //estrae dalla row l'articolo e mi restituisce un datatable con tutte le locazioni di quel articolo
                        //fino a soddisfare la quantita richiesta, se non puo l'ultima riga restituita mi dirà la quantita mancante
                        totaleComponentiConLocazioni.Merge(model.ControllaLocazioni(totaleComponentiPicking));

                        //trova un modo per controllare le locazioni e creare row per ogni locazioni finche la quantita necessaria non è soddisfatta
           
                    //Imposto la fonte dei dati del mio datagridview uguale alla tabella che ho manipolato
                    view.GetDataGridView().DataSource = totaleComponentiConLocazioni;
                    
                    //Ripristino un eventuale picking parziale effettuato in precedenza su questo ordine
                    view.GetDataGridView().Sort(view.GetDataGridView().Columns["locat"],
                        System.ComponentModel.ListSortDirection.Ascending);
                    foreach (DataGridViewRow row in view.GetDataGridView().Rows)
                    {
                        view.TrovaEColoraLocazione(row);
                    }
                  
                    view.GetDataGridView().Columns["codice_art"].HeaderText = "Articolo";
                    view.GetDataGridView().Columns["descrizione"].HeaderText = "Descrizione";
                    view.GetDataGridView().Columns["movimento"].HeaderText = "Movimento";
                    view.GetDataGridView().Columns["locat"].HeaderText = "Locazione";
                    view.GetDataGridView().Columns["qta_perlocazione"].HeaderText = "Qta";

                    view.GetDataGridView().Columns["descrizione"].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode
                            .Fill; // Puoi anche impostare AutoSizeColumnMode su AllCells per alcune colonne
                    foreach (DataGridViewColumn colonna in view.GetDataGridView().Columns)
                    {
                        colonna.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    view.GetDataGridView().ClearSelection();
                }
                else
                {
                    // La query non ha prodotto alcun risultato
                    view.DisplayErrorBox("Nessun risultato trovato.");
                }
            }
            catch (Exception ex)
            {
               view.DisplayErrorBox(ex.Message);
            }
            finally
            {
                view.SetProgressBarStyle(ProgressBarStyle.Blocks);
            }
        }

        static DataTable MergeAndSumDuplicates(DataTable dataTable, string columnNameToMerge, string columnNameToSum)
        {
            // Raggruppa i dati per la colonna specificata
            var groupedData = from row in dataTable.AsEnumerable()
                              group row by row.Field<string>(columnNameToMerge) into grouped
                              select new
                              {
                                  Key = grouped.Key,
                                  Total = grouped.Sum(r => r.Field<decimal>(columnNameToSum))
                              };

            // Crea una nuova DataTable con la struttura originale
            DataTable resultTable = dataTable.Clone();

            // Aggiungi i dati raggruppati nella nuova DataTable
            foreach (var group in groupedData)
            {
                DataRow newRow = resultTable.NewRow();
                newRow[columnNameToMerge] = group.Key;
                newRow[columnNameToSum] = group.Total; // Non è necessario convertire la somma in stringa
                resultTable.Rows.Add(newRow);
            }
            return resultTable;
        }

    }
}
