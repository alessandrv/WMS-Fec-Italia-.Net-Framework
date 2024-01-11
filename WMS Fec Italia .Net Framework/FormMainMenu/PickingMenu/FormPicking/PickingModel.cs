
using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS_Fec_Italia_MVC
{
    public class PickingModel
    {

        public Dictionary<string, int> locatCounts = new Dictionary<string, int>();

        public DataTable OttieniQuantitaOggettiComposti(IEnumerable<string> occ_artiList)
        {
            try
            {
                using (var database = new Database())
                {
                    database.Connect();

                    // Unisci tutti gli articoli composti in un'unica query usando IN
                    string occ_artiInClause = string.Join("', '", occ_artiList);

                    string query = $@"
                SELECT mpl_figlio as occ_arti,
                       mpl_padre,
                       mpl_coimp
                FROM mplegami 
                WHERE mpl_padre IN ('{occ_artiInClause}')";

                    OdbcCommand odbcCommand = new OdbcCommand(query);
                    odbcCommand.Connection = database.OdbcConnection;

                    OdbcDataAdapter adapter = new OdbcDataAdapter();
                    adapter.SelectCommand = odbcCommand;

                    DataTable dtNuoviDati = new DataTable();
                    adapter.Fill(dtNuoviDati);

                    return dtNuoviDati;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nell'ottenimento degli oggetti composti dalla tabella mplegami: {ex.Message}");
            }
        }


        public DataTable OttieniQuantitaOggettiSemplici(string occ_code, string occ_tipo)
        {
            try
            {

                using (var database = new Database())
                {
                    database.Connect();

                    DataTable temp = new DataTable();
                    string nuovaQuery = $@"
SELECT ocordic.occ_arti, ocordic.occ_qmov as mpl_coimp
FROM ocordic
WHERE occ_code = {occ_code} AND occ_tipo = '{occ_tipo}'
    AND NOT EXISTS (
        SELECT 1
        FROM mplegami
        WHERE mpl_padre = ocordic.occ_arti
    )
    AND NOT EXISTS (
        SELECT 1
        FROM wms_proibiti
        WHERE id_articolo = ocordic.occ_arti
    );
";
                    OdbcCommand odbcCommand = new OdbcCommand(nuovaQuery);
                    odbcCommand.Connection = database.OdbcConnection;
                    OdbcDataAdapter adapter = new OdbcDataAdapter();
                    adapter.SelectCommand = odbcCommand;
                    adapter.Fill(temp);
                    return temp;


                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Errore nell'ottenimento degli oggetti composti dalla tabella ocordic: {ex.Message}");
            }

        }





        public DataTable EffettuaRicercaPicking(string occ_code, string occ_tipo)
        {
            using (var database = new Database())
            {
                database.Connect();
                string query = $@"SELECT occ_arti, occ_qmov FROM ocordic WHERE occ_code = {occ_code} AND occ_tipo = '{occ_tipo}'";

                OdbcCommand odbcCommand = new OdbcCommand(query);
                odbcCommand.Connection = database.OdbcConnection;
                OdbcDataAdapter adapter = new OdbcDataAdapter();
                adapter.SelectCommand = odbcCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;

            }





        }

        public void GetDescrizioni(DataTable dataTable)
        {
            try
            {
                // Ottieni tutti i codici articolo distinti dalla tabella
                var codiciArticoloDistinct = dataTable.AsEnumerable()
                    .Select(row => row.Field<string>("occ_arti"))
                    .Distinct();

                // Creare l'elenco dei codici articolo distinti come stringa separata da virgole
                string codiciArticoloInClause = string.Join("', '", codiciArticoloDistinct);

                // Esegui la query per ottenere tutte le descrizioni in un'unica chiamata
                string queryDescrizioni = $@"
            SELECT amg_code, amg_dest
            FROM mganag
            WHERE amg_code IN ('{codiciArticoloInClause}');
        ";

                using (var database = new Database())
                {
                    database.Connect();

                    OdbcCommand odbcCommand = new OdbcCommand(queryDescrizioni);
                    odbcCommand.Connection = database.OdbcConnection;

                    OdbcDataAdapter adapter = new OdbcDataAdapter();
                    adapter.SelectCommand = odbcCommand;

                    DataTable dtDescrizioni = new DataTable();
                    adapter.Fill(dtDescrizioni);

                    // Unisci i dati delle descrizioni con la tabella principale
                    var result = from table1 in dataTable.AsEnumerable()
                                 join table2 in dtDescrizioni.AsEnumerable()
                                 on table1.Field<string>("occ_arti") equals table2.Field<string>("amg_code")
                                 select new
                                 {
                                     Row = table1,
                                     Descrizione = table2.Field<string>("amg_dest")
                                 };

                    // Assegna le descrizioni alle righe della tabella principale
                    foreach (var entry in result)
                    {
                        entry.Row["descrizione"] = entry.Descrizione;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nell'ottenimento delle descrizioni degli articoli: {ex.Message}");
            }
        }

 
        public DataTable ControllaLocazioni(DataTable dataTable)
        {
            try
            {


                DataTable newTable = new DataTable();
                newTable.Columns.Add("codice_art", typeof(string));
                newTable.Columns.Add("descrizione", typeof(string));
                newTable.Columns.Add("movimento", typeof(string));

                newTable.Columns.Add("locat", typeof(string));
                newTable.Columns.Add("qta_perlocazione",
                    typeof(int)); // Cambiare il tipo di dato in base alle tue esigenze
                using (var database = new Database())
                {
                    database.Connect();
                    foreach (DataRow row in dataTable.Rows)
                    {


                        string codiceArt = row["occ_arti"].ToString();
                        int quantitaRichiesta = Convert.ToInt32(row["mpl_coimp"]);
                        string descrizione = row["descrizione"].ToString();

                        // Esegui la query per ottenere la locazione dalla tabella wms_items e ordinarlo per data corrispondente al movimento di bfbolt
                        string queryGetLocatAndQta = $@"
                   

    SELECT 
wms_items.id_art,
        wms_items.area || '-' || wms_items.scaffale || '-' || wms_items.colonna || '-' || wms_items.piano AS locat,
        wms_items.id_mov,
        SUM(qta) AS qta_perlocazione
    FROM 
        wms_items
        WHERE wms_items.id_art = '{codiceArt}'
        GROUP BY id_art, wms_items.area, wms_items.scaffale, wms_items.colonna, wms_items.piano, id_mov
        order by id_mov, qta_perlocazione
            ";
                        OdbcCommand odbcCommand = new OdbcCommand(queryGetLocatAndQta);
                        odbcCommand.Connection = database.OdbcConnection;

                        // Creare un DataTable
                        using (var reader = odbcCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string locat = reader["locat"].ToString();
                                string filteredLocat = RimuoviTrattini(locat);
                                string mov = reader["id_mov"].ToString();
                                
                                int qtaPerLocazione = Convert.ToInt32(reader["qta_perlocazione"]);

                                // Aggiungere la riga al DataTable
                                // Aggiungi locat alla Dictionary
                                if (locatCounts.ContainsKey(filteredLocat))
                                {
                                    // Se la chiave è già presente, incrementa il conteggio
                                    locatCounts[filteredLocat]++;
                                }
                                else
                                {
                                    // Altrimenti, aggiungi la chiave con un conteggio iniziale di 1
                                    locatCounts.Add(filteredLocat, 1);
                                }

                                if (qtaPerLocazione >= quantitaRichiesta)
                                {
                                    //Se nella locazione ho tutta la merce che mi serve aggiungo la riga e indico come valore da prelevare tutta la merce
                                    newTable.Rows.Add(codiceArt, descrizione, mov, locat, quantitaRichiesta);
                                    return newTable;
                                }

                                //Nel caso non uscissi dalla funzione nell'if allora significa che la mia quantita nella locazione non è sufficiente a soddisfare quella totale
                                //Quindi aggiungo una riga dicendo quanta prelevarne da quella li specifica (che corrispondera al totale dello scaffale)
                                newTable.Rows.Add(codiceArt, descrizione, mov, locat, qtaPerLocazione);
                                quantitaRichiesta -= qtaPerLocazione;
                            }

                            if (quantitaRichiesta > 0)
                            {
                                newTable.Rows.Add(codiceArt, descrizione, null, "MANCANTE", quantitaRichiesta);
                            }
                        }
                    }
                    return newTable;
                    // Ora il DataTable contiene i dati letti dalla query
                    // Puoi utilizzare il dataTable come necessario...
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nel controllo delle locazioni: {ex.Message}");
            }
        }


        private string RimuoviTrattini(string stringa)
        {

            return stringa.Replace("-", "");

        }
        public DataTable EffettuaRicercaArticolo(string idArticolo)
        {
            try
            {

                using (var database = new Database())
                {

                    database.Connect();


                    string query = $@"
SELECT 
    subquery.id_art,
    subquery.id_mov,
    subquery.locat,
    SUM(subquery.qta) as qta,
    subquery.amg_dest
FROM (
    SELECT 
        w.id_art,
        w.id_mov,
        w.area || '-' || w.scaffale || '-' || w.colonna || '-' || w.piano AS locat,
        w.qta,
        a.amg_dest
    FROM 
        wms_items w
    LEFT JOIN 
        mganag a ON w.id_art = a.amg_code
    WHERE 
        w.id_art = '{idArticolo}'
) AS subquery
GROUP BY 
    subquery.id_art, subquery.id_mov, subquery.locat, subquery.amg_dest
ORDER BY 
    subquery.id_mov, subquery.locat;

";


                    OdbcCommand odbcCommand = new OdbcCommand(query);
                    odbcCommand.Connection = database.OdbcConnection;
                    OdbcDataAdapter adapter = new OdbcDataAdapter();
                    adapter.SelectCommand = odbcCommand;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;




                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nella effettuare la ricerca dell'articolo: {ex.Message}");
            }
        }

        private DataTable TrovaArticolo(DataTable table, int quantitaRichiesta)

        {
            try
            {


                int quantitaDaAllocare = quantitaRichiesta;
                DataTable newTable = new DataTable();
                newTable.Columns.Add("codice_art", typeof(string));
                newTable.Columns.Add("descrizione", typeof(string));
                newTable.Columns.Add("movimento", typeof(string));

                newTable.Columns.Add("locat", typeof(string));
                newTable.Columns.Add("qta_perlocazione", typeof(int)); // Ca


                string idArt = "";
                string artDesc = "";
                foreach (DataRow row in table.Rows)
                {
                    int quantitaPresente = Convert.ToInt32(row["qta"]);
                    idArt = row["id_art"].ToString();
                    artDesc = row["amg_dest"].ToString();
                    string locat = row["locat"].ToString();
                    if (locatCounts.ContainsKey(locat))
                    {
                        // Se la chiave è già presente, incrementa il conteggio
                        locatCounts[locat]++;
                    }
                    else
                    {
                        // Altrimenti, aggiungi la chiave con un conteggio iniziale di 1
                        locatCounts.Add(locat, 1);
                    }

                    if (quantitaDaAllocare <= quantitaPresente)
                    {
                        newTable.Rows.Add(idArt, artDesc, row["id_mov"], locat, quantitaDaAllocare);
                        return newTable;
                    }
                    else
                    {
                        newTable.Rows.Add(idArt, artDesc, row["id_mov"], locat, quantitaPresente);
                        quantitaDaAllocare = quantitaDaAllocare - quantitaPresente;
                    }
                    //Nel caso non uscissi dalla funzione nell'if allora significa che la mia quantita nella locazione non è sufficiente a soddisfare quella totale
                    //Quindi aggiungo una riga dicendo quanta prelevarne da quella li specifica (che corrispondera al totale dello scaffale)
                    //newTable.Rows.Add(codiceArt, descrizione, mov, locat, qtaPerLocazione);


                    //       quantitaRichiesta -= qtaPerLocazione;




                }

                newTable.Rows.Add(idArt, artDesc, "MANCANTE", null, quantitaDaAllocare);

                return newTable;
            }
            catch (Exception ex)
            {
                throw new Exception($"Impossibile trovare articolo: {ex.Message}");
            }
        }

        //DA FIXARE NUOVA LOCAT
        public void EffettuaPicking(string codiceArticolo, string codiceMovimento, string area, string scaffale, string colonna, string piano, int qta)
        {
            try
            {

                int qtaDaPrelevare = qta;
                using (var database = new Database())
                {

                    database.Connect();


                    // Esegui una query per ottenere le informazioni sui pacchi disponibili nella posizione specificata
                    string querySelect = $@"SELECT id_pacco, qta, dimensione
                    FROM wms_items 
                    WHERE id_art = '{codiceArticolo}' AND id_mov = {codiceMovimento} AND area = '{area}' AND scaffale ='{scaffale}' 
                          AND colonna = '{colonna}' AND piano = '{piano}'
                    ORDER BY id_pacco";

                    OdbcCommand odbcCommand = new OdbcCommand(querySelect);
                    odbcCommand.Connection = database.OdbcConnection;
                    string queryUpdate;
                    using (var reader = odbcCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if(qtaDaPrelevare == 0)
                            {
                                break;
                            }
                            int idPacco = Convert.ToInt32(reader["id_pacco"]);

                            int quantitaPacco = Convert.ToInt32(reader["qta"]);

                            string dimensione = reader["dimensione"].ToString();

                            int valoreDimensione;
                            if (quantitaPacco > qtaDaPrelevare)
                            {
                                // La quantità richiesta può essere soddisfatta da questo pacco
                                // Esegui l'aggiornamento della quantità nel database
                                queryUpdate =
                                    $"UPDATE wms_items SET qta = qta - {qtaDaPrelevare} WHERE id_pacco = {idPacco}";
                                database.AggiornaDatabase(queryUpdate);


                                // Esci dal ciclo poiché hai soddisfatto la richiesta

                            }
                            else
                            {

                                // La quantità richiesta supera la quantità di questo pacco
                                // Esegui l'aggiornamento della quantità nel database    DELETE FROM wms_items WHERE id_pacco={idPacco};
                                switch (dimensione)
                                {
                                    case "Piccolo":
                                        valoreDimensione = Dimensioni.piccolo;
                                        break;
                                    case "Medio":
                                        valoreDimensione = Dimensioni.medio;
                                        break;
                                    case "Grande":
                                        valoreDimensione = Dimensioni.grande;
                                        break;
                                    default:
                                        valoreDimensione = 0;
                                        break;
                                }

                                queryUpdate = $@"
        
        UPDATE wms_scaffali SET volume_libero = volume_libero + {valoreDimensione} WHERE area = '{area}' AND scaffale = '{scaffale}' AND colonna = '{colonna}' AND piano = '{piano}';
DELETE FROM wms_items WHERE id_pacco={idPacco};";


                                database.AggiornaDatabase(queryUpdate);

                            }
                                // Aggiorna la quantità da prelevare
                                qtaDaPrelevare -= quantitaPacco;
                            
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Impossibile effettuare l'operazione di picking: {ex.Message}");
            }
        }


        
    }
}
