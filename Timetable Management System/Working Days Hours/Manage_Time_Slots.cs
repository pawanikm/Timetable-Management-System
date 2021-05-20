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
    public partial class Form1 : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";
        int timeslot_id ;
    
        public Form1()
        {
            InitializeComponent();
            GridFill();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mysqlCmd = new MySqlCommand("Add_time_slot", mysqlCon);
                mysqlCmd.CommandType = CommandType.StoredProcedure;
                mysqlCmd.Parameters.AddWithValue("_id_time_slots", timeslot_id);
                mysqlCmd.Parameters.AddWithValue("_Start_time", textBox1.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_Duration", textBox2.Text.Trim());
                mysqlCmd.Parameters.AddWithValue("_End_time", textBox3.Text.Trim());
                
                mysqlCmd.ExecuteNonQuery();
                MessageBox.Show("Submitted Successfully!!");


            }
            GridFill();
            Clear();
        }
        void Clear()
        {
            textBox1.Text  = textBox2.Text = textBox3.Text = "";
        }

        private void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDataAdapt = new MySqlDataAdapter("view_time_slots", mysqlCon);
                mysqlDataAdapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data_table_Add_Room = new DataTable();
                mysqlDataAdapt.Fill(data_table_Add_Room);
                dataGridView1.DataSource = data_table_Add_Room;
                dataGridView1.Columns[0].Visible = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
