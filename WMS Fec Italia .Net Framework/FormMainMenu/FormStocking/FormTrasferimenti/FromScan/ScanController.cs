using System;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class ScanController
    {
        
        private ScanView view;
        private ScanModel model;


        public ScanController(ScanView view, ScanModel model)
        {
            this.view = view;
            this.model = model;
            view.openForm += openForm;
            view.AttachController(this);
        }

        private void openForm(object sender, EventArgs e)
        {
            TextBox scannedShelf = view.GetScannedShelf();
            try
            {
                if (model.ScaffaleEsiste(scannedShelf.Text))
                {
                    OggettiScaffaleModel modelNuovoForm = new OggettiScaffaleModel();
                    modelNuovoForm.scannedShelf = scannedShelf.Text;

                    var nuovoForm = new OggettiScaffaleView();
                    OggettiScaffaleController nuovoFormController =
                        new OggettiScaffaleController(modelNuovoForm, nuovoForm);
                    nuovoForm.AttachController(nuovoFormController);

                    nuovoForm.ShowDialog();
                }
                else
                {
                    view.DisplayErrorBox($"Scaffale non presente nel database: {scannedShelf.Text}");
                }

                scannedShelf.Clear();


            }
            catch (Exception ex)
            {
                view.DisplayErrorBox(ex.Message);
            }
        }
    }
}
