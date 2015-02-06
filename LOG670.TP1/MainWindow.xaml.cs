using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }

        private void MainCanvas_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void MainCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainCanvas.GetChildren().Select(x => x.ToCollidable()).Collisions().Count().Show();
        }
    }
}
