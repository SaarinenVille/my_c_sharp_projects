using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace CRUDNET
{
    /*
     * Tähän luokkaan tulee:
     * Uuden opiskelijan lisäys
     * Opiskelijan tietojen muokkaus
     * Opiskelijan tietojen poisto
     * Opiskelijan tietojen haku
    */
    class OPISKELIJA
    {
        YHDISTA yhteys = new YHDISTA();

        // Metodi uuden opiskelijan lisäämiseksi

        public bool lisaaOpiskelija(String enimi, String snimi, String puh, String email, int onro)
        {
            /*
             * Lisätään nämä kun on todettu että ohjelma toimii:
            String ktunnus = enimi.Substring(0, 3).ToLower() + snimi.Substring(0, 5).ToLower();
            String salis = salasana();
            String salattu = Encrypt(salis);
            */

            MySqlCommand komento = new MySqlCommand();

            String lisayskysely = "INSERT INTO yhteystiedot " +
                "(etunimi, sukunimi, puhelin, sahkoposti, opiskelijanumero) " +
                "VALUES (@enm, @snm, @puh, @eml, @ono); ";

            komento.CommandText = lisayskysely;
            komento.Connection = yhteys.otaYhteys();
            
            // Määritetään @enm, @snm, @puh, @eml @ono (@usr, @ssa)
            
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@puh", MySqlDbType.VarChar).Value = puh;
            komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            komento.Parameters.Add("@ono", MySqlDbType.UInt32).Value = onro;
            /*
             * Lisätään nämä, kun on todettu että ohjelma toimii:
            komento.Parameters.Add("@usr", MySqlDbType.VarChar).Value = ktunnus;
            komento.Parameters.Add("@ssa", MySqlDbType.VarChar).Value = salattu;
            MessageBox.Show("Käyttäjätunnuksesi on " + ktunnus + "\nSalasanasi on " + salis + "\nSalattuna se on" + salattu +"\nkirjoita nämä visusti talteen");
             */
            yhteys.avaaYhteys();
            if (komento.ExecuteNonQuery() == 1)
            {
                yhteys.suljeYhteys();
                return true;
            }
            else
            {
                yhteys.suljeYhteys();
                return false;
            }                       
        }

        // Metodi opiskelijoiden tietojen hakemiseksi
        public DataTable haeOpiskelijat()
        {
            MySqlCommand komento = new MySqlCommand("SELECT oid, etunimi, sukunimi, puhelin, sahkoposti, opiskelijanumero FROM yhteystiedot", yhteys.otaYhteys());
            MySqlDataAdapter adapteri = new MySqlDataAdapter();
            DataTable taulu = new DataTable();

            adapteri.SelectCommand = komento;
            adapteri.Fill(taulu);

            return taulu;
        }

        // Metodi opiskelijan tietojen muokkamiseksi
        public bool muokkaaOpiskelijaa(int oid, String enimi, String snimi, String puh, String email, int onro)
        {
            MySqlCommand komento = new MySqlCommand();
            String paivityskysely = "UPDATE 'yhteystiedot' SET 'etunimi'= @enm," +
                "'sukunimi'= @snm,'puhelin'= @puh,'sahkoposti'= @eml,'opiskelijanumero'= @ono" +
                " WHERE oid = @oid";
            komento.CommandText = paivityskysely;
            komento.Connection = yhteys.otaYhteys();

            // Määritetään @enm, @snm, @puh, @eml @ono
            komento.Parameters.Add("@enm", MySqlDbType.VarChar).Value = enimi;
            komento.Parameters.Add("@snm", MySqlDbType.VarChar).Value = snimi;
            komento.Parameters.Add("@puh", MySqlDbType.VarChar).Value = puh;
            komento.Parameters.Add("@eml", MySqlDbType.VarChar).Value = email;
            komento.Parameters.Add("@ono", MySqlDbType.UInt32).Value = onro;
            komento.Parameters.Add("@oid", MySqlDbType.UInt32).Value = oid;

            yhteys.avaaYhteys();
            if (komento.ExecuteNonQuery() == 1) 
            {
                yhteys.suljeYhteys();
                return true;
            }
            else
            {
                yhteys.suljeYhteys();
                return false;
            }

        }

        // Metodi tietojen poistamista varten

        public bool poistaOpiskelija(String ktunnus)
        {
            MySqlCommand komento = new MySqlCommand();
            String poistokysely = "DELETE FROM yhteystiedot WHERE oid = @ktu";
            komento.CommandText = poistokysely;
            komento.Connection = yhteys.otaYhteys();
            //@ktu
            komento.Parameters.Add("@ktu", MySqlDbType.UInt32).Value = ktunnus;

            yhteys.avaaYhteys();
            if (komento.ExecuteNonQuery() == 1) 
            { 
                yhteys.suljeYhteys();
                return true;
            }
            else
            {
                yhteys.suljeYhteys();
                return false;
            }
        }

    }
}
