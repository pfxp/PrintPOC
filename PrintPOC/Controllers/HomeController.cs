using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PdfiumViewer;
using System.Drawing;
using System.Drawing.Printing;

namespace PrintPOC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Print()
        {
            ViewBag.Message = "Printing Page";

            string printer = @"\\MELOFFICE\Colour Printer (C2500) Design";
            int margin = 20;
            string paperName = @"A4 (210 x 297 mm)";
            string filename = @"C:\dev\poc\Pdfium\test_files\test_a4.pdf";
            
            try
            {
                // Create the printer settings for our printer
                var printerSettings = new PrinterSettings
                {
                    PrinterName = printer,
                    Copies = 1
                };

                // Create our page settings for the paper size selected
                var pageSettings = new PageSettings(printerSettings)
                {
                    Margins = new Margins(margin, margin, margin, margin)
                };

                foreach (PaperSize paperSize in printerSettings.PaperSizes)
                {
                    if (paperSize.PaperName == paperName)
                    {
                        pageSettings.PaperSize = paperSize;
                        break;
                    }
                }

                using (var document = PdfDocument.Load(filename))
                {
                    using (var printDocument = document.CreatePrintDocument(PdfPrintMode.ShrinkToMargin))
                    {
                        printDocument.PrinterSettings = printerSettings;
                        printDocument.DefaultPageSettings = pageSettings;
                        printDocument.PrintController = new StandardPrintController();
                        printDocument.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Message: {ex.Message}");
            }

            return View();
        }
    }
}