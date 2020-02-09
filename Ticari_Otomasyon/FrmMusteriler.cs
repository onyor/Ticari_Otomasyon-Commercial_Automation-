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


namespace Ticari_Otomasyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl = new Sqlbaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MUSTERILER order by ID asc", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.Baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.Baglanti().Close();
        }
        
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListesi();
            Temizle();
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.Baglanti();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER" +
                "(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", MskTC.Text);
            komut.Parameters.AddWithValue("@p6", TxtMail.Text);
            komut.Parameters.AddWithValue("@p7", Cmbil.Text);
            komut.Parameters.AddWithValue("@p8", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", RchAdres.Text);
            komut.Parameters.AddWithValue("@p10", TxtVergi.Text);

            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Müşteri sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Gridde seçili olanı textboxlara çekme
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);//Satırın verisini al
            if (dr!=null)
            {
                Txtid.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTC.Text =dr["TC"].ToString();
                TxtMail.Text =dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
            }            
        }

        void Temizle()
        {
            txtAd.Text = "";
            Txtid.Text = "";
            TxtMail.Text = "";
            TxtSoyad.Text = "";
            TxtVergi.Text = "";
            MskTC.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            RchAdres.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Silme işlemi
            DialogResult uyari;
            uyari = MessageBox.Show("Silmek istediğinize emin misiniz?", "UYARI!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (uyari==DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("Delete From TBL_MUSTERILER where ID=@p1", bgl.Baglanti());
                komutsil.Parameters.AddWithValue("@p1", Txtid.Text);
                komutsil.ExecuteNonQuery();
                bgl.Baglanti();
                MessageBox.Show("Müşteri Silindi. ", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Listele();
            }            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_MUSTERILER set " +
               "AD=@P1, SOYAD=@P2, TELEFON=@P3, TELEFON2=@P4, TC=@P5,MAIL=@P6, IL=@P7,ILCE=@P8,VERGIDAIRE=@P9,ADRES=@P10 " +
               "where ID=@P11",
               bgl.Baglanti());
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@P4", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@P5", MskTC.Text);
            komut.Parameters.AddWithValue("@P6", TxtMail.Text);
            komut.Parameters.AddWithValue("@P7", Cmbil.Text);
            komut.Parameters.AddWithValue("@P8", Cmbilce.Text);
            komut.Parameters.AddWithValue("@P9", TxtVergi.Text);
            komut.Parameters.AddWithValue("@P10", RchAdres.Text);
            komut.Parameters.AddWithValue("@P11", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti();
            MessageBox.Show("Müşteri bilgisi güncellendi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}