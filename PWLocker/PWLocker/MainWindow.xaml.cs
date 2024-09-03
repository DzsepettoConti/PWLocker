﻿using System.Text;
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
        DockerElement de = new DockerElement();
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
        private async void mainWindowLoad(object sender, RoutedEventArgs e)
        {
            //WebWatcher watcher = new WebWatcher();
            //await watcher.StartMonitoring();


            lbUsername.Visibility = Visibility.Hidden;
            try
            {
                client = new FireSharp.FirebaseClient(fconfig);
            }
            catch (Exception)
            {
                MessageBox.Show("Net Error");
            }
        }

        public static int GenNextId()
        {
            szamlalalo++;
            return szamlalalo;

        }
        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            string currentusername = Convert.ToString(lbUsername.Content);
            AddForm addForm = new AddForm(currentusername);
            if (addForm.ShowDialog() == true)
            {
                GenNextId();
                de.addButtonFunction(addForm.TitleText, mainStackPanel, CopyUsernameClick, CopyEmailClick, CopyPasswordClick, deleteButtonClick);
            }
        }

        async void LiveCall(string currentusername)
        {
            string databasePath = $"Users/{currentusername}/Elements/";
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
        private void CopyUsernameClick(object sender, RoutedEventArgs e)
        {
            string textboxName;
            Button button = sender as Button;

            DockPanel dockPanel = button.Parent as DockPanel;
            Border border = dockPanel.Parent as Border;
            if (dockPanel != null)
            {
                foreach (var child in dockPanel.Children)
                {
                    if (child is Label)
                    {
                        string currentusername = Convert.ToString(lbUsername.Content);
                        Label foundLabel = (Label)child;
                        string foundLabelText = foundLabel.Name;
                        foreach (string element in elementList)
                        {
                            string[] parts = element.Split(";");

                            if (parts[0] == foundLabelText)
                            {

                                Clipboard.SetText(parts[1]);
                            }

                        }

                    }
                }
            }
        }
        private void CopyEmailClick(object sender, RoutedEventArgs e)
        {
            string textboxName;
            Button button = sender as Button;

            DockPanel dockPanel = button.Parent as DockPanel;
            Border border = dockPanel.Parent as Border;
            if (dockPanel != null)
            {
                foreach (var child in dockPanel.Children)
                {
                    if (child is Label)
                    {
                        string currentusername = Convert.ToString(lbUsername.Content);
                        Label foundLabel = (Label)child;
                        string foundLabelText = foundLabel.Name;
                        foreach (string element in elementList)
                        {
                            string[] parts = element.Split(";");

                            if (parts[0] == foundLabelText)
                            {

                                Clipboard.SetText(parts[2]);
                            }

                        }

                    }
                }
            }
        }
        private void CopyPasswordClick(object sender, RoutedEventArgs e)
        {

            string textboxName;

            Button button = sender as Button;

            DockPanel dockPanel = button.Parent as DockPanel;
            Border border = dockPanel.Parent as Border;
            if (dockPanel != null)
            {
                foreach (var child in dockPanel.Children)
                {
                    if (child is Label)
                    {
                        string currentusername = Convert.ToString(lbUsername.Content);
                        Label foundLabel = (Label)child;
                        string foundLabelText = foundLabel.Name;
                        foreach (string element in elementList)
                        {
                            string[] parts = element.Split(";");

                            if (parts[0] == foundLabelText)
                            {
                                EncryptDecrypt ec = new EncryptDecrypt(Convert.ToString(foundLabelText.Length), Convert.ToString(foundLabelText.Length));
                                string DecryptToClipboard = ec.Decrypt(parts[3]);
                                Clipboard.SetText(DecryptToClipboard);
                            }

                        }

                    }
                }
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
                Border border = dockPanel.Parent as Border;
                if (dockPanel != null)
                {

                    foreach (var child in dockPanel.Children)
                    {
                        if (child is Label)
                        {
                            string currentusername = Convert.ToString(lbUsername.Content);
                            Label foundLabel = (Label)child;
                            string foundLabelText = foundLabel.Name;

                            var result = client.Delete(@$"Users/{currentusername}/Elements/" + foundLabelText);
                        }
                    }
                }
                if (border != null)
                {
                    mainStackPanel.Children.Remove(border);
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
                lbUsername.Visibility = Visibility.Visible;
                lbUsername.Margin = new Thickness(750, 23, 0, 0);
                btnRegister.Visibility = Visibility.Hidden;
                btnLogin.Visibility = Visibility.Hidden;
                string currentusername = Convert.ToString(lbUsername.Content);

                LiveCall(currentusername);
                foreach (string element in elementList)
                {
                    string[] parts = element.Split(";");
                    if (mainStackPanel != null)
                    {
                        de.addButtonFunction(parts[0], mainStackPanel, CopyUsernameClick, CopyEmailClick, CopyPasswordClick, deleteButtonClick);
                    }
                    else
                    {
                        MessageBox.Show("mainStackPanel is null");
                    }

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
                lbUsername.Visibility = Visibility.Visible;
                lbUsername.Margin = new Thickness(750, 23, 0, 0);
                btnRegister.Visibility = Visibility.Hidden;
                btnLogin.Visibility = Visibility.Hidden;
                string currentusername = Convert.ToString(lbUsername.Content);
                LiveCall(currentusername);
            }
        }

    }
}

