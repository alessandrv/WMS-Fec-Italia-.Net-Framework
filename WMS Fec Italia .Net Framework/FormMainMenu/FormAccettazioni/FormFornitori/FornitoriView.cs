using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WMS_Fec_Italia_MVC
{
    public partial class FornitoriView : Form
    {
        public event EventHandler aggiornaButtonClicked;
        public event EventHandler onLoad;
        public event EventHandler filtroChanged;
        public event EventHandler openForm;
        public event EventHandler changeOrderData;
        public string oftTipo {  get; set; }
        public string oftCode { get; set; }

        private FornitoriController controller;
        public FornitoriView()
        {
            InitializeComponent();  // Assicurati che questa chiamata sia presente
        }

        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }

        public void AttachController(FornitoriController controller)
        {
            this.controller = controller;
        }


        public string GetFornitoreComboBoxValue()
        {
            return fornitoreComboBox.Text; // Sostituisci "textBox1" con il nome effettivo della tua casella di testo
        }
        public string GetCodiceOrdineValue()
        {
            return codiceOrdineTextBox.Text; // Sostituisci "textBox1" con il nome effettivo della tua casella di testo
        }
        public bool GetApertiCheckBoxValue()
        {
            return aperti_checkbox.Checked; // Sostituisci "textBox1" con il nome effettivo della tua casella di testo
        }
      
        public bool GetInArrivoCheckBoxValue()
        {
            return inArrivo_checkbox.Checked; // Sostituisci "textBox1" con il nome effettivo della tua casella di testo
        }
        public System.Windows.Forms.ComboBox GetFornitoreComboBoxItem()
        {
            return fornitoreComboBox; // Sostituisci "textBox1" con il nome effettivo della tua casella di testo
        }

        public DataGridView GetDataGridView()
        {
            return dataGridViewOrdiniDaConfermare;
        }
        public void PopolaDataGridView()
        {

            dataGridViewOrdiniDaConfermare.Columns["oft_tipo"].HeaderText = "Tipo";
            dataGridViewOrdiniDaConfermare.Columns["oft_inarrivo"].HeaderText = "In arrivo?";
            dataGridViewOrdiniDaConfermare.Columns["oft_code"].HeaderText = "Codice ordine";
            dataGridViewOrdiniDaConfermare.Columns["oft_stat"].HeaderText = "Stato";
            dataGridViewOrdiniDaConfermare.Columns["oft_data"].HeaderText = "Data ordine";
            dataGridViewOrdiniDaConfermare.Columns["oft_cofo"].HeaderText = "Codice fornitore";
            dataGridViewOrdiniDaConfermare.Columns["des_clifor"].HeaderText = "Ragione sociale";
           // dataGridViewOrdiniDaConfermare.Columns["oft_inarrivo"].HeaderText = "In arrivo?";
            //ataGridViewOrdiniDaConfermare.Columns["date"].HeaderText = "Data arr.";

            dataGridViewOrdiniDaConfermare.Columns["des_clifor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;  // La descrizione occuperà tutto il resto della row
          //  dataGridViewOrdiniDaConfermare.Sort(dataGridViewOrdiniDaConfermare.Columns["oft_inarrivo"], ListSortDirection.Descending);
            // Altri aggiustamenti della vista, se necessario
        }



        public void ApplicaFiltri()
        {
            //  controller.ApplicaFiltri();
        }

        public void SvuotaSelezioneDataGridView()
        {
            dataGridViewOrdiniDaConfermare.ClearSelection();
        }

        private void aggiorna_button_Click(object sender, EventArgs e)
        {

        }

        private void FormAccettazione_Load(object sender, EventArgs e)
        {
            onLoad?.Invoke(this, EventArgs.Empty);
        }



        private void FiltroChanged(object sender, EventArgs e)
        {

            filtroChanged?.Invoke(this, EventArgs.Empty);
            PopolaDataGridView();
            SvuotaSelezioneDataGridView();

        }

        private void dataGridViewOrdiniDaConfermare_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Assicurati che l'indice della riga sia valido
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewOrdiniDaConfermare.Rows.Count)
            {
                DataGridViewRow row = dataGridViewOrdiniDaConfermare.Rows[e.RowIndex];

                // Nome della colonna da controllare (sostituisci con il nome effettivo della tua colonna)
                string columnName = "oft_inarrivo";

                // Verifica se il valore nella colonna specificata è 'S'
                if (row.Cells[columnName].Value != null && row.Cells[columnName].Value.ToString() == "S")
                {
                    // Applica uno stile specifico alla riga
                    row.DefaultCellStyle.BackColor = Color.Yellow; // Puoi sostituire con il colore desiderato
                }
                else
                {
                    // Ripristina lo stile predefinito
                    row.DefaultCellStyle.BackColor = dataGridViewOrdiniDaConfermare.DefaultCellStyle.BackColor;
                }
            }
        }
        private void dataGridViewOrdiniDaConfermare_SelectionChanged(object sender, EventArgs e)
        {
            // Assicurati che sia selezionata almeno una riga
            if (dataGridViewOrdiniDaConfermare.SelectedRows.Count > 0)
            {
                // Ottieni il valore della colonna "occ_code" della riga selezionata
                oftCode = dataGridViewOrdiniDaConfermare.SelectedRows[0].Cells["oft_code"].Value.ToString();
                oftTipo = dataGridViewOrdiniDaConfermare.SelectedRows[0].Cells["oft_tipo"].Value.ToString();
                // Chiama il metodo del controller per aggiornare la variabile "occ_code"
                changeOrderData?.Invoke(this, EventArgs.Empty);
                
            }
        }
        private void RevisionaOrdineButton_Click(object sender, EventArgs e)
        {
            openForm?.Invoke(this, EventArgs.Empty);
        }
      



        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            aggiornaButtonClicked?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("Aggiornamento lista ordini completato");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

}