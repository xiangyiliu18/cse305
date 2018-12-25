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
    public partial class Payment : Form
    {
        Class1 x = new Class1("final");
        public Payment()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainSite main = new MainSite();
            main.Show();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1.enter = false;
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.dataGridView1.ClearSelection();
                panel1.Visible = true;
                this.button4.Visible = false;//delete
                this.label6.Text = "New Card";
                this.panel1.Visible = true;
                this.button6.Visible =true;
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox2.ReadOnly = false;
                this.textBox2.Enabled = true;
                this.comboBox1.Text="Credit Card";
            }
            else
            {
                panel1.Visible = false;
            }

        }
        private void Payment_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.panel1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.button6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(pictureBox2);
            this.panel1.Visible = false;
            this.button4.Visible = false;
            string[] type = new string[3];
            type[0] = "Debit Card";
            type[1] = "Creadit Card";
           type[2] = "Paypal";
            this.dataGridView1.Visible = false;
            for (int i = 0; i < type.Length; i++)
                comboBox1.Items.Add(type[i]);
            if (textBox2.Text.Trim() == "")
            {
                this.button4.Visible = false;
            }
            string sql = null;
            sql = "select P.CustomerId, C.CardNum, C.Name, C.Type, C.Expiry from payment P, card C where CustomerId='" + Form1.username + "'and C.CardNum=P.CardNum";
            x.query(sql);
            if (x.set.Tables[0].Rows.Count > 1)
            {
                this.dataGridView1.Visible = true;
                this.dataGridView1.DataSource = x.set.Tables[0];
            }
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            x.set.Reset();
            string sql = null;
            sql = "insert into card(CardNum,Name,Type,Expiry) values('" + textBox2.Text + "','" + textBox1.Text + "', '" + comboBox1.Text + "','" + textBox3.Text + "')";
            x.nonQuery(sql);
            x.set.Reset();
            sql = "insert into payment(CustomerId,CardNum) values('" + Form1.username+ "','" + textBox2.Text + "')";
            x.nonQuery(sql);
            MessageBox.Show("Add Sucessfully", "Pass", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.radioButton1.Checked = false;
            this.button4.Visible = true;
            this.button6.Visible = false;
            x.set.Reset();
            sql = "select * from payment where CustomerId='"+Form1.username+"'";
            x.query(sql);
            this.dataGridView1.DataSource = x.set.Tables[0];


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Trim() == "")
            {
                MessageBox.Show("There're no data can be delete", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.comboBox1.Text="";
                x.set.Reset();
                string sql = null;
                sql = "delete from card where CardNum='" + textBox2.Text.Trim() + "'";
                x.nonQuery(sql);
                dataGridView1.ClearSelection();
                dataGridView1.DataSource = x.set.Tables[0];
                MessageBox.Show("Delete Sucessfully", "Pass", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                if (dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    this.label6.Text = "Card Information";
                    this.panel1.Visible = true;
                    this.button6.Visible = false;
                    this.button4.Visible = true;//delete
                    this.textBox2.ReadOnly = true;
                    this.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    this.radioButton1.Checked = false;
                    this.textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    this.textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    this.comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                }
                else
                {
                    this.dataGridView1.Visible = false;
                    this.panel1.Visible = false;
                }
            }
           
        }
    }
}
