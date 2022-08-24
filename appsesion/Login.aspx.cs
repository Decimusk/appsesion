using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appsesion
{
    public partial class Login : System.Web.UI.Page
    {
        static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=aspnet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "sp_login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", txtUserId.Text.ToString());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.ToString());
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session["UserId"] = txtUserId.Text.ToString();
                    txtInfo.Text = "Login Succesful!";
                    reader.Close();
                    con.Close();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}