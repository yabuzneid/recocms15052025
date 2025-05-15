using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Utility
{
    public static class PdfConverter
    {
        public static byte[] ToPDFByteArray(this string html)
        {
            var converter = ConverterFactory.Converter;
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                    {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4Plus
                    },
                Objects =
                    {
                        new ObjectSettings()
                        {
                            PagesCount = true,
                            HtmlContent = html,
                            WebSettings = new WebSettings() { DefaultEncoding = "utf-8", LoadImages = true },
                            HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                        }
                    }
            };

            return converter.Convert(doc);
        }

    }

    public class ConverterFactory
    {
        public static SynchronizedConverter Converter { get => GetInstance()._converter; }
        private static ConverterFactory _instance = null;
        private static ConverterFactory GetInstance()
        {
            if(_instance == null)
            {
                _instance = new ConverterFactory();
            }

            return _instance;
        }

        private SynchronizedConverter _converter;
        private ConverterFactory()
        {
            _converter = new SynchronizedConverter(new PdfTools());
        }
    }
}
