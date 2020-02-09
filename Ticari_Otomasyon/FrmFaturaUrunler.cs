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
    public partial class FrmFaturaUrunDetay : Form
    {
        public FrmFaturaUrunDetay()
        {
            InitializeComponent();
        }
        public string id;

        Sqlbaglantisi bgl = new Sqlbaglantisi();

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from TBL_FATURADETAY where FATURAID='"+id+"'",bgl.Baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmFaturaUrunDetay_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDuzenleme fr = new FrmFaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.urunID = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }
    }
}
