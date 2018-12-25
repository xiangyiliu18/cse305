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
    public partial class Review : Form
    {
        Class1 x = new Class1("final");
        public static bool review;
        public static bool makeView;
        public Review()
        {
            InitializeComponent();
        }

        private void Review_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.button11.Visible = false;
            this.button1.Visible = true;
            this.button2.Visible = true;
            this.panel1.Visible = false;
            if (Form1.enter)
            {
                this.button2.Text = "Welcome " + Form1.username;
              
                this.button11.Text = "Log Out";
                this.button11.Visible = true;
                if (Form1.role == "Seller")
                {
                    this.button2.Enabled = false;
                    this.button1.Visible = false;
                    this.button3.Text = "Main Page";
                    x.set.Reset();
                    string sql = "select I.SellerId, S.SellerName, I.ItemId, I.ItemName, T.Rate, T.Detail from seller S, item I, review T where S.SellerId='"+Form1.username+"' and I.SellerId='" + Form1.username + "' and I.ItemId='" + Seller.itemId + "' and T.SellerId='" + Form1.username + "'and T.ItemId='"+Seller.itemId+"'  ";
                    x.query(sql);
                    if (x.set.Tables[0].Rows.Count > 0)
                    {
                        this.dataGridView1.DataSource = x.set.Tables[0];
                    }
                }
                else
                {

                    x.set.Reset();
                    string sql1 = "select R.SellerId, S.SellerName, R.ItemId, I.ItemName, R.Rate, R.Detail from review R,seller S,item I where R.SellerId='" + MainSite.sellerId + "' and R.ItemId='" + MainSite.itemId + "' and S.SellerId=R.SellerId and S.SellerId=I.SellerId and I.ItemId=R.ItemId";
                    x.query(sql1);
                    if (x.set.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Without  it", "Fail to View", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.dataGridView1.DataSource = x.set.Tables[0];
                    }
                }
            }
            else
            {
                x.set.Reset();
                string sql1 = "select I.SellerId, S.SellerName, I.ItemId, I.ItemName, T.Rate, T.Detail from seller S, item I, review T where S.SellerId='" + MainSite.sellerId+ "' and I.SellerId='" + MainSite.sellerId + "' and I.ItemId='" + MainSite.itemId + "' and T.SellerId='" +MainSite.item+ "'and T.ItemId='" + MainSite.itemId + "'  ";
                x.query(sql1);
                if (x.set.Tables[0].Rows.Count > 0)
                {
                    this.dataGridView1.DataSource = x.set.Tables[0];
                }
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }
        //Sign in/account
        private void button2_Click(object sender, EventArgs e)
        {
          if(this.button2.Text.Trim()=="Sign In")
            {
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                Information info = new Information();
                info.Show();
            }
            this.Close();
        }
        //sign up/ log out
        private void button11_Click(object sender, EventArgs e)
        {
            if (this.button2.Text == "Log Out")
            {
                Form1.enter = false;
                Form1 f1 = new Form1();
                f1.Show();
                f1.Close();
            }
            else
            {
                SignUp signUp = new SignUp();
                signUp.Show();
                this.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.button3.Text.Trim() == "Main Page")
            {
                if (Form1.role == "Seller")
                {
                    Seller s = new Seller();
                    s.Show();
                }
                else
                {
                    Employee ee = new Employee();
                    ee.Show();
                }
            }
            else
            {
                Cart cart = new Cart();
                cart.Show();
            }
            this.Close();
        }
    }
}
