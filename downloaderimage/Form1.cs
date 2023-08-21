using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebPageDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private List<string> ExtractImageUrls(string htmlContent)
        {
            List<string> imageUrls = new List<string>();

            // Use regular expressions to find image URLs
            string pattern = @"<img.*?src=""(.*?)"".*?>";
            MatchCollection matches = Regex.Matches(htmlContent, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                string imageUrl = match.Groups[1].Value;
                imageUrls.Add(imageUrl);
            }

            return imageUrls;
        }

        private async Task DownloadImages(List<string> imageUrls, string downloadPath)
        {
            
            using (HttpClient client = new HttpClient())
            {
                foreach (string imageUrl in imageUrls)
                {
                    try
                    {
                        // Send a GET request to the image URL
                        client.BaseAddress = new Uri(txtUrl.Text);
                        HttpResponseMessage response = await client.GetAsync(imageUrl);
                        WebRequest request = WebRequest.Create(txtUrl.Text);

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            
                            // Get the file name from the URL
                            string fileName = Path.GetFileName(imageUrl);

                            // Combine the download path and file name
                            string filePath = Path.Combine(downloadPath, fileName);

                            if(!Directory.Exists(filePath) == true)
                            {
                                Directory.CreateDirectory(filePath);
                            }

                            // Save the image to disk
                            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await response.Content.CopyToAsync(fileStream);
                            }
                        }
                        else
                        {
                            //MessageBox.Show($"Failed to download image: {imageUrl}. Status code: {response.StatusCode
                            rTBoxError.Text += $"The request returned a non-success status code: {response.StatusCode}";
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show($"Failed to download image: {imageUrl}. Error: {ex.Message}");
                        rTBoxError.Text += $"An error occurred: {ex.Message}";
                    }
                }
            }
        }

        private async void btnDownload_Click_1(object sender, EventArgs e)
        {
            string webpageUrl = txtUrl.Text;
            string downloadPath = txtDownloadPath.Text;
            WebRequest SiteyeBaglantiTalebi = HttpWebRequest.Create(txtUrl.Text);
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send a GET request to the specified web page
                    HttpResponseMessage response = await client.GetAsync(webpageUrl);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content as a string
                        string htmlContent = await response.Content.ReadAsStringAsync();

                        // Find image URLs using regular expressions
                        List<string> imageUrls = ExtractImageUrls(htmlContent);

                        // Download the images
                        await DownloadImages(imageUrls, downloadPath);
                        textBox1.Visible = true;
                        textBox1.Text += "İmage Downloaded!";
                        //MessageBox.Show("Images downloaded successfully.");
                    }
                    else
                    {
                        rTBoxError.Text += $"The request returned a non-success status code: {response.StatusCode}";
                        
                    }
                }
                catch (Exception ex)
                {
                    rTBoxError.Text += $"An error occurred: {ex.Message}";
                }
            }
        }
    }
}
