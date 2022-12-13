using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

//Author: Brandon Burt 12/12/2022 LT_Interview Question

namespace LT_photoAlbum
{
   
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/photos";


            //An http client to send the get request
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                //read the string from the response's content.
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                //Deserialize the json response into a C# array of type Post[]
                var myPhotosJSON = JsonConvert.DeserializeObject<Post[]>(jsonResponse);
                if (myPhotosJSON is not null)
                {
                    foreach (var photo in myPhotosJSON)
                    {
                        if (photo.Id == 1)
                        {
                            //print the photo album number
                            Console.WriteLine($">photo-album {photo.AlbumId}");
                            Console.WriteLine($"[{photo.Id}] {photo.Title}");
                        }
                        else if ((photo.Id % 50 == 0) && (photo.Id != 5000))
                        {
                            //print the photo album id, increment album id 
                            Console.WriteLine($"[{photo.Id}] {photo.Title}");
                            Console.WriteLine("...");
                            photo.AlbumId++;
                            Console.WriteLine($">photo-album {photo.AlbumId}");

                        }
                        else
                        {
                            //print the id and title of each post
                            Console.WriteLine($"[{photo.Id}] {photo.Title}");
                        }
                    }
                }            
            }
            catch(Exception e)
            {
                //print the exception message
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Dispose of the httpClient
                httpClient.Dispose();
            }
        }
    }   
}

