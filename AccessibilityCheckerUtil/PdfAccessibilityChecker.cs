using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Text;

namespace AccessibilityCheckerUtil
{
    public class PdfAccessibilityChecker
    {
        public string ReadData(string PdfFilePath)
        {
            if (!File.Exists(PdfFilePath))
                throw new FileNotFoundException(PdfFilePath);
            using (PdfReader reader = new PdfReader(PdfFilePath))
            {
                StringBuilder sb = new StringBuilder();
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                for (int page = 0; page < reader.NumberOfPages; page++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(reader, page + 1, strategy);
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        sb.Append(Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text))));
                    }
                }
                return sb.ToString();
            }
        }
    }
}
