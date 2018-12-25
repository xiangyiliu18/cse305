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
    public partial class Employee : Form
    {
        Class1 x = new Class1("final");
        public Employee()
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
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button8);
            this.label3.Visible = false;
            this.panel1.Visible = false;
            string[] role = new string[2];
            role[0] = "Normal";
            role[1] = "Supervisor";
            for (int i = 0; i < role.Length; i++)
                comboBox1.Items.Add(role[i]);
            string sql = "select * from employee where SupervisorId='" + Form1.username + "'";
            x.set.Reset();
            x.query(sql);
            this.dataGridView1.DataSource = x.set.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.label3.Visible = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "Normal";
                
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                if (dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
                {
                    this.panel1.Visible = true;
                    this.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//id
                    this.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();//last name
                    this.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();//first name
                    this.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    this.textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    this.comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    this.comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    this.textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                }
            }
        }
    }
}
