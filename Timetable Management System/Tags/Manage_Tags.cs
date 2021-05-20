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
    public partial class Ma : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int id_MT;

        public Ma()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //adding data into the table (add button)
        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Add_Tag", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_id_MT", id_MT);
                mySqlCmd.Parameters.AddWithValue("_tag_name", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_related_tag", textBox2.Text.Trim());
               
                GridFill();

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please fill the 'Tag Name' field");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please fill the 'Related Tag' field");
                }
                else
                {
                    mySqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                }
            }
        }
        //viewing the table in the data grid
        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewAll_mTags", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtbltag = new DataTable();
                sqlDa.Fill(dtbltag);
                dataGridView1.DataSource = dtbltag;

            }
        }
        //data grid view
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //manage tag form
        private void Ma_Load(object sender, EventArgs e)
        {
            Clear();
            GridFill();
        }
        //clearing the fields
        void Clear() {
            textBox1.Text = textBox2.Text = "";
            id_MT = 0;
           
        }
        //retrieve data to fields
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                id_MT = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
        }
        //clear button
        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //update record
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Update_Tags", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_id_MT", id_MT);
                mySqlCmd.Parameters.AddWithValue("_tag_name", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_related_tag", textBox2.Text.Trim());
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                GridFill();
            }
        }
        //delete record
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_TagsByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_id_MT", id_MT);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
