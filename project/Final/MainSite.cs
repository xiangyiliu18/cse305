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
    public partial class MainSite : Form
    {
        Class1 x = new Class1("final");
        public static bool item;
        public static string itemId;
        public static string sellerId;
        public MainSite()
        {
            InitializeComponent();
        }
        // Go to Sign Up Page---SignUp
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(this.button1.Text.Trim() == "Sign Up"))
            {
                Information info = new Information();
                info.Show();
            }
            else
            {
                SignUp signup = new SignUp();
                signup.Show();
            }
            this.Hide();

        }
        // Go to Sign In/Infor 
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button2.Text.Trim() == "Sign In")
            {
                Form1 f1 = new Form1();
                f1.Show();
            }
            else if (this.button2.Text.Trim() == "Log Out")
            {
                SignUp signup = new SignUp();
                   signup.Show();
            }
            else { Information info = new Information();
                   info.Show();
            }

            this.Hide();
        }

        private void MainSite_Load(object sender, EventArgs e)
        {
            item = false;//Main Site
           
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.dataGridView1.Visible = false;
            string[] department = new string[4];
            department[0] = "Book";
            department[1] = "Food";
            department[2] = "Computer";
            department[3] = "Shoe";
            for (int i = 0; i < department.Length; i++)
                comboBox1.Items.Add(department[i]);
            string itemSql = "select I.ItemId as Id, I.ItemName as Name,I.ItemType as Type,I.Price,S.SellerId, S.SellerName from seller S,item I where I.SellerId=S.SellerId";
            x.set.Reset();
            x.query(itemSql);
            if (x.set.Tables[0].Rows.Count > 0)
            {
                this.dataGridView1.Visible = true;
                this.dataGridView1.DataSource = x.set.Tables[0];
                this.button6.Visible = true;
                item = true;
            }
            if (Form1.enter)
            {
                this.button1.Text = Form1.username;
                this.button2.Text = "Log Out";
                if (Form1.role == "Seller")
                {
                    this.button3.Text = "Main Page";
                }
                
            }
            else
            {
                this.button1.Text = "Sign Up";
                this.button2.Text = "Sign In";
            }
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
        //See the Item Detail
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                itemId = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                sellerId= dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
                Item item = new Item();
                item.Show();
                this.Hide();
            }
            else
            {
                itemId = sellerId = null;
                MessageBox.Show("No items selected", "Fail to Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim().ToLower();
            if (!item)
            {
                MessageBox.Show("No items avaliable", "Search Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (search != "")
            {
                bool find = false;
                int i = 1;
                while (i < dataGridView1.Rows.Count) {
                    //dataGridView1.ClearSelection();
                    if (!dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().Contains(search))
                    {
                        dataGridView1.Rows[i].Visible = false;
                        find = true;
                    }
                i = i + 1;
                }
                if (!find)
                {
                    MessageBox.Show("Without that item", "Search Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Search cannot be null", "Search Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim() == "")
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
        }
    }
}
