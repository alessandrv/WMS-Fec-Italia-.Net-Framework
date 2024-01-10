
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
    public partial class FornitoreOrdineView : Form
    {


        private bool[] cellModifiedFlags;  // Array per tenere traccia delle modifiche nelle celle
        private string orderID;
        private string fornitore;
        private string data;
        private string orderType;
        private bool hasIssues;
        private int totalItems;
        private FornitoreOrdineController controller;
        public event EventHandler onLoad;
        public event EventHandler button1Clicked;
        public event EventHandler segnalaProblemaClicked;
        public FornitoreOrdineView()
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
        public void AttachController(FornitoreOrdineController controller)
        {
            this.controller = controller;
        }

        /// <summary>
        /// Gestisce il formato della DataGridView, rimuovendo alcune colonne e impostando le proprietà necessarie.
        /// </summary>
        private void DataGridViewFormat()
        {
            
            dataGridViewOggettiScaffale.Columns.Remove("ofc_desc");
            dataGridViewOggettiScaffale.Columns.Remove("ofc_des2");

            dataGridViewOggettiScaffale.Columns["ofc_qord"].Visible = false;
            dataGridViewOggettiScaffale.Columns["ofc_arti"].HeaderText = "Codice Articolo";
            dataGridViewOggettiScaffale.Columns["ofc_desc1"].HeaderText = "Descrizione";
            dataGridViewOggettiScaffale.Columns["ofc_stato"].HeaderText = "Stato";
            dataGridViewOggettiScaffale.Columns["ofc_qtarrivata"].HeaderText = "Q.ta arrivata";
            dataGridViewOggettiScaffale.Columns["ofc_desc1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;  // La descrizione occuperà tutto il resto della row
            dataGridViewOggettiScaffale.Columns["ofc_stato"].ReadOnly = true;
            dataGridViewOggettiScaffale.Columns["ofc_arti"].ReadOnly = true;
            dataGridViewOggettiScaffale.Columns["ofc_qord"].ReadOnly = true;

            dataGridViewOggettiScaffale.Columns["ofc_dtco"].ReadOnly = true;
            dataGridViewOggettiScaffale.Columns["ofc_dtco"].HeaderText = "Data prevista";

            dataGridViewOggettiScaffale.Columns.Remove("ofc_inarrivo");
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


            DataGridViewCheckBoxColumn inArrivoColumn = new DataGridViewCheckBoxColumn();
            inArrivoColumn.HeaderText = "In arrivo";
            inArrivoColumn.Name = "inArrivoColumn";

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Modificato";
            checkColumn.Name = "checkColumn";



            orderID_label.Text = $"ID ordine: {this.orderID}";
            fornitore_label.Text = $"Fornitore ordine: {this.fornitore}";
            date_label.Text = $"Data ordine: {this.data}";
            dataGridViewOggettiScaffale.Columns.Add(inArrivoColumn);
            dataGridViewOggettiScaffale.Columns.Add(checkColumn);

            dataGridViewOggettiScaffale.Columns["inArrivoColumn"].ReadOnly = true;
            dataGridViewOggettiScaffale.Columns["checkColumn"].ReadOnly = true;
            CheckInArrivoLocale(dataGridViewOggettiScaffale);
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
        /// Gestisce l'evento CellEndEdit della DataGridView, validando e aggiornando lo stato in base alle modifiche.
        /// </summary>
        /// <param name="sender">Oggetto che ha generato l'evento.</param>
        /// <param name="e">Argomenti dell'evento.</param>
        private void dataGridViewOggettiOrdine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOggettiScaffale.Columns["ofc_qtarrivata"].Index)
            {
                // Ottieni il valore modificato dalla cella
                object arrivedValueObject = dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                object expectedValueObject = dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["ofc_qord"].Value;

                if (arrivedValueObject == null || arrivedValueObject == DBNull.Value)
                {
                    dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["ofc_stato"].Value = "Mancante";
                    dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["checkColumn"].Value = false;

                    return;
                }

                if (int.TryParse(arrivedValueObject.ToString(), out int arrivedValueInt) &&
                    int.TryParse(expectedValueObject.ToString(), out int expectedValueInt))
                {
                    if (arrivedValueInt == expectedValueInt)
                    {
                        dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["ofc_stato"].Value = "Arrivato";
                    }
                    else if (arrivedValueInt < expectedValueInt)
                    {
                        dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["ofc_stato"].Value = "Parziale";
                    }
                    else
                    {
                        dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["ofc_stato"].Value = "Extra";

                    }
                }
                else
                {
                    MessageBox.Show("Il valore non è un numero intero valido.", "Errore di validazione");
                    dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = expectedValueObject;  // Reimposta il valore precedente
                }
            }
            dataGridViewOggettiScaffale.Rows[e.RowIndex].Cells["checkColumn"].Value = true;
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
        /// Controlla lo stato "In arrivo" locale nella DataGridView e lo imposta di conseguenza.
        /// </summary>
        /// <param name="dataGridView">DataGridView da controllare.</param>
        /// <returns>True se tutti gli oggetti sono in arrivo, altrimenti false.</returns>
        private bool CheckInArrivoLocale(DataGridView dataGridView)
        {

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string inArrivo = row.Cells["ofc_inarrivo"].Value.ToString();

                if (inArrivo == "S")
                {
                    row.Cells["inArrivoColumn"].Value = true;

                }

            }
            return true;


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
