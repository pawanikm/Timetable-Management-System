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

namespace TimeTableManagementSystem
{
    public partial class AddLecturers : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int lec_id;
        float rank;

        public AddLecturers()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AddLecturers_Load(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = string.Empty;
            lec_id = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Lecturers", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_lec_id", lec_id);
                mySqlCmd.Parameters.AddWithValue("_lec_name",textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_emp_id", textBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_faculty", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_department", comboBox2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_center", comboBox3.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_building", comboBox4.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_level", comboBox5.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_rank", textBox3.Text.Trim());

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please fill the Lecturer Name Field!!!");
                }
                else if (textBox2.Text == "" || textBox2.Text.Length != 6)
                {
                    MessageBox.Show("Please enter valid Employee ID, Employee ID should be 6 digits!!!");
                }
                else if(comboBox1.Text == "")
                {
                    MessageBox.Show("Please fill the Faculty Field!!!");
                }
                else if(comboBox2.Text == "")
                {
                    MessageBox.Show("Please fill the Department Field!!!");
                }
                else if(comboBox3.Text == "")
                {
                    MessageBox.Show("Please fill the Center Field!!!");
                }
                else if(comboBox4.Text == "")
                {
                    MessageBox.Show("Please fill the Building Field!!!");
                }
                else if(comboBox5.Text == "")
                {
                    MessageBox.Show("Please fill the Level Field!!!");
                }
                else if(textBox3.Text == "")
                {
                    MessageBox.Show("Please Generate the Rank!!!");
                }
                else 
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully...");
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox5.Text.Equals("Professor"))
            {
                rank = 1;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Assistant Professor"))
            {
                rank = 2;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Senior Lecturer(HG)"))
            {
                rank = 3;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Senior Lecturer"))
            {
                rank = 4;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Lecturer"))
            {
                rank = 5;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else if (comboBox5.Text.Equals("Assistant Lecturer"))
            {
                rank = 6;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }
            else
            {
                rank = 7;
                textBox3.Text = this.rank + "." + this.textBox2.Text;
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> items = new List<String>();
            comboBox2.Items.Clear();

            switch (comboBox1.SelectedItem)
            {
                case "Computing":
                    items.Add("Information Technology");
                    items.Add("Software Engineering");
                    items.Add("Cyber Security");
                    items.Add("Data Science");
                    items.Add("Information System engineering");
                    items.Add("Computer Systems and Network");
                    items.Add("Interactive Media");
                    break;
                case "Engineering":
                    items.Add("Civil Engineering");
                    items.Add("Electrical & Electronic Engineering");
                    items.Add("Mechanical Engineering");
                    items.Add("Mechatronic");
                    items.Add("Materials Engineering");
                    items.Add("Architecture");
                    items.Add("Quantity Surveying");
                    break;
                case "Business":
                    items.Add("Accounting & Finance");
                    items.Add("Business Analytics");
                    items.Add("Human Capital Management");
                    items.Add("Marketing Management");
                    items.Add("Logistics & Supply Chain Management");
                    break;
                case "Humanities & Sciences":
                    items.Add("Biotechnology");
                    items.Add("Education");
                    items.Add("Law");
                    items.Add("Mathematics");
                    items.Add("Nursing");
                    items.Add("Psychology");
                    break;
                case "Architecture":
                    items.Add("Architecture");
                    break;
                case "Hospitality & Culinary":
                    items.Add("Hospitality Management");
                    items.Add("Commercial Cookery");
                    items.Add("Event Management");
                    items.Add("Patisserie Programme");
                    break;
            }
            comboBox2.Items.AddRange(items.ToArray());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
