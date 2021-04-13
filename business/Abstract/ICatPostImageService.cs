using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface ICatPostImageService:IService<CatPostImage>
    {
        Task<bool> GetImageByPostId(int postId);
        Task<List<string>> GetImages(int postId);
         
    }
}