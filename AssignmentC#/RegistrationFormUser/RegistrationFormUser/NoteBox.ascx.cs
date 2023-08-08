using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RegistrationFormUser
{
    public partial class NoteBox : System.Web.UI.UserControl
    {
        public int userId;
        protected void ShowNotes()
        {
            if (Request.Params["userId"]!=null)
            {
                userId = Int32.Parse(Request.Params["userId"]);
                using (var dbcontext = new ProfileEntities())
                {
                    var message1 = dbcontext.note_table.Where((i) => i.userID == userId).ToList();
                    if (message1.Count > 0)
                    {
                        //userNotes.InnerHtml = "";
                        //message.InnerText = "Your notes:";
                        //for (int i = 0; i < message1.Count; i++)
                        //{
                        //    HtmlGenericControl div = new HtmlGenericControl("div");
                        //    div.InnerText = message1[i].note.ToString();
                        //    div.Attributes["style"] = "padding:10px;background-color:white;border-bottom:1px solid black;width:90%;margin:auto";
                        //    userNotes.Controls.Add(div);
                        //}
                    }
                    else
                    {
                        message.InnerText = "There are no messages! Add notes";
                    }
                }
            }
            else
            {
                note_input_box.Visible = false;
            }

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowNotes();
            }
        }
        protected void AddNoteToDB(object sender, EventArgs e)
        {
            userId = Int32.Parse(Request.Params["userId"]);
            note_table note = new note_table
            {
                userID = userId,
                note = addNoteTextBox.Text
            };
            using (var dbcontext = new ProfileEntities())
            {
                dbcontext.note_table.Add(note);
                dbcontext.SaveChanges();
            }
            addNoteTextBox.Text = "";
            ShowNotes();
        }
    }
}