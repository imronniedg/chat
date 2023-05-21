using Chat.Models;
using Chat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Chat
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        SessionDetails session;
        Socket publisher;
        Socket subscriber;
        Socket handler;
        CipherService cipherService;
        public ChatWindow(SessionDetails _serverDetails)
        {
            InitializeComponent();
            session = _serverDetails;
            this.cipherService = new CipherService(_serverDetails.Password);
            this.Title = _serverDetails.Username+ " - " + _serverDetails.SessionType.ToString().ToUpper();
        }

        private async void ChatWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (session.SessionType == SessionType.Client && session.IPAddress != null)
            {
                MessageBox.Show("Server IP Address: " + session.IPAddress);
                IPAddress ipAddress = IPAddress.Parse(session.IPAddress);
                IPEndPoint ipEndPoint = new(ipAddress, 4321);

                this.subscriber = new(
                                        ipEndPoint.AddressFamily,
                                        SocketType.Stream,
                                        ProtocolType.Tcp);
                await subscriber.ConnectAsync(ipEndPoint);
                this.Title = this.Title + " - CONNECTED TO SERVER: " + ipAddress.ToString();
                while (true)
                {
                    // Receive message.
                    var buffer = new byte[32];
                    var received = await subscriber.ReceiveAsync(buffer, SocketFlags.None);
                    string msg = await cipherService.DecryptAsync(buffer);
                    if (msg != null)
                    {
                        messageArea.Items.Add(msg);
                    }
                }
            }
            else
            {
                string hostName = Dns.GetHostName();

                IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
                IPAddress ipAddress = ipHostInfo.AddressList[ipHostInfo.AddressList.Length - 1];
                this.Title = this.Title + " - " + ipAddress.ToString();
                IPEndPoint ipEndPoint = new(ipAddress, 4321);

                this.publisher = new(
                                            ipEndPoint.AddressFamily,
                                            SocketType.Stream,
                                            ProtocolType.Tcp);

                publisher.Bind(ipEndPoint);
                publisher.Listen(100);
                this.handler = await publisher.AcceptAsync();
                while (true)
                {
                    //Receive message.
                    var buffer = new byte[32];
                    var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                    string msg = await cipherService.DecryptAsync(buffer);
                    if(msg != null)
                    {
                        messageArea.Items.Add(msg);
                    }
                }
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string msg = session.Username + ": " + messageField.Text;
            byte[] msgByte = new byte[32];
            msgByte = Encoding.UTF8.GetBytes(msg);
           
            if(session.SessionType == SessionType.Server)
            {
                messageArea.Items.Add(msg);
                msgByte = await cipherService.EncryptAsync(msg);
                await handler.SendAsync(msgByte, SocketFlags.None);
            }
            else
            {
                messageArea.Items.Add(msg);
                msgByte = await cipherService.EncryptAsync(msg);
                await subscriber.SendAsync(msgByte, SocketFlags.None);
            }

            messageField.Clear();
        }

        private void ChatWindowUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                publisher.Close();
                subscriber.Close();
                handler.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
