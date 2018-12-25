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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class1 x = new Class1("Final");
        public static string role;// Customer, Seller, Employee
        public static string username;
        public static bool enter;

        //For Sign In
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * textBox1----password
             * textBox2----username
             * comboBox1---role
             */
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                enter = false;
                MessageBox.Show("Null Values exit, please select login type, enter username and password", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!(comboBox1.Text.Trim() == "Customer" || comboBox1.Text.Trim() == "Seller" || comboBox1.Text.Trim() == "Employee"))
            {
                MessageBox.Show("Are you are customer or seller or employee??", "Invalid Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox1.Text.Trim().Length <= 5)
            { //Password length>6
                enter = false;
                MessageBox.Show("the length of password should be more than 5", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                x.set.Reset();
                role = comboBox1.Text.Trim();
                string sql = null;
                if (role == "Customer")
                {
                    sql = "select * from customer where CustomerId='" + textBox2.Text.Trim() + "'and PassWord='" + textBox1.Text.Trim() + "'";
                }
                else if (role == "Employee")
                {
                    if (textBox2.Text.Trim().Length != 6)
                    {
                        MessageBox.Show("the length of id should be equal to 6", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                        sql = "select * from employee where EmployeeId='" + textBox2.Text.Trim() + "'and PassWord='" + textBox1.Text.Trim() + "'";
                }
                else
                {
                    if (textBox2.Text.Trim().Length != 6)
                        MessageBox.Show("the length of id should be equal to 6", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        sql = "select * from seller where SellerId='" + textBox2.Text.Trim() + "'and PassWord='" + textBox1.Text.Trim() + "'";
                }
                if (sql != null){
                    x.query(sql);
                    if (x.set.Tables[0].Rows.Count >= 0)
                    {
                        enter = true;
                        username = textBox2.Text;
                        if (role == "Customer")
                        {
                            MainSite mainSite = new MainSite();
                            mainSite.Show();
                        }
                        else if (role == "Employee")
                        {
                            Information info = new Information();
                            info.Show();
                        }
                        else {
                            Seller seller = new Seller();
                            seller.Show();
                        }
                        enter = true;
                        this.Close();
                    }
                    else
                    {
                        enter = false;
                        MessageBox.Show("Username Or Password is wrong", "Invalid Sign In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
             if (comboBox1.Text.Trim() == "Employee")
            {
                this.label3.Text = "Employee Id:";
                    }
            else if(comboBox1.Text.Trim() == "Seller")
            {
                this.label3.Text = "Seller Id:";
                      }
            else
            {
                this.label3.Text = "Username:";
            }
        }
        // Go to Main Site----MainSite
        private void button2_Click(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            string[] loginRole = new string[3];
            enter = false;
            loginRole[0] = "Customer";
            loginRole[1] = "Employee";
            loginRole[2] = "Seller";
            for (int i = 0; i < loginRole.Length; i++)
                comboBox1.Items.Add(loginRole[i]);
        }
    }
}
