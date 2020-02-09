﻿using System;
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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir",8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Sivas",58);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara",6);

            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD, SUM(ADET) AS 'ADET' FROM TBL_URUNLER GROUP BY URUNAD", bgl.Baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta stok miktarı listeleme
            SqlCommand komut = new SqlCommand("SELECT URUNAD, SUM(ADET) AS 'ADET' FROM TBL_URUNLER GROUP BY URUNAD", bgl.Baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            //charta firma şehir sayısı çekme
            SqlCommand komut2 = new SqlCommand("SELECT IL, COUNT(*) FROM TBL_FIRMALAR GROUP BY IL", bgl.Baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            bgl.Baglanti().Close();
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay fr = new FrmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.ad = dr["URUNAD"].ToString();
                fr.Show();
            }
        }
    }
}
