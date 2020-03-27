using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwtf_mobile_bl;

using Xamarin.Forms;

namespace nwtf_mobile.app
{
    public class LogIn : ContentPage
    {
        private Label headerLabel;
        private Entry usernameEntry;
        private Entry passwordEntry;
        private Button logInbutton;
       // nwtf_mobile_bl.controllers.initializeDB iniDB;
        public LogIn()
        {
           // iniDB = new nwtf_mobile_bl.controllers.initializeDB();
          // var db = iniDB.instanciateDB();

            StackLayout stackLayout = new StackLayout();

            headerLabel = new Label
            {
                Text = "Log In Page",
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(10, 10, 10, 10),
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            stackLayout.Children.Add(headerLabel);

            usernameEntry = new Entry
            {
                Text = "Email ID",
                Keyboard = Keyboard.Email
            };
            stackLayout.Children.Add(usernameEntry);

            passwordEntry = new Entry
            {
                Text = "Password",
                Keyboard = Keyboard.Text,
                IsPassword = true
            };
            stackLayout.Children.Add(passwordEntry);

            logInbutton = new Button
            {
                Text = "Log In"
            };
            logInbutton.Clicked += LogInbutton_Clicked;
            stackLayout.Children.Add(logInbutton);

            Content = stackLayout;
        }

        private void LogInbutton_Clicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;
        }
    }
}