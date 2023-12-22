using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS_Fec_Italia_MVC;

namespace WMS_Fec_Italia_MVC
{
    public class StockingDettagliController
    {
        private StockingDettagliModel model;
        private StockingDettagliView view;


        public StockingDettagliController(StockingDettagliModel model, StockingDettagliView view)
        {
            this.model = model;
            this.view = view;
            this.view.scanArticolo += ControllaValiditaArticolo;
            this.view.scanFornitore += ControllaValiditaFornitore;
            this.view.scanMovimento += ControllaValiditaMovimento;
            this.view.buttonClick += buttonClick;

            this.view.AttachController(this);
        }



        private void ControllaValiditaArticolo(object sender, EventArgs e)
        {
            try
            {


                TextBox articoloTextBox = view.GetArticoloTextBox();
                string descrizioneArticolo = model.OttieniDescrizioneArticolo(articoloTextBox.Text);
                if (descrizioneArticolo != null)
                {
                    view.SetDescrizioneArticolo(descrizioneArticolo);
                    view.GetFornitoreTextBox().Focus();
                }
                else
                {
                    articoloTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }
        }
        private void ControllaValiditaFornitore(object sender, EventArgs e)
        {
            try
            {


                TextBox fornitoreTextBox = view.GetFornitoreTextBox();
                string ragioneSocialeFornitore = model.OttieniRagioneSocialeFornitore(fornitoreTextBox.Text);
                if (ragioneSocialeFornitore != null)
                {
                    view.SetRagioneSocialeFornitore(ragioneSocialeFornitore);
                    view.GetMovimentoTextBox().Focus();
                }
                else
                {
                    fornitoreTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }
        }
        private void ControllaValiditaMovimento(object sender, EventArgs e)
        {
            TextBox codiceMovimento = view.GetMovimentoTextBox();
            TextBox codiceArticolo = view.GetArticoloTextBox();
            try
            {
                if (!model.ControllaCoerenzaMovimento(codiceMovimento.Text, codiceArticolo.Text))
                {
                    view.DisplayErrorBox("Articolo selezionato non presente nel movimento indicato");
                    // codiceMovimento.Clear();

                }
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }

        }


        private void buttonClick(object sender, EventArgs e)
        {

            int volumeTot = 0;
            int volume = 0;
            switch (view.GetDimensioniComboBox().SelectedIndex)
            {

                case 1://grande da rimuovere
                    volume = 3;
                    break;
                case 2: //medio
                    volume = 2;

                    break;
                case 3://piccolo
                    volume = 1;

                    break;
                
                default:
                    volume = 0;

                    break;
            }

            if (view.GetQuantitaPerPacco().Text.Length == 0 || volume == 0)
            {
                view.DisplayErrorBox("Informazioni mancanti");
                return;
            }

            try
            {
                //Controllo se i dati sono coerenti, ovvero esiste un movimento con quel fornitore e con dentro l' articolo inserito e che il campo quantita per pacco non sia vuoto
                if (model.CoerenzaDati(view.GetMovimentoTextBox().Text, view.GetArticoloTextBox().Text,
                        view.GetFornitoreTextBox().Text))
                {
                    view.Hide();
                    volumeTot = volume * Convert.ToInt32(view.GetNumeroPacchi().Value);
                    StockingMagazzinoModel modelStockingMagazzino = new StockingMagazzinoModel();
                    modelStockingMagazzino.volumeTot = volumeTot;
                    modelStockingMagazzino.numeroPacchi = Convert.ToInt32(view.GetNumeroPacchi().Text);
                    modelStockingMagazzino.quantita = Convert.ToInt32(view.GetQuantitaPerPacco().Text);
                    modelStockingMagazzino.codiceArticolo = view.GetArticoloTextBox().Text;
                    modelStockingMagazzino.codiceFornitore = view.GetFornitoreTextBox().Text;
                    modelStockingMagazzino.codiceMovimento = view.GetMovimentoTextBox().Text;
                    modelStockingMagazzino.dimensioni = view.GetDimensioniComboBox().Text;
                    StockingMagazzinoView viewStockingMagazzino = new StockingMagazzinoView();
                    StockingMagazzinoController controllerStockingMagazzino =
                        new StockingMagazzinoController(modelStockingMagazzino, viewStockingMagazzino);
                    viewStockingMagazzino.AttachController(controllerStockingMagazzino);
                    viewStockingMagazzino.ShowDialog();

                    view.Show();
                }
                else
                {
                    view.DisplayErrorBox(
                        "+ e/o movimento non coerenti.\n Non esiste un movimento con questi dati.");

                }
            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }
        }

    }
}
