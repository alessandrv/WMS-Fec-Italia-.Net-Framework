using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMS_Fec_Italia.Net_Framework.Properties;

namespace WMS_Fec_Italia_MVC
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OttieniDimensioni();
            Application.Run(new FormMainMenu());
        }


        public static void OttieniDimensioni()
        {
            try
            {

                using (var database = new Database())
                {
                    database.Connect();

                    DataTable temp = new DataTable();
                    string nuovaQuery = $@"
SELECT *
FROM wms_volume;";
                    OdbcCommand odbcCommand = new OdbcCommand(nuovaQuery);
                    odbcCommand.Connection = database.OdbcConnection;
                    OdbcDataAdapter adapter = new OdbcDataAdapter();
                    adapter.SelectCommand = odbcCommand;
                    adapter.Fill(temp);

                    Dimensioni.piccolo = Convert.ToInt32(temp.Rows[0][1]);
                    Dimensioni.medio = Convert.ToInt32(temp.Rows[1][1]);
                    Dimensioni.grande = Convert.ToInt32(temp.Rows[2][1]);
                   

                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Errore nell'ottenimento delle dimensioni: {ex.Message}");
            }

        }
    }
}
