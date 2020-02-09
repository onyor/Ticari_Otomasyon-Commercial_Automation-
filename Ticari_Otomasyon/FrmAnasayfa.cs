using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnasayfa : Form
    {
        int SimdikiWidth = 1386;
        int SimdikiHeight = 642;
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl = new Sqlbaglantisi();
        
        //Stoklar
        void Stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Urunad, Sum(Adet) as 'Adet' From TBL_URUNLER group by URUNAD " +
                "having Sum(ADET) <= 20 order by Sum(Adet)", bgl.Baglanti());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
        }
        void Ajanda()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select top 8 TARIH, SAAT, BASLIK from TBL_NOTLAR " +
                "order by ID desc ", bgl.Baglanti());
            da2.Fill(dt2);
            GridControlAjanda.DataSource = dt2;
        }
        void FirmaHareket()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Exec FIRMAHAREKET2 ", bgl.Baglanti());
            da3.Fill(dt3);
            GridControlSonOnHareket.DataSource = dt3;
        }
        void Fihrist()
        {
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("select ad,telefon1 from TBL_FIRMALAR", bgl.Baglanti());
            da4.Fill(dt4);
            GridControlFihrist.DataSource = dt4;
        }
        void Haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("http://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            Rectangle ClienCozunurluk = new Rectangle();
            ClienCozunurluk = Screen.GetBounds(ClienCozunurluk);
            float OranWidth = ((float)ClienCozunurluk.Width / (float)SimdikiWidth);
            float OranHeight = ((float)ClienCozunurluk.Height / (float)SimdikiHeight);
            this.Scale(new SizeF(OranWidth, OranHeight));

            Stoklar();
            Ajanda();
            FirmaHareket();
            Fihrist();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/kurlar_tr.html");
            Haberler();
        }
    }
}
