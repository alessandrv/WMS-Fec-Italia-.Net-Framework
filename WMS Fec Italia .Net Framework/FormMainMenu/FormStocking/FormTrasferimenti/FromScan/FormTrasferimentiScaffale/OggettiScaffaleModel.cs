using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS_Fec_Italia_MVC;


public class OggettiScaffaleModel
{
    public string scannedShelf { get; set; }

    public DataTable LoadShelfItems()
    {
        
       
        
        string area = scannedShelf.Substring(0, 1);
        string scaffale = scannedShelf.Substring(1, 1);
        string colonna = scannedShelf.Substring(2, 2);
        string piano = scannedShelf.Substring(4, 1);
        string query = $@"SELECT wms_items.id_pacco, wms_items.id_art, mganag.amg_desc, wms_items.id_mov, wms_items.fornitore, wms_items.dimensione, wms_items.qta, 
                  wms_items.area || '-' || wms_items.scaffale || '-' || wms_items.colonna || '-' || wms_items.piano AS locat
                  FROM wms_items 
                  LEFT JOIN mganag ON wms_items.id_art = mganag.amg_code 
                  WHERE area = '{area}' AND scaffale = '{scaffale}' AND colonna = '{colonna}' AND piano ='{piano}'
                  ORDER BY wms_items.id_pacco";

        Database database = new Database();
        return database.GetDataTableFromQuery(query) ;
    }
}
