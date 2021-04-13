using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface ICatPostImageRepository:IRepository<CatPostImage>
    {
        Task<bool> GetImageByPostId(int postId);
        Task<List<string>> GetImages(int postId);
    }
}