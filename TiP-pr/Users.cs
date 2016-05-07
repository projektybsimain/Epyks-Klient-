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
    public class Users
    {
        //public string[] parameters;
        TcpClient client;
        int serverPort = 9000;
        IPEndPoint IP_End;
        NetworkStream stream;
        public bool check = false;

        private string login;
        private string password;
        private string name;
        private string surname;
        private string communicat;

        public Users(TcpClient client)
        {
            this.client = client;
        }

        public Users(int kom_inf, string login, string password, string name, string surname, TcpClient client)
        {
            this.client = client;
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            connect(kom_inf);
        }

        public Users(int kom_inf, string login, string password, TcpClient client)
        {
            this.client = client;
            this.login = login;
            this.password = password;
            connect(kom_inf);
        }

        public Users(int kom_inf, string communicat, TcpClient client)
        {
            this.client = client;
            this.communicat = communicat;
            connect(kom_inf);
        }

        public void connect(int kom_inf)
        {
            try
            {
                if (kom_inf == 1)
                {
                    String temp = "LOGIN;" + login + ";" + password + ";" + 2000;
                    SendMessage(temp);
                }
                else if (kom_inf == 2)
                {
                    String temp = "REGISTER;" + login + ";" + password + ";" + name + " " + surname + ";" + 2000;
                    SendMessage(temp);
                }
                else if (kom_inf == 3)
                 {
                    //MessageBox.Show(communicat);                         
                     SendMessage(communicat);
                 }
            }
            catch (Exception x)
            {
                MessageBox.Show("Problem z połączeniem do serwera (class Usres)");
                //throw x;
                return;
            }
        }

        public void SendMessage(String temp)
        {
            NetworkStream stream = client.GetStream();
            byte[] message = Encoding.UTF8.GetBytes(temp);
            stream.Write(message, 0, message.Length);
        }

        public string ReceiveMessage()
        {
            NetworkStream str = client.GetStream();
            byte[] inStream = new byte[255];
            str.Read(inStream, 0, 255);
            string returndata = Encoding.UTF8.GetString(inStream);
            //MessageBox.Show(returndata);
            return returndata.Substring(0, returndata.IndexOf('\0'));
        }       
    }
}
