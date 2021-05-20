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
    public partial class Manage_Students : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        int id_SG;

        public Manage_Students()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //viewing the table in the data grid
        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("ViewAll_StdGroups", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblstudent_group = new DataTable();
                sqlDa.Fill(dtblstudent_group);
                dataGridView1.DataSource = dtblstudent_group;

            }
        }

        //clear fields
        void Clear()
        {
            textBox1.Text = comboBox1.Text = numericUpDown1.Text = numericUpDown2.Text = textBox2.Text = textBox3.Text = "";
            id_SG = 0;
        }


        //update button
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Update_StdGroup", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_id_SG", id_SG);
                mySqlCmd.Parameters.AddWithValue("_Acad_Year_Sem", textBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Programme", comboBox1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Group_Num", numericUpDown1.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_SubGroup_Num", numericUpDown2.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Group_ID", textBox2.Text = this.textBox1.Text + "." + this.numericUpDown1.Text + "(" + this.comboBox1.Text + ")");
                mySqlCmd.Parameters.AddWithValue("_SubGroup_ID", textBox3.Text = this.textBox1.Text + "." + this.numericUpDown1.Text + "." + this.numericUpDown2.Text + "(" + this.comboBox1.Text + ")");
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                GridFill();
            }

        }
        //manage student form
        private void Manage_Students_Load(object sender, EventArgs e)
        {
            GridFill();
            Clear();
        }
        //retrieve data to fields
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                numericUpDown1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                numericUpDown2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                id_SG = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
        }
        //clear button
        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("Delete_StdGroupByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_id_SG", id_SG);               
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                GridFill();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
