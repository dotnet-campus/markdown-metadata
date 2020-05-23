﻿namespace Walterlv.BlogTransformer.ImageServers
{
    public sealed class ImageUploadedResponse
    {
        public string Url { get; }

        public ImageUploadedResponse(string url)
        {
            Url = url;
        }
    }
}
