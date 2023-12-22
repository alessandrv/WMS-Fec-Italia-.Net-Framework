using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_Fec_Italia_MVC
{
    public class ResiModel
    {
        public DataTable DatabaseData { get; set; }

        public void LoadTable()
        {
            using (var database = new Database())
            {
                database.Connect();

                // Utilizza un alias per semplificare la sintassi della query
                string query =
                    $@"SELECT o.oct_tipo, o.oct_code, o.oct_data,o.oct_cocl,a.des_clifor,  o.oct_toco, o.oct_rifc,o.oct_stat
                    FROM ocordit o
                    LEFT JOIN agclifor a ON o.oct_cocl = a.cod_clifor 
                    WHERE o.oct_stat = 'A'";



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
