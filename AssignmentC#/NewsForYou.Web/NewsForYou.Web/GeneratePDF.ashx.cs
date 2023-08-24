using NewsForYou.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.SessionState;
using iTextSharp.text.pdf.qrcode;
using NewsForYou.Models;

namespace NewsForYou.Web
{
    /// <summary>
    /// Summary description for GeneratePDF
    /// </summary>
    public class GeneratePDF : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string date = context.Request.Params["date"];
                var allreports = BusinessClass.GetReport(date);

                if (allreports.Count() > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Document doc = new Document();
                        PdfWriter pdf = PdfWriter.GetInstance(doc, ms);
                        doc.Open();
                        PdfPTable table = new PdfPTable(3);
                        table.AddCell("Agency Name");
                        table.AddCell("Title");
                        table.AddCell("Views");
                        foreach (var report in allreports)
                        {
                            table.AddCell(report.Agency);
                            table.AddCell(report.Title);
                            table.AddCell(report.NoOfClick.ToString());
                        }
                        doc.Add(table);

                        byte[] bytesInStream = ms.ToArray();
                        ms.Write(bytesInStream, 0, bytesInStream.Length);
                        doc.Close();
                        pdf.Close();
                        context.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                        context.Response.ContentType = "application/pdf";
                        context.Response.AddHeader("Content-Disposition", "attachment;filename=NewsReport" + date + ".pdf"); context.Response.BinaryWrite(bytesInStream);
                    }
                }

            }catch(Exception ex)
            {
                NewsForYou.Util.Utilities.WriteLog(ex);
            }




        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}