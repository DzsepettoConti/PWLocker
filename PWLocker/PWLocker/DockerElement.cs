using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Reflection;
using System.Security.RightsManagement;

namespace PWLocker
{
    internal class DockerElement
    {
        private static int elementid;
        private string objectTitle, user, email, password;
        private int azonosito;
       


        public DockerElement(string title, string user, string email, string password)
        {
            this.ObjectTitle = title;
            this.User = user;
            this.Email = email;
            this.Password = password;
            this.Azonosito = ++elementid;
        }

        public string ObjectTitle { get => objectTitle; set => objectTitle = value; }
        public string User { get => user; set => user = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Azonosito { get => azonosito; set => azonosito = value; }

        public override string ToString()
        {
            return ObjectTitle + ";" + User + ";" + Email + ";"+password+ ";"+ Azonosito;
        }
    }
}
