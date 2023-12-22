using System;
using System.Data;

namespace WMS_Fec_Italia_MVC
{
    public class FornitoriOrdineController
    {
        private FornitoreOrdineModel model;
        private FornitoreOrdineView view;
        private string oftCode;
        private string oftTipo;

        /// <summary>
        /// Inizializza una nuova istanza della classe AccettazioneOrdineController.
        /// </summary>
        /// <param name="model">Il modello associato al controller.</param>
        /// <param name="view">La vista associata al controller.</param>
        public FornitoriOrdineController(FornitoreOrdineModel model, FornitoreOrdineView view)
        {
            this.model = model;
            this.view = view;
            this.view.onLoad += OnLoad;
            this.view.button1Clicked += OnButton1Clicked;
            this.view.segnalaProblemaClicked += View_segnalaProblemaClicked;
        }

        private void View_segnalaProblemaClicked(object sender, EventArgs e)
        {
            Fotocamera fotocameraView = new Fotocamera();
            fotocameraView.ShowDialog();
        }

        /// <summary>
        /// Carica i dati dal modello al momento dell'inizializzazione.
        /// </summary>
        public void CaricaDati()
        {
            try
            {
                model.LoadData();
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox($"Errore nel caricare i dati:{ex.Message}");
            }

        }

        /// <summary>
        /// Restituisce i dati del database dal modello.
        /// </summary>
        /// <returns>Un oggetto DataTable contenente i dati del database.</returns>
        public DataTable GetDatabaseData()
        {
            return model.DatabaseData;
        }

        /// <summary>
        /// Gestisce l'evento di caricamento della vista effettuando la ricerca dei dati con il model dal database.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        public void OnLoad(object sender, EventArgs e)
        {
            CaricaDati();
            view.GetDataGridView().DataSource = GetDatabaseData();
        }

        /// <summary>
        /// Gestisce l'evento del clic sul pulsante nella vista.
        /// </summary>
        /// <param name="sender">L'oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        public void OnButton1Clicked(object sender, EventArgs e)
        {

            try
            {
                model.UpdateDatabase(view.GetDataGridView());
                view.DisplayMessageBox("Aggiornamento completato con successo.", "Successo");
                view.Close();
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox($"Errore durante l'aggiornamento nel database: {ex.Message}");
            }
        }

      

    }

}
