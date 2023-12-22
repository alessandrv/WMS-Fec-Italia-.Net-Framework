using System;
using System.Data;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public partial class OggettiScaffaleView : Form
    {
        public event EventHandler buttonClick;
        public event EventHandler onLoad;
        private OggettiScaffaleController controller;
        public OggettiScaffaleView()
        {
            InitializeComponent();

        }

        public void AttachController(OggettiScaffaleController controller)
        {
            this.controller = controller;
        }
        public DataGridView GetDataGridView()
        {
            return dataGridViewOggettiScaffale;
        }

        public void DataGridViewFormat()
        {
            dataGridViewOggettiScaffale.Columns["id_pacco"].HeaderText = "ID";
            dataGridViewOggettiScaffale.Columns["id_art"].HeaderText = "Codice articolo";
            dataGridViewOggettiScaffale.Columns["id_mov"].HeaderText = "Movimento";
            dataGridViewOggettiScaffale.Columns["fornitore"].HeaderText = "Fornitore";
            dataGridViewOggettiScaffale.Columns["dimensione"].HeaderText = "Dimensione";
            dataGridViewOggettiScaffale.Columns["amg_desc"].HeaderText = "Descrizione";
            dataGridViewOggettiScaffale.Columns["qta"].HeaderText = "Qta";
            dataGridViewOggettiScaffale.Columns["locat"].HeaderText = "Locazione";
            dataGridViewOggettiScaffale.Columns["amg_desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewOggettiScaffale.ClearSelection();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            onLoad?.Invoke(this, EventArgs.Empty);
        }


        public void DisplayMessageBox(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            buttonClick?.Invoke(this, EventArgs.Empty);
        }

        public string GetSelectedRowColumnValue(string columnName)
        {
            // Verifica se almeno una riga è selezionata
            if (dataGridViewOggettiScaffale.SelectedRows.Count > 0)
            {
                // Ottieni il valore della colonna specificata per la riga selezionata
                return dataGridViewOggettiScaffale.SelectedRows[0].Cells[columnName].Value.ToString();
            }
            return string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOggettiOrdine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Verifica se l'evento è stato generato dalla colonna delle checkbox
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewOggettiScaffale.Columns["Seleziona"].Index)
            {
                // Inverti lo stato della checkbox nella cella cliccata
                dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["Seleziona"].Value =
                    !(bool)dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["Seleziona"].Value;
            }
        }

        internal void SetScaffaleLabel(string area, string scaffale, string colonna, string piano)
        {
            scaffaleLabel.Text = $"{area}-{scaffale}-{colonna}-{piano}";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
