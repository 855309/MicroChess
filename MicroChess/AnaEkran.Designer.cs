
namespace MicroChess
{
    partial class AnaEkran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaEkran));
            this.tahtaParent = new System.Windows.Forms.Panel();
            this.YukariMenu = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniOyunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recepeKarşıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birArkadaşınaKarşıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oyunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yardımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lokasyonLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarBosluk = new System.Windows.Forms.ToolStripStatusLabel();
            this.hamleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.YukariMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tahtaParent
            // 
            this.tahtaParent.Location = new System.Drawing.Point(0, 24);
            this.tahtaParent.Name = "tahtaParent";
            this.tahtaParent.Size = new System.Drawing.Size(560, 560);
            this.tahtaParent.TabIndex = 1;
            // 
            // YukariMenu
            // 
            this.YukariMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.oyunToolStripMenuItem,
            this.hakkındaToolStripMenuItem,
            this.yardımToolStripMenuItem});
            this.YukariMenu.Location = new System.Drawing.Point(0, 0);
            this.YukariMenu.Name = "YukariMenu";
            this.YukariMenu.Size = new System.Drawing.Size(562, 24);
            this.YukariMenu.TabIndex = 2;
            this.YukariMenu.Text = "YukariMenu";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniOyunToolStripMenuItem,
            this.toolStripSeparator1,
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // yeniOyunToolStripMenuItem
            // 
            this.yeniOyunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recepeKarşıToolStripMenuItem,
            this.birArkadaşınaKarşıToolStripMenuItem});
            this.yeniOyunToolStripMenuItem.Name = "yeniOyunToolStripMenuItem";
            this.yeniOyunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yeniOyunToolStripMenuItem.Text = "Yeni Oyun";
            // 
            // recepeKarşıToolStripMenuItem
            // 
            this.recepeKarşıToolStripMenuItem.Name = "recepeKarşıToolStripMenuItem";
            this.recepeKarşıToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.recepeKarşıToolStripMenuItem.Text = "Recep\'e karşı";
            this.recepeKarşıToolStripMenuItem.Click += new System.EventHandler(this.recepeKarşıToolStripMenuItem_Click);
            // 
            // birArkadaşınaKarşıToolStripMenuItem
            // 
            this.birArkadaşınaKarşıToolStripMenuItem.Enabled = false;
            this.birArkadaşınaKarşıToolStripMenuItem.Name = "birArkadaşınaKarşıToolStripMenuItem";
            this.birArkadaşınaKarşıToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.birArkadaşınaKarşıToolStripMenuItem.Text = "Bir arkadaşına karşı (yakında)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // oyunToolStripMenuItem
            // 
            this.oyunToolStripMenuItem.Name = "oyunToolStripMenuItem";
            this.oyunToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.oyunToolStripMenuItem.Text = "Oyun";
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            // 
            // yardımToolStripMenuItem
            // 
            this.yardımToolStripMenuItem.Name = "yardımToolStripMenuItem";
            this.yardımToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.yardımToolStripMenuItem.Text = "Yardım";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lokasyonLabel,
            this.statusBarBosluk,
            this.hamleLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 584);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(562, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusBar";
            // 
            // lokasyonLabel
            // 
            this.lokasyonLabel.Name = "lokasyonLabel";
            this.lokasyonLabel.Size = new System.Drawing.Size(25, 17);
            this.lokasyonLabel.Text = "0, 0";
            // 
            // statusBarBosluk
            // 
            this.statusBarBosluk.Name = "statusBarBosluk";
            this.statusBarBosluk.Size = new System.Drawing.Size(463, 17);
            this.statusBarBosluk.Spring = true;
            // 
            // hamleLabel
            // 
            this.hamleLabel.Name = "hamleLabel";
            this.hamleLabel.Size = new System.Drawing.Size(59, 17);
            this.hamleLabel.Text = "Sıra Sizde.";
            // 
            // AnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 606);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tahtaParent);
            this.Controls.Add(this.YukariMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.YukariMenu;
            this.Name = "AnaEkran";
            this.Text = "MicroChess";
            this.Load += new System.EventHandler(this.AnaEkran_Load);
            this.YukariMenu.ResumeLayout(false);
            this.YukariMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel tahtaParent;
        private System.Windows.Forms.MenuStrip YukariMenu;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oyunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yardımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniOyunToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lokasyonLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusBarBosluk;
        private System.Windows.Forms.ToolStripStatusLabel hamleLabel;
        private System.Windows.Forms.ToolStripMenuItem recepeKarşıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem birArkadaşınaKarşıToolStripMenuItem;
    }
}

