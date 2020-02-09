using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {

        int SimdikiWidth = 1920;
        int SimdikiHeight = 1080;
        public FrmAnaModul()
        {
            InitializeComponent();
        }
        // nesne oluşturduk
        FrmUrunler Fr;
        FrmMusteriler Fr2;
        FrmFirmalar Fr3;
        FrmPersonel Fr4;
        FrmRehber Fr5;
        FrmGiderler Fr6;
        FrmBankalar Fr7;
        FrmFaturalar Fr8;
        FrmNotlar Fr9;
        FrmHareketler Fr10;
        FrmRaporlar Fr11;
        FrmStoklar Fr12;
        FrmAyarlar Fr13;
        FrmKasa Fr14;
        FrmAnasayfa Fr15;

        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Ürünler formuna bağlanma işlemi
            if (Fr==null || Fr.IsDisposed) // sayfa yenileme engelliyor
            {
                FrmUrunler frmUrunler = new FrmUrunler();
                Fr = frmUrunler;
                Fr.MdiParent = this;
                Fr.Show(); //form gösterme
            }

        }
        
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Fr2==null || Fr2.IsDisposed)
            {
                FrmMusteriler frmMusteriler = new FrmMusteriler();
                Fr2 = frmMusteriler;
                Fr2.MdiParent = this;
                Fr2.Show();
            }
        }
        
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr3 == null || Fr3.IsDisposed)
            {
                FrmFirmalar frmFirmalar = new FrmFirmalar();
                Fr3 = frmFirmalar;
                Fr3.MdiParent = this;
                Fr3.Show();
            }
        }
        
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr4 == null || Fr4.IsDisposed)
            {
                FrmPersonel frmPersonel = new FrmPersonel();
                Fr4 = frmPersonel;
                Fr4.MdiParent = this;
                Fr4.Show();
            }
        }
        
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr5 == null || Fr5.IsDisposed)
            {
                FrmRehber frmRehber = new FrmRehber();
                Fr5 = frmRehber;
                Fr5.MdiParent = this;
                Fr5.Show();
            }
        }
                
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr6 == null || Fr6.IsDisposed)
            {
                FrmGiderler frmGiderler = new FrmGiderler();
                Fr6 = frmGiderler;
                Fr6.MdiParent = this;
                Fr6.Show();
            }

        }
                
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr7 == null || Fr7.IsDisposed)
            {
                FrmBankalar frmBankalar = new FrmBankalar();
                Fr7 = frmBankalar;
                Fr7.MdiParent = this;
                Fr7.Show();
            }

        }

        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr8==null || Fr8.IsDisposed)
            {
                FrmFaturalar frmFaturalar = new FrmFaturalar();
                Fr8 = frmFaturalar;
                Fr8.MdiParent = this;
                Fr8.Show();
            }

        }
        
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr9==null || Fr9.IsDisposed)
            {
                FrmNotlar frmNotlar = new FrmNotlar();
                Fr9 = frmNotlar;
                Fr9.MdiParent=this;
                Fr9.Show();
            }
        }
        
        private void Btn_Hareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr10 == null || Fr10.IsDisposed)
            {
                FrmHareketler frmHareketler = new FrmHareketler();
                Fr10 = frmHareketler;
                Fr10.MdiParent = this;
                Fr10.Show();
            }
        }
        
        private void Btn_Raporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Fr11 == null || Fr11.IsDisposed)
            {
                FrmRaporlar frmRaporlar = new FrmRaporlar();
                Fr11 = frmRaporlar;
                Fr11.MdiParent = this;
                Fr11.Show();
            }
        }

        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr12 == null || Fr12.IsDisposed)
            {
                FrmStoklar frmStoklar = new FrmStoklar();
                Fr12 = frmStoklar;
                Fr12.MdiParent = this;
                Fr12.Show();
            }
        }
                
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr13 == null || Fr13.IsDisposed)
            {
                FrmAyarlar frmAyarlar = new FrmAyarlar();
                Fr13 = frmAyarlar;
                Fr13.Show();
            }
        }
                
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr14 == null || Fr14.IsDisposed)
            {
                FrmKasa frmKasa = new FrmKasa();
                Fr14 = frmKasa;
                Fr14.ad = kullanici;
                Fr14.MdiParent = this;
                Fr14.Show();
            }
        }

        public string kullanici;        
        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            Rectangle ClienCozunurluk = new Rectangle();
            ClienCozunurluk = Screen.GetBounds(ClienCozunurluk);
            float OranWidth = ((float)ClienCozunurluk.Width / (float)SimdikiWidth);
            float OranHeight = ((float)ClienCozunurluk.Height / (float)SimdikiHeight);
            this.Scale(new SizeF(OranWidth, OranHeight));

            if (Fr15 == null || Fr15.IsDisposed)
            {
                FrmAnasayfa frmAnasayfa = new FrmAnasayfa();
                Fr15 = frmAnasayfa;
                Fr15.MdiParent = this;
                Fr15.Show();
            }
        }
        
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Fr15 == null)
            {
                FrmAnasayfa frmAnasayfa = new FrmAnasayfa();
                Fr15 = frmAnasayfa;
                Fr15.MdiParent = this;
                Fr15.Show();
            }
        }
    }
}