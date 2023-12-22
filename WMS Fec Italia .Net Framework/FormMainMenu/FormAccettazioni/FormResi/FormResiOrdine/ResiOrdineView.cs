
using System.Data.Odbc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public partial class ResiOrdineView : Form
    {


        private bool[] cellModifiedFlags;  // Array per tenere traccia delle modifiche nelle celle
        private string orderID;
        private string fornitore;
        private string data;
        private string orderType;
        private bool hasIssues;
        private int totalItems;
        private ResiOrdineController controller;
        public event EventHandler onLoad;
        public event EventHandler button1Clicked;
        public event EventHandler segnalaProblemaClicked;
        public ResiOrdineView()
        {
            InitializeComponent();
            this.orderID = orderID;
            this.orderType = orderType;

        }
        public void DisplayMessageBox(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }
        public void AttachController(ResiOrdineController controller)
        {
            this.controller = controller;
        }

        /// <summary>
        /// Gestisce il formato della DataGridView, rimuovendo alcune colonne e impostando le proprietà necessarie.
        /// </summary>
        private void DataGridViewFormat()
        {
            dataGridViewOggettiScaffale.Columns.Remove("occ_tipo");
            dataGridViewOggettiScaffale.Columns.Remove("occ_code");
             dataGridViewOggettiScaffale.Columns.Remove("occ_desc");
            dataGridViewOggettiScaffale.Columns.Remove("occ_des2");
            dataGridViewOggettiScaffale.Columns.Remove("occ_riga");
            dataGridViewOggettiScaffale.Columns["occ_arti"].HeaderText = "Codice Articolo";
            dataGridViewOggettiScaffale.Columns["occ_desc1"].HeaderText = "Descrizione";
            dataGridViewOggettiScaffale.Columns["occ_qmov"].HeaderText = "Qta";

            dataGridViewOggettiScaffale.Columns["occ_desc1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;  // La descrizione occuperà tutto il resto della row
            dataGridViewOggettiScaffale.Columns["occ_arti"].ReadOnly = true;
            dataGridViewOggettiScaffale.Columns["occ_qmov"].ReadOnly = true;
            dataGridViewOggettiScaffale.ClearSelection();
        }

        /// <summary>
        /// Gestisce l'evento Load del form, popolando la DataGridView con i dati dal controller e formattandola.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        private void Form4_Load(object sender, EventArgs e)
        {
            onLoad?.Invoke(this, EventArgs.Empty);

            DataGridViewFormat();

            // Inizializza l'array di flag per le modifiche
            cellModifiedFlags = new bool[dataGridViewOggettiScaffale.Rows.Count];
        }

        /// <summary>
        /// Gestisce l'evento EditingControlShowing della DataGridView, aggiungendo un gestore di eventi per l'evento KeyPress.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>

        private void dataGridViewOggettiOrdine_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox textBox)
            {
                // Aggiungi il gestore di eventi per l'evento KeyPress
                textBox.KeyPress += TextBox_KeyPress;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Consentire solo i numeri (0-9) e il tasto Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Impedisci l'inserimento del carattere
                e.Handled = true;
            }
        }

        /// <summary>
        /// Restituisce la DataGridView.
        /// </summary>
        /// <returns>Oggetto DataGridView associato alla vista.</returns>
        public DataGridView GetDataGridView()
        {
            return dataGridViewOggettiScaffale; // Sostituisci "textBox1" con il nome effettivo della tua casella di testo
        }

        

        /// <summary>
        /// Gestisce l'evento Click del pulsante button1, confermando le modifiche tramite l'invocazione di un evento.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vuoi confermare le modifiche a quest'ordine?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button1Clicked?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Restituisce la cella selezionata in base al nome della colonna.
        /// </summary>
        /// <param name="columnName">Nome della colonna.</param>
        /// <returns>Oggetto DataGridViewCell corrispondente alla cella selezionata.</returns>
        private DataGridViewCell GetSelectedRowColumn(string columnName)
        {
            // Verifica se almeno una riga è selezionata
            if (dataGridViewOggettiScaffale.SelectedRows.Count > 0)
            {
                // Ottieni il valore della colonna specificata per la riga selezionata
                return dataGridViewOggettiScaffale.SelectedRows[0].Cells[columnName];
            }

            return null;
        }

        /// <summary>
        /// Segnala lo stato "In arrivo" locale in base alla cella selezionata e allo stato specificato.
        /// </summary>
        /// <param name="selectedCell">Cella selezionata.</param>
        /// <param name="staArrivando">Indica se l'oggetto è in arrivo.</param>
        private void SegnalaStatoInArrivoLocale(DataGridViewCell selectedCell, bool staArrivando)
        {
            string value;
            selectedCell.Value = staArrivando;
            if (staArrivando)
            {
                value = "S";
            }
            else
            {
                value = "N";
            }

        }


        /// <summary>
        /// Gestisce l'evento Click del pulsante button2, chiudendo il form.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            segnalaProblemaClicked?.Invoke(this, EventArgs.Empty);
        }
    }



}
