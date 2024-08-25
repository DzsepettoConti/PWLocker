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

namespace PWLocker
{
    /// <summary>
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        public string TitleText { get; private set; }
        public string UsernameText { get; private set; }
        public string PasswordText { get; private set; }
        public string EmailText { get; private set; }

        public AddForm()
        {
            InitializeComponent();
        }
        IFirebaseConfig fconfig = new FirebaseConfig()
        {
            AuthSecret = "7o9oh4EvBAN5maV69Wbxysbi7fJ91hqsmIPEUNWd",
            BasePath = "https://pwlocker-8782c-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        private void addFormLoad(object sender, RoutedEventArgs e)
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





        private void btnSubmitClick(object sender, RoutedEventArgs e)
        {
            TitleText = tbTitle.Text;
            UsernameText = tbUsername.Text;
            PasswordText = tbPassword.Text;
            EmailText = tbEmail.Text;

            DockerElement de = new DockerElement(
             TitleText,
             UsernameText,
             PasswordText,
             EmailText);
            var setter = client.Set("Elemets/" + TitleText, de);
            MessageBox.Show("Data Inserted");


            this.DialogResult = true;
            this.Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


    }
}
