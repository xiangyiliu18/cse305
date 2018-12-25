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
    public partial class Check : Form
    {
        Class1 x = new Class1("fina");
        public Check()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim()!= ""|| this.comboBox3.Text!="")
            {
                
                MessageBox.Show("OrderSucessful", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                    MessageBox.Show("information does not complete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainSite mainSite = new MainSite();
            mainSite.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void Check_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.comboBox3);
            this.panel3.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.textBox4);
            this.panel4.Controls.Add(this.comboBox4);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(radioButton3);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.panel4);
            this.panel4.Visible = false;
            x.set.Reset();
            string sql = "select Address from customer where CustomerId='" + Form1.username + "'";
            x.query(sql);
            DataTable v = x.set.Tables[0];
            this.textBox1.Text = v.Rows[0][0].ToString();
            string[] loginRole = new string[3];
            loginRole[0] = "USPS";
            loginRole[1] = "Fedfx";
            loginRole[2] = "UPS";
            for (int i = 0; i < loginRole.Length; i++)
                comboBox1.Items.Add(loginRole[i]);
            string[] loginRole1 = new string[3];
            loginRole1[0] = "Slow";
            loginRole1[1] = "Normal";
            loginRole1[2] = "Fast";
            for (int i = 0; i < loginRole.Length; i++)
                comboBox2.Items.Add(loginRole1[i]);
            x.set.Reset();
            string sqll = "select * from payment where CustomerId='" + Form1.username + "'";
            x.query(sqll);
            if (x.set.Tables[0].Rows.Count > 1)
            {
                comboBox3.Visible = true;
                this.radioButton4.Enabled = true;
                DataTable vi = x.set.Tables[0];
                for (int i = 0; i < x.set.Tables[0].Rows.Count; i++)
                {
                    comboBox3.Items.Add(vi.Rows[i][1].ToString());
                }
            }
            else
            {
                this.radioButton4.Enabled = false;
                comboBox3.Visible = false;

            }
            string[] loginRole2 = new string[3];
            loginRole2[0] = "Credit Card";
            loginRole2[1] = "Debit Card";
            loginRole2[2] = "Paypal";
            for (int i = 0; i < loginRole.Length; i++)
                comboBox3.Items.Add(loginRole2[i]);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                x.set.Reset();
                string sql = "select Address from customer where CustomerId='" + Form1.username + "'";
                x.query(sql);
                DataTable v = x.set.Tables[0];
                this.textBox1.Text = v.Rows[0][0].ToString();
                this.textBox1.Enabled = false;
            }
            else
            {
                this.textBox1.Enabled = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                panel3.Visible = false;
            }
            else
            {
                panel3.Visible = true;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (this.label9.Text.Trim() == "0.00")
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true; ;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "USPS" || comboBox1.Text.Trim() == "Fedfx" || comboBox1.Text.Trim() == "UPS")
            {
                comboBox2.Visible = true;
                label7.Visible = true;
                comboBox2.Text = "";
            }
            else
            {
                comboBox2.Visible = false;
                label7.Visible = false;
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            double fee;
            if (comboBox1.Text.Trim() == "USPS")
            {
                if (comboBox2.Text.Trim() == "Slow")
                {
                    fee = 2;
                }
                else if (comboBox2.Text.Trim() == "Normal")
                {
                    fee = 4;
                }
                else
                {
                    fee = 5;
                }
            }
            else if (comboBox2.Text.Trim() == "Fedfx")
            {
                if (comboBox2.Text.Trim() == "Slow")
                {
                    fee = 4;
                }
                else if (comboBox2.Text.Trim() == "Normal")
                {
                    fee = 8;
                }
                else
                {
                    fee = 9;
                }
            }
            else if (comboBox1.Text.Trim() == "UPS")
            {
                if (comboBox2.Text.Trim() == "Slow")
                {
                    fee = 4;
                }
                else if (comboBox2.Text.Trim() == "Normal")
                {
                    fee = 10;
                }
                else
                {
                    fee = 11;
                }
            }
            else
            {
                fee = 0;
            }
            this.label9.Text = Convert.ToString(fee);
            if (fee > 0)
            {
                this.label14.Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked)
            {
                this.label17.Visible = true;
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.comboBox4.Text = "Credit Card";
                this.panel4.Visible = true;
            }
            else
            {
                this.label17.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.textBox1.Clear();
                this.textBox1.Enabled = true;
            }
            else
            {

                this.textBox1.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                this.panel4.Visible = true;
                x.set.Reset();
                string sqll = "select * from payment where CustomerId='" + Form1.username + "'";
                x.query(sqll);
                if (x.set.Tables[0].Rows.Count > 1)
                {

                    comboBox3.Visible = true;
                    this.radioButton4.Enabled = true;
                    DataTable vi = x.set.Tables[0];
                    for (int i = 0; i < x.set.Tables[0].Rows.Count; i++)
                    {

                        comboBox3.Items.Add(vi.Rows[i][1].ToString());
                    }
                }
                else
                {
                    radioButton3.Select();

                }
            }
          
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.Text != "")
            {
                this.button4.Enabled = true;
            }
        }
    }

    
    }
