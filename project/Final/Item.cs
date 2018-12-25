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
    public partial class Item : Form
    {
        Class1 x=new Class1("final");
        public static string itemId;
        public static string sellerId;
        public static string sellerName;
        public static string itemName;
        public static double price;
        public static int qty;
        public Item()
        {
            InitializeComponent();
        }

        private void Item_Load(object sender, EventArgs e)
        {
           
            itemId = sellerId = null;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.numericUpDown2);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Visible = false; // Unable to Review
            //Unable to Edit item
            this.textBox1.ReadOnly = true;
            this.textBox2.ReadOnly = true;
            this.textBox3.ReadOnly = true;
            this.textBox4.ReadOnly = true;//Price
            this.textBox6.ReadOnly = true;
            this.button4.Visible = false;   //Add Item
            this.button7.Visible = false;  //Update Item
            this.button1.Visible = true;
            this.button5.Visible = false;   //Delete Item
            this.button11.Text = "Sign Up";
            this.button2.Text = "Sign In";
            this.button3.Text = "Main Page";   //cart
            string[] department = new string[4];
            qty= 0;
            department[0] = "Book";
            department[1] = "Food";
            department[2] = "Computer";
            department[3] = "Shoe";
            for (int i = 0; i < department.Length; i++)
                comboBox1.Items.Add(department[i]);
            if (Review.review)
            {
                this.panel2.Visible = true;
                this.button9.Text = "Update Review";
                this.button10.Visible = true;
            }
            if (Form1.enter)
            {
                this.button2.Text = "Welcome "+Form1.username;
                this.button11.Text = "Log Out";
                this.panel1.Visible = true;
                string sql = null;
               if (Form1.role == "Customer")
                {
                    this.button2.Enabled = true;
                    this.button6.Visible = true; //Can add items to cart
                    this.button6.Text = "Add Cart";
                    this.button3.Text = "Shopping Cart";// see cart
                    x.set.Reset();
                    sql = "select I.ItemId,I.ItemName, I.ItemType,I.Price, S.SellerId, S.SellerName from item I, seller S where I.ItemId='" + MainSite.itemId+ "' and I.SellerId='"+MainSite.sellerId+"'and S.SellerId='"+MainSite.sellerId+"'";
                    x.query(sql);
                    if (x.set.Tables[0].Rows.Count > 0)
                    {
                      
                        DataTable view = x.set.Tables[0];
                        textBox1.Text = view.Rows[0][0].ToString();//Item Id
                        itemId = textBox1.Text;
                        textBox2.Text = view.Rows[0][1].ToString();//Item Name
                        comboBox1.Text = view.Rows[0][2].ToString();
                        textBox4.Text = view.Rows[0][3].ToString();//Price
                        textBox3.Text = view.Rows[0][5].ToString();//Seller Name
                        textBox6.Text = view.Rows[0][4].ToString();//Seller Id
                        sellerId = textBox6.Text;
                    }
                }
                else if (Form1.role == "Seller")
                {
                    this.button6.Visible = false;//cannot add to cart
                    this.button1.Visible = false;
                    this.button2.Enabled = false;
                    this.textBox3.Text = Seller.name;
                    this.textBox6.Text = Form1.username;
                    if (Seller.select)
                        {
                        textBox4.ReadOnly = false;
      
                        this.comboBox1.Enabled = false;
                            this.button5.Visible = true;
                            this.button4.Visible = true;
                            this.button7.Visible = true;
                            this.button7.Enabled = true;
                            this.button5.Enabled = true;
                        string sql1 = null;
                            x.set.Reset();
                            sql1 = "select I.ItemId, I.ItemName,I.ItemType, I.Price, T.Qty from item I, inventory T where I.ItemId='" + Seller.itemId + "' and I.SellerId='" + Form1.username + "' and T.ItemId = '" + Seller.itemId + "' and T.SellerId = '" + Form1.username + "'";
                            x.query(sql1);
          
                        if (x.set.Tables[0].Rows.Count > 0)
                        {
                            DataTable view = x.set.Tables[0];
                            textBox1.Text = view.Rows[0][0].ToString();
                             textBox2.Text = view.Rows[0][1].ToString();
                            textBox4.Text = view.Rows[0][3].ToString();
                            comboBox1.Text = view.Rows[0][2].ToString();
                            numericUpDown1.Value = (int)view.Rows[0][4];
                        }
                        }
                        else
                        {
                              textBox1.ReadOnly = false;
                             textBox2.ReadOnly = false;
                              textBox4.ReadOnly = false;
                             comboBox1.Enabled = true;
                            this.button7.Enabled = false;
                            this.button5.Enabled = false;
                        this.button6.Visible = true;
                        this.button6.Text = "Add";
                        }

                }
 
            }
            else
            {
                this.button3.Text = "Shopping Cart";
                x.set.Reset();
               string sql= "select I.ItemId,I.ItemName, I.ItemType,I.Price, S.SellerId, S.SellerName from item I,seller S where I.ItemId='" + MainSite.itemId + "' and I.SellerId='"+MainSite.sellerId+"'and  S.SellerId='" + MainSite.sellerId + "'";
                x.query(sql);
                if (x.set.Tables[0].Rows.Count > 0)
                {
                    DataTable view = x.set.Tables[0];
                    textBox1.Text = view.Rows[0][0].ToString();//Item Id
                    textBox2.Text = view.Rows[0][1].ToString();//Item Name
                    comboBox1.Text = view.Rows[0][2].ToString();
                    textBox4.Text = view.Rows[0][3].ToString();//Price
                    textBox3.Text = view.Rows[0][4].ToString();//Seller Name
                    textBox6.Text = view.Rows[0][5].ToString();//Seller Id
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                MainSite mainSite = new MainSite();
                mainSite.Show();
            this.Close();
        }
        //Sign in/Account
        private void button2_Click(object sender, EventArgs e)
        {
            if (!(this.button2.Text.Trim() == "Sign In"))
            {
                Form1.enter = false;
                this.panel2.Visible = false;
                if (Form1.role == "Customer")
                {
                    this.button4.Visible = false; //Add
                    this.button5.Visible = false; //Delete
                    this.button7.Visible = false; //Update
                }   else
                    {
                        Information info = new Information();
                        info.Show();
                    }
                    this.Close();
            }
            else
            {
                Form1 info = new Form1();
                info.Show();
                this.Close();
            }
        }
        // Update Items
        private void button7_Click(object sender, EventArgs e)
        {
            double price;
            if (double.TryParse(textBox4.Text.Trim(), out price))
            {
                x.set.Reset();
                string sql = "update item set Price='" + textBox4.Text.Trim() + "'where ItemId='" + textBox1.Text.Trim() + "' and SellerId='" + Form1.username + "'";
                x.nonQuery(sql);
                x.set.Reset();
                string sql1 = "update inventory set Qty='" + numericUpDown1.Value + "'where ItemId='" + textBox1.Text.Trim() + "' and SellerId='" + Form1.username + "'";
                x.nonQuery(sql1);
                MessageBox.Show("Update Sucessfully", "Pass", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("price is double", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            itemId = textBox1.Text.Trim();
                string sql = "select * from review where ItemId='" + textBox1.Text.Trim() + "'and SellerId='" + textBox6.Text.Trim()+ "'";
                x.set.Reset();
                x.query(sql);
                if (x.set.Tables[0].Rows.Count > 0)
                {
              
                    Review review = new Review();
                    review.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Without any view records about it", "Fail to View", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.button6.Text == "Add")
            {
                this.button8.Enabled = false;
                double price;
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Null value", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!(comboBox1.Text == "Book" || comboBox1.Text == "Food" || comboBox1.Text == "Shoe" || comboBox1.Text == "Computer"))
                {
                    MessageBox.Show("Type is wrong", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (textBox1.Text.Trim().Length != 6)
                {
                    MessageBox.Show("id length wrong", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (double.TryParse(textBox4.Text.Trim(), out price))
                {
                    x.set.Reset();
                    string ss = "select * from item where ItemId='" + textBox1.Text.Trim() + "' and SellerID='" + Form1.username + "'";
                    x.query(ss);
                    if (x.set.Tables[0].Rows.Count > 1)
                    {
                        MessageBox.Show("The item already exists", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        x.set.Reset();
                        string sql1 = null;
                        sql1 = "insert into item(ItemId, ItemName, ItemType,Price, SellerId) values('" + textBox1.Text + "','" + textBox2.Text + "', '" + comboBox1.Text + "','" + textBox4.Text + "', '" + textBox6.Text + "')";
                        x.nonQuery(sql1);
                        x.set.Reset();
                        sql1 = "insert into inventory(SellerId, ItemId, Qty) values('" + textBox6.Text + "','" + textBox1.Text + "', '" + numericUpDown1.Value + "')";
                        x.nonQuery(sql1);
                        this.button7.Enabled = true;
                        this.button5.Enabled = true;
                        this.button8.Visible = false;//Cannore view reivew;
                        MessageBox.Show("Add Item Sucessfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Price is not double", "fail", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else if (this.numericUpDown1.Value != 0)
            {
                itemId = textBox1.Text.ToString().Trim();
                sellerId = textBox6.Text.Trim();
                itemName = textBox2.Text.Trim();
                sellerName = textBox3.Text.Trim();
                price = Convert.ToDouble(textBox4.Text.ToString().Trim());
                qty =(int) this.numericUpDown1.Value;
                Cart cart = new Cart();
                cart.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The Qty canonot be lower than 1", "Fail to Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Sign up / Log out
        private void button11_Click(object sender, EventArgs e)
        {
            if (this.button11.Text.Trim() == "Sign Up") {
                SignUp signup = new SignUp();
                signup.Show();
                this.Close();
            }
            else{
                Form1 f1 = new Form1();
                f1.Show();
                this.Close();
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
        //Add Item
        private void button4_Click(object sender, EventArgs e)
        {
            this.button8.Visible = false;//Cannore view reivew;
            this.textBox1.Clear(); //id
            this.textBox2.Clear(); // name
            this.button7.Enabled = false;
            this.button5.Enabled = false;
            this.textBox4.Clear();// price
            this.comboBox1.Enabled = true;
            this.numericUpDown1.Value = 1;
            this.button6.Text = "Add";
            this.button6.Visible = true;
            this.textBox1.ReadOnly = false;
            this.textBox2.ReadOnly = false;
            this.textBox4.ReadOnly = false;
            
        }
        //Delete Item
        private void button5_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text.Trim() == "" || textBox1.Text.Trim().Length != 6))
            {
                x.set.Reset();
                string sql = "delete  from item where ItemId='" + textBox1.Text + "' and SellerId='" + textBox6.Text + "'";
                x.nonQuery(sql);
                x.set.Reset();
                sql = "delete  from inventory where ItemId='" + textBox1.Text + "' and SellerId='" + textBox6.Text + "'";
                x.nonQuery(sql);
            }
            else
                MessageBox.Show("No Item need to be delete", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
