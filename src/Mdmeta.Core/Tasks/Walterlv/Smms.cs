using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mdmeta.Tasks.Walterlv
{
    public sealed class Smms : IImageServer
    {
        public async Task<ImageUploadedResponse> UploadAsync(string localImagePath)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://sm.ms");
            client.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36");

            string result;
            using (var stream = File.OpenRead(localImagePath))
            {
                HttpContent content = new StreamContent(stream);
                var form = new MultipartFormDataContent();
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                form.Add(content, "smfile", Path.GetFileName(localImagePath));
                var response = await client.PostAsync("/api/upload", form);
                result = response.Content.ReadAsStringAsync().Result;
            }

            var smmsResponse = JsonConvert.DeserializeObject<SmmsResponse>(result);
            return smmsResponse;
        }
    }
}
