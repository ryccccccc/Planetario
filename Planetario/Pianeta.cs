using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planetario
{
    internal class Pianeta
    {
        public double Massa { get; set; }
        public Vector Posizione { get; set; }
        public Vector Velocita { get; set; }
        public Vector Accelerazione { get; set; }
        public Color Colore { get; set; }

        public Pianeta(double massa, Vector posizione, Vector velocita, Color colore)
        {
            Massa = massa;
            Posizione = posizione;
            Velocita = velocita;
            Colore = colore;
        }
        public static bool operator ==(Pianeta p1, Pianeta p2)
        {
            return p1.Massa == p2.Massa && p1.Colore == p2.Colore;
        }
        public static bool operator !=(Pianeta p1, Pianeta p2)
        {
            return !(p1 == p2);
        }
        public override string ToString()
        {
            return string.Format("Massa: {0}, Posizione: {1}, Velocità: {2}", Massa, Posizione, Velocita);
        }
    }
}
