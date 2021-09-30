using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BilgeKafe.Data;
using BilgeKafe.UI.Properties;
using Newtonsoft.Json;

namespace BilgeKafe.UI
{
    public partial class AnaForm : Form
    {
        KafeVeri db = new KafeVeri();

        public AnaForm()
        {

            //  OrnekUrunleriOlustur();
            InitializeComponent();
            MasalariOlustur(); // 1-
        }

        private void MasalariOlustur()
        {
            #region 2-Imaj Listesinin oluşturulması
            ImageList imageList = new ImageList();
            imageList.Images.Add("bos", Resources.bos);
            imageList.Images.Add("dolu", Resources.dolu);
            imageList.ImageSize = new Size(64, 64);
            lvwMasalar.LargeImageList = imageList;
            #endregion
            for (int i = 1; i <= db.MasaAdet; i++)
            {
                ListViewItem lvi = new ListViewItem($"Masa {i}");
                lvi.Tag = i;
                lvi.ImageKey = db.Siparisler.Any(s => s.MasaNo == i && s.SiparisDurum == SiparisDurum.Aktif) ? "dolu" : "bos";
                lvwMasalar.Items.Add(lvi);
            }
        }

        private void lvwMasalar_DoubleClick(object sender, EventArgs e) // 3
        {
            // boş alana tıkladığında çalışmaz item üzerinde double click olduğunda çalışıyor.
            ListViewItem lvi = lvwMasalar.SelectedItems[0];
            lvi.ImageKey = "dolu";
            int masaNo = (int)lvi.Tag;
            // Tıklanan masaya ait (varsaa) siparişi bul
            Siparis siparis = db.Siparisler.FirstOrDefault(x => x.MasaNo == masaNo && x.SiparisDurum == SiparisDurum.Aktif);
            // Eğer sipariş henüz oluşturulmadıysa
            if (siparis == null)
            {
                siparis = new Siparis() { MasaNo = masaNo };
                db.Siparisler.Add(siparis);
            }

            SiparisForm frmSiparis = new SiparisForm(db, siparis);
            frmSiparis.MasaTasindi += FrmSiparis_MasaTasindi;
            frmSiparis.ShowDialog();
            if (siparis.SiparisDurum != SiparisDurum.Aktif)
            {
                lvi.ImageKey = "bos";
            }
        }

        private void FrmSiparis_MasaTasindi(object sender, MasaTasindiEventArgs e)
        {
            foreach (ListViewItem listView in lvwMasalar.Items)
            {
                if ((int)listView.Tag == e.EskiMasaNo)
                {
                    listView.ImageKey = "bos";
                }
                if ((int)listView.Tag == e.YeniMasaNo)
                {
                    listView.ImageKey = "dolu";
                }
            }
        }

        private void tsmiGecmisSiparisler_Click(object sender, EventArgs e)
        {
            new GecmisSiparislerForm(db).ShowDialog();
        }

        private void tsmiUrunler_Click(object sender, EventArgs e)
        {
            new UrunlerForm(db).ShowDialog();
        }
    }
}
