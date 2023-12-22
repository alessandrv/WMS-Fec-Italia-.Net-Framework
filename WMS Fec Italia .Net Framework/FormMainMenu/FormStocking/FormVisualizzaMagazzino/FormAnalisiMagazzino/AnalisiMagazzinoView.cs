using System;
using System.Data;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public partial class AnalisiMagazzinoView : Form
    {

        private DataTable globalDatabaseData;
        private DataTable totalItemsDatabaseData;
        private AnalisiMagazzinoController controller;
        public event EventHandler onCambioFiltro;
        public event EventHandler onLoad;
        public event EventHandler onCellClick;
        public event EventHandler onButtonClick;


        public AnalisiMagazzinoView()
        {
            InitializeComponent();
        }

        public void AttachController(AnalisiMagazzinoController controller)
        {
            this.controller = controller;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            onLoad?.Invoke(this, EventArgs.Empty);
            //aggiornaLista();

            dataGridViewListaArticoli.ClearSelection();
            //dataGridViewListaArticoli.SelectionChanged += this.dataGridViewListaArticoli_SelectionChanged;

        }
        public DataGridView GetDataGridViewListaArticoli()
        {
            return dataGridViewListaArticoli;
        }
        public DataGridView GetDataGridViewLocazioniArticolo()
        {
            return dataGridViewLocazioniArticolo;
        }
        public string GetSelectedIdArticolo()
        {
            return GetSelectedRowColumnValue(dataGridViewListaArticoli, "id_art");
           
        }
        public string GetSelectedFornitore()
        {
            return GetSelectedRowColumnValue(dataGridViewListaArticoli, "fornitore");
        }
        public string GetSelectedArea()
        {
            return GetSelectedRowColumnValue(dataGridViewLocazioniArticolo, "area");
        }
        public string GetSelectedScaffale()
        {
            return GetSelectedRowColumnValue(dataGridViewLocazioniArticolo, "scaffale");
        }
        public string GetSelectedColonna()
        {
            return GetSelectedRowColumnValue(dataGridViewLocazioniArticolo, "colonna");
        }
        public string GetSelectedPiano()
        {
            return GetSelectedRowColumnValue(dataGridViewLocazioniArticolo, "piano");
        }
        public TextBox GetArticoloTextBox()
        {
            return articoloTextBox;
        }
        public TextBox GetFornitoreTextBox()
        {
            return fornitoreTextBox;
        }
        private void button1_Click_4(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            onButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void cambioFiltri(object s, EventArgs e)
        {
            onCambioFiltro?.Invoke(this, EventArgs.Empty);
            dataGridViewLocazioniArticolo.DataSource = null;
        }

       

        private string GetSelectedRowColumnValue(DataGridView dataGridView, string columnName)
        {
            // Verifica se almeno una riga è selezionata
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Ottieni il valore della colonna specificata per la riga selezionata
                return dataGridView.SelectedRows[0].Cells[columnName].Value.ToString();
            }
            return string.Empty;
        }

      
        public void FormatListaDataGridView()
        {
           // dataGridViewListaArticoli.ClearSelection();
            dataGridViewListaArticoli.Columns["id_art"].HeaderText = "Codice articolo";
            dataGridViewListaArticoli.Columns["fornitore"].HeaderText = "Codice fornitore";
            dataGridViewListaArticoli.Columns["qta_totale"].HeaderText = "Qta totale";

        }

        public void FormatLocazioniDataGridView()
        {
            dataGridViewLocazioniArticolo.Columns["id_pacco"].HeaderText = "ID";
            dataGridViewLocazioniArticolo.Columns["id_art"].Visible = false;
            dataGridViewLocazioniArticolo.Columns["id_mov"].HeaderText = "Movimento";
            dataGridViewLocazioniArticolo.Columns["fornitore"].Visible = false;
            dataGridViewLocazioniArticolo.Columns["area"].HeaderText = "Area";
            dataGridViewLocazioniArticolo.Columns["scaffale"].HeaderText = "Scaffale";
            dataGridViewLocazioniArticolo.Columns["colonna"].HeaderText = "Colonna";
            dataGridViewLocazioniArticolo.Columns["piano"].HeaderText = "Piano";
            dataGridViewLocazioniArticolo.Columns["qta"].HeaderText = "Qta";
            dataGridViewLocazioniArticolo.Columns["dimensione"].HeaderText = "Dimensione";

        }

        public void aggiornaLista()
        {
      
            //dataGridViewListaArticoli.SelectionChanged -= this.dataGridViewListaArticoli_SelectionChanged;

            onLoad?.Invoke(controller, EventArgs.Empty);
            dataGridViewListaArticoli.ClearSelection();
            articoloTextBox.Clear();
            fornitoreTextBox.Clear();
            //dataGridViewListaArticoli.SelectionChanged += this.dataGridViewListaArticoli_SelectionChanged;

            dataGridViewLocazioniArticolo.DataSource = null;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            aggiornaLista();
            MessageBox.Show("Lista merce aggiornata", "Ordini");
        }


       

        private void dataGridViewListaArticoli_SelectionChanged(object sender, EventArgs e)
        {

        }

        public void DisplayMessageBox(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewListaArticoli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            onCellClick?.Invoke(this, EventArgs.Empty);
        }
    }

}

