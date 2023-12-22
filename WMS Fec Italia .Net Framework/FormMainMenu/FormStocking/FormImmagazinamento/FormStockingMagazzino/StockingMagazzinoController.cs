using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS_Fec_Italia_MVC;

namespace WMS_Fec_Italia_MVC
{
    public class StockingMagazzinoController
    {
        private StockingMagazzinoModel model;
        private StockingMagazzinoView view;


        public StockingMagazzinoController(StockingMagazzinoModel model, StockingMagazzinoView view)
        {
            this.model = model;
            this.view = view;
            this.view.AttachController(this);
            this.view.onLoad += ColoraLocazioni;
            this.view.onButtonClick += InserisciMerce;
            view.onChangedTab += OnChangedTab;
        }

      

        private void InserisciMerce(object sender, EventArgs e)
        {
            TextBox scaffaleTextBox = view.GetScaffaleSelezionatoTextBox();
            string scaffaleText = scaffaleTextBox.Text;
            string area = scaffaleText.Substring(0, 1);
            string scaffale = scaffaleText.Substring(1, 1);
            string colonna = scaffaleText.Substring(2, 2);
            string piano = scaffaleText.Substring(4, 1);

            if (model.GetLocazioniLibereGeneriche().Contains(scaffaleText) || model.GetLocazioniLibereFornitori().Contains(scaffaleText))
            {

                // La stringa è presente nell'HashSet

                try
                {
                    model.ConfermaInserimento(area, scaffale, colonna, piano);
                    view.DisplayMessageBox("Inserimento completato.", "Successo");
                    view.Close();
                }
                catch (Exception ex)
                {
                    view.DisplayErrorBox(ex.Message);
                }
                
                    
                
               

            }
            else
            {
                // La stringa non è presente nell'HashSet
                view.DisplayErrorBox($"{area}-{scaffale}-{colonna}-{piano} risulta pieno. Contatta l'amministratore del database per verifiche.");

            }
            scaffaleTextBox.Clear();
        }

        
        private void ColoraLocazioni(object sender, EventArgs e)
        {
            try
            {


                model.ControllaSpaziCompatibili();
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
                return;
            }

            foreach (string locazione in model.GetLocazioniLibereGeneriche())
            {
               
                view.FindAndHighlightLabel(locazione, Color.LawnGreen);
            }
            foreach (string locazione in model.GetLocazioniLibereFornitori())
            {

                view.FindAndHighlightLabel(locazione, Color.DeepSkyBlue);
            }
        }
       
        private void OnChangedTab(object sender, EventArgs e)
        {


            try
            {


                model.ControllaSpaziCompatibili();
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }
            foreach (string locazione in model.GetLocazioniLibereGeneriche())
            {

                view.FindAndHighlightLabel(locazione, Color.LawnGreen);
            }
            foreach (string locazione in model.GetLocazioniLibereFornitori())
            {

                view.FindAndHighlightLabel(locazione, Color.DeepSkyBlue);
            }
        }


    }
}
