using Chat.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
           
        }


        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
         SessionDetails sessionDetails = new SessionDetails();
            if(usernameField.Text != null && passwordField.Password != null)
            {
                if(clientOpt.IsChecked == true)
                {
                    sessionDetails.IPAddress = serverIPField.Text;
                    sessionDetails.SessionType = SessionType.Client;
                }
                else
                {
                    sessionDetails.SessionType = SessionType.Server;

                }
                    sessionDetails.Username = usernameField.Text;
                    sessionDetails.Password = passwordField.Password;
                
                ChatWindow chatWindow = new ChatWindow(sessionDetails);
                this.Close();
                chatWindow.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Credentials");
            }
        }

        private void serverOpt_Checked(object sender, RoutedEventArgs e)
        {
            serverIPLbl.Visibility = Visibility.Hidden;
            serverIPField.Visibility = Visibility.Hidden;
        }

        private void clientOpt_Checked(object sender, RoutedEventArgs e)
        {
            serverIPLbl.Visibility = Visibility.Visible;
            serverIPField.Visibility = Visibility.Visible;
        }
    }
}
