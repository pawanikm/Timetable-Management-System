using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Student
{
    public partial class Add_Student_Group : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int id_SG;

        public Add_Student_Group()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Save student group
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_StdGroup", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;

                mySqlCmd.Parameters.AddWithValue("_id_SG", id_SG);
                mySqlCmd.Parameters.AddWithValue("_Acad_Year_Sem", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Programme", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Group_Num", numericUpDown1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_SubGroup_Num", numericUpDown2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Group_ID", textBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_SubGroup_ID", textBox3.Text.Trim());
                                           
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfully");                                          
            }
        }
        //clear fields
        void Clear()
        {
            textBox1.Text = comboBox1.Text = numericUpDown1.Text = numericUpDown2.Text = textBox2.Text = textBox3.Text = "";
            id_SG = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //clear button
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //add student form
        private void Add_Student_Group_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        //Generate button
        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = this.textBox1.Text + "." + this.numericUpDown1.Text + "(" + this.comboBox1.Text + ")";
            textBox3.Text = this.textBox1.Text + "." + this.numericUpDown1.Text + "." + this.numericUpDown2.Text + "(" + this.comboBox1.Text + ")";

            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill the 'Academic Year and Semester' field");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select a Programme");
            }
            else if (numericUpDown1.Text == "" || numericUpDown1.Text == "0")
            {
                MessageBox.Show("Please select a Group Number");
            }
            else if (numericUpDown2.Text == "" || numericUpDown2.Text == "0")
            {
                MessageBox.Show("Please select a Sub Group Number");
            }
        }
    }
}
