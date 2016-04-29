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

namespace TiP_pr
{
    public partial class Epyks : Form
    {

        public NetworkStream STR;

        public Epyks()
        {
            InitializeComponent();         
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox2.Text == "")
            {
                textBox3.Clear();
                textBox2.Clear();
                label1.Text = "Error: Incorrect login or password!";
                return;
            }

            try
            {
                Users user_login = new Users(1, textBox2.Text, textBox3.Text);
                string temp = user_login.ReceiveMessage();
                if ( temp == "AUTH;SUCCESS;")
                {
                    this.Visible = false;
                    Zalogowany f = new Zalogowany();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    label1.Text = "Error: Incorrect login or password!";
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z logowaniem! (class Login)");
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Rejestracja f = new Rejestracja();
            f.ShowDialog();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Epyks_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
