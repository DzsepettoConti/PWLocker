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

using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace PWLocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> elementList = new List<string>();
        private static int szamlalalo;
        DockerElement de;

        public MainWindow()
        {
            InitializeComponent();
        }

        IFirebaseConfig fconfig = new FirebaseConfig(){
            AuthSecret = "7o9oh4EvBAN5maV69Wbxysbi7fJ91hqsmIPEUNWd",
            BasePath = "https://pwlocker-8782c-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;
        private void mainWindowLoad(object sender, RoutedEventArgs e)
        {
            
            try
            {
                client = new FireSharp.FirebaseClient(fconfig);
            }
            catch (Exception)
            {
                MessageBox.Show("Net Error");
            }
            LiveCall();
            foreach (string element in elementList)
            {
                string[] parts = element.Split(";");
                addButtonFunction(parts[0]);
            }


        }

        public static int Szamlalalo { get => szamlalalo; set => szamlalalo = value; }

        public static int GenNextId() 
        {
            szamlalalo++;
            return szamlalalo;
        }
        public void addButtonFunction(string Title) 
        {
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
                Text = Title,
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

            // Create the fourth Button with TextBlock content
            Button button4 = new Button
            {
                Content = "Remove",
                Height = 30,
                Width = 70,
                Margin = new Thickness(10, 0, 10, 0)
            };
            button4.Click += deleteButtonClick;

            newDockPanel.Children.Add(button4);

            // Add the DockPanel to the StackPanel
            MainStackPanel.Children.Add(newDockPanel);
        }
        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            AddForm addForm = new AddForm();
            if (addForm.ShowDialog() == true) 
            {
                GenNextId();
                addButtonFunction(addForm.TitleText);
            }
        }
        private async void syncButtonClick(object sender, RoutedEventArgs e)
        {
            LiveCall();
        }

        async void LiveCall() 
        {
            FirebaseResponse res = client.Get(@"Elemets");
            Dictionary<string, DockerElement> data = JsonConvert.DeserializeObject<Dictionary<string, DockerElement>>(res.Body.ToString());
            foreach (var item in data) 
            {
                string elementString = item.Value.ToString();
                elementList.Add(elementString);
            }
            File.WriteAllLines("databaseTest.txt", elementList);
        }

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            
            Button button = sender as Button;

            DockPanel dockPanel = button.Parent as DockPanel;

            if (dockPanel != null)
            {
                MainStackPanel.Children.Remove(dockPanel);
                MessageBox.Show("Törölve");
            }
        }
    }
}

