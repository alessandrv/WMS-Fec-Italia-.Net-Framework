
using System;
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
    public partial class TrasferimentiMagazzinoView : Form
    {
        private HashSet<string> storageLocations;
        private int volumeTotale;
        private Label ultimoLabelSelezionato = null;
        private string codiceArticolo;
        private string codiceFornitore;
        private string codiceMovimento;
        private int qtaDaDepositare;
        private int numPacchi;
        private string dimensione;
        private TrasferimentiMagazzinoController controller;
        public event EventHandler onLoad;
        public event EventHandler onButtonClick;


        public TrasferimentiMagazzinoView()
        {
            InitializeComponent();
        }
        public void AttachController(TrasferimentiMagazzinoController controller)
        {
            this.controller = controller;
        }

        public TextBox GetScaffaleSelezionatoTextBox()
        {
            return scaffaleSelezionatoTextBox;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Chiamare la funzione o eseguire il codice desiderato quando viene premuto "Invio"
                try
                {

                    string area = scaffaleSelezionatoTextBox.Text.Substring(0, 1);
                    string scaffale = scaffaleSelezionatoTextBox.Text.Substring(1, 1);
                    string colonna = scaffaleSelezionatoTextBox.Text.Substring(2, 2);
                    string piano = scaffaleSelezionatoTextBox.Text.Substring(4, 1);
                    if (MessageBox.Show($"Confermi la collocazione della merce in posizione {area}-{scaffale}-{colonna}-{piano}?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        onButtonClick?.Invoke(this, EventArgs.Empty);

                    }
                    else
                    {
                        scaffaleSelezionatoTextBox.Clear();

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

        private void Form6_Load(object sender, EventArgs e)
        {
            // Crea un'istanza della classe Database
            //analyizeSpace();
            onLoad?.Invoke(this, EventArgs.Empty);
            scaffaleSelezionatoTextBox.Focus();

        }


        public void FindAndHighlightLabel(string location, Color color)
        {
            Control[] controls = this.Controls.Find(location, true);
            if (controls.Length > 0 && controls[0] is Label)
            {
                // Cambia il colore dello sfondo della Label in giallo
                Label label = (Label)controls[0];
                label.BackColor = color;


            }
        }


        private void RipristinaFocusTextBox()
        {
            // Ripristina il focus al TextBox
            scaffaleSelezionatoTextBox.Focus();
        }

        private void Form6_Click(object sender, EventArgs e)
        {
            // Quando viene cliccato qualsiasi altro controllo nel form, ripristina il focus al TextBox
            RipristinaFocusTextBox();
        }

        private void ForwardButton(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex + 1;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scaffaleSelezionatoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '\'')
            {
                // Impedisci l'inserimento del carattere '-' nel TextBox
                e.Handled = true;
            }
        }

        private void BackButton(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex - 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex - 1;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = 1;

        }

        private void tabControlWithoutHeader1_SelectedIndexChanged(object sender, EventArgs e)
        {
            scaffaleSelezionatoTextBox.Focus();
        }

        public void DisplayMessageBox(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
