using System;
using System.Drawing;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public partial class VisualizzaMagazzinoView : Form
    {


        private VisualizzaMagazzinoController controller;
        public event EventHandler onLoad;

        public VisualizzaMagazzinoView()
        {
            InitializeComponent();


        }
        public void AttachController(VisualizzaMagazzinoController controller)
        {
            this.controller = controller;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Crea un'istanza della classe Database
            //analyizeSpace();
            onLoad?.Invoke(this, EventArgs.Empty);


        }




        public void FindAndHighlightLabel(Control[] controls, Color color)
        {

            if (controls.Length > 0 && controls[0] is Label)
            {
                // Cambia il colore dello sfondo della Label in giallo
                Label label = (Label)controls[0];
                label.BackColor = color;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex + 1;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControlWithoutHeader1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (tabControlWithoutHeader1.SelectedIndex != tabControlWithoutHeader1.TabCount - 1)
            {
                tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex + 1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (tabControlWithoutHeader1.SelectedIndex != 0)
            {
                tabControlWithoutHeader1.SelectedIndex = tabControlWithoutHeader1.SelectedIndex - 1;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
