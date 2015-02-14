using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using LOG670.TP1.Classes;

namespace LOG670.TP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double speed = 0;
        List<Canvas> Lanes = new List<Canvas>();

        Rectangle Car = new Rectangle();

        public MainWindow()
        {
            InitializeComponent();
            //Lane1.GetChildren().Select(x => x.ToCollidable()).Collisions().Count().Show();

            // Add the lanes
            Lanes.Add(Lane0);
            Lanes.Add(Lane1);
            Lanes.Add(Lane2);
            Lanes.Add(Lane3);

            Car.Width = 50;
            Car.Height = 50;
            Car.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Car.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Car.Fill = Brushes.CornflowerBlue;
            Lane2.Children.Add(Car);

            Destination destination1 = new Destination(30, true);
            Destination destination2 = new Destination(40, false);
            Destination destination3 = new Destination(100, true);

            Vehicle c1 = new Vehicle(0, 20, destination1, null);
            Vehicle c2 = new Vehicle(0, 20, destination2, null);
            Vehicle c3 = new Vehicle(0, 20, destination1, null);
            Vehicle c4 = new Vehicle(0, 20, destination2, null);

            c1.StartConvoy(c2);
            c3.JoinConvoy(c1);
            c4.JoinConvoy(c2);
            c1.LeaveConvoy();
            c1.SetDestination(destination3);

        }

        private Boolean ValidateInvariants()
        {

            return Lanes.All(l => l.GetChildren().Select(x => x.ToCollidable()).Collisions().Count() == 0);
        }

        private void ChangeLane(Rectangle r, Boolean left)
        {
            Canvas currentLane = r.Parent as Canvas;
            if (currentLane == null)
                return;


            int index = Lanes.IndexOf(currentLane);

            if (left)
                index--;
            else //right
                index++;

            if (index < 0 || index > Lanes.Count - 1)
                return;

            currentLane.Children.Remove(r);
            Lanes[index].Children.Add(r);
            ValidateInvariants().Show("Invariant validation: {0}");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    speed++;
                    speed.Show("Speed is now: {0}");
                    break;
                case Key.Down:
                    speed--;
                    speed.Show("Speed is now: {0}");
                    break;
                case Key.Left:
                    ChangeLane(Car, true);
                    break;
                case Key.Right:
                    ChangeLane(Car, false);
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rectangle r = new Rectangle();
            r.Width = 50;
            r.Height = 50;
            r.Fill = Brushes.CornflowerBlue;
            Lane0.Children.Add(r);
        }
    }
}
