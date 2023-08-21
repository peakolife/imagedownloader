using System;
using System.ComponentModel;
using System.Net;

namespace imageDownloadAyyildiz
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public void DosyaIndir(string URL, string IndirilecekDizin, string DosyaAdi)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(URL), IndirilecekDizin + "/" + DosyaAdi);
        }
        private static void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Dosya indiriliyor: %{0}", e.ProgressPercentage);
            Console.Read();
        }
        private static void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Dosya indirme tamamlandı.");
            Console.Read();
        }
    }
}
