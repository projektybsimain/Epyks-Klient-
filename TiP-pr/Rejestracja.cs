using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;

namespace TiP_pr
{
    public partial class Rejestracja : Form
    {

        int serverPort = 9000;

        public Rejestracja()
        {
            InitializeComponent();
        }

        static int FreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            //MessageBox.Show("" + port);
            return port;
        }

        static string sha256(string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sha256("haslo"));
            if (textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                textBox3.Clear();
                textBox2.Clear();
                textBox1.Clear();
                label5.Text = "Error: Complete all fields!";
                return;
            }
            if (textBox1.Text.Length <=5)
            {
                label5.Text = "Error: Password too short!";
                return;
            }
            if (textBox1.Text.Length >= 25)
            {
                label5.Text = "Error: Password too long!";
                return;
            }
            if (textBox3.Text.Length >= 25)
            {
                label5.Text = "Error: Login too long!";
                return;
            }
            if (textBox2.Text != textBox1.Text)
            {
                label5.Text = "Error: Incorrect password!";
                return;
            }
            try
            {
                TcpClient client = new TcpClient();
                IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort);
                client.Connect(IP_End);
                Users user_registion = new Users(2, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text, client, FreeTcpPort());
                string temp = user_registion.ReceiveMessage();
                if (temp == "AUTH;SUCCESS;!$")
                {
                    this.Visible = false;
                    Zalogowany f = new Zalogowany(client, textBox3.Text);
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    label5.Text = "Error: Choose another login!";
                    return;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Problem z rejestracją!");
                throw x;
                return;
            }
        }

        private void Rejestracja_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
