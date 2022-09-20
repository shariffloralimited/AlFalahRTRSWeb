using System;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace RTGS
{
    public class ReportGen
    {
        public void SetDoc(Document document, string str, string LogoImage, DataTable dt, string SettlementDate)
        {
            Font fnt = new Font(Font.HELVETICA, 8);
            Font fntblue = new Font(Font.HELVETICA, 8);
            fntblue.Color = new Color(0, 0, 255);
            Font fntbld = new Font(Font.HELVETICA, 8);
            fntbld.SetStyle(Font.BOLD);

            HeaderFooter footer = new HeaderFooter(new Phrase(str, fnt), false);
            footer.Alignment = Element.ALIGN_CENTER;

            document.Footer = footer;
            document.Open();

            iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(LogoImage);
            jpeg.Alignment = Element.ALIGN_RIGHT;
            Cell logocell = new Cell();
            logocell.Add(jpeg);

            iTextSharp.text.Table headertable = new iTextSharp.text.Table(3);
            headertable.DefaultCell.Border = Rectangle.NO_BORDER;
            headertable.DefaultCell.VerticalAlignment = Cell.ALIGN_BOTTOM;
            headertable.Cellpadding = 0;
            headertable.Cellspacing = 0;
            headertable.Border = 0;
            headertable.Width = 100;

            string headphrase = "Report Date and Time: " + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm");

            headertable.AddCell(new Phrase(headphrase, fntblue));

            headertable.AddCell("Transaction Report for " + SettlementDate + "\n");
            headertable.AddCell(logocell);

            document.Add(headertable);

            document.Add(new iTextSharp.text.Paragraph(" "));
            iTextSharp.text.pdf.PdfPTable datatable = new iTextSharp.text.pdf.PdfPTable(13);
            datatable.DefaultCell.Padding = 1;
            datatable.DefaultCell.BorderColor = new iTextSharp.text.Color(200, 200, 200);
            float[] headerwidths = { 6, 7, 10, 12, 13, 12, 13, 8, 8, 8, 4, 9, 6 };
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 99;

            iTextSharp.text.pdf.BaseFont bf = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.WINANSI, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

            datatable.DefaultCell.BorderWidth = 0.5f;
            datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(200, 200, 200);
            //------------------------------------------

            datatable.AddCell(new iTextSharp.text.Phrase("Form", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Settlm Date", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Branch", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Senders A/C", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Sender", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Receivers A/C", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Receivers", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Amount", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Charge", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Vat", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("CCY", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Bank", fnt));
            datatable.AddCell(new iTextSharp.text.Phrase("Status", fnt));

            datatable.HeaderRows = 1;
            datatable.DefaultCell.BackgroundColor = new iTextSharp.text.Color(255, 255, 255);
            datatable.DefaultCell.BorderWidth = 0.25f;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["FormName"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["SttlmDt"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Branch"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrAcctId"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["DbtrNm"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrAcctId"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CdtrNm"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["SttlmAmt"]).ToString("0.00"), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["ChargedAmount"]).ToString("0.00"), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase(((decimal)dt.Rows[i]["VatAmount"]).ToString("0.00"), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["CCY"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["Bank"]).ToString(), fnt));
                datatable.AddCell(new iTextSharp.text.Phrase((dt.Rows[i]["StatusName"]).ToString(), fnt));

            }

            //-------------TOTAL IN FOOTER --------------------
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(SttlmAmt)", "").ToString()), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(ChargedAmount)", "").ToString()), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase(Utilities.ToMoney(dt.Compute("SUM(VatAmount)", "").ToString()), fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            datatable.AddCell(new iTextSharp.text.Phrase("", fntbld));
            //-------------END TOTAL -------------------------

            document.Add(datatable);

            //////////////////////////////////////////////

            document.Close();
            dt.Dispose();
        }

    }
}