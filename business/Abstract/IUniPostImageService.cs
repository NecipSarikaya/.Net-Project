using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUniPostImageService:IService<UniPostImage>
    {
        Task<bool> HasImage(int postId);
        Task<List<string>> GetImages(int postId);
    }
}