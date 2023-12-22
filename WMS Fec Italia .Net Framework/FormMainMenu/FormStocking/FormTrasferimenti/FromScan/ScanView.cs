using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WMS_Fec_Italia_MVC
{
    public partial class ScanView : Form
    {
        private ScanController controller;
        public event EventHandler openForm;

        public ScanView()
        {
            InitializeComponent();
        }

        public void AttachController(ScanController controller)
        {
            this.controller = controller;
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
                try
                {
                    openForm?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Impedire il beep di sistema associato a premere "Invio"
                e.SuppressKeyPress = true;
            }
        }

        public System.Windows.Forms.TextBox GetScannedShelf()
        {
            return scaffaleTextBox;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void scaffaleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || e.KeyChar == '\'')
            {
                // Impedisci l'inserimento del carattere '-' nel TextBox
                e.Handled = true;
            }
        }
    }
}
