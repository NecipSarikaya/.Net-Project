using System;

namespace data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICatCommentLikeRepository catCommentLikeRepository {get;}
        ICatCommentRepository catCommentRepository {get;}
        ICategoryRepository categoryRepository {get;}
        ICatPostImageRepository catPostImageRepository {get;}
        ICatPostLikeRepository catPostLikeRepository {get;}
        ICatPostRepository catPostRepository {get;}
        IDepartmentRepository departmentRepository {get;}
        IUniCommentLikeRepository uniCommentLikeRepository {get;}
        IUniCommentRepository uniCommentRepository {get;}
        IUniPostImageRepository uniPostImageRepository {get;}
        IUniPostLikeRepository uniPostLikeRepository {get;}
        IUniPostRepository uniPostRepository {get;}
        IUniversityRepository universityRepository {get;}
        IUserFollowUserRepository userFollowUserRepository {get;}
        IUserRepository userRepository {get;}
    }
}