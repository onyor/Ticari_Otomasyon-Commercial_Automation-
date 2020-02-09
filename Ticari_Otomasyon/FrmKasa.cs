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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        //Müşteri hareketleri çekme
        void MusteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHaretker", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //Firma Hareketleri Çekme
        void FirmaHareket()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FirmaHareketler", bgl.Baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void GiderListeleme()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from TBL_GIDERLER", bgl.Baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        public string ad;

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            LblAktifKullanici.Text = ad;

            MusteriHareket();
            FirmaHareket();
            GiderListeleme();
            //Toplam tutarı hesaplama
            SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) from TBL_FATURADETAY", bgl.Baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKasaToplam.Text = dr1[0].ToString() +" ₺";

            }
            bgl.Baglanti().Close();

            //SON AYIN FATURASI
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK + SU + DOGALGAZ + INTERNET + EKSTRA) from TBL_GIDERLER ORDER BY ID ASC", bgl.Baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " ₺";

            }
            bgl.Baglanti().Close();

            //SON AYIN PERSONEL MAAŞLARI
            SqlCommand komut3 = new SqlCommand("Select MAASLAR from TBL_GIDERLER ORDER BY ID ASC", bgl.Baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblPersonelMaaslari.Text = dr3[0].ToString() + " ₺";

            }
            bgl.Baglanti().Close();

            //TOPLAM MUSTERI SAYISI
            SqlCommand komut4 = new SqlCommand("Select COUNT(*) from TBL_MUSTERILER", bgl.Baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMusteriSayisi.Text = dr4[0].ToString() + " Kişi";
                
            }
            bgl.Baglanti().Close();
           
            //TOPLAM FIRMA SAYISI
            SqlCommand komut5 = new SqlCommand("Select COUNT(*) from TBL_FIRMALAR", bgl.Baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString() + " Tane";

            }
            bgl.Baglanti().Close();
            //TOPLAM FIRMA ŞEHİR SAYISI
            //DISTINC TEKRARSIZ SAY
            SqlCommand komut6 = new SqlCommand("Select COUNT(DISTINCT(IL)) from TBL_FIRMALAR", bgl.Baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblSehirSayisi.Text = dr6[0].ToString();

            }
            bgl.Baglanti().Close();
            //TOPLAM MÜŞTERİ ŞEHİR SAYISI
            SqlCommand komut7 = new SqlCommand("Select COUNT(DISTINCT(IL)) from TBL_MUSTERILER", bgl.Baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblSehirSayisi2.Text = dr7[0].ToString();

            }
            bgl.Baglanti().Close();
            //TOPLAM PERSONEL SAYISI
            SqlCommand komut8 = new SqlCommand("Select COUNT(*) from TBL_PERSONELLER", bgl.Baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblPersonelSayisi.Text = dr8[0].ToString();

            }
            bgl.Baglanti().Close();
            //TOPLAM ÜRÜN SAYISI
            SqlCommand komut9 = new SqlCommand("Select SUM(ADET) from TBL_URUNLER", bgl.Baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = dr9[0].ToString();

            }
            bgl.Baglanti().Close();
}

        int sayac=0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            //Elektrik
            if (sayac>0 && sayac<=5)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text="Elektrik";
                SqlCommand komut10 = new SqlCommand("SELECT TOP 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.Baglanti().Close();
            }
            //Su faturası
            if (sayac>5 && sayac<=10)
            {
                groupControl10.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut11 = new SqlCommand("SELECT TOP 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.Baglanti().Close();
            }
            //Doğalgaz
            if (sayac > 10 && sayac <= 15)
            {
                groupControl10.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut12 = new SqlCommand("SELECT TOP 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.Baglanti().Close();
            }
            //İnternet
            if (sayac > 15 && sayac <= 20)
            {
                groupControl10.Text = "İnternet";
                chartControl1.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut13 = new SqlCommand("SELECT TOP 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.Baglanti().Close();
            }
            //EKSTRA
            if (sayac > 20 && sayac <= 30)
            {
                groupControl10.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut14 = new SqlCommand("SELECT TOP 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.Baglanti().Close();
            }
            if (sayac==27)
            {
                sayac = 0;
            }
        }

        int sayac2;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            //Elektrik
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl11.Text = "Elektrik";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("SELECT TOP 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.Baglanti().Close();
            }
            //Su faturası
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl11.Text = "Su";
                chartControl2.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut11 = new SqlCommand("SELECT TOP 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.Baglanti().Close();
            }
            //Doğalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl11.Text = "Doğalgaz";
                chartControl2.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut12 = new SqlCommand("SELECT TOP 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.Baglanti().Close();
            }
            //İnternet
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl11.Text = "İnternet";
                chartControl2.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut13 = new SqlCommand("SELECT TOP 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.Baglanti().Close();
            }
            //EKSTRA
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl11.Text = "Ekstra";
                chartControl2.Series["Aylar"].Points.Clear();
                //Chart controle su faturası son 4 ay listeleme
                SqlCommand komut14 = new SqlCommand("SELECT TOP 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.Baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.Baglanti().Close();
            }
            if (sayac2 ==26 )
            {
                sayac2 = 0;
            }
        }
    }
}
