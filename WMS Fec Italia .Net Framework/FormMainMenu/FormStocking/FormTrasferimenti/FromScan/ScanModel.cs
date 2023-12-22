using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_Fec_Italia_MVC
{
    public class ScanModel
    {
        public bool ScaffaleEsiste(string scannedShelf)
        {



            string area = scannedShelf.Substring(0, 1);
            string scaffale = scannedShelf.Substring(1, 1);
            string colonna = scannedShelf.Substring(2, 2);
            string piano = scannedShelf.Substring(4, 1);
            string query = $@"SELECT area
                          FROM wms_scaffali 
                          WHERE area = '{area}' AND scaffale = '{scaffale}' AND colonna = '{colonna}' AND piano ='{piano}'";
            Database database = new Database();
            database.GetDataTableFromQuery(query);
            return (database.GetDataTableFromQuery(query).Rows.Count > 0);
        }
    }
}
