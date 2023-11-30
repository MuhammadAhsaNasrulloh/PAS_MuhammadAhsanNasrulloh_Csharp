using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAS_MuhammadAhsanNasrulloh
{
    public partial class Form1 : Form
    {
        readonly string username = "Ahsan";
        readonly string password = "251106";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" ||  textBox2.Text == "")
            {
                MessageBox.Show("Isi dengan lengkap");
            } else if(textBox1.Text != username || textBox2.Text != password)
            {
                MessageBox.Show("Username/Password salah!");
            }
            else
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }
    }
}
