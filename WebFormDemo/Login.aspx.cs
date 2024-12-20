using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormDemo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_log(object sender, EventArgs e)
        {
            string disusername = uname.Text;
            string dispassword = pass.Text;
            try
            {
                //databse connection
                string cs = "Data Source=MANDISH\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();

                string disQuery = "select * from tbl_reg where username=@username and password=@password";
                SqlCommand sc = new SqlCommand(disQuery, conn);
                sc.Parameters.AddWithValue("username", disusername);
                sc.Parameters.AddWithValue("password", dispassword);
                int res = sc.ExecuteNonQuery();

                //execute query
                SqlDataReader sd = sc.ExecuteReader();
                if (sd.Read() == true)
                {
                    l3.Text = "Recoed found. Welcome!";
                }
                else
                {
                    l3.Text = "Username or password incorrect.";
                }


            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}