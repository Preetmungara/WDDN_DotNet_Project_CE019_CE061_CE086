using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Project_1_Sample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CreateProductConnectionString"].ToString());


                string uid = TextBox1.Text.ToString();
                string pass = TextBox2.Text.ToString();
                con.Open();
                string qry = "select * from test where UserId='" + uid + "' and Password='" + pass + "'";

               /* MessageBox.Show(qry);*/


                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();


                if (sdr.Read())
                {
                 /*   Label4.Text = qry;*/
                    //Server.Transfer("Register.aspx");
                    Response.Redirect("Register.aspx");
                   /* Label4.Text = "Login Sucess......!!";*/
                }
                else
                {
                    Label4.Text = "UserId & Password Is not correct Try again..!!";

                }
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}