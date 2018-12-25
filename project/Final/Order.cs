using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class Order : Form
    {
        Class1 x = new Class1("final");
        public Order()
        {
            InitializeComponent();
        }
        //For Sign Out
        private void button2_Click(object sender, EventArgs e)
        {
            Form1.enter = false;
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }
  //For Item Review
        private void button4_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Close();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.button5.Text = Form1.username;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.Show();
            this.Close();
        }
    }
}
