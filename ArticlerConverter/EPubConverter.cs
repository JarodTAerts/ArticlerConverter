using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlerConverter
{
    public static class EPubConverter
    {
        public static string EPubOutputDirectory = "EPubs";

        public static async Task<string> ConvertUrlToEPub(string url)
        {

            SmartReader.Reader sr = new SmartReader.Reader(url);
            sr.KeepClasses = true;

            SmartReader.Article article = sr.GetArticle();

            if (article.IsReadable)
            {
                Console.WriteLine($"Converting {article.Title} - {article.SiteName}...");

                var htmlString = $"<h1>{article.Title}</h1>\n\n{article.TextContent.Replace("\n", "<br>")}";
                await File.WriteAllTextAsync("test.html", htmlString);

                // Ensure the directory for the output files exists
                Directory.CreateDirectory(EPubOutputDirectory);

                string epubFileName = $"{article.Title}.epub";
                string commandString = $"/C ebook-convert .\\test.html \"{EPubOutputDirectory}\\{epubFileName}\" --base-font-size 14 --pretty-print --title \"{article.Title}\" --authors \"{article.SiteName}\" --epub-inline-toc --no-default-epub-cover";
                CommandLineHelper.RunCmdHidden(commandString);

                return epubFileName;
            }
            else
            {
                throw new Exception("Rendered article is not readable.");
            }
        }

    }
}
