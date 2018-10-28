namespace Mdmeta.Tasks.Walterlv
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
