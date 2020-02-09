using System;
using System.Data.SqlClient;
using System.Linq;

namespace Ticari_Otomasyon
{
    class Sqlbaglantisi
    {
        public SqlConnection Baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-S4C5D2M;Initial Catalog=DboTicariOtomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
