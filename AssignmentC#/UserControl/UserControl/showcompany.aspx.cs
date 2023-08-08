using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class showcompany : System.Web.UI.Page
    {
        public int companyID;
        protected void Page_Load(object sender, EventArgs e)
        {
            companyID = Int32.Parse(Request.Params["companyId"]);
            using (var dbcontext = new ProfileEntities())
            {
                var user = dbcontext.Companies.Single((i) => i.ID == companyID);
                companynameID.InnerText = user.CompanyName.ToString();
                var message1 = dbcontext.notes.Where((i) => i.objectID == companyID && i.objectType=="company").ToList();
                if(message1!= null)
                {
                    message.InnerHtml="";
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
            notetextbox_input.SaveData(companyID);

            Page_Load(sender, e);
        }
    }
}