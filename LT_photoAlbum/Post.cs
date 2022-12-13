﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LT_photoAlbum
{
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
