using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TiP_pr
{
    class Users
    {
        public Command Command { get; private set; }
        public string[] parameters;
        TcpClient client;
        int serverPort = 9000;
        IPEndPoint IP_End;
        NetworkStream stream;

        private string login;
        private string password;
        private string name;
        private string surname;


        public Users(int kom_inf, string login, string password, string name, string surname)
        {
            Command = new Command(String.Empty);
            client = new TcpClient();
            IP_End = new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort);
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            connect(kom_inf);
            stream = client.GetStream();
        }

        public Users(int kom_inf, string login, string password)
        {
            Command = new Command(String.Empty);
            client = new TcpClient();
            IP_End = new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort);
            this.login = login;
            this.password = password;
            connect(kom_inf);
            stream = client.GetStream();
        }
    
        public void connect(int kom_inf)
        {
            try
            {
                client.Connect(IP_End);
                if (kom_inf == 1)
                {
                    Login();
                }
                else if (kom_inf == 2)
                {
                    Register();
                }                  
            }
            catch (Exception x)
            {
                MessageBox.Show("Problem z połączeniem do serwera (class Usres)");
                return;
            }
        }

        public void Register()
        {
            NetworkStream stream = client.GetStream();
            byte[] message = Encoding.UTF8.GetBytes("REGISTER;" + login + ";" + password + ";" + name + " " + surname + ";" + 2000);
            stream.Write(message, 0, message.Length);
        }

        public void Login()
        {
            NetworkStream stream = client.GetStream();
            byte[] message = Encoding.UTF8.GetBytes("LOGIN;" + login + ";" + password + ";" + 2000);
            stream.Write(message, 0, message.Length);
        }

        public string ReceiveMessage()
        {
            NetworkStream stream = client.GetStream();
            byte[] inStream = new byte[255];
            stream.Read(inStream, 0, 255);
            string returndata = Encoding.UTF8.GetString(inStream);
            MessageBox.Show(returndata);
            return returndata.Substring(0, returndata.IndexOf('\0'));
        }

    }
}
