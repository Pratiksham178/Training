using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace viewState
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                tbUserName.Text = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            
        }
        protected void rbLBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbLBackColor.SelectedItem.Value.Equals("Red"))
            {
                TextBox1.BackColor = Color.Red;
            }
            else if (rbLBackColor.SelectedItem.Value.Equals("Green"))
            {
                TextBox1.BackColor = Color.Green;
            }
            else if (rbLBackColor.SelectedItem.Value.Equals("Blue"))
            {
                TextBox1.BackColor = Color.Blue;
            }
        }

        protected void rbLForeColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbLForeColor.SelectedItem.Value.Equals("Red"))
            {
                TextBox1.ForeColor = Color.Red;
            }
            else if (rbLForeColor.SelectedItem.Value.Equals("Green"))
            {
                TextBox1.ForeColor = Color.Green;
            }
            else if (rbLForeColor.SelectedItem.Value.Equals("Blue"))
            {
                TextBox1.ForeColor = Color.Blue;
            }
        }
    }
}