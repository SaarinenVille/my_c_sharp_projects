using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDNET
{
    /*
     * Yhdistetään MySql-tietokantaan
     * Tarvitsee MySql Connectorin sekä XAMPin
    */
    class YHDISTA
    {
        
        public string yhteyslause()
        {
            return "datasource = localhost; port=3306;username=root;password=;database=opiskelijat";
        }
        

        private MySqlConnection yhteys = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=opiskelijat; SSL Mode = None");

        // Funktio yhdistämistä varten
        public MySqlConnection otaYhteys() 
        { 
            return yhteys; 
        }
        // Funktio yhteyden avaamista varten (käyttää System.Data-kirjastoa)
        public void avaaYhteys()
        {
            if (yhteys.State == ConnectionState.Closed)
            {
                yhteys.Open();
            }
        }
        // Seuraavaksi funktio yhteyden sulkemista varten
        public void suljeYhteys()
        {
            if (yhteys.State == ConnectionState.Open)
            {
                yhteys.Close();
            }
        }

    }
}
