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
    public partial class Seller : Form
    {
        Class1 x = new Class1("final");
        public static string itemId;
        public static string name;
        public static bool select;
        public static bool test;
        public Seller()
        {
            InitializeComponent();
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            select = false;
            name = null;
            test = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.button6);//for delete
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.button1.Text = "Item Management";
            this.dataGridView1.Visible = false;
            this.dataGridView1.ClearSelection();
            this.button2.Text = "Log Out";
            this.textBox2.PasswordChar.Equals("");

            this.textBox2.Enabled = true;
            this.button6.Visible = false;//delete Seller
            this.button4.Visible = false;// Add Seller
            this.panel2.Visible = false;
            this.textBox6.ReadOnly = true;

            if (Form1.enter)
            {//For Seller
                if (Form1.role == "Seller")
                {
                    this.button2.Text = "Log Out";
                    this.button3.Visible = true;// Update seller information
                    x.set.Reset();
                    string sellerSql = "select * from seller where SellerId='" + Form1.username + "'";
                    x.query(sellerSql);
                    if (x.set.Tables[0].Rows.Count > 0)
                    {//Show Seller Infomation
                        this.panel2.Visible = true;
                        DataTable view = x.set.Tables[0];
                        textBox6.Text = view.Rows[0][0].ToString();//seller id
                        textBox1.Text = view.Rows[0][1].ToString();//seller name
                        name = textBox1.Text.Trim();
                        textBox2.Text = view.Rows[0][2].ToString();//password
                    }
                    string itemSql = "select T.ItemId as Id, T.ItemName as Name,T.Price, I.Qty from item T, inventory I where T.SellerId='" + Form1.username + "' and I.SellerId='" + Form1.username + "' and I.ItemId=T.ItemId";
                    x.set.Reset();
                    x.query(itemSql);
                    if (x.set.Tables[0].Rows.Count > 0)
                    {//Show Intem Information
                        this.dataGridView1.DataSource = x.set.Tables[0];
                        this.dataGridView1.Visible = true;
                        this.button1.Text = "Item Management";
                    }
                    else
                    {
                        this.button1.Text = "Add Item";
                    }
                }
                //Employee ineVentory
                else
                {
                    this.button2.Text = "Main Page";
                    this.textBox6.ReadOnly = false;
                    this.dataGridView1.Visible = true;
                    if (Information.checkInventory)
                    {
                        this.label7.Text = "Inventory Information";
                        this.button1.Text = "Inventory Information";
                        this.button1.Enabled = false;
                        this.panel2.Visible = false;
                        string sql = "select I.ItemId, I.ItemName, S.SellerId, S.SellerName, T.Qty from inventory T, item I, seller S where S.SellerId=I.SellerId and T.ItemId=I.ItemId and T.SellerId=I.SellerId";
                        x.set.Reset();
                        x.query(sql);
                        if (x.set.Tables[0].Rows.Count > 0)
                        {
                            this.dataGridView1.DataSource = x.set.Tables[0];
                        }

                    }
                    else
                    {
                        this.label7.Text = "Seller Information";
                        this.button1.Text = "Seller Information";
                        this.textBox2.PasswordChar.Equals("*");
                        // this.textBox2.Enabled = false;
                        this.panel2.Visible = true;
                        this.panel1.Visible = false;
                        this.button1.Visible = false;
                        string sql = "select * from seller";
                        this.dataGridView1.Visible = true;
                        x.set.Reset();
                        x.query(sql);
                        this.dataGridView1.DataSource = x.set.Tables[0];
                    }
                    this.button6.Visible = true;
                    this.button4.Visible = true;
                }
            }
        }
        //Log out
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button2.Text == "Log Out")
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
        //Update Seller Information
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("The value cannot be empty", "Fail to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox2.Text.Trim().Length <= 5)
            {
                MessageBox.Show("The length of password should be empty", "Fail to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //x.set.Reset();
                string updateSql = "update seller set SellerName='" + textBox1.Text.Trim() + "',PassWord='" + textBox2.Text.Trim() + "' where SellerId='" + this.textBox6.Text.Trim() + "'";
                x.nonQuery(updateSql);
                if (Form1.role == "Employee")
                {
                    x.set.Reset();
                    updateSql = "select * from seller";
                    x.query(updateSql);

                    dataGridView1.DataSource = x.set.Tables[0];
                }
                name = this.textBox1.Text.Trim();
            }
            MessageBox.Show("Update Successfully", "Success to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text.Trim() == "Add")
            {
                name = this.textBox1.Text.Trim();
            }
            Item item = new Item();
            item.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             this.panel1.Visible = true;
            string itemId = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
            string itemName = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            int qty = (int)dataGridView1.CurrentRow.Cells[3].Value;
            this.textBox4.Text = itemId;
            this.textBox3.Text = itemName;
            this.numericUpDown1.Value = qty;   
            }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (Information.checkInventory)
            {
                sql = "update inventory set Qty = '" + numericUpDown1.Value + "'where SellerId = '" + this.dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' and ItemId='" + textBox4.Text.Trim() + "'";

            }
            else
            {
               sql= "update inventory set Qty = '" + numericUpDown1.Value + "'where SellerId = '" + Form1.username + "' and ItemId='" + textBox4.Text.Trim() + "'";

            }
            x.nonQuery(sql);
            MessageBox.Show("Update Successfully", "Success to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
    
                if (dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim()!="") {
                    this.button3.Visible = true;
                    select = true;
                    itemId = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                    if (!Information.checkSeller)
                    {
                        this.panel1.Visible = true;
                        this.textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        this.textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                       
                            if (Information.checkInventory)
                                this.numericUpDown1.Value = (int)dataGridView1.CurrentRow.Cells[4].Value;
                            else

                                this.numericUpDown1.Value = (int)dataGridView1.CurrentRow.Cells[3].Value;
                        
                    }
                    else
                    {
                        this.panel1.Visible = false;
                        this.textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        this.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        this.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    }
                }
                else
                {
                    itemId = null;
                   
                    this.panel1.Visible = false;
                }
            }
        }
        //For Add/Delete Item
        private void button6_Click(object sender, EventArgs e)
        {
            if (Form1.role == "Employee")
            {
               // MessageBox.Show("Dewwlete Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (this.textBox6.Text.Trim() != ""&&this.button6.Text.Trim()=="Delete")
                {
                   // MessageBox.Show("Delddete Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //x.set.Reset();
                    string sql = "delete from seller where SellerId='" + this.textBox6.Text.Trim() + "' ";
                    x.nonQuery(sql);
                    MessageBox.Show("Delete Sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // this.dataGridView1.Update();
                     x.set.Reset();
                   sql = "select * from seller";
                    x.query(sql);
                    this.dataGridView1.Update();
                    dataGridView1.DataSource = x.set.Tables[0];
                }
                else
                {
                    MessageBox.Show("no seller can be delete", "Fail to delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
        //Clear For Add
        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            if (this.textBox1.Text.Trim() == "" || this.textBox6.Text.Trim() == "" || this.textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Fai", "Fail ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (this.textBox6.Text.Trim().Length!=6)
            {
                MessageBox.Show("Fail", "Fail to Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else {
                x.set.Reset();
                string sql="select * from where SellerId='"+this.textBox6.Text.Trim()+"'";
                x.query(sql);
                if (x.set.Tables[0].Rows.Count > 1)
                {
                    MessageBox.Show("Fail", "Fail to Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else {
                    x.set.Reset();
                    sql = "insert into seller (SellerId, SelleName, PassWord) values('" + this.textBox6.Text.Trim() + "','" + this.textBox1.Text.Trim() + "', '" + this.textBox2.Text.Trim() + "')";
                    x.nonQuery(sql);
                    sql = "select * from where seller";
                    x.query(sql);
                    dataGridView1.DataSource = x.set.Tables[0];

                    MessageBox.Show("Sucess", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.button4.Visible = true;
        }
    }
}
