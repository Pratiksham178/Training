using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class show : System.Web.UI.Page
    {
        public int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = Int32.Parse(Request.Params["userId"]);
            using(var dbcontext = new ProfileEntities())
            {
                var user = dbcontext.Employees.Single((i)=>i.ID==userID);
                nameID.InnerText = user.Name.ToString();
                var companyname=dbcontext.Companies.Single((i)=>i.ID==user.CompanyId).CompanyName.ToString();
                companynameID.InnerText = companyname;
                var message1 = dbcontext.notes.Where((i) => i.objectID == userID && i.objectType == "employee").ToList();
                if (message1 != null)
                {
                    message.InnerHtml = "";
                    message.InnerText = "Messages:";
                    for (int i = 0; i < message1.Count; i++)
                    {
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.ID = "message" + i;
                        div.InnerText = message1[i].objectNote.ToString();
                        message.Controls.Add(div);
                    }
                }
            }

            
        }
        public void Addtodb(object sender, EventArgs e)
        {
            notetextbox_input.SaveData(userID);
            Page_Load(sender,e);
        }
    }
}