using System.Threading.Tasks;

namespace Mdmeta.Tasks.Walterlv
{
    public interface IImageServer
    {
        Task<ImageUploadedResponse> UploadAsync(string localImagePath);
    }
}
