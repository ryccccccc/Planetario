using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planetario
{
    internal class Planetario
    {
        public List<Pianeta> Pianeti { get; set; }

        public Planetario()
        {
            Pianeti = new List<Pianeta>();
        }

        public double G = 5;
        public double DeltaT = 3;

        public Vector ForzaTot(Pianeta p)
        {
            Vector ftot = Vector.Parse("0;0");
            foreach (Pianeta p1 in Pianeti)
            {
                if (p1.Massa == p.Massa)
                    break;
                else
                { 
                    double fg = G * p.Massa * p1.Massa / ((p1.Posizione  - p.Posizione) * (p1.Posizione - p.Posizione));
                    Vector forzaG = fg * (p1.Posizione - p.Posizione).Versore();
                    ftot = ftot + forzaG;
                }
            }
            return ftot;
        } 

        public void Muovi()
        {
            //nuova posizione per ogni pianeta  
            foreach (Pianeta p in Pianeti)
            {
                p.Accelerazione = ForzaTot(p) / p.Massa;
                p.Velocita = p.Velocita + p.Accelerazione * DeltaT;
                p.Posizione = p.Posizione + p.Velocita * DeltaT + 0.5 * p.Accelerazione * DeltaT * DeltaT;
            }
        }
    }
}
