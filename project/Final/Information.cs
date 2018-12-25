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
    public partial class Information : Form
    {
        Class1 x = new Class1("final");
        public static bool order;
        public static bool review;
        public static bool checkInventory;
        public static bool checkSeller;
        public Information()
        {
            InitializeComponent();
        }
        //Go to Main Site ---MainSite Page
        private void button5_Click(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }
        //Log Out and Return to Main Site ---MainSite Page
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void Information_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.dataGridView1);
            this.button5.Visible = false;//Main Site
            this.button9.Visible = false;//Payment management
            this.panel3.Visible = false;
            this.button7.Visible = false;//Employee management
            checkInventory = checkSeller=false;
            x.set.Reset();
            string sql = null;
            this.button3.Text = "Shopping Cart";
            if (Form1.role == "Customer")
            {
                this.panel3.Visible = true;
                this.button4.Visible = false;// Inventory Button 
                this.button7.Visible = false;// Employee Button 
                this.button1.Visible = false;// Seller Button
                this.button5.Visible = true; // Main Site
                this.label3.Text = "Email:";
                this.textBox4.ReadOnly = false;
                this.button9.Visible = true;
                this.label9.Text = "Order Informaiton";
                this.button6.Text = "Select Order";
                this.label5.Text= "Address:";
                sql = "select CustomerId,PassWord,LastName,FirstName,PhoneNumber,EmailId,Address from customer where  CustomerId='" +Form1.username+ "'";
            }
            else 
            {
                this.button3.Text = "Main Page";
                this.label3.Text = "Supervisor:";
                    this.textBox4.ReadOnly = true;
                this.textBox5.ReadOnly = true;
                    this.label5.Text = "Role:";
                    sql = "select EmployeeId,PassWord,LastName,FirstName,PhoneNumber,SupervisorId,DesignationRole from employee where  EmployeeId='" + Form1.username+ "'";
                    this.button4.Visible = true;// Inventory Button;
                    this.button7.Visible = false;// Employee Button 
                    this.button1.Visible = true; //Seller Button
            }
            x.query(sql);
            if (x.set.Tables[0].Rows.Count > 0)
            {
                this.button8.Visible = true;//Update
                DataTable view = x.set.Tables[0];
                textBox6.Text = view.Rows[0][0].ToString();//username
                textBox7.Text = view.Rows[0][1].ToString();//password
                textBox1.Text = view.Rows[0][2].ToString();//last name
                textBox2.Text = view.Rows[0][3].ToString();//first name
                textBox3.Text = view.Rows[0][4].ToString();//phone number
                textBox4.Text = view.Rows[0][5].ToString();//supervsior
                textBox5.Text = view.Rows[0][6].ToString();//address/role
                if (textBox5.Text.Trim() == "Supervisor")
                    this.button7.Visible = true;
            }
            else
            {
                MessageBox.Show("No data", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainSite mainSite = new MainSite();
                this.Close();
                mainSite.Close();
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
        // Go to Inventory Management Page
        private void button4_Click(object sender, EventArgs e)
        {  
                checkInventory = true;
            checkSeller = false;
                this.label9.Text = "Inventory Informaiton";
                this.button6.Text = "Select for Update";
            Seller seller = new Seller();
            seller.Show();
            this.Hide();
        }
        //Go to Employee Management Page
        private void button7_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Close();
        }
        // Go to Item Page for reviews
        private void button9_Click(object sender, EventArgs e)
        {
            if (review)
            {
                Item item = new Item();
                item.Show();
                this.Close();
            }
            else
                MessageBox.Show("No Reiews can be managed", "Fail to manage review", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox7.Text.Trim() == "")
            {
                MessageBox.Show("Null Values Exist", "Fail to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                x.set.Reset();
                string sql = null;
                if (!(textBox3.Text.Trim().Length == 12 || textBox3.Text.Substring(3, 1).ToString() == "-" && textBox3.Text.Substring(7, 1).ToString() == "-"))
                {
                    MessageBox.Show("The phone number should be xxx-xxx-xxxx", "Fail to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (textBox7.Text.Length > 5)
                    {
                        if (Form1.role == "Customer")
                        {
                            sql = "select * from  customer where EmailId='" + textBox4.Text.Trim() + "'";
                            x.query(sql);
                            if (x.set.Tables[0].Rows.Count > 1)
                            {
                                MessageBox.Show("The email has been already register by others", "Fail to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                sql = "update customer set Password='" + textBox7.Text.Trim() + "',LastName='" + textBox1.Text.Trim() + "',FirstName='" + textBox2.Text.Trim() + "',PhoneNumber='" + textBox3.Text.Trim() + "', EmailId='" + textBox4.Text.Trim() + "', Address='" + textBox5.Text.Trim() + "'where CustomerId='" + Form1.username + "'";
                        }
                        else
                            sql = "update employee set Password='" + textBox7.Text.Trim() + "',LastName='" + textBox1.Text.Trim() + "',FirstName='" + textBox2.Text.Trim() + "',PhoneNumber='" + textBox3.Text.Trim() + "'where EmployeeId='" + Form1.username + "'"; 
                        x.nonQuery(sql);
                        MessageBox.Show("Update Successfully", "Success to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("The length of password should be more than 6", "Fail to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkSeller = true;
            checkInventory = false;
            Seller seller = new Seller();
            seller.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.button6.Text.Trim() == ("Select Order")) {
                if (order)
                {
                    Order order1 = new Order();
                    order1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No Orders can be managed", "Fail to manage order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Item item = new Item();
                item.Show();
                this.Close();        
            }
            }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
            this.Close();
        }
    }
}
