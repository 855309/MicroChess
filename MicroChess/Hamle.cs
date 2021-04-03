using MicroChess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroChess
{
    public class Hamle
    {
        public Parca Parca { get; set; }
        public Lokasyon Lokasyon { get; set; }
        public int Onem { get; set; } // yeme = 2, kacma = 1, normal = 0

        public Task Yap()
        {
            if (TasUtils.tasVarMi(Lokasyon))
            {
                Parca ordakiParca = TasUtils.parcaAl(Lokasyon);

                AnaEkran.tahta.Parent.Controls.Remove(ordakiParca.Pb);

                AnaEkran.tahta.Parcalar.Remove(ordakiParca);

                TasUtils.parcaOynat(Parca, Lokasyon);
            }
            else
            {
                TasUtils.parcaOynat(Parca, Lokasyon);
            }

            AnaEkran.hareketCal();

            return Task.CompletedTask;
        }
    }
}
