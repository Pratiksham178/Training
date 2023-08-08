using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Tabletype { get; set; }
        public void SaveData(int ID) {
            using(var dbcontext = new ProfileEntities())
            {
                note u = new  note{ objectID = ID, objectType = Tabletype, objectNote = noteTextbox.Text };
                dbcontext.notes.Add(u);
                dbcontext.SaveChanges();
            }
            
        }

    }
}