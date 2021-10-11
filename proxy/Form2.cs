using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace proxy
{
    public partial class Form2 : Form
    {
        int aantal_pogingen = 0;

        private void Login()
        {
            if (textBox1.Text.Equals("admin") & textBox2.Text.Equals("admin"))
            {

                this.Hide();
                Form1 ss = new Form1();
                ss.Show();

            }
            else
            {
                aantal_pogingen++;

                if (aantal_pogingen == 3)
                {
                    label3.Text = "";
                    label3.Text = "Max aantal pogingen bereikt";
                    Thread.Sleep(2000);
                    this.Close();
                }


                label3.Text = "Login met juiste gebruiker en paswoord";
            }



        }
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        public Form2()
        {
            InitializeComponent();
            this.textBox2.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text="";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

    }
}
