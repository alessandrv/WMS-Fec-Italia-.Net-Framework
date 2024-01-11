using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Linq;


namespace WMS_Fec_Italia_MVC
{
    public partial class PickingView : Form
    {
        private Dictionary<string, int> locatCounts;
        private PickingController controller;
        public event EventHandler onSearchButton;
        public event EventHandler onArticoloSearch;
        public event EventHandler onArticoloScannerizzato;
        public event EventHandler salvaStatoPicking;
        public event EventHandler effettuaPicking;


        private string orderID;
        public PickingView()
        {
            InitializeComponent();
           // this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impedisce il ridimensionamento
          //  this.WindowState = FormWindowState.Maximized;

        }
        //Forzo la dimensione della finesta: IL tablet prova a ridimensionarla. Windows forms non è ottimizzato e quindi il cambio di dimensioni degli elementi causa lag.
        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Minimized)
            {
            //    this.WindowState = FormWindowState.Maximized;
            }
        }

        public void AttachController(PickingController controller)
        {
            this.controller = controller;
        }


        public TextBox GetCodiceOrdineTextBox()
        {
            return ordineTextBox;
        }
        public ComboBox GetTipoOrdineTextBox()
        {
            return tipoComboBox;
        }
        public DataGridView GetDataGridView()
        {
            return dataGridViewTotale;
        }
        public NumericUpDown GetNumericUpDown()
        {
            return numericUpDown1;
        }
        public TextBox GetArticoloSearchTextBox()
        {
            return articoloSearchTextBox;
        }
        public TextBox GetLocazioneScannerizzataTextBox()
        {
            return scaffaleTextBox;
        }
        public void SetProgressBarStyle(ProgressBarStyle progressBarStyle)
        {
            toolStripProgressBar1.Style = progressBarStyle;
        }
        private void searchButton_Click_1(object sender, EventArgs e)
        {
            if (ordineTextBox.Text != "")
            {
                onSearchButton?.Invoke(this, EventArgs.Empty);
                scaffaleTextBox.Focus();
            }



        }



        public void TrovaEColoraLocazione(DataGridViewRow row)
        {
            if (row.Cells["locat"].Value.ToString().Equals("MANCANTE"))
            {
                row.DefaultCellStyle.BackColor = Color.Red; // Puoi sostituire con il colore desiderato
            }

            else if (row.DefaultCellStyle.BackColor != Color.LawnGreen)
            {
                string nomeLabel = row.Cells["locat"].Value.ToString().Replace("-", "");
                ;

                // Cerca il controllo Label nel form utilizzando il nome
                Label labelDaCambiare = Controls.Find(nomeLabel, true).FirstOrDefault() as Label;


                // Verifica se il controllo è stato trovato
                if (labelDaCambiare != null)
                {

                    // Imposta il colore di sfondo del Label
                    labelDaCambiare.BackColor = Color.Yellow; // Sostituisci con il colore desiderato
                }
                else
                {
                    // Il Label con il nome specificato non è stato trovato
                    MessageBox.Show("Label non trovato: " + nomeLabel);
                }
            }
        }










        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ordineTextBox.Text != "")
                {
                    onSearchButton?.Invoke(this, EventArgs.Empty);
                    scaffaleTextBox.Focus();

                }



            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridViewTotale_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewTotale.ClearSelection();
        }

        private void ConfermaPickingButtonClick(object sender, EventArgs e)
        {
            //invoko crea ordine picking


            if (button3.Text == "Conferma picking")
            {
                //salvaStatoPicking?.Invoke(this, EventArgs.Empty);
                //invoka effetuapicking
                effettuaPicking?.Invoke(this, EventArgs.Empty);
               
                
            }
            else
            {
                //if (MessageBox.Show("Vuoi salvare il picking parziale?\n ATTENZIONE: Questa operazione salva solamente gli articoli scannerizzati, la merce non verrà scaricata dal magazzino finchè non verrà effettuato il picking totale.", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                
                //    salvaStatoPicking?.Invoke(this, EventArgs.Empty);

                    MessageBox.Show("Scannerizza tutti gli articoli per scaricare gli articoli dal magazzino.");
                
            }
        }


        private bool segnaPrelevato()
        {
            string codiceArticolo = articoloTextBox.Text;
            string codiceMovimento = movimentoTextBox.Text;
            string locazione = scaffaleTextBox.Text;
            bool successo = false;
            foreach (DataGridViewRow row in dataGridViewTotale.Rows)
            {
            
                // Controlla le condizioni specificate
                if (row.Cells["codice_art"].Value.ToString().Trim() == codiceArticolo &&
                    row.Cells["movimento"].Value.ToString().Trim() == codiceMovimento &&
                    row.Cells["locat"].Value.ToString().Trim() == locazione)
                {

                    row.DefaultCellStyle.BackColor = Color.LawnGreen;

                    onArticoloScannerizzato?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(
                        $"Articolo {codiceArticolo} nello scaffale {locazione} con movimento {codiceMovimento} prelevato.");
                    return true;
                }
            }


            return false;

        }

        private void ControllaStatoPicking()
        {
            bool pickingCompleto = true;
            foreach (DataGridViewRow row in dataGridViewTotale.Rows)
            {
                if (row.DefaultCellStyle.BackColor != Color.LawnGreen)
                {
                    pickingCompleto = false;

                    break;
                }
            }
            if (pickingCompleto)
            {
                button3.Text = "Conferma picking";
            }
        }
        private void movimentoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chiamare la funzione o eseguire il codice desiderato quando viene premuto "Invio"
                try
                {
                    if (!segnaPrelevato())
                    {
                        MessageBox.Show("Oggetto non presente nella lista di prelievo");

                    }
                    else
                    {
                        ControllaStatoPicking();
                        PulisciCampiButton(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Impedire il beep di sistema associato a premere "Invio"
                e.SuppressKeyPress = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            onArticoloSearch?.Invoke(this, EventArgs.Empty);
            scaffaleTextBox.Focus();
        }

        public void PulisciLocazioni(Dictionary<string, int> locatCounts)
        {
            foreach (KeyValuePair<string, int> coppia in locatCounts)
            {
                string chiave = coppia.Key;
                Label labelDaCambiare = Controls.Find(chiave, true).FirstOrDefault() as Label;

                // Verifica se il controllo è stato trovato
                if (labelDaCambiare != null)
                {
                    // Imposta il colore di sfondo del Label
                    labelDaCambiare.BackColor = Color.White; // Sostituisci con il colore desiderato
                }

            }

            locatCounts.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Essendo l'ultima zona del magazzino per ora, lo facciamo tornare all'index iniziale
            tabControlWithoutHeader1.SelectedIndex = 1;
        }

        private void ForwardButton(object sender, EventArgs e)
        {
            if (tabControlWithoutHeader1.SelectedIndex != tabControlWithoutHeader1.TabCount - 1)
            {
                tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex + 1;
            }
        }
        private void BackButton(object sender, EventArgs e)
        {
            if (tabControlWithoutHeader1.SelectedIndex != 0)
            {
                tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex - 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //questo porterà all'ultimo index, avendo gia inserito il terzo ci porta in uno vuoto quindi andiamo invece solamente all'ultimo configurato: il secondo

            //tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.TabPages.Count;
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex + 1;

        }

        private void ordineTextBox_Enter(object sender, EventArgs e)
        {

        }

        private void PulisciCampiButton(object sender, EventArgs e)
        {
            scaffaleTextBox.Clear();
            movimentoTextBox.Clear();
            articoloTextBox.Clear();
            scaffaleTextBox.Focus();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Close();

        }

        public void DisplayMessageBox(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }

        private void scaffaleTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                // Chiamare la funzione o eseguire il codice desiderato quando viene premuto "Invio"

                articoloTextBox.Focus();

                // Sopprimi il tasto
                e.SuppressKeyPress = true;
            }

        }

        private void articoloTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chiamare la funzione o eseguire il codice desiderato quando viene premuto "Invio"

                movimentoTextBox.Focus();

                // Sopprimi il tasto
                e.SuppressKeyPress = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void scaffaleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cambio ' con-
            if (e.KeyChar == '\'')
                {
                    e.KeyChar = '-';
                
                }
            
        }
    }



}

