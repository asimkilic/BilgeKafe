
namespace BilgeKafe.UI
{
    partial class AnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiUrunler = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGecmisSiparisler = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwMasalar = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUrunler,
            this.tsmiGecmisSiparisler});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiUrunler
            // 
            this.tsmiUrunler.Name = "tsmiUrunler";
            this.tsmiUrunler.Size = new System.Drawing.Size(58, 20);
            this.tsmiUrunler.Text = "Ürünler";
            this.tsmiUrunler.Click += new System.EventHandler(this.tsmiUrunler_Click);
            // 
            // tsmiGecmisSiparisler
            // 
            this.tsmiGecmisSiparisler.Name = "tsmiGecmisSiparisler";
            this.tsmiGecmisSiparisler.Size = new System.Drawing.Size(108, 20);
            this.tsmiGecmisSiparisler.Text = "Geçmiş Siparişler";
            this.tsmiGecmisSiparisler.Click += new System.EventHandler(this.tsmiGecmisSiparisler_Click);
            // 
            // lvwMasalar
            // 
            this.lvwMasalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMasalar.HideSelection = false;
            this.lvwMasalar.Location = new System.Drawing.Point(0, 27);
            this.lvwMasalar.Name = "lvwMasalar";
            this.lvwMasalar.Size = new System.Drawing.Size(788, 411);
            this.lvwMasalar.TabIndex = 1;
            this.lvwMasalar.UseCompatibleStateImageBehavior = false;
            this.lvwMasalar.DoubleClick += new System.EventHandler(this.lvwMasalar_DoubleClick);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwMasalar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BilgeKafe";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUrunler;
        private System.Windows.Forms.ToolStripMenuItem tsmiGecmisSiparisler;
        private System.Windows.Forms.ListView lvwMasalar;
    }
}