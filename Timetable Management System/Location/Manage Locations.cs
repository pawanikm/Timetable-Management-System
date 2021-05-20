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
    public partial class Manage_Locations : Form
    {

        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int location_id;
        string room_type;


        public Manage_Locations()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Manage_Locations_Load(object sender, EventArgs e)
        {
            Clear();
            GridFill();
        }

       void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("View_Location", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Location = new DataTable();
                mysqlDataAdapt.Fill(data_table_Location);
                dataGridView2.DataSource = data_table_Location;
                dataGridView2.Columns[0].Visible = false;

            }
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

        void Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            location_id = 0;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                
                location_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());

                room_type = dataGridView2.CurrentRow.Cells[3].Value.ToString();

                if(room_type == "Lecture Hall")
                {
                    radioButton1.Checked = true;
                }
                else if(room_type == "Lab")
                {
                    radioButton2.Checked = true;
                }

            }

        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            room_type = "Lecture Hall";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            room_type = "Lab";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Update_Location", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Location_Id", location_id);
                mysqlCmd.Parameters.AddWithValue("_Building_Name", textBox1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Room_Name", textBox2.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Room_Type", room_type);
                mysqlCmd.Parameters.AddWithValue("_Capacity", textBox3.Text.Trim());
                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!!");
            }
            Clear();
            GridFill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("LocationDeletebyID", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;

                mysqlCmd.Parameters.AddWithValue("_Location_Id", location_id);
                
                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!!");
            }
            Clear();
            GridFill();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellSelect(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
