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

namespace TiP_pr
{
    public partial class Rejestracja : Form
    {
        public Rejestracja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                textBox3.Clear();
                textBox2.Clear();
                textBox1.Clear();
                label5.Text = "Error: Complete all fields!";
                return;
            }
            if (textBox2.Text != textBox1.Text)
            {
                label5.Text = "Error: Incorrect password!";
                return;
            }
            try
            {
                Users user_registion = new Users(2, textBox3.Text, textBox2.Text, textBox4.Text, textBox5.Text);
                string temp = user_registion.ReceiveMessage();
                if (temp == "AUTH;SUCCESS;")
                {
                    this.Visible = false;
                    Zalogowany f = new Zalogowany();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    label5.Text = "Error: Choose another login!";
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem z rejestracją!");
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
