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

        public MainWindow()
        {
            InitializeComponent();

            "---------------------------------------------------------------------------".Show();
            try
            {

                Brand b = new Brand(1, "");

                Destination d1 = new Destination(30, true);
                Destination d2 = new Destination(40, false);
                Destination d3 = new Destination(100, true);

                Vehicle c1 = new Vehicle(0, 20, d1, b);
                Vehicle c2 = new Vehicle(1, 20, d2, b);
                Vehicle c3 = new Vehicle(2, 20, d1, b);
                Vehicle c4 = new Vehicle(3, 20, d2, b);

                Lane l1 = new Lane(new List<LOG670.TP1.Classes.Object>(), new List<Destination>(), 1);
                Lane l2 = new Lane(new List<LOG670.TP1.Classes.Object>(), new List<Destination>(), 2);
                Lane l3 = new Lane(new List<LOG670.TP1.Classes.Object>() { c1, c2, c3, c4 }, new List<Destination>() { d1, d2, d3 }, 3);

                Highway h = new Highway(new List<Lane>() { l1, l2, l3 }, 30, 10);

                
                c1.StartConvoy(c2);
                c3.JoinConvoy(c2);
                c4.JoinConvoy(c3);
                c2.LeaveConvoy();
                c3.SetDestination(d3);
            } 
            catch(Exception e) 
            {
                e.Message.Show();
            }

        }

    }
}
