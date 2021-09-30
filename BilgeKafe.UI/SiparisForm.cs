using BilgeKafe.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeKafe.UI
{
    public partial class SiparisForm : Form
    {
        public event EventHandler<MasaTasindiEventArgs> MasaTasindi;
        private readonly KafeVeri db;
        private readonly Siparis siparis;
        private readonly BindingList<SiparisDetay> blSiparisDetaylar;
        public SiparisForm(KafeVeri kafeVeri, Siparis siparis)
        {
            db = kafeVeri;
            this.siparis = siparis;
            blSiparisDetaylar = new BindingList<SiparisDetay>(siparis.SiparisDetaylar);
            blSiparisDetaylar.ListChanged += BlSiparisDetaylar_ListChanged;
            InitializeComponent();
            dgvSiparisDetaylari.AutoGenerateColumns = false; // kolon başlıklarını otomatik eklemesini kapattık, bu halde ekleme yapılırsa exception fırlatır.
            UrunleriListele();
            MasaNoyuGuncelle();
            dgvSiparisDetaylari.DataSource = blSiparisDetaylar;
            MasaNolariListele();
            // OdemeTutariniGuncelle();
            blSiparisDetaylar.ResetBindings();
        }

        private void MasaNolariListele()
        {
            cboMasaNo.DataSource =
                Enumerable.Range(1, 20)
                .Where(s => !db.AktifSiparisler.Any(x => x.MasaNo == s))
                .ToList();
            //for (int i = 1; i <= db.MasaAdet; i++)
            //{
            //    if (!db.AktifSiparisler.Any(s => s.MasaNo == i))
            //    {
            //        cboMasaNo.Items.Add(i);
            //    }
            //}
        }

        private void BlSiparisDetaylar_ListChanged(object sender, ListChangedEventArgs e)
        {
            // e.ListChangedType  enum'dır her bir olayın ayrı bir nuamrası var delete için add için vb. eventler için özelleştirmeye gidilebilir.
            OdemeTutariniGuncelle();
        }

        private void OdemeTutariniGuncelle()
        {
            lblOdemeTutari.Text = siparis.ToplamTutarTL;
        }

        private void UrunleriListele()
        {
            cboUrun.DataSource = db.Urunler;
        }

        private void MasaNoyuGuncelle()
        {
            Text = $"{siparis.MasaNo}";
            lblMasaNo.Text = $"{siparis.MasaNo:00}";
        }

        private void btnDetayEkle_Click(object sender, EventArgs e)
        {
            Urun urun = (Urun)cboUrun.SelectedItem;
            int adet = (int)nudAdet.Value;
            if (urun == null)
            {
                MessageBox.Show("Önce bir ürün seçmelisiniz");
                return;
            }
            SiparisDetay sd = new SiparisDetay()
            {
                UrunAd = urun.UrunAd,
                BirimFiyat = urun.BirimFiyat,
                Adet = adet
            };
            blSiparisDetaylar.Add(sd); // binding listten dolayı siparis.SiparisDetaylarinada ekleyecek.
            //OdemeTutariniGuncelle(); bindinglistchange ile yaptıks

        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{siparis.ToplamTutarTL} tutarını tahsil edildiyse sipariş kapatılacaktır. Onaylıyor musunuz?", "Ödeme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                SiparisiKapat(SiparisDurum.Odendi);
            }
        }

        private void btnSiparisIptal_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Sipariş iptal edilecektir onaylıyor musunuz?", "İptal Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                SiparisiKapat(SiparisDurum.Iptal);
            }

        }
        private void SiparisiKapat(SiparisDurum durum)
        {
            siparis.OdenenTutar = durum == SiparisDurum.Odendi ? siparis.ToplamTutar() : 0;
            siparis.SiparisDurum = durum;
            siparis.KapanisZamani = DateTime.Now;
            db.AktifSiparisler.Remove(siparis);
            db.GecmisSiparisler.Add(siparis);
            Close();
        }

        private void btnMasaTasi_Click(object sender, EventArgs e)
        {
            int eskiMasaNo = siparis.MasaNo;
            int yeniMasaNo = (int)cboMasaNo.SelectedItem;
            siparis.MasaNo = yeniMasaNo;
            MasaNoyuGuncelle();
            MasaNolariListele();
            MasaTasindiEventArgs args = new MasaTasindiEventArgs()
            {
                EskiMasaNo = eskiMasaNo,
                YeniMasaNo = yeniMasaNo

            };

            if (MasaTasindi != null)
            {
                MasaTasindi(this, args);
            }
        }
    }
}
