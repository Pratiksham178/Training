using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginUserRegistration
{
    public class FileDetails
    {
        public string name;
        public int userID;

    }
    public partial class Form :MasterClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["userId"] != null)
            {
                notetextbox_input.Attributes["Style"] = "display:block";
                Delete.Visible = true;
            }
            else
            {
                notetextbox_input.Attributes["Style"] = "display:none";
                buttonsdiv.Attributes["Style"] = "display:none";
            }
        }

        protected void DeleteUser(object sender, EventArgs e)
        {
            var specificUserId = Int32.Parse(Request.Params["userId"]);
            using (var dbcontext = new ProfileEntities())
            {
                var deleteuser = dbcontext.userDetails.Where((i) => i.ID == specificUserId).ToList();
                dbcontext.userDetails.RemoveRange(deleteuser);
                var deletehobbies = dbcontext.Hobby_table.Where((i) => i.userID == specificUserId).ToList();
                dbcontext.Hobby_table.RemoveRange(deletehobbies);
                var deletelanguages = dbcontext.language_table.Where((i) => i.userID == specificUserId).ToList();
                dbcontext.language_table.RemoveRange(deletelanguages);
                var userroles = dbcontext.userrolerelation.Where((i) => i.userID == specificUserId).ToList();
                dbcontext.userrolerelation.RemoveRange(userroles);
                var deletenotes = dbcontext.note_table.Where((i) => i.ID == specificUserId).ToList();
                dbcontext.note_table.RemoveRange(deletenotes);
                dbcontext.SaveChanges();
            }
            Response.Redirect("LoginPage.aspx");
        }
        [WebMethod]
        public static List<FileDetails> GetAllFiles()
        {

            using (var dbcontext = new ProfileEntities())
            {
                var allfiles = new List<FileDetails>();
                var allfilelist = dbcontext.filelist;
                foreach (var file in allfilelist)
                {
                    var fileinfo = new FileDetails();
                    fileinfo.name = file.filename;
                    fileinfo.userID = file.userID;
                    allfiles.Add(fileinfo);
                }
                return allfiles;
            }
        }
        [WebMethod]
        public static void UploadFile(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fname = context.Server.MapPath("~/uploads/" + file.FileName);
                    file.SaveAs(fname);

                    using (var dbcontext = new ProfileEntities())
                    {
                        
                        //filelist onefile = new filelist
                        //{
                        //    userID = context.Request.Formdata["userId"],
                        //    filename = file.FileName
                        //};

                       // dbcontext.filelist.Add(onefile);
                    }
                }
            }

            
        }
    }
}