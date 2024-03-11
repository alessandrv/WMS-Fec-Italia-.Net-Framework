using System;
using System.Drawing;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public partial class StockingMagazzinoView : Form
    {

        private StockingMagazzinoController controller;
        public event EventHandler onLoad;
        public event EventHandler onButtonClick;
        public event EventHandler onChangedTab;


        public StockingMagazzinoView()
        {
            InitializeComponent();
            
        }
        public void AttachController(StockingMagazzinoController controller)
        {
            this.controller = controller;
        }

        public TextBox GetScaffaleSelezionatoTextBox()
        {
            return scaffaleSelezionatoTextBox;
        }
       

        public string GetAreaMagazzino()
        {
            switch (tabControlWithoutHeader1.TabIndex)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                default:
                    return string.Empty;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex + 1;
            tabControlWithoutHeader1.TabIndex = tabControlWithoutHeader1.TabIndex + 1;
            scaffaleSelezionatoTextBox.Focus();

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BackButton(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex - 1;
            tabControlWithoutHeader1.TabIndex = tabControlWithoutHeader1.TabIndex - 1;

            scaffaleSelezionatoTextBox.Focus();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex - 1;
            tabControlWithoutHeader1.TabIndex = tabControlWithoutHeader1.TabIndex - 1;
            scaffaleSelezionatoTextBox.Focus();

        }

        private void ForwardButton(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex + 1;
            tabControlWithoutHeader1.TabIndex = tabControlWithoutHeader1.TabIndex + 1;
            scaffaleSelezionatoTextBox.Focus();

        }

        public int GetIndexAreaMagazzino()
        {
            return tabControlWithoutHeader1.TabIndex;
        }

        private void tabControlWithoutHeader1_TabIndexChanged(object sender, EventArgs e)
        {
            onChangedTab?.Invoke(this, EventArgs.Empty);
        }

        private void scaffaleSelezionatoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '\'')
            {
                // Impedisci l'inserimento del carattere '-' nel TextBox
                e.Handled = true;
            }
        }
        public void DisplayMessageBox(string message, string title)
        {
            MessageBox.Show(message, title);
        }
        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }
        private void tabControlWithoutHeader1_SelectedIndexChanged(object sender, EventArgs e)
        {
            scaffaleSelezionatoTextBox.Focus();
        }
    }
}
