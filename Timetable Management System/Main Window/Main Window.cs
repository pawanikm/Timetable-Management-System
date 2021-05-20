using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTableManagementSystem;

namespace Timetable_Management_System.Location
{
    public partial class Main_Window : Form
    {
        public Main_Window()
        {
            InitializeComponent();
            hideSubMenu();
            showChildForms(new Dashboard());
            
            

            hideInfoBox();
        }

        private void hideSubMenu()
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel15.Visible = false;
            panel19.Visible = false;

        }

       
        private void showSubMenu(Panel p)
        {
            if (p.Visible == false)
            {
                hideSubMenu();
                p.Visible = true;
            }
            else
            {
                p.Visible = false;
            }

        }

        private void hideInfoBox()
        {
            label1.Visible = false;
        }

        private void showInfoBox(Label l)
        {
            if (l.Visible == false)
            {
                hideInfoBox();
                l.Visible = true;
            }
            else
            {
                l.Visible = false;
            }
        }


        private Form currentForm = null;

        private void showChildForms(Form f)
        {
            if (currentForm != null)
            {
                currentForm.Close();

            }

            currentForm = f;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Top;

            panel11.Controls.Add(f);
            panel11.Tag = f;
            f.BringToFront();
            f.Show();

        }

        //Student Groups
        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        //Add student group
        private void button2_Click(object sender, EventArgs e)
        {
            showChildForms(new WindowsFormsApp1.Student.Add_Student_Group());


        }

        //Manage Student Groups
        private void button3_Click(object sender, EventArgs e)
        {
            showChildForms(new WindowsFormsApp1.Student.Manage_Students());

        }

        //Lecturers
        private void button4_Click(object sender, EventArgs e)
        {
            showSubMenu(panel5);
        }

        //Add lecturers
        private void button10_Click(object sender, EventArgs e)
        {
            showChildForms(new TimeTableManagementSystem.AddLecturers());


        }

        //Manage lecturers
        private void button11_Click(object sender, EventArgs e)
        {
            showChildForms(new TimeTableManagementSystem.ManageLecturers());


        }

        //Subjects
        private void button5_Click(object sender, EventArgs e)
        {
            showSubMenu(panel6);
        }

        //Add subjects
        private void button12_Click(object sender, EventArgs e)
        {
            showChildForms(new TimeTableManagementSystem.AddSubject());


        }

        //Manage Subjects
        private void button13_Click(object sender, EventArgs e)
        {
            showChildForms(new TimeTableManagementSystem.ManageSubjects());


        }

        //Tags
        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(panel7);
        }

        //Manage Tags 
        private void button15_Click(object sender, EventArgs e)
        {
            showChildForms(new WindowsFormsApp1.Student.Ma());
        }

        //Location
        private void button7_Click(object sender, EventArgs e)
        {
            showSubMenu(panel8);
        }

        //Add location
        private void button8_Click(object sender, EventArgs e)
        {
            showChildForms(new Add_Location());
        }

        //Manage location
        private void button9_Click(object sender, EventArgs e)
        {
            showChildForms(new Manage_Locations());
        }


        //working days & hours
        private void button16_Click(object sender, EventArgs e)
        {
            showSubMenu(panel12);
        }


        //Add working days & hours button
        private void button17_Click(object sender, EventArgs e)
        {
            showChildForms(new Time_Table_Management_System.AddWorkingDaysHours1());
        }

        //Manage working days & hours
        private void button18_Click(object sender, EventArgs e)
        {
            showChildForms(new Time_Table_Management_System.ManageWorkingdayshours());
        }

        //Time slots
        private void button19_Click(object sender, EventArgs e)
        {
            showSubMenu(panel13);
        }

        //Manage timeslots
        private void button21_Click(object sender, EventArgs e)
        {
            showChildForms(new Time_Table_Management_System.Form1());
        }



        //dashboard
        private void button30_Click(object sender, EventArgs e)
        {
            showChildForms(new Dashboard());

        }

        //sessions
        private void button14_Click(object sender, EventArgs e)
        {
            showSubMenu(panel15);
        }

        //Add session
        private void button22_Click(object sender, EventArgs e)
        {
            showChildForms(new TimeTableManagementSystem.AddSessions());
        }
        //Manage session
        private void button23_Click(object sender, EventArgs e)
        {
            showChildForms(new TimeTableManagementSystem.ManageSessions());
        }


        //session allocation
        private void button26_Click(object sender, EventArgs e)
        {
            showChildForms(new WindowsFormsApp1.Student.Session_Allocation());
        }

        //Location Allocation
        private void button29_Click(object sender, EventArgs e)
        {
            showSubMenu(panel19);
        }
        //Special Rooms
        private void button28_Click(object sender, EventArgs e)
        {
            showChildForms(new Add_Suitable_Room());
        }
        //Session Rooms
        private void button27_Click(object sender, EventArgs e)
        {
            showChildForms(new Allocate_Suitable_Location());
        }

        //Timetables
        private void button31_Click(object sender, EventArgs e)
        {
            showChildForms(new TimeTableManagementSystem.GenerateTimeTable());
        }

        //info button
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            showInfoBox(label1);
        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        
        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
