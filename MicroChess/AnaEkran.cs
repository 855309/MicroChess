using MicroChess.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MicroChess
{
    public partial class AnaEkran : Form
    {
        public static Color siyahColor = Color.FromArgb(181, 136, 99);
        public static Color beyazColor = Color.FromArgb(240, 217, 181);

        public AnaEkran()
        {
            InitializeComponent();
        }

        public int blokGenisligi = 70;

        public static List<List<Panel>> paneller = new List<List<Panel>>();

        public static Tahta tahta = new Tahta();

        public static bool oynayabilirMi = true;

        public void TahtaOlustur()
        {
            paneller.Clear();

            for (int x = 0; x < 8; x++)
            {
                int xindex = x * blokGenisligi;

                List<Panel> satirlist = new List<Panel>();

                for (int y = 0; y < 8; y++)
                {
                    int yindex = y * blokGenisligi;

                    Panel panel = new Panel();

                    panel.Name = "panel_" + x + "_" + y;
                    panel.Location = new Point(xindex, yindex);
                    panel.Parent = tahtaParent;
                    panel.Size = new Size(blokGenisligi, blokGenisligi);

                    if ((x + y) % 2 == 0)
                    {
                        panel.BackColor = beyazColor;
                    }
                    else
                    {
                        panel.BackColor = siyahColor;
                    }

                    //panel.BringToFront();

                    panel.MouseClick += panelDokunma;
                    panel.MouseEnter += pnGeziniyor;

                    satirlist.Add(panel);
                }

                paneller.Add(satirlist);
            }

            List<Parca> parcalar = new List<Parca>();

            for (int piyonb = 0; piyonb <= 8; piyonb++)
            {
                Parca piyon = new Parca();
                piyon.Lokasyon = new Lokasyon();
                piyon.Lokasyon.X = piyonb;
                piyon.Lokasyon.Y = 6;
                piyon.Tas = Tas.Piyon;
                piyon.Taraf = Taraf.Beyaz;

                parcalar.Add(piyon);
            }

            for (int piyonb = 0; piyonb <= 8; piyonb++)
            {
                Parca piyon = new Parca();
                piyon.Lokasyon = new Lokasyon();
                piyon.Lokasyon.X = piyonb;
                piyon.Lokasyon.Y = 1;
                piyon.Tas = Tas.Piyon;
                piyon.Taraf = Taraf.Siyah;

                parcalar.Add(piyon);
            }

            Parca beyazkale1 = new Parca();
            beyazkale1.Lokasyon = new Lokasyon();
            beyazkale1.Lokasyon.X = 0;
            beyazkale1.Lokasyon.Y = 7;
            beyazkale1.Tas = Tas.Kale;
            beyazkale1.Taraf = Taraf.Beyaz;

            Parca beyazkale2 = new Parca();
            beyazkale2.Lokasyon = new Lokasyon();
            beyazkale2.Lokasyon.X = 7;
            beyazkale2.Lokasyon.Y = 7;
            beyazkale2.Tas = Tas.Kale;
            beyazkale2.Taraf = Taraf.Beyaz;

            Parca siyahkale1 = new Parca();
            siyahkale1.Lokasyon = new Lokasyon();
            siyahkale1.Lokasyon.X = 0;
            siyahkale1.Lokasyon.Y = 0;
            siyahkale1.Tas = Tas.Kale;
            siyahkale1.Taraf = Taraf.Siyah;

            Parca siyahkale2 = new Parca();
            siyahkale2.Lokasyon = new Lokasyon();
            siyahkale2.Lokasyon.X = 7;
            siyahkale2.Lokasyon.Y = 0;
            siyahkale2.Tas = Tas.Kale;
            siyahkale2.Taraf = Taraf.Siyah;

            Parca siyahat1 = new Parca();
            siyahat1.Lokasyon = new Lokasyon();
            siyahat1.Lokasyon.X = 6;
            siyahat1.Lokasyon.Y = 0;
            siyahat1.Tas = Tas.At;
            siyahat1.Taraf = Taraf.Siyah;

            Parca siyahat2 = new Parca();
            siyahat2.Lokasyon = new Lokasyon();
            siyahat2.Lokasyon.X = 1;
            siyahat2.Lokasyon.Y = 0;
            siyahat2.Tas = Tas.At;
            siyahat2.Taraf = Taraf.Siyah;

            Parca beyazat1 = new Parca();
            beyazat1.Lokasyon = new Lokasyon();
            beyazat1.Lokasyon.X = 6;
            beyazat1.Lokasyon.Y = 7;
            beyazat1.Tas = Tas.At;
            beyazat1.Taraf = Taraf.Beyaz;

            Parca beyazat2 = new Parca();
            beyazat2.Lokasyon = new Lokasyon();
            beyazat2.Lokasyon.X = 1;
            beyazat2.Lokasyon.Y = 7;
            beyazat2.Tas = Tas.At;
            beyazat2.Taraf = Taraf.Beyaz;

            Parca beyazfil1 = new Parca();
            beyazfil1.Lokasyon = new Lokasyon();
            beyazfil1.Lokasyon.X = 5;
            beyazfil1.Lokasyon.Y = 7;
            beyazfil1.Tas = Tas.Fil;
            beyazfil1.Taraf = Taraf.Beyaz;

            Parca beyazfil2 = new Parca();
            beyazfil2.Lokasyon = new Lokasyon();
            beyazfil2.Lokasyon.X = 2;
            beyazfil2.Lokasyon.Y = 7;
            beyazfil2.Tas = Tas.Fil;
            beyazfil2.Taraf = Taraf.Beyaz;

            Parca siyahfil1 = new Parca();
            siyahfil1.Lokasyon = new Lokasyon();
            siyahfil1.Lokasyon.X = 5;
            siyahfil1.Lokasyon.Y = 0;
            siyahfil1.Tas = Tas.Fil;
            siyahfil1.Taraf = Taraf.Siyah;

            Parca siyahfil2 = new Parca();
            siyahfil2.Lokasyon = new Lokasyon();
            siyahfil2.Lokasyon.X = 2;
            siyahfil2.Lokasyon.Y = 0;
            siyahfil2.Tas = Tas.Fil;
            siyahfil2.Taraf = Taraf.Siyah;

            Parca siyahvezir = new Parca();
            siyahvezir.Lokasyon = new Lokasyon();
            siyahvezir.Lokasyon.X = 3;
            siyahvezir.Lokasyon.Y = 0;
            siyahvezir.Tas = Tas.Vezir;
            siyahvezir.Taraf = Taraf.Siyah;

            Parca siyahsah = new Parca();
            siyahsah.Lokasyon = new Lokasyon();
            siyahsah.Lokasyon.X = 4;
            siyahsah.Lokasyon.Y = 0;
            siyahsah.Tas = Tas.Sah;
            siyahsah.Taraf = Taraf.Siyah;

            Parca beyazvezir = new Parca();
            beyazvezir.Lokasyon = new Lokasyon();
            beyazvezir.Lokasyon.X = 3;
            beyazvezir.Lokasyon.Y = 7;
            beyazvezir.Tas = Tas.Vezir;
            beyazvezir.Taraf = Taraf.Beyaz;

            Parca beyazsah = new Parca();
            beyazsah.Lokasyon = new Lokasyon();
            beyazsah.Lokasyon.X = 4;
            beyazsah.Lokasyon.Y = 7;
            beyazsah.Tas = Tas.Sah;
            beyazsah.Taraf = Taraf.Beyaz;

            parcalar.Add(beyazkale1);
            parcalar.Add(beyazkale2);
            parcalar.Add(siyahkale1);
            parcalar.Add(siyahkale2);
            parcalar.Add(siyahat1);
            parcalar.Add(siyahat2);
            parcalar.Add(beyazat1);
            parcalar.Add(beyazat2);
            parcalar.Add(siyahfil1);
            parcalar.Add(siyahfil2);
            parcalar.Add(beyazfil1);
            parcalar.Add(beyazfil2);
            parcalar.Add(siyahvezir);
            parcalar.Add(siyahsah);
            parcalar.Add(beyazvezir);
            parcalar.Add(beyazsah);

            tahta.Parcalar = parcalar;

            foreach (Parca parca in tahta.Parcalar)
            {
                PictureBox box = new PictureBox();

                box.Name = "tas_" + parca.Lokasyon.X + "_" + parca.Lokasyon.Y;
                box.SizeMode = PictureBoxSizeMode.Zoom;
                box.BackColor = Color.Transparent;

                tahta.Parcalar.ElementAt(tahta.Parcalar.FindIndex(p => p == parca)).Pb = box; //onemli

                if (parca.Taraf == Taraf.Beyaz)
                {
                    string renk = "beyaz";

                    if (parca.Tas == Tas.Piyon)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "piyon.png"));
                    }

                    if (parca.Tas == Tas.At)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "at.png"));
                    }

                    if (parca.Tas == Tas.Kale)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "kale.png"));
                    }

                    if (parca.Tas == Tas.Vezir)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "vezir.png"));
                    }

                    if (parca.Tas == Tas.Sah)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "sah.png"));
                    }

                    if (parca.Tas == Tas.Fil)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "fil.png"));
                    }

                    //box.Parent = beyazPanel;
                }
                else
                {
                    string renk = "siyah";

                    if (parca.Tas == Tas.Piyon)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "piyon.png"));
                    }

                    if (parca.Tas == Tas.At)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "at.png"));
                    }

                    if (parca.Tas == Tas.Kale)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "kale.png"));
                    }

                    if (parca.Tas == Tas.Vezir)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "vezir.png"));
                    }

                    if (parca.Tas == Tas.Sah)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "sah.png"));
                    }

                    if (parca.Tas == Tas.Fil)
                    {
                        box.Image = Image.FromFile(Path.Combine("taslar", renk, "fil.png"));
                    }

                    //box.Parent = siyahPanel;
                }

                box.Location = new Point(parca.Lokasyon.X * blokGenisligi, parca.Lokasyon.Y * blokGenisligi);
                box.Size = new Size(blokGenisligi, blokGenisligi);

                box.Parent = tahtaParent;

                if ((parca.Lokasyon.X + parca.Lokasyon.Y) % 2 == 0)
                {
                    box.BackColor = beyazColor;
                }
                else
                {
                    box.BackColor = siyahColor;
                }

                box.BringToFront();

                box.MouseClick += tasDokunma;
                box.MouseEnter += pbGeziniyor;
            }
        }

        //Ana Girdi
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            //TahtaOlustur();

            tahta.Parent = tahtaParent;

            windowsMediaPlayer.URL = "sesler/hareket.mp3";

            //muzikPlayer.URL = "sesler/muzik.mp3";
            //muzikPlayer.settings.volume = 25;
            //muzikPlayer.controls.play();
        }

        bool tasDokundu = false;

        public static Color dokunmaColor = Color.FromArgb(52, 61, 70);

        public static Color gidilebilecekYerAcikColor = Color.FromArgb(250, 189, 252);
        public static Color gidilebilecekYerKoyuColor = Color.FromArgb(196, 155, 234);

        Parca currentParca = new Parca();

        public static WindowsMediaPlayer windowsMediaPlayer = new WindowsMediaPlayer();

        public void tasDokunma(object sender, MouseEventArgs args)
        {
            if (oynayabilirMi)
            {
                if (!tasDokundu)
                {
                    PictureBox box = (PictureBox)sender;

                    Parca boxparca = new Parca();

                    foreach (Parca parca in tahta.Parcalar)
                    {
                        if (parca.Pb == box)
                        {
                            boxparca = parca;
                        }
                    }

                    if (boxparca.Taraf != Taraf.Siyah)
                    {
                        boxparca.Pb.BackColor = dokunmaColor;

                        currentParca = boxparca;

                        List<Lokasyon> yerler = TasUtils.OynayabilecegiYerleriAl(boxparca);

                        foreach (Lokasyon lokasyon in yerler)
                        {
                            if ((lokasyon.X + lokasyon.Y) % 2 == 0)
                            {
                                paneller[lokasyon.X][lokasyon.Y].BackColor = gidilebilecekYerAcikColor;

                                if (TasUtils.tasVarMi(lokasyon))
                                {
                                    Parca pc = TasUtils.parcaAl(lokasyon);

                                    pc.Pb.BackColor = gidilebilecekYerAcikColor;

                                    
                                }
                            }
                            else
                            {
                                paneller[lokasyon.X][lokasyon.Y].BackColor = gidilebilecekYerKoyuColor;

                                if (TasUtils.tasVarMi(lokasyon))
                                {
                                    Parca pc = TasUtils.parcaAl(lokasyon);

                                    pc.Pb.BackColor = gidilebilecekYerKoyuColor;
                                }
                            }
                        }

                        sonGidilebilecekYerler = yerler;

                        tasDokundu = true;
                    }
                }
                else
                {
                    PictureBox box = (PictureBox)sender;

                    Parca boxparca = new Parca();

                    foreach (Parca parca in tahta.Parcalar)
                    {
                        if (parca.Pb == box)
                        {
                            boxparca = parca;
                        }
                    }

                    if (boxparca.Taraf == Taraf.Siyah)
                    {
                        if (boxparca.Pb.BackColor == gidilebilecekYerAcikColor || boxparca.Pb.BackColor == gidilebilecekYerKoyuColor)
                        {
                            tahtaParent.Controls.Remove(boxparca.Pb);

                            currentParca.Pb.Location = box.Location;

                            currentParca.Lokasyon.X = box.Location.X / blokGenisligi;
                            currentParca.Lokasyon.Y = box.Location.Y / blokGenisligi;

                            if ((currentParca.Lokasyon.X + currentParca.Lokasyon.Y) % 2 == 0)
                            {
                                currentParca.Pb.BackColor = beyazColor;
                            }
                            else
                            {
                                currentParca.Pb.BackColor = siyahColor;
                            }

                            tahta.Parcalar.Remove(boxparca);

                            tasDokundu = false;

                            GidilebilecekYerSil();

                            hareketCal();

                            YapayZekaOyna();
                        }
                    }
                    else
                    {
                        if ((currentParca.Lokasyon.X + currentParca.Lokasyon.Y) % 2 == 0)
                        {
                            currentParca.Pb.BackColor = beyazColor;
                        }
                        else
                        {
                            currentParca.Pb.BackColor = siyahColor;
                        }

                        boxparca.Pb.BackColor = dokunmaColor;

                        currentParca = boxparca;

                        GidilebilecekYerSil();

                        List<Lokasyon> yerler = TasUtils.OynayabilecegiYerleriAl(boxparca);

                        foreach (Lokasyon lokasyon in yerler)
                        {
                            if ((lokasyon.X + lokasyon.Y) % 2 == 0)
                            {
                                paneller[lokasyon.X][lokasyon.Y].BackColor = gidilebilecekYerAcikColor;

                                if (TasUtils.tasVarMi(lokasyon))
                                {
                                    Parca pc = TasUtils.parcaAl(lokasyon);

                                    pc.Pb.BackColor = gidilebilecekYerAcikColor;
                                }
                            }
                            else
                            {
                                paneller[lokasyon.X][lokasyon.Y].BackColor = gidilebilecekYerKoyuColor;

                                if (TasUtils.tasVarMi(lokasyon))
                                {
                                    Parca pc = TasUtils.parcaAl(lokasyon);

                                    pc.Pb.BackColor = gidilebilecekYerKoyuColor;
                                }
                            }
                        }

                        sonGidilebilecekYerler = yerler;

                        tasDokundu = true;
                    }
                }
            }
            else
            {
                vurgulaHamleLabel(Color.Red);
            }
        }

        public async void vurgulaHamleLabel(Color color)
        {
            Color origin = Color.FromKnownColor(KnownColor.ControlText);

            hamleLabel.ForeColor = color;

            await Task.Delay(500);

            hamleLabel.ForeColor = origin;
        }

        public void GidilebilecekYerSil()
        {
            foreach (Lokasyon lokasyon in sonGidilebilecekYerler)
            {
                if ((lokasyon.X + lokasyon.Y) % 2 == 0)
                {
                    paneller[lokasyon.X][lokasyon.Y].BackColor = beyazColor;
                }
                else
                {
                    paneller[lokasyon.X][lokasyon.Y].BackColor = siyahColor;
                }

                if (TasUtils.tasVarMi(lokasyon))
                {
                    Parca pc = TasUtils.parcaAl(lokasyon);

                    if ((lokasyon.X + lokasyon.Y) % 2 == 0)
                    {
                        pc.Pb.BackColor = beyazColor;
                    }
                    else
                    {
                        pc.Pb.BackColor = siyahColor;
                    }
                }
            }
        }

        public List<Lokasyon> sonGidilebilecekYerler = new List<Lokasyon>();

        public void panelDokunma(object sender, MouseEventArgs args)
        {
            if (oynayabilirMi)
            {
                if (tasDokundu)
                {
                    Panel dkpanel = (Panel)sender;

                    if (dkpanel.BackColor == gidilebilecekYerAcikColor || dkpanel.BackColor == gidilebilecekYerKoyuColor)
                    {
                        Parca pc = tahta.Parcalar.ElementAt(tahta.Parcalar.FindIndex(p => p == currentParca));

                        currentParca.Pb.Location = dkpanel.Location;

                        currentParca.Lokasyon.X = dkpanel.Location.X / blokGenisligi;
                        currentParca.Lokasyon.Y = dkpanel.Location.Y / blokGenisligi;

                        if ((currentParca.Lokasyon.X + currentParca.Lokasyon.Y) % 2 == 0)
                        {
                            currentParca.Pb.BackColor = beyazColor;
                        }
                        else
                        {
                            currentParca.Pb.BackColor = siyahColor;
                        }

                        tasDokundu = false;
                        hareketCal();

                        GidilebilecekYerSil();

                        YapayZekaOyna();
                    }
                }
            }
        }

        public int dusunmeSuresi = 5000;

        public string yapayZekaAdi = "Recep";
        
        public Random random = new Random();
        public async void YapayZekaOyna()
        {
            oynayabilirMi = false;

            hamleLabel.Text = yapayZekaAdi + " düşünüyor...";

            DateTime baslamaZamani = DateTime.UtcNow;

            Hamle hamle = await YapayZeka.Oyna();
            
            TimeSpan fark = DateTime.UtcNow - baslamaZamani;

            if (fark.TotalMilliseconds > 0) 
            {
                await Task.Delay(TimeSpan.FromMilliseconds(random.Next(1000, dusunmeSuresi)) - fark);
            }

            await hamle.Yap();

            hamleLabel.Text = yapayZekaAdi + " hamle yaptı. Sıra Sizde.";

            oynayabilirMi = true;
        }

        public static void hareketCal()
        {
            windowsMediaPlayer.controls.play();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void pbGeziniyor(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;

            Parca boxparca = new Parca();

            foreach (Parca parca in tahta.Parcalar)
            {
                if (parca.Pb == box)
                {
                    boxparca = parca;
                }
            }

            lokasyonLabel.Text = boxparca.Tas.ToString() + " - " + boxparca.Lokasyon.X + ", " + boxparca.Lokasyon.Y + " - " +  boxparca.Taraf.ToString();
        }

        public void pnGeziniyor(object sender, EventArgs e)
        {
            Panel dkpanel = (Panel)sender;

            int x = dkpanel.Location.X / blokGenisligi;
            
            int y = dkpanel.Location.Y / blokGenisligi;

            lokasyonLabel.Text = "Boşluk - " + x + ", " + y;
        }

        private void recepeKarşıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tahtaParent.Controls.Clear();
            TahtaOlustur();
        }
    }
}
