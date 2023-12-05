using Projektinis_darbas_akademine_is.Classes;
using Projektinis_darbas_akademine_is.sql;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace Projektinis_darbas_akademine_is
{
    public partial class Login_form : Form
    {
        public static string username;
        public static string userpass;
        public static string SQLIP = "localhost";
        
        public Login_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            string login = Vardas.Text;
            string password = Slaptazodis.Text;
            LoginService loginService_studentas = new LoginService(new StudentLoginValidation());
            LoginController prisijungimas_studentas = new LoginController(loginService_studentas);
            username = login;
            userpass = password;

            if (prisijungimas_studentas.HandleLogin(login, password))
            {
                ActiveForm.Hide();
                MessageBox.Show("Prisijungta");
                Student_form DataBase_Editor = new Student_form();
                DataBase_Editor.Show();

            }
            else
            {
                LoginService loginService_destytojas = new LoginService(new TeacherLoginValidation());
                LoginController prisijungimas_destytojas = new LoginController(loginService_destytojas);
                if (prisijungimas_destytojas.HandleLogin(login, password))
                {
                    ActiveForm.Hide();
                    MessageBox.Show("Prisijungta");
                    Teacher_form DataBase_Editor = new Teacher_form();
                    DataBase_Editor.Show();

                }
                else
                {
                    LoginService loginService_administratorius = new LoginService(new AdminLoginValidation());
                    LoginController prisijungimas_administratorius = new LoginController(loginService_administratorius);
                    if (prisijungimas_administratorius.HandleLogin(login, password))
                    {
                        ActiveForm.Hide();
                        MessageBox.Show("Prisijungta");
                        Admin_form DataBase_Editor = new Admin_form();
                        DataBase_Editor.Show();

                    }
                    else
                    {
                        MessageBox.Show("Neteisingi duomenys");
                    }
                }
            }

            //sql.ModifyDataSet("InsertTeacher", parameters);





        }


    }




}