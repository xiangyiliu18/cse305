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
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }
        // Go To Main Page---MainSite
        private void button5_Click(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           if(this.button7.Text.Trim()=="Sign Up")
            {
                SignUp signUp = new SignUp();
                signUp.Show();
                this.Close();
            }
            else
            {
                Information info = new Information();
                info.Show();
                this.Hide();
            }
        }
        //For checking out
        private void button4_Click(object sender, EventArgs e)
        {
            if (Form1.enter)
            {
                Check check = new Check();
                check.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You neet to sign in first", "Fail To Check Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //For Going back to Check Item
        private void button1_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.Show();
            this.Hide();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dataGridView1);
            bool find = false;
            dataGridView1.Columns[0].Name = "Item Id";
            dataGridView1.Columns[1].Name = "Item Name";
            dataGridView1.Columns[2].Name = "Seller Name";
            dataGridView1.Columns[3].Name = "Seller Id";
            dataGridView1.Columns[4].Name = "Qty";
            dataGridView1.Columns[5].Name = "Price";
            dataGridView1.Columns[6].Name = "Total Price";


            /*for (int j=0; j < dataGridView1.ColumnCount; j--)
                {
                if (dataGridView1.Rows[j].Cells[0].Value.ToString() == Item.itemId && dataGridView1.Rows[j].Cells[3].Value.ToString() == Item.sellerId)
                {
                    int t=(int)dataGridView1.Rows[0].Cells[4].Value;
                    t = t + Item.qty;
                    dataGridView1.Rows[0].Cells[4].Value = t.ToString();
                    find= true;
                    break;
                }
                }*/
            if (!find)
            {
              
                dataGridView1.Rows.Add(Item.itemName, Item.itemId, Item.sellerId, Item.sellerName, Convert.ToString(Item.qty), Convert.ToString(Item.price), Convert.ToString(Item.qty * Item.price));
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

  
    }
}
