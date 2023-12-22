using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS_Fec_Italia_MVC
{
    public class VisualizzaMagazzinoController
    {
        private VisualizzaMagazzinoModel model;
        private VisualizzaMagazzinoView view;

        public VisualizzaMagazzinoController(VisualizzaMagazzinoModel model, VisualizzaMagazzinoView view)
        {
            this.view = view;
            this.model = model;
            view.onLoad += onLoad;
            view.AttachController(this);
        }

        private void onLoad(object sender, EventArgs e)
        {
            string scaffale = model.area + model.scaffale + model.colonna + model.piano;
            
            Control[] controls = view.Controls.Find(scaffale, true);

            view.FindAndHighlightLabel(controls, Color.LawnGreen);

        }
    }
}
