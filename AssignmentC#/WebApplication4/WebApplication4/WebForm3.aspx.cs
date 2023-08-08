using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void GridBind()
        {
            using (var dbcontext = new ProfileEntities())
            {
                GridView1.DataSource = dbcontext.user_table.ToList();
                GridView1.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridBind();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "")
            {
                Label1.Text = "Please Select a City";
            }
            else
                Label1.Text = "Your Choice is: " + DropDownList1.SelectedValue;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void UpdateUser(object sender, EventArgs e)
        {
            using (var dbcontext = new ProfileEntities())
            {
                int userID = Int32.Parse(userID_input.Value.ToString());
                var updateuser = dbcontext.user_table.Single(s => s.userId == userID);
                updateuser.email = emailId_input.Value.ToString();
                updateuser.firstName = first_name_input.Value.ToString();
                updateuser.lastName = last_name_input.Value.ToString();
                updateuser.city = city_input.Value.ToString();
                updateuser.stateId = Int32.Parse(stateid_input.Value);
                updateuser.countryId = Int32.Parse(countryid_input.Value);
                updateuser.zipcode = zipcode_input.Value.ToString();
                dbcontext.SaveChanges();


                dbcontext.SaveChanges();
            }
            GridView1.EditIndex = -1;
            GridBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            int userID = Convert.ToInt32(row.Cells[0].Text);
            update_form.Style.Add("display", "block");
            userID_input.Value= userID.ToString();
            emailId_input.Value = row.Cells[1].Text.ToString();
            first_name_input.Value = row.Cells[2].Text.ToString();
            last_name_input.Value = row.Cells[3].Text.ToString();
            countryid_input.Value = row.Cells[4].Text.ToString();
            stateid_input.Value = row.Cells[5].Text.ToString();
            city_input.Value = row.Cells[6].Text.ToString();
            zipcode_input.Value= row.Cells[7].Text.ToString();
        }
        protected void OnRowCommand(object sender, GridViewDeleteEventArgs e)
        {
            if (e.Command == "Delete")
            {

            }
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int userID = Convert.ToInt32(row.Cells[0].Text);
            using(var dbcontext = new ProfileEntities())
            {
                var deleteuser = dbcontext.user_table.SingleOrDefault(s => s.userId == userID);
                if (deleteuser != null)
                {
                    dbcontext.user_table.Remove(deleteuser);
                    dbcontext.SaveChanges();
                }
            }
            GridBind();
        }
    }
}