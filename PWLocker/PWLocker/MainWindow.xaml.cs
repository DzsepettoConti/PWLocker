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

        IFirebaseConfig fconfig = new FirebaseConfig()
        {
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
                Name = Title,
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
            string currentusername = Convert.ToString(lbUsername.Content);
            AddForm addForm = new AddForm(currentusername);
            if (addForm.ShowDialog() == true)
            {
                GenNextId();
                addButtonFunction(addForm.TitleText);
            }
        }

        async void LiveCall(string currentusername)
        {
            string databasePath = $"Users/{currentusername}/Elements/";
            MessageBox.Show(databasePath);
            FirebaseResponse res = client.Get(@$"{databasePath}");
            Dictionary<string, DockerElement> data = JsonConvert.DeserializeObject<Dictionary<string, DockerElement>>(res.Body.ToString());
            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    string elementString = item.Value.ToString();
                    elementList.Add(elementString);
                }
                File.WriteAllLines("databaseTest.txt", elementList);
            }
        }

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            string textboxName;

            MessageBoxResult valasz = MessageBox.Show("Biztos Törölni akarja az adott Egységet?", "Kérdés", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (valasz == MessageBoxResult.Yes)
            {
                Button button = sender as Button;

                DockPanel dockPanel = button.Parent as DockPanel;

                foreach (var child in dockPanel.Children)
                {
                    if (child is TextBox)
                    {
                        string currentusername = Convert.ToString(lbUsername.Content);
                        TextBox foundTextBox = (TextBox)child;
                        textboxName = foundTextBox.Name;
                        var result = client.Delete(@$"Users/{currentusername}/Elements/" + textboxName);
                    }
                }
                if (dockPanel != null)
                {
                    MainStackPanel.Children.Remove(dockPanel);
                }
            }
            else if (valasz == MessageBoxResult.No)
            {
                MessageBox.Show("A Nem gombra kattintottál.");
            }
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            LoginRegister logreg = new LoginRegister();
            logreg.btnLogin.Visibility = Visibility.Visible;
            logreg.btnRegister.Visibility = Visibility.Hidden;
            logreg.lbPasswordAgain.Visibility = Visibility.Hidden;
            logreg.tbPassword2.Visibility = Visibility.Hidden;
            if (logreg.ShowDialog() == true)
            {
                lbUsername.Content = logreg.mainUsername;
                string currentusername = Convert.ToString(lbUsername.Content);
                MessageBox.Show($"Ez a user: {currentusername}");
                LiveCall(currentusername);
                foreach (string element in elementList)
                {
                    string[] parts = element.Split(";");
                    addButtonFunction(parts[0]);
                }
            }
        }
        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            LoginRegister logreg = new LoginRegister();
            AddForm af = new AddForm();
            logreg.btnLogin.Visibility = Visibility.Hidden;
            logreg.btnRegister.Visibility = Visibility.Visible;
            logreg.lbPasswordAgain.Visibility = Visibility.Visible;
            logreg.tbPassword2.Visibility = Visibility.Visible;
            if (logreg.ShowDialog() == true)
            {
                lbUsername.Content = logreg.mainUsername;
                string currentusername = Convert.ToString(lbUsername.Content);
                LiveCall(currentusername);
            }
        }

    }
}

