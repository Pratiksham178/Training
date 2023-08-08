using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LoginUserRegistration
{
    public partial class files : System.Web.UI.UserControl
    {
        public int userId;
        protected void ShowFiles()
        {
            if (Request.Params["userId"] != null)
            {
                userId = Int32.Parse(Request.Params["userId"]);
                using (var dbcontext = new ProfileEntities())
                {
                    //var eachdivhtml = "<div class=\"filename\">[filename]</div>\r\n        <div class=\"download\"><button id=\"download_btn\" type=\"button\" class=\"[id-dwnld]\"><i class=\"fa fa-download\"></i></button></div>\r\n        <div class=\"delete\"><button id=\"delete_btn\" type=\"button\" class=\"[id-dlt]\"><i class=\"fa fa-trash\"></i></button></div>";
                    //var eachdivhtml = "<div class=\"filename\">[filename]</div>";
                    var message1 = dbcontext.filelist.Where((i) => i.userID == userId).ToList();
                    if (message1.Count > 0)
                    {
                        fileGridView.DataSource = message1;
                        fileGridView.DataBind();
                        //filebox.InnerHtml = "";
                        //message_file.InnerText = "Your files:";
                        //for (int i = 0; i < message1.Count; i++)
                        //{
                        //    HtmlGenericControl div = new HtmlGenericControl("div");
                        //    var filename = message1[i].filename;
                        //    div.Attributes.Add("class", "eachfile");
                        //    //div.Attributes["style"]= "display:flex;\r\n    flex-direction:row;\r\n    background-color:white;\r\n    width:90%;\r\n    margin:auto;"
                        //    //div.InnerHtml = eachdivhtml.Replace("[filename]", filename).Replace("[id-dwnld]", message1[i].userID.ToString()).Replace("[id-dlt]", message1[i].userID.ToString());
                        //    div.InnerHtml = eachdivhtml.Replace("[filename]", filename);

                        //    filebox.Controls.Add(div);
                        //}
                    }
                    else
                    {
                        message_file.InnerText = "There are no files! Add files";
                    }
                }
            }
            else
            {
                filebox.Visible = false;
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowFiles();
            }
        }
        protected void UploadFile(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                var dbcontext = new ProfileEntities();
                var count = 0;
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    string fn = System.IO.Path.GetFileName(uploadedFile.FileName);
                    string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                    uploadedFile.SaveAs(SaveLocation);
                    count++;
                    userId = Int32.Parse(Request.Params["userId"]);
                    filelist file = new filelist
                    {
                        userID = userId,
                        filename = uploadedFile.FileName
                    };

                    dbcontext.filelist.Add(file);

                }

                dbcontext.SaveChanges();
                ShowFiles();
            }
            else
            {
                uploadFileText.InnerText = "Please select a file to upload.";
            }
        }
        protected void DeleteOrDownloadFile(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "dwnld")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string filename = fileGridView.DataKeys[index].Values[0].ToString();
                string filePath = Server.MapPath("upload") + "\\" + filename;
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    // Clear Rsponse reference  
                    Response.Clear();
                    // Add header by specifying file name  
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    // Add header for content length  
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    // Specify content type  
                    Response.ContentType = "text/plain";
                    // Clearing flush  
                    Response.Flush();
                    // Transimiting file  
                    Response.TransmitFile(file.FullName);
                    Response.End();
                }
            }
            if (e.CommandName == "dlt")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string filename = fileGridView.DataKeys[index].Values[0].ToString();
                string deleteLocation = Server.MapPath("upload") + "\\" + filename;
                FileInfo file = new FileInfo(deleteLocation);
                if (file.Exists)
                {
                    file.Delete();
                    using (var dbcontext = new ProfileEntities())
                    {
                        userId = Int32.Parse(Request.Params["userId"]);
                        var deletefile = dbcontext.filelist.Where((i) => i.userID == userId).Where((i) => i.filename == filename).ToList();
                        dbcontext.filelist.RemoveRange(deletefile);
                        dbcontext.SaveChanges();
                        ShowFiles();
                    }
                }

            }

        }
    }
}
   