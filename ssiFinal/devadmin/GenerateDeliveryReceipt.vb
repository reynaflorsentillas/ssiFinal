Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System
Imports System.Web

Namespace ssiFinal
	Public Class GenerateDeliveryReceipt
		Inherits PdfPageEventHelper
		Protected ReadOnly Property footer As Font
			Get
				Dim baseColor As iTextSharp.text.BaseColor = New iTextSharp.text.BaseColor(128, 128, 128)
				Return FontFactory.GetFont("Arial", 9!, 0)
			End Get
		End Property

		Public Sub New()
			MyBase.New()
		End Sub

		Public Overrides Sub OnEndPage(ByVal writer As PdfWriter, ByVal doc2 As Document)
			Dim pdfPTable As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2) With
			{
				.TotalWidth = doc2.PageSize.Width,
				.HorizontalAlignment = 1
			}
			Dim paragraph As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph("Received By:", Me.footer)
			paragraph.Add(Environment.NewLine)
			paragraph.Add(Environment.NewLine)
			paragraph.Add(Environment.NewLine)
			paragraph.Add("_____________________________")
			paragraph.Add(Environment.NewLine)
			paragraph.Add("Print Signature Over Printed Name")
			paragraph.Add(Environment.NewLine)
			paragraph.Add(Environment.NewLine)
			paragraph.Add(Environment.NewLine)
			paragraph.Add("Time Delivered:____________________")
			Dim pdfPCell As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(paragraph) With
			{
				.Border = 0,
				.PaddingLeft = 50!
			}
			pdfPTable.AddCell(pdfPCell)
			paragraph = New iTextSharp.text.Paragraph("Received From:", Me.footer)
			paragraph.Add(Environment.NewLine)
			paragraph.Add(Environment.NewLine)
			paragraph.Add(Environment.NewLine)
			paragraph.Add("_____________________________")
			paragraph.Add(Environment.NewLine)
			paragraph.Add("Print Signature Over Printed Name")
			pdfPCell = New iTextSharp.text.pdf.PdfPCell(paragraph) With
			{
				.HorizontalAlignment = 0,
				.Border = 0,
				.PaddingLeft = 70!
			}
			pdfPTable.AddCell(pdfPCell)
			pdfPTable.WriteSelectedRows(0, -1, 0!, doc2.BottomMargin + 50!, writer.DirectContent)
		End Sub

		Public Overrides Sub OnStartPage(ByVal writer As PdfWriter, ByVal doc2 As Document)
			Dim pdfPTable As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2) With
			{
				.TotalWidth = doc2.PageSize.Width
			}
			pdfPTable.SetWidths(New Single() { 30!, 70! })
			Dim instance As Image = Image.GetInstance(String.Concat(HttpContext.Current.Server.MapPath("PDF"), "/ssilogo.jpg"))
			instance.ScalePercent(60!)
			Dim pdfPCell As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(instance) With
			{
				.HorizontalAlignment = 0,
				.PaddingRight = 0!,
				.PaddingLeft = 115!,
				.Border = 0
			}
			Dim phrase As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
			phrase.Add(New Chunk("" & VbCrLf & "SSI Storage Solutions Incorporated" & VbCrLf & "", FontFactory.GetFont("Calibri", 15!, 1)))
			phrase.Add(New Chunk("9008 Jesuit St., Sta. Ana Village, Brgy. Sun Valley, West Service Road," & VbCrLf & "", FontFactory.GetFont("Calibri", 10!, 0)))
			phrase.Add(New Chunk("Bicutan Parañaque City, Philippines, 1700. Tel. No. (02) 659-8908", FontFactory.GetFont("Calibri", 10!, 0)))
			Dim pdfPCell1 As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase) With
			{
				.PaddingRight = 0!,
				.PaddingLeft = 0!,
				.Border = 0
			}
			Dim pdfPTable1 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1) With
			{
				.TotalWidth = doc2.PageSize.Width
			}
			Dim paragraph As iTextSharp.text.Paragraph = New iTextSharp.text.Paragraph()
			paragraph.Add(New Chunk("Delivery Receipt", FontFactory.GetFont("Calibri", 15!, 1)))
			Dim pdfPCell2 As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(paragraph) With
			{
				.PaddingRight = 0!,
				.PaddingLeft = 250!,
				.Border = 0
			}
			pdfPTable.AddCell(pdfPCell)
			pdfPTable.AddCell(pdfPCell1)
			pdfPTable1.AddCell(pdfPCell2)
			pdfPTable.WriteSelectedRows(0, -1, 0!, doc2.PageSize.Height - 10!, writer.DirectContent)
			pdfPTable1.WriteSelectedRows(0, -1, 0!, doc2.PageSize.Height - 100!, writer.DirectContent)
		End Sub
	End Class
End Namespace