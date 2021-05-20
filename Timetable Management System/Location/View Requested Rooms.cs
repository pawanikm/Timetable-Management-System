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


namespace Timetable_Management_System.Location
{
    public partial class View_Requested_Rooms : Form
    {
        string connectionString = @"Server=us-cdbr-east-03.cleardb.com;Database=heroku_bcf68a92068cc8d;Uid=b4c4846ae4a54f;Pwd=8d771c56;";

        public View_Requested_Rooms()
        {
            InitializeComponent();
        }

        
        //Search Button
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("Search_Requested_Rooms", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_searchValue", textBox1.Text);
                DataTable dtblLec = new DataTable();
                sqlDa.Fill(dtblLec);
                dataGridView1.DataSource = dtblLec;
                dataGridView1.Columns[0].Visible = true;

            }
        }

        //Refresh Button
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void View_Requested_Rooms_Load(object sender, EventArgs e)
        {

        }

       
    }
}
