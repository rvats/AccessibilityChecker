using AccessibilityCheckerUtil;
using System;

namespace AccessibilityCheckerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Accessibility Checker Console Application");
            PdfAccessibilityChecker pdfAccessibilityChecker = new PdfAccessibilityChecker();
            var readPdfText = pdfAccessibilityChecker.ReadData("AccessibilityChecker.pdf");
            Console.WriteLine(readPdfText);
            Console.ReadKey();
        }
    }
}
