using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHtmlAgilityPack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Adding attributes to html <a> tag
             */
            HtmlTag_AddAttribute();
        }

        private static void HtmlTag_AddAttribute()
        {
            string html = File.ReadAllText("HtmlFile/First.html");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            string focusTag = "//a[@href]";
            document.LoadHtml(html);

            var focusList = document.DocumentNode.SelectNodes(focusTag);

            foreach (var aTag in focusList)
            {
                if (string.IsNullOrEmpty(aTag.GetAttributeValue("target", string.Empty)))
                {
                    aTag.SetAttributeValue("target", "_blank");
                    document.DocumentNode.SetChildNodesId(aTag);
                }
            }
             
            File.WriteAllText(@"HtmlFile/Second.html", document.DocumentNode.InnerHtml);
        }
    }
}
