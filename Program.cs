using System;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Example.pdf");

        using (PdfDocument document = new PdfDocument())
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            gfx.DrawString("Hello, world!", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height),
                XStringFormats.TopCenter);

            gfx.DrawString($"Name: {name}", font, XBrushes.Black,
                new XRect(0, 100, page.Width, page.Height),
                XStringFormats.TopCenter);

            document.Save(path);
        }

        Console.WriteLine($"PDF created at {path}");
    }
}
