using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace imagedownloader
{
    
    class Program
    {

        static async Task Main()
        {
            string webpageUrl = "https://manhuafast.com/manga/fist-demon-of-mount-hua/chapter-60/";
            string downloadPath = "C:/downloads";
            if (!Directory.Exists(downloadPath)== true)
            {
                Directory.CreateDirectory(downloadPath);
                Console.WriteLine("created.");
            }


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

                        Console.WriteLine("Images downloaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"The request returned a non-success status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            Console.ReadLine();
        }

        static List<string> ExtractImageUrls(string htmlContent)
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

        static async Task DownloadImages(List<string> imageUrls, string downloadPath)
        {
            using (HttpClient client = new HttpClient())
            {
                foreach (string imageUrl in imageUrls)
                {
                    try
                    {
                        // Send a GET request to the image URL
                        HttpResponseMessage response = await client.GetAsync(imageUrl);

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            // Get the file name from the URL
                            string fileName = Path.GetFileName(imageUrl);

                            // Combine the download path and file name
                            string filePath = Path.Combine(downloadPath, fileName);

                            // Save the image to disk
                            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await response.Content.CopyToAsync(fileStream);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Failed to download image: {imageUrl}. Status code: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to download image: {imageUrl}. Error: {ex.Message}");
                    }
                }
            }
        }
    }

}

