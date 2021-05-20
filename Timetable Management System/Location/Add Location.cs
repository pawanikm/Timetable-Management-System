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

namespace Timetable_Management_System
{
    public partial class Add_Location : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";


        int location_id;
        string room_type;

        public Add_Location()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Add_Location_Load(object sender, EventArgs e)
        {
            Clear();
        }


        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            location_id = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            room_type = "Lecture Hall";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            room_type = "Lab";
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_Location", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Location_Id", location_id);
                mysqlCmd.Parameters.AddWithValue("_Building_Name", textBox1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Room_Name", textBox2.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Room_Type", room_type);
                mysqlCmd.Parameters.AddWithValue("_Capacity", textBox3.Text.Trim());

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please fill the Building Name Field!!!");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please fill the Room Name Field!!!");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please fill the Capacity Field!!!");
                }
                else if (room_type != "Lecture Hall" && room_type != "Lab")
                {
                    MessageBox.Show("Please select the Room Type!!!");
                }
                else
                {
                    mysqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully!!");
                }

            }

            Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
