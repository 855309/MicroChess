using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroChess.Core
{
    public class TasUtils
    {
        public static List<Lokasyon> OynayabilecegiYerleriAl(Parca parca)
        {
            List<Lokasyon> yerler = new List<Lokasyon>();

            if (parca.Tas == Tas.Piyon)
            {
                yerler = PiyonOynayabilecegiYerleriAl(parca);
            }
            else if (parca.Tas == Tas.At)
            {
                yerler = AtOynayabilecegiYerleriAl(parca);
            }
            else if (parca.Tas == Tas.Kale)
            {
                yerler = KaleOynayabilecegiYerleriAl(parca);
            }
            else if (parca.Tas == Tas.Fil)
            {
                yerler = FilOynayabilecegiYerleriAl(parca);
            }
            else if (parca.Tas == Tas.Vezir)
            {
                yerler = VezirOynayabilecegiYerleriAl(parca);
            }
            else if (parca.Tas == Tas.Sah)
            {
                yerler = SahOynayabilecegiYerleriAl(parca);
            }

            foreach (Lokasyon lk in yerler.ToList())
            {
                if (lk.X >= 8)
                {
                    yerler.Remove(lk);
                }

                if (lk.X < 0)
                {
                    yerler.Remove(lk);
                }

                if (lk.Y >= 8)
                {
                    yerler.Remove(lk);
                }

                if (lk.Y < 0)
                {
                    yerler.Remove(lk);
                }
            }

            return yerler;
        }

        public static List<Lokasyon> PiyonOynayabilecegiYerleriAl(Parca piyon)
        {
            List<Lokasyon> yerler = new List<Lokasyon>();

            if (piyon.Taraf == Taraf.Beyaz)
            {
                if (piyon.Lokasyon.Y == 6)
                {
                    yerler.Add(new Lokasyon() 
                    { 
                        X = piyon.Lokasyon.X,
                        Y = piyon.Lokasyon.Y - 1
                    });

                    yerler.Add(new Lokasyon()
                    {
                        X = piyon.Lokasyon.X,
                        Y = piyon.Lokasyon.Y - 2
                    });
                }
                else
                {
                    if (piyon.Lokasyon.Y - 1 < 8)
                    {
                        if (piyon.Lokasyon.Y - 1 > 0)
                        {
                            yerler.Add(new Lokasyon()
                            {
                                X = piyon.Lokasyon.X,
                                Y = piyon.Lokasyon.Y - 1
                            });
                        }
                    }
                }
            }
            else
            {
                if (piyon.Lokasyon.Y == 1)
                {
                    yerler.Add(new Lokasyon()
                    {
                        X = piyon.Lokasyon.X,
                        Y = piyon.Lokasyon.Y + 1
                    });

                    yerler.Add(new Lokasyon()
                    {
                        X = piyon.Lokasyon.X,
                        Y = piyon.Lokasyon.Y + 2
                    });
                }
                else
                {
                    if (piyon.Lokasyon.Y - 1 < 8)
                    {
                        if (piyon.Lokasyon.Y - 1 > 0)
                        {
                            yerler.Add(new Lokasyon()
                            {
                                X = piyon.Lokasyon.X,
                                Y = piyon.Lokasyon.Y + 1
                            });
                        }
                    }
                }
            }

            foreach (Lokasyon lk in yerler.ToList())
            {
                if (tasVarMi(lk))
                {
                    yerler.Remove(lk);
                }
            }

            if (piyon.Taraf == Taraf.Beyaz)
            {
                Lokasyon l1 = new Lokasyon()
                {
                    X = piyon.Lokasyon.X + 1,
                    Y = piyon.Lokasyon.Y - 1
                };

                Lokasyon l2 = new Lokasyon()
                {
                    X = piyon.Lokasyon.X - 1,
                    Y = piyon.Lokasyon.Y - 1
                };

                if (tasVarMi(l1))
                {
                    if (parcaAl(l1).Taraf != piyon.Taraf)
                    {
                        yerler.Add(l1);
                    }
                }

                if (tasVarMi(l2))
                {
                    if (parcaAl(l2).Taraf != piyon.Taraf)
                    {
                        yerler.Add(l2);
                    }
                }
            }
            else
            {
                Lokasyon l1 = new Lokasyon()
                {
                    X = piyon.Lokasyon.X + 1,
                    Y = piyon.Lokasyon.Y + 1
                };

                Lokasyon l2 = new Lokasyon()
                {
                    X = piyon.Lokasyon.X - 1,
                    Y = piyon.Lokasyon.Y + 1
                };

                if (tasVarMi(l1))
                {
                    if (parcaAl(l1).Taraf != piyon.Taraf)
                    {
                        yerler.Add(l1);
                    }
                }

                if (tasVarMi(l2))
                {
                    if (parcaAl(l2).Taraf != piyon.Taraf)
                    {
                        yerler.Add(l2);
                    }
                }
            }

            return yerler;
        }

        public static bool tasVarMi(Lokasyon lokasyon)
        {
            List<Parca> pc = AnaEkran.tahta.Parcalar;
            foreach (Parca parca in pc)
            {
                if (parca.Lokasyon.X == lokasyon.X)
                {
                    if (parca.Lokasyon.Y == lokasyon.Y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Parca parcaAl(Lokasyon lokasyon)
        {
            foreach (Parca parca in AnaEkran.tahta.Parcalar)
            {
                if (parca.Lokasyon.X == lokasyon.X)
                {
                    if (parca.Lokasyon.Y == lokasyon.Y)
                    {
                        return parca;
                    }
                }
            }

            return null;
        }

        public static List<Lokasyon> caprazAl(Lokasyon lokasyon)
        {
            return null;
        }

        public static void parcaOynat(Parca parca, Lokasyon lokasyon)
        {
            AnaEkran.tahta.Parcalar.ElementAt(AnaEkran.tahta.Parcalar.FindIndex(p => p == parca)).Lokasyon = lokasyon;
            AnaEkran.tahta.Parcalar.ElementAt(AnaEkran.tahta.Parcalar.FindIndex(p => p == parca)).Pb.Location = AnaEkran.paneller[lokasyon.X][lokasyon.Y].Location;

            if ((parca.Lokasyon.X + AnaEkran.tahta.Parcalar.ElementAt(AnaEkran.tahta.Parcalar.FindIndex(p => p == parca)).Lokasyon.Y) % 2 == 0)
            {
                AnaEkran.tahta.Parcalar.ElementAt(AnaEkran.tahta.Parcalar.FindIndex(p => p == parca)).Pb.BackColor = AnaEkran.beyazColor;
            }
            else
            {
                AnaEkran.tahta.Parcalar.ElementAt(AnaEkran.tahta.Parcalar.FindIndex(p => p == parca)).Pb.BackColor = AnaEkran.siyahColor;
            }
        }

        public static List<Lokasyon> AtOynayabilecegiYerleriAl(Parca at)
        {
            List<Lokasyon> yerler = new List<Lokasyon>();

            // y - 2 & x + 1
            // y - 2 & x - 1
            // y - 1 & x + 2
            // y - 1 & x - 2
            // ------------
            // y + 2 & x + 1
            // y + 2 & x - 1
            // y + 1 & x + 2
            // y + 1 & x - 2

            Lokasyon l1 = new Lokasyon()
            {
                X = at.Lokasyon.X + 1,
                Y = at.Lokasyon.Y - 2
            };

            Lokasyon l2 = new Lokasyon()
            {
                X = at.Lokasyon.X - 1,
                Y = at.Lokasyon.Y - 2
            };

            Lokasyon l3 = new Lokasyon()
            {
                X = at.Lokasyon.X + 2,
                Y = at.Lokasyon.Y - 1
            };

            Lokasyon l4 = new Lokasyon()
            {
                X = at.Lokasyon.X - 2,
                Y = at.Lokasyon.Y - 1
            };

            Lokasyon l5 = new Lokasyon()
            {
                X = at.Lokasyon.X + 1,
                Y = at.Lokasyon.Y + 2
            };

            Lokasyon l6 = new Lokasyon()
            {
                X = at.Lokasyon.X - 1,
                Y = at.Lokasyon.Y + 2
            };

            Lokasyon l7 = new Lokasyon()
            {
                X = at.Lokasyon.X + 2,
                Y = at.Lokasyon.Y + 1
            };

            Lokasyon l8 = new Lokasyon()
            {
                X = at.Lokasyon.X - 2,
                Y = at.Lokasyon.Y + 1
            };

            yerler.Add(l1);
            yerler.Add(l2);
            yerler.Add(l3);
            yerler.Add(l4);
            yerler.Add(l5);
            yerler.Add(l6);
            yerler.Add(l7);
            yerler.Add(l8);

            foreach (Lokasyon l in yerler.ToList())
            {
                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf == at.Taraf)
                    {
                        yerler.Remove(l);
                    }
                }
            }

            return yerler;
        }

        public static List<Lokasyon> KaleOynayabilecegiYerleriAl(Parca kale)
        {
            List<Lokasyon> yerler = DikeyVeYatayLokasyonlariAl(kale);

            return yerler;
        }

        public static List<Lokasyon> DikeyVeYatayLokasyonlariAl(Parca parca)
        {
            List<Lokasyon> yerler = new List<Lokasyon>();

            Lokasyon lokasyon = parca.Lokasyon;

            for (int xu = lokasyon.X + 1; xu < 8; xu++)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = xu,
                    Y = lokasyon.Y
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            for (int xa = lokasyon.X - 1; xa >= 0; xa--)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = xa,
                    Y = lokasyon.Y
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            for (int yu = lokasyon.Y + 1; yu < 8; yu++)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = lokasyon.X,
                    Y = yu
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            for (int ya = lokasyon.Y - 1; ya >= 0; ya--)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = lokasyon.X,
                    Y = ya
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            foreach (Lokasyon l in yerler.ToList())
            {
                if (l.X == parca.Lokasyon.X)
                {
                    if (l.Y == parca.Lokasyon.Y)
                    {
                        yerler.Remove(l);
                    }
                }
            }

            return yerler;
        }

        public static List<Lokasyon> CaprazLokasyonlariAl(Parca parca)
        {
            List<Lokasyon> yerler = new List<Lokasyon>();

            Lokasyon lokasyon = parca.Lokasyon;

            for (int xu = lokasyon.X + 1, yu = lokasyon.Y + 1; xu < 8 && yu < 8; xu++, yu++)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = xu,
                    Y = yu
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            for (int xu = lokasyon.X - 1, yu = lokasyon.Y + 1; 0 <= xu && yu < 8; xu--, yu++)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = xu,
                    Y = yu
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            for (int xu = lokasyon.X + 1, yu = lokasyon.Y - 1; xu < 8 && 0 <= yu; xu++, yu--)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = xu,
                    Y = yu
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            for (int xu = lokasyon.X - 1, yu = lokasyon.Y - 1; 0 <= xu && 0 <= yu; xu--, yu--)
            {
                Lokasyon l = new Lokasyon()
                {
                    X = xu,
                    Y = yu
                };

                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf != parca.Taraf)
                    {
                        yerler.Add(l);
                    }

                    break;
                }
                else
                {
                    yerler.Add(l);
                }
            }

            foreach (Lokasyon l in yerler.ToList())
            {
                if (l.X == parca.Lokasyon.X)
                {
                    if (l.Y == parca.Lokasyon.Y)
                    {
                        yerler.Remove(l);
                    }
                }
            }

            return yerler;
        }

        public static List<Lokasyon> FilOynayabilecegiYerleriAl(Parca fil)
        {
            List<Lokasyon> yerler = CaprazLokasyonlariAl(fil);

            return yerler;
        }

        public static List<Lokasyon> VezirOynayabilecegiYerleriAl(Parca vezir)
        {
            List<Lokasyon> yerler = new List<Lokasyon>();

            List<Lokasyon> caprazYerler = CaprazLokasyonlariAl(vezir);

            List<Lokasyon> yatayDikeyYerler = DikeyVeYatayLokasyonlariAl(vezir);

            foreach (Lokasyon p in caprazYerler)
            {
                yerler.Add(p);
            }

            foreach (Lokasyon p in yatayDikeyYerler)
            {
                yerler.Add(p);
            }

            return yerler;
        }

        public static List<Lokasyon> SahOynayabilecegiYerleriAl(Parca sah)
        {
            List<Lokasyon> yerler = new List<Lokasyon>();

            yerler.Add(new Lokasyon() 
            { 
                X = sah.Lokasyon.X + 1,
                Y = sah.Lokasyon.Y
            });

            yerler.Add(new Lokasyon()
            {
                X = sah.Lokasyon.X - 1,
                Y = sah.Lokasyon.Y
            });

            yerler.Add(new Lokasyon()
            {
                X = sah.Lokasyon.X,
                Y = sah.Lokasyon.Y + 1
            });

            yerler.Add(new Lokasyon()
            {
                X = sah.Lokasyon.X,
                Y = sah.Lokasyon.Y - 1
            });

            foreach (Lokasyon l in yerler.ToList())
            {
                if (tasVarMi(l))
                {
                    if (parcaAl(l).Taraf == sah.Taraf)
                    {
                        yerler.Remove(l);
                    }
                }
            }

            return yerler;
        }
    }
}
