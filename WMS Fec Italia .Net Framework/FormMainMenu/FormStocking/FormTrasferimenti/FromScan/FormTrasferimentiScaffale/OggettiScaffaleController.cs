using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS_Fec_Italia.Net_Framework.Properties;
using WMS_Fec_Italia_MVC;



public class OggettiScaffaleController
{
    private OggettiScaffaleModel model;
    private OggettiScaffaleView view;

    public OggettiScaffaleController(OggettiScaffaleModel model, OggettiScaffaleView view)
    {
        this.model = model;
        this.view = view;
        view.onLoad += onLoad;
        view.buttonClick += buttonClick;
        view.AttachController(this);
    }

    private void onLoad(object sender, EventArgs e)
    {
        try
        {


            SetDataGrid(model.LoadShelfItems());
            string area = model.scannedShelf.Substring(0, 1);
            string scaffale = model.scannedShelf.Substring(1, 1);
            string colonna = model.scannedShelf.Substring(2, 2);
            string piano = model.scannedShelf.Substring(4, 1);
            view.SetScaffaleLabel(area, scaffale, colonna, piano);
        }
        catch (Exception ex)
        {
            view.DisplayErrorBox($"Errore durante il caricamento degli oggetti nello scaffale: {ex.Message}");
        }
    }

    private void SetDataGrid(DataTable dt)
    {
        
        // Aggiungi una colonna checkbox al DataTable
        DataColumn checkColumn = new DataColumn("Seleziona", typeof(bool));
        checkColumn.DefaultValue = false;

        // Assegna il DataTable come DataSource
        view.GetDataGridView().DataSource = dt;

        // Imposta la colonna checkbox alla fine delle colonne nel DataGridView
        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
        checkBoxColumn.HeaderText = "Seleziona";
        checkBoxColumn.DataPropertyName = "Seleziona";
        dt.Columns.Add(checkColumn);
        view.DataGridViewFormat();
    }

    private void buttonClick(object sender, EventArgs e)
    {
        List<string> volumiDaSpostare = new List<string>();
        HashSet<string> fornitoriUnici = new HashSet<string>();
        List<int> id_pacchi = new List<int>();
        // Verifica se il DataGridView è associato a un DataTable
        if (view.GetDataGridView().DataSource is DataTable dataTable)
        {

            foreach (DataRow riga in dataTable.Rows)
            {
                // Verifica se la colonna checkbox è spuntata
                if (riga["Seleziona"] != null && riga["Seleziona"] != DBNull.Value &&
                    Convert.ToBoolean(riga["Seleziona"]) == true)
                {
                    // La colonna "Seleziona" è spuntata
                    view.GetDataGridView().Rows[dataTable.Rows.IndexOf(riga)].Selected = true;

                    id_pacchi.Add(Convert.ToInt32(view.GetSelectedRowColumnValue("id_pacco")));
                    volumiDaSpostare.Add(view.GetSelectedRowColumnValue("dimensione"));
                    fornitoriUnici.Add(view.GetSelectedRowColumnValue("fornitore"));

                }
            }
           


            if (volumiDaSpostare.Count == 0)
            {
                return;
            }
            int spostamentoDiVolume = 0;

            foreach (string valore in volumiDaSpostare)
            {
                switch (valore)
                {
                    case "Piccolo":
                        spostamentoDiVolume += Dimensioni.piccolo;
                        break;
                    case "Medio":
                        spostamentoDiVolume += Dimensioni.medio;
                        break;
                    case "Grande":
                        spostamentoDiVolume += Dimensioni.grande;
                        break;
                }
            }

            //Se tutti i pacchi hanno lo stesso fornitore allora andrò a suggerire l'area del magazzino del fornitore.
            string fornitore;
            if (fornitoriUnici.Count == 1)
            {
                fornitore = fornitoriUnici.First();
            }
            else
            {
                fornitore = null;
            }

            TrasferimentiMagazzinoModel modelTrasferimentiMagazzino = new TrasferimentiMagazzinoModel();
            modelTrasferimentiMagazzino.spostamentoDiVolume = spostamentoDiVolume;
            modelTrasferimentiMagazzino.idPacchi = id_pacchi;
            modelTrasferimentiMagazzino.fornitore = fornitore;
            modelTrasferimentiMagazzino.scaffaleProvenienza = model.scannedShelf;

            TrasferimentiMagazzinoView viewTrasferimentiMagazzino = new TrasferimentiMagazzinoView();
            TrasferimentiMagazzinoController controllerTrasferimentiMagazzino = new TrasferimentiMagazzinoController(modelTrasferimentiMagazzino, viewTrasferimentiMagazzino);
            viewTrasferimentiMagazzino.AttachController(controllerTrasferimentiMagazzino);
            viewTrasferimentiMagazzino.ShowDialog();
            try
            {
                SetDataGrid(model.LoadShelfItems());
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox($"Errore durante il caricamento degli oggetti nello scaffale: {ex.Message}");
            }
        }
    }
}
