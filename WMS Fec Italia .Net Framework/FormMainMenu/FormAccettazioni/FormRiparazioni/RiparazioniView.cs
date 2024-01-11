using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using ProgressBar = System.Windows.Forms.ProgressBar;
using TextBox = System.Windows.Forms.TextBox;

namespace WMS_Fec_Italia_MVC
{
    public partial class RiparazioniView : Form
    {
        public event EventHandler buttonClick;
        public event EventHandler onLoad;
        public ProgressBar progressbar { set; get; }
        private RiparazioniController controller;



        public RiparazioniView()
        {
            InitializeComponent();
             


        }
        public void DisplayErrorBox(string message)
        {
            MessageBox.Show(message, "Errore");
        }
        public void DisplayMessageBox(string message, string title)
        {
            MessageBox.Show(message, title);
        }

        public void AttachController(RiparazioniController controller)
        {
            this.controller = controller;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public TextBox GetTicketTextBox()
        {
            return textBox2;
        }
        public ComboBox GetClientiComboBox()
        {
            return comboBox1;
        }

      

        private void RiparazioniView_Load(object sender, EventArgs e)
        {
            
            onLoad?.Invoke(this, EventArgs.Empty);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            buttonClick?.Invoke(this, EventArgs.Empty);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fotocamera formFotocamera = new Fotocamera();
            formFotocamera.ShowDialog();
            this.Close();
        }
    }
}
