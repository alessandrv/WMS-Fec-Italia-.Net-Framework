using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_Fec_Italia_MVC
{
    public class FornitoriModel
    {
        public DataTable DatabaseData { get; set; }

        public void LoadTable()
        {
            using (var database = new Database())
            {
                database.Connect();

                // Utilizza un alias per semplificare la sintassi della query
                string query =
                    $@"SELECT o.oft_tipo, o.oft_code, o.oft_stat, o.oft_data, o.oft_cofo, a.des_clifor, o.oft_inarrivo
                    FROM ofordit o
                    LEFT JOIN agclifor a ON o.oft_cofo = a.cod_clifor 
                    WHERE o.oft_cofo = a.cod_clifor AND o.oft_stat = 'A'
ORDER BY o.oft_inarrivo desc";



                OdbcCommand odbcCommand = new OdbcCommand(query);
                odbcCommand.Connection = database.OdbcConnection;
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = odbcCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DatabaseData = dt;
            }
        }
    }
}
