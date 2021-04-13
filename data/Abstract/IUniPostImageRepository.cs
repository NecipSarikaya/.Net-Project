using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUniPostImageRepository:IRepository<UniPostImage>
    {
        Task<bool> HasImage(int postId);
        Task<List<string>> GetImages(int postId);
    }
}