using FireSharp.Config;
using FireSharp.Interfaces;
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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace PWLocker
{
    /// <summary>
    /// Interaction logic for LoginRegister.xaml
    /// </summary>
    public partial class LoginRegister : Window
    {
        List<string> userList = new List<string>();
        public  string mainUsername, mainPassword;

        public bool pwOK;
        public LoginRegister()
        {
            InitializeComponent();
        }
        IFirebaseConfig fconfig = new FirebaseConfig()
        {
            AuthSecret = "7o9oh4EvBAN5maV69Wbxysbi7fJ91hqsmIPEUNWd",
            BasePath = "https://pwlocker-8782c-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        private void LoginRegisterWindowLoad(object sender, RoutedEventArgs e)
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

        private void pwCheck()
        {
            if (tbPassword.Text.Length > 5)
            {
                if (tbPassword.Text != tbPassword2.Text)
                {
                    MessageBox.Show("Nem egyeznek a jelszók");
                    pwOK = false;
                }
                else
                {
                    pwOK = true;
                }
            }
            else
            {
                MessageBox.Show("A jelszava nem éri el a minimum 5 karaktert");
                pwOK = false;
            }
        }


        private void lrWindowLoginClick(object sender, RoutedEventArgs e)
        {
            mainUsername = tbUsername.Text;
            mainPassword = tbPassword.Text;

            userList.Clear();
            MainUser mu = new MainUser(mainUsername, mainPassword);

            FirebaseResponse res = client.Get(@"Users");
            string datatest = res.Body;

            Dictionary<string, MainUser> data = JsonConvert.DeserializeObject<Dictionary<string, MainUser>>(res.Body.ToString());
            bool userExists = false;
            foreach (var item in data)
            {
                string elementString = item.Value.ToString();
                userList.Add(elementString);
            }
            foreach (string element in userList)
            {
                string[] parts = element.Split(";");
                if (parts[0] == mainUsername)
                {
                    if (parts[1] == mainPassword)
                    {
                        MessageBox.Show($"Sikeres bejelentkezés ide: {mainUsername}");
                        this.DialogResult = true;
                    }
                    else 
                    {
                        MessageBox.Show("Helytelen a password");
                        break;
                    }
                }
            }
            
        }


        
        private void lrWindowRegisterClick(object sender, RoutedEventArgs e)
        {
            mainUsername = tbUsername.Text;
            mainPassword = tbPassword.Text;

            userList.Clear();
            MainUser mu = new MainUser(mainUsername, mainPassword);

            FirebaseResponse res = client.Get(@"Users");
            string datatest = res.Body;

            Dictionary<string, MainUser> data = JsonConvert.DeserializeObject<Dictionary<string, MainUser>>(res.Body.ToString());
            bool userExists = false;
            foreach (var item in data)
            {
                string elementString = item.Value.ToString();
                userList.Add(elementString);
            }
            foreach (string element in userList)
            {
                string[] parts = element.Split(";");
                if (parts[0] == mainUsername)
                {
                    userExists = true;
                    break;
                }
            }
            if (userExists)
            {
                MessageBox.Show($"Van már ilyen User: {mainUsername}");
            }
            else
            {
                pwCheck();
                if (pwOK)
                {
                    var setter = client.Set("Users/" + tbUsername.Text, mu);
                    MessageBox.Show("Felhasználó létre hozva");
                    this.DialogResult = true;
                }
            }
        }


    }
}
