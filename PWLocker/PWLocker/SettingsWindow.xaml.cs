using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;

namespace PWLocker
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public System.Windows.Media.Color BGColor { get; set; }
        public bool BGSetDone = false;
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void cbRedChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindowGrid.Background = new SolidColorBrush(Colors.Red);
            BGColor = System.Windows.Media.Color.FromRgb(199, 37, 62);
            BGSetDone = true;
        }
        private void cbBlueChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindowGrid.Background = new SolidColorBrush(Colors.Navy);
            BGColor = System.Windows.Media.Color.FromRgb(124, 245, 255);
            BGSetDone = true;
        }
        private void cbGreenChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindowGrid.Background = new SolidColorBrush(Colors.DarkSeaGreen);
            BGColor = System.Windows.Media.Color.FromRgb(208, 245, 190);
            BGSetDone = true;

        }
        private void cbPurpleChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindowGrid.Background = new SolidColorBrush(Colors.MediumPurple);
            BGColor = System.Windows.Media.Color.FromRgb(100, 57, 255);
            BGSetDone = true;
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
