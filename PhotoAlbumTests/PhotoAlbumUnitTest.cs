using System;
using System.Net.Http;
using LT_photoAlbum;
using Newtonsoft.Json;

namespace PhotoAlbumTests;

[TestClass]
public class UnitTest1
{
    string url = "https://jsonplaceholder.typicode.com/photos";
    //An http client to send the get request
    HttpClient httpClient = new HttpClient();

    [TestMethod]
    public async Task JsonDataParseTest()
    {
        var httpResponseMessage = await httpClient.GetAsync(url);
        //read the string from the response's content.
        string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
        //Deserialize the json response into a C# array of type Post[]
        var myPhotosJSON = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

        var photo in myPhotosJSON;

        myPosts.Contains($"{photo.title}".Equals("reprehenderit est deserunt velit ipsam"));
    }

    public class Post
    {
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string? ThumbnailUrl { get; set; }
    }
}
