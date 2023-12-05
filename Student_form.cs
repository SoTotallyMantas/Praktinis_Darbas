using Projektinis_darbas_akademine_is.sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projektinis_darbas_akademine_is
{
    public partial class Student_form : Form
    {
        public Student_form()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string login = Login_form.username;
            string password = Login_form.userpass;

            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("studentname", login);
            parameters.Add("studentlastname", password);
            DataTable usertable = sql.FillDataSet("SortStudentSubjectByStudent", parameters);
            sql.Close();
            dataGridView1.DataSource = usertable;


        }

        private void Student_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
