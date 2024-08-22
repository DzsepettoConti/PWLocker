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
using System.Windows.Shapes;

namespace PWLocker
{
    /// <summary>
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            // Create a new DockPanel
            DockPanel newDockPanel = new DockPanel
            {
                Height = 50,
                Width = 700,
                Margin = new Thickness(10)
            };

            // Create the TextBox
            TextBox myTextBox = new TextBox
            {
                Name = "myTextBox",
                Text = "Hello, World!",
                Width = 200,
                Height = 50,
                FontSize = 36
            };
            newDockPanel.Children.Add(myTextBox);

            // Create the first Button
            Button button1 = new Button
            {
                Height = 30,
                Width = 70,
                Margin = new Thickness(180, 0, 0, 0)
            };
            newDockPanel.Children.Add(button1);

            // Create the second Button
            Button button2 = new Button
            {
                Height = 30,
                Width = 70,
                Margin = new Thickness(10, 0, 0, 0)
            };
            newDockPanel.Children.Add(button2);

            // Create the third Button
            Button button3 = new Button
            {
                Height = 30,
                Width = 70,
                Margin = new Thickness(10, 0, 0, 0)
            };
            newDockPanel.Children.Add(button3);

            Button button4 = new Button
            {
                Height = 30,
                Width = 70,
                Margin = new Thickness(10, 0, 10, 0)
            };
            TextBlock textBlock = new TextBlock
            {
                Text = tbTitle.Text
            };
            button4.Content = textBlock;
            newDockPanel.Children.Add(button4);
            mainWindow.AddDockPanel(newDockPanel);
            this.Close();
        }
    }
}
