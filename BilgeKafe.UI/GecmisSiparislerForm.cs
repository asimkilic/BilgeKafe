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
    public partial class GecmisSiparislerForm : Form
    {
        private readonly KafeVeri db;
        //private readonly BindingList<Siparis> blGecmisSiparisler;
        //private List<SiparisDetay> siparisDetay;
        public GecmisSiparislerForm(KafeVeri db)
        {
            InitializeComponent();

            this.db = db;
            // blGecmisSiparisler = new BindingList<Siparis>(db.GecmisSiparisler);
            // dgvSiparisler.DataSource = blGecmisSiparisler;

            dgvSiparisler.AutoGenerateColumns = false;
            dgvSiparisDetaylar.AutoGenerateColumns = false;
            dgvSiparisler.DataSource = db.Siparisler.Where(x => x.SiparisDurum != SiparisDurum.Aktif).ToList();


        }



        private void dgvSiparisler_Click(object sender, EventArgs e)
        {


            if (dgvSiparisler.SelectedRows != null)
            {
                // siparisDetay = blGecmisSiparisler[dgvSiparisler.SelectedRows[0].Index].SiparisDetaylar;
                //dgvSiparisDetaylar.DataSource= blGecmisSiparisler[dgvSiparisler.SelectedRows[0].Index].SiparisDetaylar;
            }
        }

        private void dgvSiparisler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSiparisler.SelectedRows.Count != 1)
            {
                dgvSiparisDetaylar.DataSource = null;
            }
            else
            {
                DataGridViewRow satir = dgvSiparisler.SelectedRows[0];
                Siparis siparis = (Siparis)satir.DataBoundItem;
                dgvSiparisDetaylar.DataSource = siparis.SiparisDetaylar.ToList();
            }
        }
    }
}
