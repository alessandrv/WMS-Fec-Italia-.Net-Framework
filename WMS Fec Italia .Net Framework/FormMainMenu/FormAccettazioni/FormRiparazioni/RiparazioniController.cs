using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class RiparazioniController
    {
        private RiparazioniModel model;
        private RiparazioniView view;
 
        
        /// <summary>
        /// Inizializza una nuova istanza della classe AccettazioneOrdineController.
        /// </summary>
        /// <param name="model">Il modello associato al controller.</param>
        /// <param name="view">La vista associata al controller.</param>
        public RiparazioniController(RiparazioniModel model, RiparazioniView view)
        {
            this.model = model;
            this.view = view;
            view.buttonClick += buttonClicked;
            view.onLoad += OnLoad;
            
        }

        private void OnLoad(object sender, EventArgs e)
        {
            PopulateComboBox();

        }

        private void buttonClicked(object sender, EventArgs e)
        {
            try
            {
                model.InsertRiparazione(view.GetTicketTextBox().Text, view.GetClientiComboBox().Text);
                view.DisplayMessageBox("Operazione eseguita con successo.",
                    "Successo!");
                view.Close();
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }
        }

        private void PopulateComboBox()
        {
            ComboBox comboBox = view.GetClientiComboBox();
            List<string> clienti = model.LoadClienti();

            foreach (string cliente in clienti)
            {
                comboBox.Items.Add(cliente);
               
            }
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            
        }

    }
}
