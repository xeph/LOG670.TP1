using System;
using System.Collections.Generic;
using System.Linq;
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
            var ls = new List<Collidable<T>>(collidables);
            var cs = new HashSet<Tuple<Collidable<T>, Collidable<T>>>();

            foreach (var c1 in ls)
            {
                foreach (var c2 in ls)
                {
                    if (c1 != c2 && c1.CollidesWith(c2))
                    {
                        var t1 = Tuple.Create(c1, c2);
                        var t2 = Tuple.Create(c2, c1);
                        if (cs.Add(t1) && cs.Add(t2))
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

        public static T Show<T>(this T t, String Format = "{0}")
        {
            Console.Out.WriteLine(Format, t);
            return t;
        }

        public static IEnumerable<T> ShowCount<T>(IEnumerable<T> ts)
        {
            ts.Count().Show();
            return ts;
        }

    }
}
