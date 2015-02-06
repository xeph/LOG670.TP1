using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG670.TP1
{
    class Collidable<T>
    {
        public T Object { get; set; }
        public Double X { get; set; }
        public Double Y { get; set; }
        public Double Width { get; set; }
        public Double Height { get; set; }

        public Collidable(T o, Double X, Double Y, Double Width, Double Height)
        {
            this.Object = o;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        public Boolean CollidesWith(Collidable<T> other)
        {
            Double dX = this.X - other.X;
            Double dY = this.Y - other.Y;
            Collidable<T> rightest = (dX < 0) ? this : other;
            Collidable<T> topest = (dY < 0) ? this : other;

            dX = Math.Abs(dX);
            dY = Math.Abs(dY);

            return dX <= rightest.Width || dY <= topest.Height;
        }

        public string ToString()
        {
            return this.Object.ToString() + " " + X.ToString() + " " + Y.ToString() + " " + Width.ToString() + " " + Height.ToString();
        }
    }
}
