using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class AnalisiMagazzinoController
    {
        private AnalisiMagazzinoModel model;
        private AnalisiMagazzinoView view;


        public AnalisiMagazzinoController(AnalisiMagazzinoModel model, AnalisiMagazzinoView view)
        {
            this.model = model;
            this.view = view;
            view.onLoad += onLoad;
            view.onCellClick += onCellClick;
            view.onCambioFiltro += ApplicaFiltri;
            view.onButtonClick += OpenForm;
            this.view.AttachController(this);
        }

        private void OpenForm(object sender, EventArgs e)
        {
            VisualizzaMagazzinoModel modelVisualizzaMagazzino = new VisualizzaMagazzinoModel();
            modelVisualizzaMagazzino.area = view.GetSelectedArea();
            modelVisualizzaMagazzino.scaffale = view.GetSelectedScaffale();
            modelVisualizzaMagazzino.colonna = view.GetSelectedColonna();
            modelVisualizzaMagazzino.piano = view.GetSelectedPiano();
            var viewVisualizzaMagazzino = new VisualizzaMagazzinoView();
            VisualizzaMagazzinoController controllerStockingDettagli = new VisualizzaMagazzinoController(modelVisualizzaMagazzino, viewVisualizzaMagazzino);
            viewVisualizzaMagazzino.AttachController(controllerStockingDettagli);

            viewVisualizzaMagazzino.ShowDialog();
        }

        private void ApplicaFiltri(object sender, EventArgs e)
        {
            var values = new List<string>();

            // Creare una stringa di filtro per la ricerca nella colonna oft_code
            string filtroCodice = string.IsNullOrEmpty(view.GetArticoloTextBox().Text)
                ? ""
                : $"Convert(id_art, 'System.String') LIKE '%{view.GetArticoloTextBox().Text}%'";

            // Aggiungi il filtro per la colonna oft_inarrivo
            string filtroFornitore = string.IsNullOrEmpty(view.GetFornitoreTextBox().Text)
               ? ""
               : $"Convert(fornitore, 'System.String') LIKE '%{view.GetFornitoreTextBox().Text}%'";

            // Combinare i filtri con AND
            string filterExpression = "";

            List<string> filtri = new List<string> { filtroFornitore, filtroCodice };
            filtri.RemoveAll(f => string.IsNullOrEmpty(f));

            if (filtri.Any())
            {
                filterExpression = string.Join(" AND ", filtri);
            }

            // Applicare il filtro alla vista della DataGridView
     
            model.CompressedDatabaseData.DefaultView.RowFilter = filterExpression;
            view.GetDataGridViewListaArticoli().ClearSelection();
        }

        private void onCellClick(object sender, EventArgs e)
        {
            view.GetDataGridViewLocazioniArticolo().DataSource = model.LoadLocazioniArticolo(view.GetSelectedIdArticolo(), view.GetSelectedFornitore());
            try
            {
                view.FormatLocazioniDataGridView();

            }
            catch
            {

            }
        }

        private void onLoad(object sender, EventArgs e)
        {
            try
            {
                
                view.GetDataGridViewListaArticoli().DataSource = model.LoadDataTable("wms_items");
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox($"Errore nel caricare la tabella wms_items dal database: {ex.Message}");
            }

            view.FormatListaDataGridView();
        }
        
    }
}
