using Org.BouncyCastle.Asn1.X509;
using Projektinis_darbas_akademine_is.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projektinis_darbas_akademine_is
{
    public partial class Admin_form : Form
    {
        public Admin_form()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            switch (comboBox1.SelectedIndex)
            {
                case 0: // student
                    {
                        DataTable usertable = sql.FillDataSet("GetStudents");
                        dataGridView1.DataSource = usertable;

                        Studentgroupbox.Visible = true;
                        StudentGroupgroupbox.Visible = false;
                        StudentSubjectGroup.Visible = false;
                        Subjectbox.Visible = false;
                        TaughtSubjectgroupbox.Visible = false;
                        Teachergroupbox.Visible = false;

                        break;
                    }
                case 1: // student_group
                    {
                        DataTable usertable = sql.FillDataSet("GetStudentGroup");
                        dataGridView1.DataSource = usertable;

                        Studentgroupbox.Visible = false;
                        StudentGroupgroupbox.Visible = true;
                        StudentSubjectGroup.Visible = false;
                        Subjectbox.Visible = false;
                        TaughtSubjectgroupbox.Visible = false;
                        Teachergroupbox.Visible = false;
                        break;
                    }
                case 2: // student_subject
                    {
                        DataTable usertable = sql.FillDataSet("SortStudentSubject");
                        dataGridView1.DataSource = usertable;
                        dataGridView1.DataSource = usertable;
                        Studentgroupbox.Visible = false;
                        StudentGroupgroupbox.Visible = false;
                        StudentSubjectGroup.Visible = true;
                        Subjectbox.Visible = false;
                        TaughtSubjectgroupbox.Visible = false;
                        Teachergroupbox.Visible = false;
                        break;
                    }
                case 3: // subject
                    {
                        DataTable usertable = sql.FillDataSet("GetAllSubjects");
                        dataGridView1.DataSource = usertable;

                        Studentgroupbox.Visible = false;
                        StudentGroupgroupbox.Visible = false;
                        StudentSubjectGroup.Visible = false;
                        Subjectbox.Visible = true;
                        TaughtSubjectgroupbox.Visible = false;
                        Teachergroupbox.Visible = false;
                        break;
                    }
                case 4: // taught_subject
                    {
                        DataTable usertable = sql.FillDataSet("GetTaughtSubjectDetails");
                        dataGridView1.DataSource = usertable;

                        Studentgroupbox.Visible = false;
                        StudentGroupgroupbox.Visible = false;
                        StudentSubjectGroup.Visible = false;
                        Subjectbox.Visible = false;
                        TaughtSubjectgroupbox.Visible = true;
                        Teachergroupbox.Visible = false;
                        break;
                    }
                case 5: // teacher
                    {
                        DataTable usertable = sql.FillDataSet("GetTeachers");
                        dataGridView1.DataSource = usertable;

                        Studentgroupbox.Visible = false;
                        StudentGroupgroupbox.Visible = false;
                        StudentSubjectGroup.Visible = false;
                        Subjectbox.Visible = false;
                        TaughtSubjectgroupbox.Visible = false;
                        Teachergroupbox.Visible = true;
                        break;
                    }



            }
            sql.Close();
        }
        // Student
        private void StudentCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (StudentCombobox.SelectedIndex)
            {
                case 0: // add
                    {
                        StudentInsertBox.Visible = true;
                        StudentDeletebox.Visible = false;
                        StudentUpdateBox.Visible = false;
                        break;
                    }
                case 1: // delete
                    {
                        StudentDeletebox.Visible = true;
                        StudentInsertBox.Visible = false;
                        StudentUpdateBox.Visible = false;
                        break;
                    }
                case 2: // update
                    {
                        StudentUpdateBox.Visible = true;
                        StudentDeletebox.Visible = false;
                        StudentInsertBox.Visible = false;
                        break;
                    }
            }
        }

        private void StudentDelete_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentId", StudentDeleteIDText.Text);
            sql.ModifyDataSet("DeleteStudent", parameters);
            DataTable usertable = sql.FillDataSet("GetStudents");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void StudentUpdate_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentId", StudentUpdateIDText.Text);
            parameters.Add("firstName", StudentUpdateFirstNameText.Text);
            parameters.Add("lastName", StudentUpdateLastNameText.Text);
            parameters.Add("studentGroupId", StudentUpdateGroupIDText.Text);
            sql.ModifyDataSet("UpdateStudent", parameters);
            DataTable usertable = sql.FillDataSet("GetStudents");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void StudentInsert_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentId", StudentUpdatetIDText.Text);
            parameters.Add("firstName", StudentInsertFirstNameText.Text);
            parameters.Add("lastName", StudentInsertLastNameText.Text);
            parameters.Add("studentGroupId", StudentInsertGroupIDText.Text);
            sql.ModifyDataSet("InsertStudent", parameters);
            DataTable usertable = sql.FillDataSet("GetStudents");
            dataGridView1.DataSource = usertable;
            sql.Close();

        }
        // Student Group
        private void StudentGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (StudentGroupComboBox.SelectedIndex)
            {
                case 0: // add
                    {
                        StudentGroupInsertbox.Visible = true;
                        StudentGroupDeleteBox.Visible = false;
                        StudentGroupUpdateBox.Visible = false;
                        break;
                    }
                case 1: // delete
                    {
                        StudentGroupInsertbox.Visible = false;
                        StudentGroupDeleteBox.Visible = true;
                        StudentGroupUpdateBox.Visible = false;
                        break;
                    }
                case 2: // update
                    {
                        StudentGroupInsertbox.Visible = false;
                        StudentGroupDeleteBox.Visible = false;
                        StudentGroupUpdateBox.Visible = true;
                        break;
                    }
            }
        }
        private void StudentGroupDelete_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("groupId", StudentGroupDeleteID.Text);
            sql.ModifyDataSet("Deletegroup", parameters);
            DataTable usertable = sql.FillDataSet("GetStudentGroup");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void StudentGroupUpdate_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("groupId", StudentGroupUpdateGroupId.Text);
            parameters.Add("newgroupname", StudentGroupUpdateName.Text);
            sql.ModifyDataSet("UpdateStudentGroup", parameters);
            DataTable usertable = sql.FillDataSet("GetStudentGroup");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void StudentGroupInsert_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentGroupId", StudentGroupInsertID.Text);
            parameters.Add("studentGroupName", StudentGroupInsertName.Text);
            sql.ModifyDataSet("InsertStudentGroup", parameters);
            DataTable usertable = sql.FillDataSet("GetStudentGroup");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void StudentSubjectcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (StudentSubjectcombobox.SelectedIndex)
            {
                case 0: // add
                    {
                        StudentSubjectInsertbox.Visible = true;
                        StudentSubjectDeletebox.Visible = false;
                        StudentSubjectUpdatebox.Visible = false;
                        break;
                    }
                case 1: // delete
                    {
                        StudentSubjectInsertbox.Visible = false;
                        StudentSubjectDeletebox.Visible = true;
                        StudentSubjectUpdatebox.Visible = false;
                        break;
                    }
                case 2: // update
                    {
                        StudentSubjectInsertbox.Visible = false;
                        StudentSubjectDeletebox.Visible = false;
                        StudentSubjectUpdatebox.Visible = true;
                        break;
                    }
            }
        }

        private void StudentSubjectDelete_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentsubjectid", StudentSubjectDeleteID.Text);
            sql.ModifyDataSet("Deletestudentsubject", parameters);
            DataTable usertable = sql.FillDataSet("SortStudentSubject");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void StudentSubjectUpdate_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentSubjectId", StudentSubjectUpdateID.Text);
            parameters.Add("studentId", StudentSubjectUpdateStudentID.Text);
            parameters.Add("SubjectId", StudentSubjectUpdateSubjectID.Text);
            parameters.Add("newGrade", StudentSubjectUpdateGrade.Text);
            sql.ModifyDataSet("UpdateStudentSubject", parameters);
            DataTable usertable = sql.FillDataSet("SortStudentSubject");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void StudentSubjectInsert_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentsubjectId", StudentSubjectInsertID.Text);
            parameters.Add("studentId", StudentSubjectInsertStudentID.Text);
            parameters.Add("subjectId", StudentSubjectInsertSubjectID.Text);
            parameters.Add("grade", StudentSubjectInsertGrade.Text);
            sql.ModifyDataSet("InsertStudentSubject", parameters);
            DataTable usertable = sql.FillDataSet("SortStudentSubject");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void Subjectbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Subjectcombobox.SelectedIndex)
            {
                case 0: // add
                    {
                        SubjectInsertbox.Visible = true;
                        SubjectDeletebox.Visible = false;
                        SubjectUpdatebox.Visible = false;
                        break;
                    }
                case 1: // delete
                    {
                        SubjectInsertbox.Visible = false;
                        SubjectDeletebox.Visible = true;
                        SubjectUpdatebox.Visible = false;
                        break;
                    }
                case 2: // update
                    {
                        SubjectInsertbox.Visible = false;
                        SubjectDeletebox.Visible = false;
                        SubjectUpdatebox.Visible = true;
                        break;
                    }
            }
        }

        private void SubjectDelete_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subjectId", SubjectDeleteID.Text);
            sql.ModifyDataSet("DeleteSubject", parameters);
            DataTable usertable = sql.FillDataSet("GetAllSubjects");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void SubjectUpdate_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subjectId", SubjectUpdateID.Text);
            parameters.Add("subjectName", SubjectUpdateName.Text);
            sql.ModifyDataSet("UpdateSubject", parameters);
            DataTable usertable = sql.FillDataSet("GetAllSubjects");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void SubjectInsert_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("subjectId", SubjectInsertID.Text);
            parameters.Add("subjectName", SubjectInsertName.Text);
            sql.ModifyDataSet("InsertSubject", parameters);
            DataTable usertable = sql.FillDataSet("GetAllSubjects");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void TaughtsubjectCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TaughtsubjectComboBox.SelectedIndex)
            {
                case 0: // add
                    {
                        TaughtSubjectInsertbox.Visible = true;
                        TaughtSubjectDeletebox.Visible = false;
                        TaughtSubjectUpdatebox.Visible = false;
                        break;
                    }
                case 1: // delete
                    {
                        TaughtSubjectInsertbox.Visible = false;
                        TaughtSubjectDeletebox.Visible = true;
                        TaughtSubjectUpdatebox.Visible = false;
                        break;
                    }
                case 2: // update
                    {
                        TaughtSubjectInsertbox.Visible = false;
                        TaughtSubjectDeletebox.Visible = false;
                        TaughtSubjectUpdatebox.Visible = true;
                        break;
                    }
            }
        }

        private void TaughtSubjectInsert_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("teacherId", TaughtSubjectInsertTeacherID.Text);
            parameters.Add("taughtSubjectId", TaughtSubjectInsertID.Text);
            parameters.Add("subjectId", TaughtSubjectInsertSubjectID.Text);
            parameters.Add("studentGroupId", TaughtSubjectInsertGroupID.Text);
            sql.ModifyDataSet("InsertTaughtSubject", parameters);
            DataTable usertable = sql.FillDataSet("GetTaughtSubjectDetails");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void TaughtSubjectDelete_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("taughtSubjectId", TaughtSubjectDeleteID.Text);
            sql.ModifyDataSet("DeleteTaughtSubject", parameters);
            DataTable usertable = sql.FillDataSet("GetTaughtSubjectDetails");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void TaughtSubjectUpdate_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("teacherId", TaughtSubjectUpdateTeacherID.Text);
            parameters.Add("taughtSubjectId", TaughtSubjectUpdateID.Text);
            parameters.Add("subjectId", TaughtSubjectUpdateSubjectID.Text);
            parameters.Add("studentGroupId", TaughtSubjectUpdateGroupID.Text);
            sql.ModifyDataSet("UpdateTaughtSubject", parameters);
            DataTable usertable = sql.FillDataSet("GetTaughtSubjectDetails");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void teachercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (teachercombobox.SelectedIndex)
            {
                case 0: // add
                    {
                        TeacherInsertbox.Visible = true;
                        TeacherDeletebox.Visible = false;
                        TeacherUpdatebox.Visible = false;
                        break;
                    }
                case 1: // delete
                    {
                        TeacherInsertbox.Visible = false;
                        TeacherDeletebox.Visible = true;
                        TeacherUpdatebox.Visible = false;
                        break;
                    }
                case 2: // update
                    {
                        TeacherInsertbox.Visible = false;
                        TeacherDeletebox.Visible = false;
                        TeacherUpdatebox.Visible = true;
                        break;
                    }
            }
        }

        private void TeacherInsert_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("teacherId", TeacherInsertID.Text);
            parameters.Add("teacherFirstName", TeacherInsertFirstName.Text);
            parameters.Add("teacherLastName", TeacherInsertLastName.Text);
            sql.ModifyDataSet("InsertTeacher", parameters);
            DataTable usertable = sql.FillDataSet("GetTeachers");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void TeacherDelete_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("teacherId", TeacherDeleteID.Text);
            sql.ModifyDataSet("DeleteTeacher", parameters);
            DataTable usertable = sql.FillDataSet("GetTeachers");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void TeacherUpdate_Click(object sender, EventArgs e)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("FirstName", TeacherUpdateFirstName.Text);
            parameters.Add("LastName", TeacherUpdateLastName.Text);
            parameters.Add("teacherId", TeacherUpdateID.Text);
            sql.ModifyDataSet("UpdateTeacher", parameters);
            DataTable usertable = sql.FillDataSet("GetTeachers");
            dataGridView1.DataSource = usertable;
            sql.Close();
        }

        private void Admin_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        

    }
}
