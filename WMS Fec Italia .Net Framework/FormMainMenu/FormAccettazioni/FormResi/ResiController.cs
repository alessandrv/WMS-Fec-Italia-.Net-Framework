using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace WMS_Fec_Italia_MVC
{
    public class ResiController
    {
        private readonly ResiModel model;
        private readonly ResiView view;
        private string octCode;
        private string octTipo;

        public ResiController(ResiModel model, ResiView view)
        {
            this.model = model;
            this.view = view;
            this.view.aggiornaButtonClicked += OnLoad;
            this.view.openForm += OpenForm;
            this.view.onLoad += OnLoad;
            this.view.filtroChanged += FiltroChanged;
            view.AttachController(this);
        }

        public void CaricaDati()
        {
            try
            {
                model.LoadTable();
                CaricaFornitoriDalDataGridView();
                CaricaTipoOrdiniDaDataGridView();

                view.PopolaDataGridView();
                ApplicaFiltri();
                view.SvuotaSelezioneDataGridView();
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }
        
        }

        public void CaricaTipoOrdiniDaDataGridView()
        {
            // Utilizzo di HashSet per tracciare i fornitori già aggiunti
            HashSet<string> uniqueTipo = new HashSet<string>();

            // Rimuovi tutti gli elementi esistenti dal ComboBox
            ComboBox tipoComboBox = view.GetTipoComboBox();
            tipoComboBox.Items.Clear();

            // Aggiungi un campo vuoto come primo elemento
            tipoComboBox.Items.Add("");

            // Itera attraverso le righe del DataGridView e aggiungi fornitori unici al ComboBox
            foreach (DataRow row in GetDatabaseData().Rows)
            {
                // Assumendo che la colonna con il nome del fornitore si chiami "des_clifor"
                if (row["oct_tipo"] != null && row["oct_tipo"] != DBNull.Value)
                {
                    string tipo = row["oct_tipo"].ToString();

                    // Verifica se il fornitore è già stato aggiunto
                    if (!uniqueTipo.Contains(tipo))
                    {
                        tipoComboBox.Items.Add(tipo);
                        uniqueTipo.Add(tipo);
                    }
                }
            }
        }

        /// <summary>
        /// Carica i fornitori dal DataGridView nella vista.
        /// </summary>
        public void CaricaFornitoriDalDataGridView()
        {
            // Utilizzo di HashSet per tracciare i fornitori già aggiunti
            HashSet<string> uniqueFornitori = new HashSet<string>();

            // Rimuovi tutti gli elementi esistenti dal ComboBox
            ComboBox fornitoreComboBox = view.GetFornitoreComboBoxItem();
            fornitoreComboBox.Items.Clear();

            // Aggiungi un campo vuoto come primo elemento
            fornitoreComboBox.Items.Add("");

            // Itera attraverso le righe del DataGridView e aggiungi fornitori unici al ComboBox
            foreach (DataRow row in GetDatabaseData().Rows)
            {
                // Assumendo che la colonna con il nome del fornitore si chiami "des_clifor"
                if (row["des_clifor"] != null && row["des_clifor"] != DBNull.Value)
                {
                    string fornitore = row["des_clifor"].ToString();

                    // Verifica se il fornitore è già stato aggiunto
                    if (!uniqueFornitori.Contains(fornitore))
                    {
                        fornitoreComboBox.Items.Add(fornitore);
                        uniqueFornitori.Add(fornitore);
                    }
                }
            }
        }
        /// <summary>
        /// Applica filtri alla vista del DataGridView in base ai parametri specificati.
        /// </summary>
        /// <param name="fornitore">Fornitore da filtrare.</param>
        /// <param name="aperti">Indica se includere gli ordini aperti.</param>
        /// <param name="chiusi">Indica se includere gli ordini chiusi.</param>
        /// <param name="inArrivo">Indica se includere gli ordini in arrivo.</param>
        /// <param name="codiceOrdine">Codice dell'ordine per il filtro.</param>
        public void ApplicaFiltri()
        {
            string fornitore = view.GetFornitoreComboBoxValue();
            string tipo = view.GetTipoComboBox().Text;
            bool aperti = view.GetApertiCheckBoxValue();
            bool inArrivo = view.GetInArrivoCheckBoxValue();
            string codiceOrdine = view.GetCodiceOrdineValue();
            var values = new List<string>();

            if (aperti)
                values.Add("'A'");

            
            if (values.Count == 0)
            {
                //LEttera a caso per non dare nessun risultato
                values.Add("'L'");
            }

            // and so on
            string statoOrdini = string.Join(",", values);

            string filterExpressionStato = $"oct_stat IN ({statoOrdini})";

            string filtroFornitore = !string.IsNullOrEmpty(fornitore)
                ? $"des_clifor = '{fornitore}'"
                : "";
            string filtroTipo = !string.IsNullOrEmpty(tipo)
                ? $"oct_tipo = '{tipo}'"
                : "";
            // Creare una stringa di filtro per la ricerca nella colonna oft_code
            string filtroCodice = string.IsNullOrEmpty(codiceOrdine)
                ? ""
                : $"Convert(oct_code, 'System.String') LIKE '%{codiceOrdine}%'";

            // Aggiungi il filtro per la colonna oft_inarrivo
            

            // Combinare i filtri con AND
            string filterExpression = "";

            List<string> filtri = new List<string> { filterExpressionStato, filtroTipo,filtroFornitore, filtroCodice };
            filtri.RemoveAll(f => string.IsNullOrEmpty(f));

            if (filtri.Any())
            {
                filterExpression = string.Join(" AND ", filtri);
            }

            if (GetDatabaseData() is DataTable dt)
            {
                // Applicare il filtro alla vista della DataGridView
                dt.DefaultView.RowFilter = filterExpression;
            }
        }

        /// <summary>
        /// Imposta i dati dell'ordine nel controller.
        /// </summary>
        /// <param name="octTipo">Tipo dell'ordine.</param>
        /// <param name="octCode">Codice dell'ordine.</param>
        public void SetOrderData(string octTipo, string octCode)
        {
            // Aggiorna la variabile "occCode" con il valore ricevuto
            this.octTipo = octTipo;
            this.octCode = octCode;
        }
        /// <summary>
        /// Ottiene i dati del database dal model.
        /// </summary>
        /// <returns>DataTable contenente i dati del database.</returns>
        public DataTable GetDatabaseData()
        {
            return model.DatabaseData;
        }
        /// <summary>
        /// Gestisce l'evento di caricamento.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        public void OnLoad(object sender, EventArgs e)
        {
            CaricaDati();
            ApplicaFiltri();

        }
        /// <summary>
        /// Gestisce l'evento del pulsante.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        public void FiltroChanged(object sender, EventArgs e)
        {

            // Logica da eseguire quando il pulsante viene premuto
            ApplicaFiltri();
        }
        /// <summary>
        /// Gestisce l'apertura di un nuovo form.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        public void OpenForm(object sender, EventArgs e)
        {
            ResiOrdineModel modelNuovoForm = new ResiOrdineModel();
            modelNuovoForm.octCode = octCode;
            modelNuovoForm.octTipo = octTipo;

            var nuovoForm = new ResiOrdineView();
            ResiOrdineController nuovoFormController = new ResiOrdineController(modelNuovoForm, nuovoForm);
            nuovoForm.AttachController(nuovoFormController);
            nuovoFormController.updateSuccessful += OnLoad;
            nuovoForm.ShowDialog();

            //CaricaDati();

            //ApplicaFiltri();
        }
    }

}
