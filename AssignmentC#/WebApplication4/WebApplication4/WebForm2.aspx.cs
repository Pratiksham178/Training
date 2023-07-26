using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCourses.Text = "None";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var message = "";
            if (CheckBox1.Checked)
            {
                message = CheckBox1.Text + " ";
            }
            if (CheckBox2.Checked)
            {
                message += CheckBox2.Text + " ";
            }
            if (CheckBox3.Checked)
            {
                message += CheckBox3.Text;
            }
            ShowCourses.Text = message;
        }
        //protected void Button_Click(object sender, EventArgs e)
        //{
        //    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        //    {
        //        string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        //        string SaveLocation = Server.MapPath("upload") + "\\" + fn;
        //        try
        //        {
        //            FileUpload1.PostedFile.SaveAs(SaveLocation);
        //            FileUploadStatus.Text = "The file has been uploaded.";
        //        }
        //        catch (Exception ex)
        //        {
        //            FileUploadStatus.Text = "Error: " + ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        FileUploadStatus.Text = "Please select a file to upload.";
        //    }
        //}
        protected void Button_Click(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                var count = 0;
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    string fn = System.IO.Path.GetFileName(uploadedFile.FileName);
                    string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                    try
                    {
                        uploadedFile.SaveAs(SaveLocation);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        FileUploadStatus.Text = "Error: " + ex.Message;
                    }
                }
                if (count > 0)
                {
                    FileUploadStatus.Text = count + " files has been uploadeddddddd.";
                }
            }
            else
            {
                FileUploadStatus.Text = "Please select a file to upload.";
            }
        }
        protected void download_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\pratiksham\\Desktop\\hi.txt";
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
            else Label2.Text = "Requested file is not available to download";
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            userInput.Text = UserName.Text;
        }
        public void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ShowDate.Text = "You Selected:" + Calendar1.SelectedDate.ToString("D");
        }
    }
}