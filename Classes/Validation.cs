using Microsoft.VisualBasic.Logging;
using Projektinis_darbas_akademine_is.Interface;
using Projektinis_darbas_akademine_is.sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektinis_darbas_akademine_is.Classes
{
    internal class StudentLoginValidation : ILoginValidation
    {

        public bool ValidateLogin(string username, string password)
        {
            sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
            sql.Open();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@firstname", username);
            parameters.Add("@lastname", password);
            DataTable usertable = sql.FillDataSet("GetStudentByName", parameters);
            sql.Close();
            string Checkusername;
            string Checkpassword;
            bool Loginin = false;
            if (usertable.Rows.Count > 0)
            {
                foreach (DataRow row in usertable.Rows)
                {
                    Checkusername = usertable.Rows[0]["student_first_name"].ToString();
                    Checkpassword = usertable.Rows[0]["student_last_name"].ToString();
                    Loginin = CheckLogin.Check(username, password, Checkusername, Checkpassword);
                }
            }
            return Loginin;
        }
    }
        internal class TeacherLoginValidation : ILoginValidation
        {
            public bool ValidateLogin(string username, string password)
            {
                sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
                sql.Open();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@firstname", username);
                DataTable usertable = sql.FillDataSet("GetTeacherByName", parameters);
                 sql.Close();
                string Checkusername;
                string Checkpassword;
                bool Loginin = false;
                if (usertable.Rows.Count > 0)
                {
                    foreach (DataRow row in usertable.Rows)
                    {
                        Checkusername = usertable.Rows[0]["teacher_first_name"].ToString();
                        Checkpassword = usertable.Rows[0]["teacher_last_name"].ToString();
                        Loginin = CheckLogin.Check(username, password, Checkusername, Checkpassword);
                    }
                }
                return Loginin;
            }
        }
        internal class AdminLoginValidation : ILoginValidation
        {
            public bool ValidateLogin(string username, string password)
            {
                sql_class sql = new sql_class(Login_form.SQLIP, "praktinis_darbas", "root", "12321", "3306");
                sql.Open();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@firstname", username);
                DataTable usertable = sql.FillDataSet("GetAdminByName", parameters);
                sql.Close();
                string Checkusername;
                string Checkpassword;
                bool Loginin = false;
                if (usertable.Rows.Count > 0)
                {
                    foreach (DataRow row in usertable.Rows)
                    {
                        Checkusername = usertable.Rows[0]["admin_first_name"].ToString();
                        Checkpassword = usertable.Rows[0]["admin_last_name"].ToString();
                        Loginin = CheckLogin.Check(username, password, Checkusername, Checkpassword);
                    }
                }
                return Loginin;
            }
        }

        internal class LoginService
        {
            private readonly ILoginValidation validator;

            public LoginService(ILoginValidation validator)
            {
                this.validator = validator;
            }

            public bool Login(string username, string password)
            {
                return validator.ValidateLogin(username, password);
            }
        }

        internal class LoginController
        {
            private readonly LoginService loginService;

            public LoginController(LoginService loginService)
            {
                this.loginService = loginService;
            }

            public bool HandleLogin(string username, string password)
            {
                bool loginSuccessful = loginService.Login(username, password);

                if (loginSuccessful)
                {
                return true;
                }
                else
                {
                return false;
                }
                
                
                  
                
                
            }
        }
    }

