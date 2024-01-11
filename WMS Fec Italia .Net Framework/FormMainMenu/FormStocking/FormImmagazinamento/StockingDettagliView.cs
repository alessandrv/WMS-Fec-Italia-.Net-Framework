using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.VisualStyles;

namespace WMS_Fec_Italia_MVC
{
    public partial class StockingDettagliView : Form
    {
        public event EventHandler scanArticolo;
        public event EventHandler scanFornitore;
        public event EventHandler scanMovimento;
        public event EventHandler buttonClick;

        private StockingDettagliController controller;

        public StockingDettagliView()
        {
            InitializeComponent();
            articoloCodeTextBox.Focus();

            // Aggiungi i tuoi "radio button" labels al gestore


        }
        private void ClearAllTextBoxes(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control.HasChildren)
                {
                    // Ricorsivamente chiama la funzione per tutti i controlli figli
                    ClearAllTextBoxes(control);
                }
            }
        }
        public void AttachController(StockingDettagliController controller)
        {
            this.controller = controller;
        }
        public TextBox GetArticoloTextBox()
        {
            return articoloCodeTextBox;
        }
        public TextBox GetFornitoreTextBox()
        {
            return fornitoreCode;
        }
        public TextBox GetMovimentoTextBox()
        {
            return movimentoTextBox;
        }
        public ComboBox GetDimensioniComboBox()
        {
            return dimensioneComboBox;
        }
        public TextBox GetQuantitaPerPacco()
        {
            return quantitaPerPaccoTextBox;
        }
        public NumericUpDown GetNumeroPacchi()
        {
            return numeroPacchiNumBox;
        }

        public void SetDescrizioneArticolo(string descrizioneArticolo)
        {
            descrizioneTextBox.Text = descrizioneArticolo;
        }
        public void SetRagioneSocialeFornitore(string ragioneSociale)
        {
            ragioneSocialTextBox.Text = ragioneSociale;
        }

        private void aritcoloCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chiamare la funzione o eseguire il codice desiderato quando viene premuto "Invio"
                try
                {
                    scanArticolo?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Sopprimi il tasto
                e.SuppressKeyPress = true;
            }
        }
        private void fornitoreCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chiamare la funzione o eseguire il codice desiderato quando viene premuto "Invio"
                try
                {
                    scanFornitore?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Impedire il beep di sistema associato a premere "Invio"
                e.SuppressKeyPress = true;
            }
        }
        private void movimentoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chiamare la funzione o eseguire il codice desiderato quando viene premuto "Invio"
                try
                {
                    scanMovimento?.Invoke(this, EventArgs.Empty);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Impedire il beep di sistema associato a premere "Invio"
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            buttonClick?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(this);
            articoloCodeTextBox.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            articoloCodeTextBox.Clear();
            descrizioneTextBox.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fornitoreCode.Clear();
            ragioneSocialTextBox.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            movimentoTextBox.Clear();
        }
    }
}
