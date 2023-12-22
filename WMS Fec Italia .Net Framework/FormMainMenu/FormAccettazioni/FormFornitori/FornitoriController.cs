using System.Collections.Generic;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;


namespace WMS_Fec_Italia_MVC
{
    public class FornitoriController
    {
        private readonly FornitoriModel model;
        private readonly FornitoriView view;
        private string oftCode;
        private string oftTipo;

        public FornitoriController(FornitoriModel model, FornitoriView view)
        {
            this.model = model;
            this.view = view;
            this.view.aggiornaButtonClicked += OnLoad;
            this.view.openForm += OpenForm;
            this.view.onLoad += OnLoad;
            this.view.filtroChanged += FiltroChanged;
            this.view.changeOrderData += ChangeOrderData;
            view.AttachController(this);
        }

        private void ChangeOrderData(object sender, EventArgs e)
        {
            SetOrderData(view.oftTipo, view.oftCode);
        }

        public void CaricaDati()
        {
            try
            {
                model.LoadTable();
                CaricaFornitoriDalDataGridView();

                view.GetDataGridView().DataSource = GetDatabaseData();
                view.PopolaDataGridView();

                ApplicaFiltri();
                view.SvuotaSelezioneDataGridView();
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
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
            bool aperti = view.GetApertiCheckBoxValue();
            bool chiusi = view.GetChiusiCheckBoxValue();
            bool inArrivo = view.GetInArrivoCheckBoxValue();
            string codiceOrdine = view.GetCodiceOrdineValue();
            var values = new List<string>();

            if (aperti)
                values.Add("'A'");

            if (chiusi)
                values.Add("'C'");

            if (values.Count == 0)
            {
                values.Add("'L'");
            }

            // and so on
            string statoOrdini = string.Join(",", values);

            string filterExpressionStato = $"oft_stat IN ({statoOrdini})";

            string filtroFornitore = !string.IsNullOrEmpty(fornitore)
                ? $"des_clifor = '{fornitore}'"
                : "";

            // Creare una stringa di filtro per la ricerca nella colonna oft_code
            string filtroCodice = string.IsNullOrEmpty(codiceOrdine)
                ? ""
                : $"Convert(oft_code, 'System.String') LIKE '%{codiceOrdine}%'";

            // Aggiungi il filtro per la colonna oft_inarrivo
            string filtroInArrivo = inArrivo
                ? "oft_inarrivo = 'S'"
                : "";

            // Combinare i filtri con AND
            string filterExpression = "";

            List<string> filtri = new List<string> { filterExpressionStato, filtroFornitore, filtroCodice, filtroInArrivo };
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
        /// <param name="oftTipo">Tipo dell'ordine.</param>
        /// <param name="oftCode">Codice dell'ordine.</param>
        public void SetOrderData(string oftTipo, string oftCode)
        {
            // Aggiorna la variabile "occCode" con il valore ricevuto
            this.oftTipo = oftTipo;
            this.oftCode = oftCode;
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
          FornitoreOrdineModel modelNuovoForm = new FornitoreOrdineModel();
            modelNuovoForm.ofcCode = oftCode;
            modelNuovoForm.ofcTipo = oftTipo;

            var nuovoForm = new FornitoreOrdineView();
            FornitoriOrdineController nuovoFormController = new FornitoriOrdineController(modelNuovoForm, nuovoForm);
            nuovoForm.AttachController(nuovoFormController);

            nuovoForm.ShowDialog();

            CaricaDati();

            ApplicaFiltri();
        }
    }

}