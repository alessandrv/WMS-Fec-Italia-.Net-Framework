
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS_Fec_Italia.Net_Framework;
using WMS_Fec_Italia.Net_Framework.Properties;
using WMS_Fec_Italia_MVC;


namespace WMS_Fec_Italia_MVC
{
    public partial class FormMainMenu : Form
    {
        public FormMainMenu()
        {
            InitializeComponent();
        }




        private void AccettazioneFornitoriClick(object sender, EventArgs e)
        {
            FornitoriModel modelAccettazione = new FornitoriModel();
            var viewAccettazione = new FornitoriView();
            FornitoriController controllerAccettazione = new FornitoriController(modelAccettazione, viewAccettazione);
            viewAccettazione.AttachController(controllerAccettazione);
            this.Hide();
            viewAccettazione.ShowDialog();
            this.Show();

        }

        private void PickingClick(object sender, EventArgs e)
        {
            PickingModel modelPicking = new PickingModel();
            var viewPicking = new PickingView();
            PickingController controllerAccettazione = new PickingController(modelPicking, viewPicking);
            viewPicking.AttachController(controllerAccettazione);
            this.Hide();
            viewPicking.ShowDialog();
            this.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockingMagazzinoClick(object sender, EventArgs e)
        {
           StockingDettagliModel modelStockingDettagli = new StockingDettagliModel();


           var viewStockingDettagli = new StockingDettagliView();
           StockingDettagliController controllerStockingDettagli = new StockingDettagliController(modelStockingDettagli, viewStockingDettagli);
           viewStockingDettagli.AttachController(controllerStockingDettagli);
            this.Hide();
          viewStockingDettagli.ShowDialog();
            this.Show();

        }



        private void TrasferimentiClick(object sender, EventArgs e)
        {

          var viewScan = new ScanView();
           var modelScan = new ScanModel();
           ScanController controllerScan = new ScanController(viewScan, modelScan);
          viewScan.AttachController(controllerScan);
            this.Hide();
         viewScan.ShowDialog();
            this.Show();
        }
        private void VisualizzaMagazzinoClick(object sender, EventArgs e)
        {
           AnalisiMagazzinoModel modelAnalisiMagazzino = new AnalisiMagazzinoModel();
          var viewAnalisiMagazzino = new AnalisiMagazzinoView();
           AnalisiMagazzinoController controllerStockingDettagli = new AnalisiMagazzinoController(modelAnalisiMagazzino, viewAnalisiMagazzino);
           viewAnalisiMagazzino.AttachController(controllerStockingDettagli);
            this.Hide();
           viewAnalisiMagazzino.ShowDialog();
            this.Show();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonResi(object sender, EventArgs e)
        {
           ResiModel modelReso = new ResiModel();
           var viewResi = new ResiView();
           ResiController controllerResi = new ResiController(modelReso, viewResi);
           viewResi.AttachController(controllerResi);

            this.Hide();
           viewResi.ShowDialog();
            this.Show();
        }

        private void buttonRiparazioni(object sender, EventArgs e)
        {
            RiparazioniModel modelRiparazioni = new RiparazioniModel();
            var viewRiparazioni = new RiparazioniView();
            RiparazioniController controllerRiparazioni = new RiparazioniController(modelRiparazioni, viewRiparazioni);
            viewRiparazioni.AttachController(controllerRiparazioni);


            viewRiparazioni.ShowDialog();
            this.Show();

        }

        
        



    }
}
