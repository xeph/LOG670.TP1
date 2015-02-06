using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LOG670.TP1
{
    static class Extensions
    {
        public static IEnumerable<UIElement> GetChildren(this Canvas c)
        {
            foreach(UIElement uie in c.Children)
            {
                yield return uie;
            }
        }

        public static Collidable<UIElement> ToCollidable(this UIElement e)
        {
            var fe = e as FrameworkElement;
            if (fe == null)
            {
                return new Collidable<UIElement>(e, Double.NaN, Double.NaN, Double.NaN, Double.NaN);
            }
            var p = fe.TranslatePoint(new Point(0.0, 0.0), null);
            var c = new Collidable<UIElement>(e, p.X, p.Y, fe.ActualWidth, fe.ActualHeight);
            c.Show();
            return c;
        }

        public static IEnumerable<Tuple<Collidable<T>, Collidable<T>>> Collisions<T>(this IEnumerable<Collidable<T>> collidables)
        {
            var Collisions = new HashSet<Tuple<Collidable<T>, Collidable<T>>>();
            foreach (var c1 in collidables)
            {
                foreach (var c2 in collidables)
                {
                    if (c1 != c2 && c1.CollidesWith(c2))
                    {
                        var t1 = new Tuple<Collidable<T>, Collidable<T>>(c1, c2);
                        var t2 = new Tuple<Collidable<T>, Collidable<T>>(c2, c1);
                        if(Collisions.Add(t1) && Collisions.Add(t2))
                        {
                            yield return t1;
                        }
                    }
                }
            }
        }

        public static T Show<T>(this T t)
        {
            Console.Out.WriteLine(t.ToString());
            return t;
        }
    }
}
