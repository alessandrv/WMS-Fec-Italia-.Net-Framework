using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class TrasferimentiMagazzinoController
    {
        private TrasferimentiMagazzinoModel model;
        private TrasferimentiMagazzinoView view;

        public TrasferimentiMagazzinoController(TrasferimentiMagazzinoModel model, TrasferimentiMagazzinoView view)
        {
            this.model = model;
            this.view = view;
            view.onLoad += ColoraLocazioni;
            view.onButtonClick += InserisciMerce;
            view.AttachController(this);
        }

        private void InserisciMerce(object sender, EventArgs e)
        {
            TextBox scaffaleScannerizzato = view.GetScaffaleSelezionatoTextBox();
            string scaffaleText = scaffaleScannerizzato.Text;
            string area = scaffaleText.Substring(0, 1);
            string scaffale = scaffaleText.Substring(1, 1);
            string colonna = scaffaleText.Substring(2, 2);
            string piano = scaffaleText.Substring(4, 1);
            if (model.GetLocazioniLibereGeneriche().Contains(scaffaleText) || model.GetLocazioniLibereFornitori().Contains(scaffaleText))
            {

                // La stringa è presente nell'HashSet

                

                // La stringa è presente nell'HashSet
                try
                {


                    if (model.ConfermaInserimento(area, scaffale, colonna, piano))
                    {
                        view.DisplayMessageBox("Inserimento completato.", "Successo");
                        view.Close();
                    }
                    else
                    {
                        view.DisplayErrorBox("Inserimento fallito.");
                    }
                }
                catch (Exception ex)
                {
                    view.DisplayErrorBox(ex.Message);
                }

            }
            else
            {
                // La stringa non è presente nell'HashSet
                view.DisplayErrorBox($"{area}-{scaffale}-{colonna}-{piano} risulta pieno o inesistente. Contatta l'amministratore del database per verifiche.");

            }
            scaffaleScannerizzato.Clear();
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
            }

            foreach (string locazione in model.GetLocazioniLibereGeneriche())
            {
                view.FindAndHighlightLabel(locazione, Color.LawnGreen);
            }
            foreach (string locazione in model.GetLocazioniLibereFornitori())
            {
                view.FindAndHighlightLabel(locazione, Color.DeepSkyBlue);
            }
            view.FindAndHighlightLabel(model.scaffaleProvenienza, Color.Gray);
        }

    }
}
