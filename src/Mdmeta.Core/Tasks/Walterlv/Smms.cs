using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Mdmeta.Tasks.Walterlv
{
    public sealed class Smms
    {
        public async Task<string> UploadAsync(string localImagePath)
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
                form.Add(content, "smfile", "123");
                var response = await client.PostAsync("/api/upload", form);
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}
