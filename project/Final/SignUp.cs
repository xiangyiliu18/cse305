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
    public partial class SignUp : Form
    {
        Class1 x = new Class1("final");
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()=="" || textBox2.Text.Trim()== "" || textBox3.Text.Trim()== "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == ""||textBox6.Text.Trim()==""||textBox7.Text.Trim()=="")
            {
                MessageBox.Show("Null Value exists", "Fail to Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
            else if (!(textBox5.Text.Trim().Length == 12|| textBox7.Text.Trim().Length > 5))
            {
                MessageBox.Show("length problem", "Fail to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(!(textBox5.Text.Substring(3, 1).ToString() == "-" && textBox5.Text.Substring(7, 1).ToString() == "-"))
            {
                MessageBox.Show("The phone number should be xxx-xxx-xxxx", "Fail to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                {
                bool pass = true;
                string sql = "select * from customer where CustomerId='" + textBox1.Text.Trim() + "'";
                x.set.Reset();
                x.query(sql);
                if (x.set.Tables[0].Rows.Count > 1)
                {
                    pass = false;
                    MessageBox.Show("Username has already exists", "Fail to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    pass = true;
                string sql1 = "select * from customer where EmailId='" + textBox4.Text.Trim() + "'";
                x.set.Reset();
                x.query(sql1);
                x.query(sql);
                if (x.set.Tables[0].Rows.Count > 0)
                {
                    pass = false;
                    MessageBox.Show("Username has already exists", "Fail to create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    pass = true;
                if (pass)
                {
                    x.set.Reset();
                    string sql2 = null;
                    sql2 = "insert into customer(CustomerId, FirstName,LastName,EmailId,PhoneNumber,Address, PassWord) values('" + textBox1.Text + "','" + textBox3.Text + "', '" + textBox2.Text + "','" + textBox4.Text + "', '" + textBox5.Text + "', '"+textBox7.Text.Trim()+"', '"+textBox6.Text.Trim()+"')";
                    x.nonQuery(sql2);
                    MessageBox.Show("Create  Sucessfully, please sign in ", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Close();
                }

            }
        }
    }
}
