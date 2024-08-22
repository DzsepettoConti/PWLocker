using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PWLocker
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

        public void AddDockPanel(DockPanel dockPanel) 
        {
        MainStackPanel.Children.Add(dockPanel);
        
        } 
        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            AddForm secondwindow = new AddForm();
            secondwindow.Show();
        }
    }
}