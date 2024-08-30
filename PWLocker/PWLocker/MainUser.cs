using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Media.Animation;
using System.IO;

namespace PWLocker
{
    internal class MainUser
    {
        private string mainUserName, mainPassword;

        public MainUser(string mainUserName, string mainPassword)
        {
            this.MainUserName = mainUserName;
            this.MainPassword = mainPassword;
        }

        public string MainUserName { get => mainUserName; set => mainUserName = value; }
        public string MainPassword { get => mainPassword; set => mainPassword = value; }

        public MainUser() { }
        public override string ToString()
        {
            return MainUserName + ";" + MainPassword;
        }


    }
}
