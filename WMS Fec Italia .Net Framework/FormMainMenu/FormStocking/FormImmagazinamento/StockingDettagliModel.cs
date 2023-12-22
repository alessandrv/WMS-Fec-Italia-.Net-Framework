using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_Fec_Italia_MVC
{
    public class StockingDettagliModel
    {
        public string OttieniDescrizioneArticolo(string codiceArticolo)
        {
            using (var database = new Database())
            {
                try
                {
                    database.Connect();
                    string query = $"SELECT amg_desc FROM mganag WHERE amg_code = '{codiceArticolo}'";
                    string campoRichiesto = "amg_desc";
                    // Estrapola il campo
                    object risultato = database.EstrapolaCampo(database.EseguiQuery(query), campoRichiesto);

                    if (risultato != null)
                    {

                        return risultato.ToString();
                    }
                    else
                    {

                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Impossibile ottenere descrizione articolo: {ex.Message}");
                }


            }

        }
        public string OttieniRagioneSocialeFornitore(string codiceFornitore)
        {
            using (var database = new Database())
            {
                try
                {
                    database.Connect();
                    //DA cambiare con tabella del database giusta
                    string query = $"SELECT des_clifor FROM agclifor  WHERE cod_clifor = '{codiceFornitore}'";
                    string campoRichiesto = "des_clifor";



                    // Estrapola il campo
                    object risultato = database.EstrapolaCampo(database.EseguiQuery(query), campoRichiesto);

                    if (risultato != null)
                    {

                        return risultato.ToString();
                    }
                    else
                    {

                        return null;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception($"Impossibile ottenere ragione sociale del fornitore: {ex.Message}");
                }
            }
        }

        public bool ControllaCoerenzaMovimento(string codiceMovimento, string codiceArticolo)
        {
            using (var database = new Database())
            {
                try
                {
                    database.Connect();


                    string condizioni = $"gim_arti = '{codiceArticolo}' AND gim_code = '{codiceMovimento}'";
                    DataTable risultatoDataTable = database.LoadData("mggior", condizioni);

                    if (risultatoDataTable != null && risultatoDataTable.Rows.Count > 0)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore controllo coerenza del movimento inserito rispetto all'articolo: {ex.Message}");
                }
                

            }
        }
        public bool CoerenzaDati(string codiceMovimento, string codiceArticolo, string codiceFornitore)
        {
            using (var database = new Database())
            {
                try
                {
                    database.Connect();
                    string condizioni = $"gim_arti = '{codiceArticolo}' AND gim_code = '{codiceMovimento}'";
                    DataTable risultatoDataTable = database.LoadData("mggior", condizioni);

                    if (risultatoDataTable != null && risultatoDataTable.Rows.Count > 0)
                    {
                        condizioni = $"blt_cocl = '{codiceFornitore}' AND blt_code = '{codiceMovimento}'";
                        risultatoDataTable = database.LoadData("bfbolt", condizioni);
                        if (risultatoDataTable != null && risultatoDataTable.Rows.Count > 0)
                        {
                            return true;
                        }

                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore durante il controllo della coerenza dei dati: {ex.Message}");

                }
            }
        }
    }
}
