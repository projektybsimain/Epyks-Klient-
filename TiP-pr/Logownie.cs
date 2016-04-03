using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiP_pr
{
    public partial class Epyks : Form
    {
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
            
            this.Hide();         
            Zalogowany f = new Zalogowany();
            f.Show(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rejestracja f = new Rejestracja();
            f.Show(); 
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
    }
}
