using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1_Sample
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["CreateProductConnectionString"].ConnectionString;
            string query = "SELECT * FROM Product";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Insert(object sender, EventArgs e)
        {

            string Pid = RandomDigits(10);
            string pr_name = name.Text;
            string discription_name = discription.Text;
            string price_value = price.Text;
            string qty_count = qty.Text;
            string path = "~/Image/" + FileUpload1.FileName;


            /*string name = txtName.Text;
            string country = txtCountry.Text;*/

            /*txtName.Text = "";
            txtCountry.Text = "";*/

            name.Text = "";
            discription.Text = "";
            price.Text = "";
            qty.Text = "";

            string query = "INSERT INTO Product VALUES(@Pid, @pr_name,@discription_name, @price_value,@qty_count,@file)";

            FileUpload1.SaveAs(Server.MapPath("Image") + "/" + FileUpload1.FileName);

            /*string query = "INSERT INTO Product VALUES(@Name, @Country)";*/
            string constr = ConfigurationManager.ConnectionStrings["CreateProductConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Pid", Pid);
                    cmd.Parameters.AddWithValue("@pr_name", pr_name);
                    cmd.Parameters.AddWithValue("@discription_name", discription_name);
                    cmd.Parameters.AddWithValue("@price_value", price_value);
                    cmd.Parameters.AddWithValue("@qty_count", qty_count);
                    cmd.Parameters.AddWithValue("@file", path);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string Pid = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.FindControl("name") as TextBox).Text;
            string discription = (row.FindControl("discription") as TextBox).Text;
            string price = (row.FindControl("price") as TextBox).Text;
            string qty = (row.FindControl("qty") as TextBox).Text;
            string file = (row.FindControl("Image1") as Image).ImageUrl;


            string query = "UPDATE Product SET  Pname=@Pname, PDiscription=@PDiscription, Price=@Price, Qty=@Qty, prod_imgpath=@prod_imgpath WHERE Id=@id";


            /*string query = "UPDATE Product SET Name=@Name, Country=@Country WHERE CustomerId=@CustomerId";*/

            string constr = ConfigurationManager.ConnectionStrings["CreateProductConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@id", Pid);
                    cmd.Parameters.AddWithValue("@Pname", name);
                    cmd.Parameters.AddWithValue("@PDiscription", discription);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Qty", qty);
                    cmd.Parameters.AddWithValue("@prod_imgpath", file);


                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Pid = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Product WHERE Id=@Id";
            string constr = ConfigurationManager.ConnectionStrings["CreateProductConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Id", Pid);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }



        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }


        

        /*protected void Create_Product(object sender, EventArgs e)
        {
            try
            {

                string path = "~/Image/" + FileUpload1.FileName;

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CreateProductConnectionString"].ConnectionString);

                conn.Open();

                string Pid = RandomDigits(10);
                string pr_name = name.Text;
                string discription_name = discription.Text;
                string price_value = price.Text;
                string qty_count = qty.Text;


 string query = "insert into Product values('" + Pid + "','" + pr_name + "', '" + discription_name + "','" + price_value + "','" + qty_count + "','" + path + "')";

                FileUpload1.SaveAs(Server.MapPath("Image") + "/" + FileUpload1.FileName);

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                cmd.CommandText = query;
                int x = cmd.ExecuteNonQuery();
                conn.Close();

                if (x > 0)
                {
                    Response.Write("Item inserted Successfully");
                }
                else
                {
                    Response.Write("Try Again");
                }

            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }
        }*/

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}