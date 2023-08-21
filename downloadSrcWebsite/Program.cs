using System;
using System.IO;
using System.Net;

namespace downloadSrcWebsite
{
    class Program
    {
        static void Main(string[] args)
        {
            WebRequest SiteyeBaglantiTalebi = HttpWebRequest.Create("https://www.fktuningshop.com/tofas-sahin-sticker-2-adet-");
            WebResponse GelenCevap = SiteyeBaglantiTalebi.GetResponse();
            StreamReader CevapOku = new StreamReader(GelenCevap.GetResponseStream());
            string KaynakKodlar = CevapOku.ReadToEnd();
            int IcerikBaslangicIndex = KaynakKodlar.IndexOf("<h1>") + 4;
            int IcerikBitisIndex = KaynakKodlar.Substring(IcerikBaslangicIndex).IndexOf("</h6>");

            Console.WriteLine(KaynakKodlar.Substring(IcerikBaslangicIndex, IcerikBitisIndex));
            Console.Read();
        }
    }
}
