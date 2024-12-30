using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebFormDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //after button is clicked controls come here
        protected void btn_ans(object sender, EventArgs e)
        {
            try
            {
                //extracting form field
                string id = uid.Text;
                string username = uname.Text;
                string password = pass.Text;
                string repassword = repass.Text;
                string gender = "";
                if (rb1.Checked)
                {
                    gender = rb1.Text;
                }
                else
                {
                    gender = rb2.Text;
                }
                string faculty = "";
                if(fac.SelectedValue != "")
                {
                    faculty = fac.SelectedValue;
                }
                //databse connection
                string cs = "Data Source=MANDISH\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string insQuery = "insert into tbl_reg values(@id,@username,@password,@repassword,@gender,@faculty)";
                SqlCommand sc = new SqlCommand(insQuery, conn);
                sc.Parameters.AddWithValue("id", id);
                sc.Parameters.AddWithValue("username", username);
                sc.Parameters.AddWithValue("password", password);
                sc.Parameters.AddWithValue("repassword", repassword);
                sc.Parameters.AddWithValue("gender", gender);
                sc.Parameters.AddWithValue("faculty", faculty);
                int res = sc.ExecuteNonQuery();
                if (res > 0)
                {
                    l7.Text = "data inserted";
                }
                else
                {
                    l7.Text = "data not inserted";
                }
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
            }

        }
    }
}