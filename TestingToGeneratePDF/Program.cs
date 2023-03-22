using System.Diagnostics;
using System.Drawing;

namespace MainProgram
{
    class Program
    {
        private static void Main(string[] args)
        {
            GeneratePdf Obj = new GeneratePdf();

            Console.WriteLine("IronPdf:");
            Obj.TestUseIronPdf();
            Console.WriteLine("\n\n\n");

            Console.WriteLine("PdfSharp:");
            Obj.TestUsePdfSharp();
            Console.WriteLine("\n\n\n");

            Console.WriteLine("Syncfusion:");
            Obj.TestUseSyncfusion();
            Console.WriteLine("\n\n\n");

            Console.WriteLine("\n\n\nPress any key to exit:");
            Console.ReadLine();

        }
    }

    class GeneratePdf
    {
        // Can't use using for these because some methods might be confused.

        public void TestUseIronPdf()
        {
            // Reference: https://ironpdf.com/blog/using-ironpdf/how-to-generate-pdf-asp-net-csharp/

            string pdfContent = "<h1>This is a testing to create a pdf file using IronPdf</h1>\n" +
                "Old classic Hello world!";
            string pdfSaveName = "../../../IronPdf.pdf";

            Console.WriteLine("pdf content:\n" + pdfContent);
            Console.WriteLine("pdf save name: " + pdfSaveName);

            try
            {
                Console.WriteLine("Start IronPdf");

                Console.WriteLine("Creating pdfDocument pdf");
                IronPdf.PdfDocument pdf = new IronPdf.ChromePdfRenderer().RenderHtmlAsPdf(pdfContent);
                Console.WriteLine("Created pdfDocument pdf");

                Console.WriteLine("Saving pdf file");
                pdf.SaveAs(pdfSaveName);
                Console.WriteLine("Saved pdf file");

                Console.WriteLine("IronPdf finished successfully");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error occur:\n" + error);

                Console.WriteLine("Press any key to continue:");
                Console.ReadLine();
            }
        }

        public void TestUsePdfSharp()
        {
            // Reference: https://procodeguide.com/dotnet/create-pdf-file-in-csharp-net/

            string pdfContent = "This is a testing using PdfSharp";
            string pdfSaveName = "../../../PdfSharp.pdf";

            Console.WriteLine("pdf content:\n" + pdfContent);
            Console.WriteLine("pdf save name: " + pdfSaveName);

            try
            {
                Console.WriteLine("Start PdfSharp");

                Console.WriteLine("Doing something in System.Text.Encoding.RegisterProvider");
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                Console.WriteLine("Done something in System.Text.Encoding.RegisterProvider");

                Console.WriteLine("Creating XFont font");
                PdfSharp.Drawing.XFont font = new PdfSharp.Drawing.XFont("Calibri", 10);
                Console.WriteLine("Created XFont font");

                Console.WriteLine("Creating PdfDocument pdf");
                PdfSharp.Pdf.PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
                Console.WriteLine("Created PdfDocument pdf");

                Console.WriteLine("Creating pdfPage page for pdf");
                PdfSharp.Pdf.PdfPage page = pdf.AddPage();
                Console.WriteLine("Created pdfPage page for pdf");

                Console.WriteLine("Creating XGraphics gfx for page");
                PdfSharp.Drawing.XGraphics gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                Console.WriteLine("Created XGraphics gfx for page");

                // page.Width and page.Height is both in points which is 612 x 792.
                // 1 point = 1 / 72 inch.
                // 1 inch = 2.54 cm
                Console.WriteLine("Drawing to the XGraphics gfx");
                gfx.DrawString(pdfContent, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(0, 0, page.Width, page.Height), PdfSharp.Drawing.XStringFormats.TopLeft);
                Console.WriteLine("Drew to the XGraphics gfx");

                Console.WriteLine("Saving pdf file");
                pdf.Save(pdfSaveName);
                Console.WriteLine("Saved pdf file");

                Console.WriteLine("Opening pdf file");
                Process.Start(pdfSaveName);
                Console.WriteLine("Opened pdf file");

                Console.WriteLine("PdfSharp finished successfully");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error occur:\n" + error);

                Console.WriteLine("Press any key to continue:");
                Console.ReadLine();
            }
        }

        public void TestUseSyncfusion()
        {
            // Reference: https://www.syncfusion.com/kb/5825/how-to-set-the-page-margin-in-a-pdf-using-c-and-vb-net

            string pdfContent = "This is a testing using Syncfusion";
            string pdfSaveName = "../../../Syncfusion.pdf";

            Console.WriteLine("pdf content:\n" + pdfContent);
            Console.WriteLine("pdf save name: " + pdfSaveName);

            try
            {
                Console.WriteLine("Start Syncfusion");

                Console.WriteLine("Creating PdfFont font");
                Syncfusion.Pdf.Graphics.PdfFont font = new Syncfusion.Pdf.Graphics.PdfStandardFont(Syncfusion.Pdf.Graphics.PdfFontFamily.TimesRoman, 10);
                Console.WriteLine("Created XFont font");

                Console.WriteLine("Creating PdfBrush brsh");
                Syncfusion.Pdf.Graphics.PdfBrush brsh = new Syncfusion.Pdf.Graphics.PdfSolidBrush(Color.Black);
                Console.WriteLine("Created PdfBrush brsh");

                Console.WriteLine("Creating PdfDocument pdf");
                Syncfusion.Pdf.PdfDocument pdf = new Syncfusion.Pdf.PdfDocument();
                Console.WriteLine("Created PdfDocument pdf");

                Console.WriteLine("Setting margin of pdf");
                pdf.PageSettings.Margins.All = 50;
                Console.WriteLine("Setted margin of pdf");

                Console.WriteLine("Creating PdfPage page for pdf");
                Syncfusion.Pdf.PdfPage page = pdf.Pages.Add();
                Console.WriteLine("Created PdfPage page for pdf");

                Console.WriteLine("Creating PdfGraphics gfx for page");
                Syncfusion.Pdf.Graphics.PdfGraphics gfx = page.Graphics;
                Console.WriteLine("Created PdfGraphics gfx for page");

                Console.WriteLine("Drawing text to the PdfGraphics gfx");
                gfx.DrawString(pdfContent, font, brsh, new PointF(20, 20));
                Console.WriteLine("Drew text to the PdfGraphics gfx");

                Console.WriteLine("Drawing rectangle to the PdfGraphics gfx");
                gfx.DrawRectangle(Syncfusion.Pdf.Graphics.PdfPens.Red, new Rectangle(0, 0, Convert.ToInt32(page.GetClientSize().Width), Convert.ToInt32(page.GetClientSize().Height)));
                Console.WriteLine("Drew rectangle to the PdfGraphics gfx");

                Console.WriteLine("Saving pdf file");
                pdf.Save(pdfSaveName);
                Console.WriteLine("Saved pdf file");

                Console.WriteLine("Closing pdf");
                pdf.Close(true);
                Console.WriteLine("Closed pdf");

                Console.WriteLine("Opening pdf file");
                Process.Start(pdfSaveName);
                Console.WriteLine("Opened pdf file");

                Console.WriteLine("Syncfusion finished successfully");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error occur:\n" + error);

                Console.WriteLine("Press any key to continue:");
                Console.ReadLine();
            }
        }
    }
}