using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroChess.Core
{
    public class YapayZeka
    {
        private static Random random = new Random();

        public static bool ilkHamleMi = true;
        public static async Task<Hamle> Oyna()
        {
            if (ilkHamleMi)
            {
                Lokasyon parcaLokasyonu = new Lokasyon() 
                { 
                    X = 3,
                    Y = 1
                };

                Parca parca = new Parca();

                foreach (Parca p in AnaEkran.tahta.Parcalar)
                {
                    if (p.Lokasyon.X == parcaLokasyonu.X && p.Lokasyon.Y == parcaLokasyonu.Y)
                    {
                        parca = p;

                        break;
                    }
                }

                ilkHamleMi = false;

                return await Task.FromResult(new Hamle() 
                { 
                    Parca = parca,
                    
                    Lokasyon = new Lokasyon() 
                    { 
                        X = 3,
                        Y = 2
                    },

                    Onem = 0
                });
            }

            List<Parca> parcalar = AnaEkran.tahta.Parcalar;

            List<Parca> beyazParcalar = new List<Parca>();
            List<Parca> siyahParcalar = new List<Parca>();

            List<Hamle> enIyiHamleler = new List<Hamle>();

            foreach (Parca p in parcalar)
            {
                if (p.Taraf == Taraf.Beyaz)
                {
                    beyazParcalar.Add(p);
                }
                else if (p.Taraf == Taraf.Siyah)
                {
                    siyahParcalar.Add(p);
                }
            }

            #region şah kontrol

            Parca sah = new Parca();

            foreach (Parca sp in siyahParcalar)
            {
                if (sp.Tas == Tas.Sah)
                {
                    sah = sp;

                    break;
                }
            }

            //şah kontrol
            foreach (Parca p in beyazParcalar)
            {
                List<Lokasyon> oy = TasUtils.OynayabilecegiYerleriAl(p);

                foreach (Lokasyon oyer in oy)
                {
                    if (oyer.X == sah.Lokasyon.X && oyer.Y == sah.Lokasyon.Y)
                    {
                        List<Lokasyon> sahinOynayabilecegiYerler = TasUtils.OynayabilecegiYerleriAl(sah);

                        foreach (Lokasyon l in sahinOynayabilecegiYerler)
                        {
                            foreach (Parca bp in beyazParcalar)
                            {
                                List<Lokasyon> bpGbYl = TasUtils.OynayabilecegiYerleriAl(bp);

                                bool gidebilirMi = false;

                                foreach (Lokasyon bpGbY in bpGbYl)
                                {
                                    if (l.X != bpGbY.X && l.Y != bpGbY.Y)
                                    {
                                        gidebilirMi = true;

                                        return await Task.FromResult(new Hamle()
                                        {
                                            Lokasyon = l,
                                            Parca = sah,
                                            Onem = TasDegerleri.TasDegeriAl(sah.Tas)
                                        });
                                    }
                                }
                            }
                        }
                    }
                }
            }

            #endregion


            #region tarama
            // depth: 2

            List<Hamle> hamleler = new List<Hamle>();
            Hamle sonHamle = new Hamle();

            foreach (Parca sp in siyahParcalar.ToList())
            {
                //yeme kontrolü
                foreach (Parca bp in beyazParcalar.ToList())
                {
                    foreach (Lokasyon l in TasUtils.OynayabilecegiYerleriAl(sp))
                    {
                        if (l.X == bp.Lokasyon.X && l.Y == bp.Lokasyon.Y)
                        {
                            if (bp.Tas != Tas.Sah) //şahı yiyemez aq
                            {
                                //yiyebilirse ekliycek
                                Hamle yemeHamle = new Hamle()
                                {
                                    Lokasyon = bp.Lokasyon,
                                    Parca = sp,
                                    Onem = 2
                                };

                                yemeHamle.Onem = TasDegerleri.TasDegeriAl(bp.Tas);

                                hamleler.Add(yemeHamle);
                            }
                        }
                    }
                }

                #region kaçma
                
                List<Lokasyon> gidebilecegiyerler = TasUtils.OynayabilecegiYerleriAl(sp);

                foreach (Parca bp in beyazParcalar)
                {
                    List<Lokasyon> gbYrlR = TasUtils.OynayabilecegiYerleriAl(bp);

                    foreach (Lokasyon yl in gbYrlR)
                    {
                        if (yl.X == sp.Lokasyon.X && yl.Y == sp.Lokasyon.Y)
                        {
                            List<Lokasyon> yiyemeyecegiyerler = new List<Lokasyon>();

                            foreach (Lokasyon lklk in gidebilecegiyerler)
                            {
                                foreach (Parca bpp in beyazParcalar)
                                {
                                    List<Lokasyon> lokasyonlargb = TasUtils.OynayabilecegiYerleriAl(bpp);

                                    foreach (Lokasyon gby in lokasyonlargb)
                                    {
                                        if (gby.X != lklk.X || gby.Y != lklk.Y)
                                        {
                                            yiyemeyecegiyerler.Add(lklk);
                                        }
                                    }
                                }
                            }

                            hamleler.Add(new Hamle()
                            { 
                                Lokasyon = yiyemeyecegiyerler[random.Next(yiyemeyecegiyerler.Count)],
                                Parca = sp,
                                Onem = (int)Math.Ceiling((double)(TasDegerleri.TasDegeriAl(sp.Tas) * (1 / 2)))
                            });
                        }
                    }
                }
                
                #endregion

                foreach (Lokasyon gby in gidebilecegiyerler.ToList())
                {
                    List<Parca> geciciSiyah = siyahParcalar;

                    geciciSiyah.Remove(sp);

                    Parca varsayimParca = new Parca()
                    {
                        Lokasyon = gby,
                        Pb = sp.Pb,
                        Taraf = sp.Taraf,
                        Tas = sp.Tas
                    };

                    geciciSiyah.Add(varsayimParca);

                    foreach (Parca gsp in geciciSiyah.ToList())
                    {
                        if (!beyazYiyebilirMi(gsp.Lokasyon, beyazParcalar))
                        {
                            hamleler.Add(new Hamle()
                            {
                                Lokasyon = gby,
                                Parca = sp,
                                Onem = 0
                            });
                        }
                    }
                }
                
            }

            #endregion

            hamleler = hamleler.ToList().OrderBy(h => h.Onem).ToList();

            hamleler.Reverse();

            sonHamle = hamleler.ToList()[0];

            return await Task.FromResult(sonHamle);
        }

        public static List<Parca> yiyebilirMiyim(Lokasyon lokasyon, List<Parca> siyahlar)
        {
            List<Parca> parcalar = new List<Parca>();

            foreach (Parca p in siyahlar)
            {
                List<Lokasyon> oY = TasUtils.OynayabilecegiYerleriAl(p);

                foreach (Lokasyon l in oY)
                {
                    if (l.X == lokasyon.X && l.Y == lokasyon.Y)
                    {
                        parcalar.Add(p);
                    }
                }
            }

            if (parcalar.Count == 0)
            {
                return null;
            }
            else
            {
                return parcalar;
            }
        }

        public static bool beyazYiyebilirMi(Lokasyon lokasyon, List<Parca> beyazParcalar)
        {
            List<Parca> parcalar = AnaEkran.tahta.Parcalar;

            foreach (Parca p in beyazParcalar)
            {
                List<Lokasyon> lok = TasUtils.OynayabilecegiYerleriAl(p);

                foreach (Lokasyon l in lok)
                {
                    if (l.X == p.Lokasyon.X)
                    {
                        if (l.Y == p.Lokasyon.Y)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
