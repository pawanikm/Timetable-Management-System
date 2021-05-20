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


namespace Time_Table_Management_System
{
    public partial class AddWorkingDaysHours1 : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";
        int idWorking_dayshours;
        string days, day1, day2, day3, day4, day5, day6, day7 ="";

        public AddWorkingDaysHours1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
           
        }

       

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void AddWorkingDaysHours1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_Workingdayshours", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                days = day1 + day2 + day3 + day4 + day5 + day6 + day7;

                mysqlCmd.Parameters.AddWithValue("_idWorking_dayshours", idWorking_dayshours);
                mysqlCmd.Parameters.AddWithValue("_noWorking_days", numericUpDown1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Working_days", days);
                mysqlCmd.Parameters.AddWithValue("_Working_hours", numericUpDown2.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Working_minutes", numericUpDown3.Text.Trim());

                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully!!");
                

            }

            Clear();
        }
        void Clear()
        {
            numericUpDown1.Text = numericUpDown2.Text = numericUpDown3.Text = "";
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = checkBox5.Checked = checkBox6.Checked = checkBox7.Checked = false;

            idWorking_dayshours = 0;

        }



                
private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            day1 = "Monday";
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            day2 = "Tuesday";

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            day3 = "Wednesday";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            day4 = "Thursday";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            day5 = "Friday";
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            day6 = "saturday";
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            day7 = "Sunday";
        }

        private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
  }
    

