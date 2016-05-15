using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiP_pr
{
    public partial class InvitationsPanel : Form
    {
        private Users us;
        private TcpClient client;

        public InvitationsPanel(TcpClient client_ref)
        {
            InitializeComponent();
            this.client = client_ref;
            us = new Users(client);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string welcome = textBox2.Text;
            if (welcome == "")
            {
                welcome = "Hello!";
            }
            us.SendMessage("INVITE;"+login+";"+welcome+ "!$");
            MessageBox.Show("You invite new friend!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
