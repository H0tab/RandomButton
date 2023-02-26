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

namespace RandomButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random;

        public MainWindow()
        {
            InitializeComponent();

            random = new();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SpawnButton();
        }

        private void SpawnButton()
        {
            var button = new Button();

            button.Width = 50;
            button.Height = 50;

            double minLeft = button.Width - MainGrid.ActualWidth;
            double maxLeft = MainGrid.ActualWidth - button.Width;
            double minTop = button.Height - MainGrid.ActualHeight;
            double maxTop = MainGrid.ActualHeight - button.Height;

            double left = RandomBetween(minLeft, maxLeft);
            double top = RandomBetween(minTop, maxTop);
            button.Margin = new Thickness(left, top, 0, 0);

            button.Click += (s, e) =>
            {
                MainGrid.Children.Remove((Button) s);

                SpawnButton();
            };

            MainGrid.Children.Add(button);
        }

        private double RandomBetween(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
