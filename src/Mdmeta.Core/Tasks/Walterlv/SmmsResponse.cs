namespace Mdmeta.Tasks.Walterlv
{
    public class Data
    {
        public int width { get; set; }
        public int height { get; set; }
        public string filename { get; set; }
        public string storename { get; set; }
        public int size { get; set; }
        public string path { get; set; }
        public string hash { get; set; }
        public int timestamp { get; set; }
        public string ip { get; set; }
        public string url { get; set; }
        public string delete { get; set; }
    }

    public class SmmsResponse
    {
        public string code { get; set; }
        public Data data { get; set; }

        public static implicit operator ImageUploadedResponse(SmmsResponse response)
        {
            return new ImageUploadedResponse(response.data.url);
        }
    }
}