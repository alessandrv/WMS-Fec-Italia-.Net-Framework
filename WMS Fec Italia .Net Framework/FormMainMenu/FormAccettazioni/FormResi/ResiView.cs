using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;

using System.Data.Odbc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System;

namespace WMS_Fec_Italia_MVC
{
    public partial class ResiView : Form
    {
        public event EventHandler aggiornaButtonClicked;
        public event EventHandler onLoad;
        public event EventHandler filtroChanged;
        public event EventHandler openForm;



        private ResiController controller;
        public ResiView()
        {
            InitializeComponent();  // Assicurati che questa chiamata sia presente
        }

        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }

        public void AttachController(ResiController controller)
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
        public System.Windows.Forms.ComboBox GetTipoComboBox()
        {
            return tipoComboBox; // Sostituisci "textBox1" con il nome effettivo della tua casella di testo
        }


        public void PopolaDataGridView()
        {
            dataGridViewOrdiniDaConfermare.DataSource = controller.GetDatabaseData();
            dataGridViewOrdiniDaConfermare.Columns["oct_tipo"].HeaderText = "Tipo";
            dataGridViewOrdiniDaConfermare.Columns["oct_code"].HeaderText = "Codice ordine";
            dataGridViewOrdiniDaConfermare.Columns["oct_stat"].HeaderText = "Stato";
            dataGridViewOrdiniDaConfermare.Columns["oct_data"].HeaderText = "Data";
            dataGridViewOrdiniDaConfermare.Columns["oct_cocl"].HeaderText = "Codice cliente";
            dataGridViewOrdiniDaConfermare.Columns["oct_toco"].HeaderText = "Categoria";
            dataGridViewOrdiniDaConfermare.Columns["oct_rifc"].HeaderText = "Riferimento";
            //dataGridViewOrdiniDaConfermare.Columns["oct_actz"].HeaderText = "Data accettazione";

            dataGridViewOrdiniDaConfermare.Columns["des_clifor"].HeaderText = "Ragione sociale";
            //dataGridViewOrdiniDaConfermare.Columns["oft_inarrivo"].HeaderText = "In arrivo?";
            //ataGridViewOrdiniDaConfermare.Columns["date"].HeaderText = "Data arr.";

            dataGridViewOrdiniDaConfermare.Columns["des_clifor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;  // La descrizione occuperà tutto il resto della row
            //dataGridViewOrdiniDaConfermare.Sort(dataGridViewOrdiniDaConfermare.Columns["date"], ListSortDirection.Descending);
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
            aggiornaButtonClicked?.Invoke(this, EventArgs.Empty);
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


        private void dataGridViewOrdiniDaConfermare_SelectionChanged(object sender, EventArgs e)
        {
            // Assicurati che sia selezionata almeno una riga
            if (dataGridViewOrdiniDaConfermare.SelectedRows.Count > 0)
            {
                // Ottieni il valore della colonna "occ_code" della riga selezionata
                string oftCode = dataGridViewOrdiniDaConfermare.SelectedRows[0].Cells["oct_code"].Value.ToString();
                string oftTipo = dataGridViewOrdiniDaConfermare.SelectedRows[0].Cells["oct_tipo"].Value.ToString();
                // Chiama il metodo del controller per aggiornare la variabile "occ_code"
                controller.SetOrderData(oftTipo, oftCode);
            }
        }
        private void RevisionaOrdineButton_Click(object sender, EventArgs e)
        {
            openForm?.Invoke(this, EventArgs.Empty);
        }
        private void dataGridViewOrdiniDaConfermare_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Assicurati che l'indice della riga sia valido
          
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



