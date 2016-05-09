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
using System.IO;
using System.Text.RegularExpressions;


namespace TiP_pr
{
    public partial class Zalogowany : Form
    {

        private string contacts;
        private string[] contacts_table;
        private string name;
        private string[] name_table;
        private string invitations;
        private string[] invitations_table;
        private TcpClient client;
        private List<string> invite_contacts;
        private List<string> invite_message;
        private String login;

        public Zalogowany(TcpClient client, String login)
        {
            InitializeComponent();
            this.login = login;
            this.client = client;
            inicjalizacja();
            interface_label();
            inform();
        }

        private void inicjalizacja()
        {
            try
            {             
                Users user_contacts = new Users(3, "CONTACTS", client); //- DODAĆ DODAWANIE DO LISTY I OTRZYMYWANIE WIADOMOŚCI
                contacts = user_contacts.ReceiveMessage();
                contacts_list();

                Users user_name = new Users(3, "GET_NAME", client);
                name = user_name.ReceiveMessage();
                name_table = Regex.Split(name, ";");

                Users user_invitations = new Users(3, "INVITATIONS", client);
                invitations = user_invitations.ReceiveMessage();
                invitations_table = Regex.Split(invitations, ";");
                invite_contacts = new List<string>();
                invite_message = new List<string>();
                for (int i = 1; i < invitations_table.Length; i += i + 2)
                {
                    //MessageBox.Show(invitations_table[i]);
                    invite_contacts.Add(invitations_table[i]);
                }
                for (int i = 3; i < invitations_table.Length; i += i + 2)
                {
                    //MessageBox.Show(invitations_table[i]);
                    invite_message.Add(invitations_table[i]);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Something goes wrong! (Class Zalogowany)");
                return;
            }
        }

        private void inform()
        {
            if (invite_contacts != null)
            {
                richTextBox1.Text = "You have new invitations:\n";
                for (int i = 0; i < invite_contacts.Count; i++)
                {
                    richTextBox1.Text += "Name: " + invite_contacts[0] + "  Message: "+ invite_message[0];
                }

            }
        }

        private void contacts_list()
        {
            contacts_table = Regex.Split(contacts, ";");
            for (int i = 1; i < contacts_table.Length; i=+i+3)
            {
                //MessageBox.Show(contacts_table[i]);
                listBox1.Items.Add(contacts_table[i]);
            }

        }

        private void interface_label()
        {
            label2.Text = name_table[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Profile pro = new Profile(client, login);
            pro.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            InvitationsPanel invite = new InvitationsPanel(client);
            invite.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string curItem = listBox1.SelectedItem.ToString();
                if (curItem != null)
                {
                    Users rej_inv = new Users(client);
                    rej_inv.SendMessage("REMOVE;" + curItem);
                    listBox1.Items.Remove(curItem);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select invite!");
                return;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Users accept_inv = new Users(client);
            Invitation invite = new Invitation(client, accept_inv, invite_contacts);
            invite.ShowDialog();
            if (accept_inv.check == true)
            {
                contacts = accept_inv.ReceiveMessage();
                accept_inv.check = false;
                listBox1.Items.Clear();
                contacts_list();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string curItem = listBox1.SelectedItem.ToString();
                if (curItem != null)
                {
                    Users rej_inv = new Users(client);
                    rej_inv.SendMessage("BLOCK;" + curItem);
                    listBox1.Items.Remove(curItem);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select a friend first!");
                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string curItem = listBox1.SelectedItem.ToString();
                if (curItem != null)
                {
                    Users rej_inv = new Users(client);
                    rej_inv.SendMessage("UNLOCK;" + curItem);
                    listBox1.Items.Remove(curItem);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select a friend first!");
                return;
            }
        }
    }
}

