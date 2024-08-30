using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Reflection;
using System.Security.RightsManagement;
using System.Windows.Media;

namespace PWLocker
{
    internal class DockerElement
    {
        private static int elementid;
        private string objectTitle, user, email, password;
        private int azonosito;
       
        public DockerElement() { }

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

        public void addButtonFunction(string Title, StackPanel stackpanel, RoutedEventHandler copyPasswordButtonClick, RoutedEventHandler removeButtonClick)
        {
            // Create a new DockPanel
            DockPanel newDockPanel = new DockPanel
            {
                Height = 50,
                Width = 700,
                Margin = new Thickness(10)
            };

            // Create the Label
            Label myLabel = new Label
            {
                Name = Title,
                Content = Title,
                Width = 200,
                Height = 50,
                FontSize = 36
            };
            newDockPanel.Children.Add(myLabel);

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
            button3.Click += copyPasswordButtonClick;
            newDockPanel.Children.Add(button3);

            // Create the fourth Button with TextBlock content
            Button button4 = new Button
            {
                Content = "Remove",
                Height = 30,
                Width = 70,
                Margin = new Thickness(10, 0, 10, 0)
            };
            button4.Click += removeButtonClick;
            newDockPanel.Children.Add(button4);

            // Create the Border and add the DockPanel to it
            Border border = new Border
            {
                BorderThickness = new Thickness(5),
                BorderBrush = Brushes.Purple,
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(2),
                Margin = new Thickness(5),
                Child = newDockPanel // Add the DockPanel to the Border
            };

            stackpanel.Children.Add(border);
        }


    }
}
