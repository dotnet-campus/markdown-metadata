using System.Threading.Tasks;

namespace Walterlv.BlogTransformer.ImageServers
{
    public interface IImageServer
    {
        Task<ImageUploadedResponse> UploadAsync(string localImagePath);
    }
}
