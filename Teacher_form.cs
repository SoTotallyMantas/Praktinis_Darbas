using MySqlX.XDevAPI.Relational;
using Projektinis_darbas_akademine_is.sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projektinis_darbas_akademine_is
{
    public partial class Teacher_form : Form
    {
        private string studentfistname;
        private string studentlastname;

        public Teacher_form()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {


            DataTable table = Taught_subject_Query();
            dataGridView1.DataSource = table;

            foreach (DataRow row in table.Rows)
            {
                comboBox3.Items.Add(row["subject_name"].ToString());

            }


        }

        private DataTable Taught_subject_Query()
        {
            string login = Login_form.username;
            string password = Login_form.userpass;

            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("teachername", login);
            parameters.Add("teacherlastname", password);
            DataTable usertable = sql.FillDataSet("GetTaughtSubjectByTeacher", parameters);
            sql.Close();
            return usertable;
        }
        private DataTable GetStudentsInGroup(string groupname)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("groupName", comboBox1.SelectedItem.ToString());
            DataTable usertable = sql.FillDataSet("GetStudentsInGroup", parameters);
            sql.Close();
            return usertable;
        }
        private DataTable GetAvailableGroups()
        {
            string login = Login_form.username;
            string password = Login_form.userpass;

            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("teacherfirstname", login);
            parameters.Add("teacherlastname", password);
            parameters.Add("subjectname", comboBox3.SelectedItem.ToString());
            DataTable usertable = sql.FillDataSet("GetAvailableGroups", parameters);
            sql.Close();
            return usertable;
        }
        private DataTable GetStudentSubject(string studentname, string studentlastname)
        {
            string login = Login_form.username;
            string password = Login_form.userpass;

            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentname", studentname);
            parameters.Add("studentlastname", studentlastname);
            parameters.Add("subject_name", comboBox3.SelectedItem.ToString());
            DataTable usertable = sql.FillDataSet("GetStudentSubjectByStudentAndSubject", parameters);
            sql.Close();
            return usertable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = GetStudentsInGroup(comboBox1.SelectedItem.ToString());
            dataGridView1.DataSource = table;
            foreach (DataRow row in table.Rows)
            {
                comboBox2.Items.Add(row["student_first_name"].ToString() + " " + row["student_last_name"]);

            }
            comboBox2.Visible = true;
            button2.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataTable table = GetAvailableGroups();
            foreach (DataRow row in table.Rows)
            {
                comboBox1.Items.Add(row["student_group_name"].ToString());
            }

            comboBox1.Visible = true;
            button1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable table = GetStudentSubject(studentfistname, studentlastname);
            string sentence = comboBox2.SelectedItem.ToString();
            string[] words = sentence.Split(' ');
            studentfistname = words[0];
            studentlastname = words[1];
            dataGridView1.DataSource = table;
            dataGridView1.Columns["student_subject_id"].DisplayIndex = 0;
            dataGridView1.Columns["subject_name"].DisplayIndex = 1;
            dataGridView1.Columns["grade"].DisplayIndex = 2;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;

        }
        private void UpdateStudentSubject()
        {

            string grade = textBox2.Text;
            string student_subject_id = textBox1.Text;

            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentSubjectId", student_subject_id);
            parameters.Add("newGrade", grade);
            sql.ModifyDataSet("UpdateStudentSubjectGrade", parameters);
            sql.Close();

        }
        private int GetSubject()
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subjectName", comboBox3.SelectedItem.ToString());
            DataTable usertable = sql.FillDataSet("GetSubject", parameters);
            return Convert.ToInt32(usertable.Rows[0]["subject_id"]);
        }
        private int GetStudentByName()
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("lastname", studentlastname);
            parameters.Add("firstname", studentfistname);
            DataTable usertable = sql.FillDataSet("GetStudentByName", parameters);
            return Convert.ToInt32(usertable.Rows[0]["student_id"]);
        }
        private void InsertStudentSubject()
        {
            int subject_id = GetSubject();
            int student_id = GetStudentByName();
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentId", student_id);
            parameters.Add("subjectId", subject_id);
            try
            {
                parameters.Add("grade", Convert.ToInt32(textBox2.Text.ToString()));
            }
            catch (Exception e)
            {
                MessageBox.Show("Please enter grade");
            }
            sql.ModifyDataSet("InsertStudentSubject", parameters);
            sql.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            InsertStudentSubject();
            DataTable table = GetStudentSubject(studentfistname, studentlastname);
            dataGridView1.DataSource = table;
            dataGridView1.Columns["student_subject_id"].DisplayIndex = 0;
            dataGridView1.Columns["subject_name"].DisplayIndex = 1;
            dataGridView1.Columns["grade"].DisplayIndex = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateStudentSubject();
            DataTable table = GetStudentSubject(studentfistname, studentlastname);
            dataGridView1.DataSource = table;
            dataGridView1.Columns["student_subject_id"].DisplayIndex = 0;
            dataGridView1.Columns["subject_name"].DisplayIndex = 1;
            dataGridView1.Columns["grade"].DisplayIndex = 2;
        }
        private void DeleteStudentSubject()
        {

            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            try
            {
                parameters.Add("studentsubjectid", Convert.ToInt32(textBox1.Text.ToString()));
            }
            catch (Exception e)
            {
                MessageBox.Show("Please enter student subject id");
            }
            sql.ModifyDataSet("Deletestudentsubject", parameters);
            sql.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DeleteStudentSubject();
            DataTable table = GetStudentSubject(studentfistname, studentlastname);
            dataGridView1.DataSource = table;
            dataGridView1.Columns["student_subject_id"].DisplayIndex = 0;
            dataGridView1.Columns["subject_name"].DisplayIndex = 1;
            dataGridView1.Columns["grade"].DisplayIndex = 2;
        }

        private void Teacher_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }

}
