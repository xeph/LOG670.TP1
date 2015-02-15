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
                Lane l3 = new Lane(new List<LOG670.TP1.Classes.Object>() {c1, c2, c3, c4},
                    new List<Destination>() {d1, d2, d3}, 3);

                Highway h = new Highway(new List<Lane>() {l1, l2, l3}, 30, 10);


                c1.StartConvoy(c2);
                c3.JoinConvoy(c2);
                c4.JoinConvoy(c3);
                c2.LeaveConvoy();
                c3.SetDestination(d3);
            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_ChangeLane()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>() , new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);


                ve1.ChangeLane(la1);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_ChangeLane2()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);


                ve1.ChangeLane(la2);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        /// <summary>
        /// impossible
        /// </summary>
        public void Labo1_Test_ChangeLane3()
        {
        }


        public void Labo1_Test_JoinConvoy()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);
                Vehicle ve3 = new Vehicle(5, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);


                ve2.JoinConvoy(ve1);
                ve3.JoinConvoy(ve2);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_JoinConvoy2()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);
                Vehicle ve3 = new Vehicle(5, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);


                ve2.JoinConvoy(ve1);
                ve3.JoinConvoy(ve1);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_JoinConvoy3()
        {
        }

        public void Labo1_Test_JoinConvoy4()
        {
        }

        public void Labo1_Test_JoinConvoy5()
        {
        }

        public void Labo1_Test_JoinConvoy6()
        {
        }

        public void Labo1_Test_JoinConvoy7()
        {
        }

        public void Labo1_Test_JoinConvoy8()
        {
        }

        public void Labo1_Test_JoinConvoy9()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);
                Vehicle ve3 = new Vehicle(5, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);


                ve2.JoinConvoy(ve1);
                ve2.TheNavigator.IsActive = false;
                ve3.JoinConvoy(ve1);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }

        }

        public void Labo1_Test_LeaveConvoy()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);
                Vehicle ve3 = new Vehicle(5, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve2.JoinConvoy(ve1);
                ve3.JoinConvoy(ve1);

                ve2.LeaveConvoy();


            }
            catch (Exception e)
            {
                e.Message.Show();
            }

        }

        public void Labo1_Test_LeaveConvoy2()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);
                Vehicle ve3 = new Vehicle(5, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);


                ve2.LeaveConvoy();

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_LeaveConvoy3()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);
                Vehicle ve3 = new Vehicle(5, 70, null, br2);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve2.JoinConvoy(ve1);
                ve2.TheNavigator.IsActive = false;
                ve2.LeaveConvoy();


            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_LeaveConvoy4()
        {
        }

        public void Labo1_Test_LeaveConvoy5()
        {
        }

        public void Labo1_Test_SetDestination()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");

                Destination de1 = new Destination(6, true);
                Destination de2 = new Destination(12, true);

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
              
                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve1.SetDestination(de1);
                ve1.SetDestination(de2);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_SetDestination2()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");

                Destination de1 = new Destination(6, true);
                Destination de2 = new Destination(12, true);

                Vehicle ve1 = new Vehicle(6, 70, null, br1);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve1.SetDestination(de2);
                ve1.SetDestination(de2);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_SetDestination3()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");

                Destination de1 = new Destination(6, true);
                Destination de2 = new Destination(12, true);

                Vehicle ve1 = new Vehicle(6, 70, null, br1);

                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve1.SetDestination(de1);
                ve1.TheNavigator.IsActive = false;
                ve1.SetDestination(de2);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_SetDestination4()
        {
        }

        public void Labo1_Test_StartConvoy()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);
                
               
                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2}, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2}, 100, 60);

                ve2.StartConvoy(ve1);
                
            }
            catch (Exception e)
            {
                e.Message.Show();
            }

        }

        public void Labo1_Test_StartConvoy2()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);


                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve2.StartConvoy(ve1);
                ve2.StartConvoy(ve1);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_StartConvoy3()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);


                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve1.StartConvoy(ve2);
                ve2.StartConvoy(ve1);

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_StartConvoy4()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);


                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve1.TheNavigator.IsActive = true;
                ve1.StartConvoy(ve2);


            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_StartConvoy5()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Vehicle ve2 = new Vehicle(7, 70, null, br2);


                Lane la1 = new Lane(new List<Classes.Object>(), new List<Destination>(), 1);
                Lane la2 = new Lane(new List<Classes.Object>() { ve1, ve2 }, new List<Destination>(), 2);

                Highway h = new Highway(new List<Lane> { la1, la2 }, 100, 60);

                ve2.TheNavigator.IsActive = true;
                ve1.StartConvoy(ve2);
               

            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Labo1_Test_StartConvoy6()
        {
        }

        public void Labo1_Test_StartConvoy7()
        {
        }

        public void Labo1_Test_StartConvoy8()
        {
        }

        public void Labo1_Test_StartConvoy9()
        {
        }

        public void Operation_Garage_RepairVehicle_CannotRepair()
        {

            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");
                Brand br2 = new Brand(2, "Honda");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Garage g1 = new Garage(6, new List<Brand>() { br2 });

                ve1.TheNavigator.Engine.IsOk = false;

                g1.RepairVehicle(ve1);
            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Operation_Garage_RepairVehicle_NoNeed()
        {
            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Garage g1 = new Garage(6, new List<Brand>() { br1 });

                ve1.TheNavigator.Engine.IsOk = true;

                g1.RepairVehicle(ve1);
            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Operation_Garage_RepairVehicle_NotAtPosition()
        {
            "---------------------------------------------------------------------------".Show();
            try
            {
                Brand br1 = new Brand(3, "Toyota");

                Vehicle ve1 = new Vehicle(6, 70, null, br1);
                Garage g1 = new Garage(7, new List<Brand>(){br1});

                ve1.TheNavigator.Engine.IsOk = false;

                g1.RepairVehicle(ve1);
            }
            catch (Exception e)
            {
                e.Message.Show();
            }
        }

        public void Operation_Garage_RepairVehicle_PostConditionFalse()
        {
        }

        public void Operation_Garage_RepairVehicle_PostConditionTrue()
        {
        }
    }
}