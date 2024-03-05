using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planetario
{
    internal readonly struct Vector
    {
        private readonly double x;
        private readonly double y;

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }

        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
        }

        //Metodi
        public double Modulo()
        {
            Vector v = new Vector(X, Y);
            return (double)Math.Sqrt((v.X * v.X) + (v.Y * v.Y));
        }
        public Vector Versore()
        {
            Vector v = new Vector(X, Y);
            double mod = v.Modulo();
            return v / mod;
        }

        //Overload degli Operatori
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static Vector operator +(Vector v)
        {
            return v;
        }
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }
        public static double operator *(Vector v1, Vector v2)
        {
            return v1.Modulo() * v2.Modulo();
        }
        public static Vector operator *(double n, Vector v)
        {
            return new Vector(n * v.X, n * v.Y);
        }
        public static Vector operator *(Vector v, double n)
        {
            return new Vector(v.X * n, v.Y * n);
        }
        public static Vector operator /(Vector v1, Vector v2)
        {
            return new Vector(v1.X / v2.X, v1.Y / v2.Y);
        }
        public static Vector operator /(Vector v, double n)
        {
            return new Vector(v.X / n, v.Y / n);
        }
        public static bool operator ==(Vector v1, Vector v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        //Parse
        public override string ToString()
        {
            return string.Format("{0};{1}", X, Y);
        }
        public static Vector Parse(string txt)
        {
            var parts = txt.Split(';');
            double a = double.Parse(parts[0]);
            double b = double.Parse(parts[1]);
            Vector vp = new Vector(a, b);
            return vp;
        }

        public static bool TryParse(string s, ref Vector v)
        {
            String[] parts = s.Split(';');
            if (parts.Length != 2)
            {
                return false;
            }

            int n;
            if (int.TryParse(parts[0], out n))
            {
                return false;
            }
            int d;
            if (int.TryParse(parts[0], out d))
            {
                return false;
            }
            v = new Vector(n, d);
            return true;
        }
    }
}
