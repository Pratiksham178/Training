using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Buisness;
using UserManagement.Model;

namespace UserManagement
{
    public partial class FormBasicinfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<UserRole> roles = Form.GetUserRoleCheckList();
            foreach (UserRole role in roles)
            {
                ListItem listItem = new ListItem(role.RoleName,role.RoleId.ToString());
                CheckBoxList1.Items.Add(listItem);
            }
            if (!IsPostBack)
            {
                if (Request.Params["userId"] != null)
                {
                    Save.Text = "Update";
                }
            }
        }
    }
}