using data.Abstract;
using Microsoft.Extensions.Configuration;

namespace data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private MentorContext _context;
        private IConfiguration _configuration;
        public UnitOfWork(IConfiguration configuration,MentorContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        private ICatCommentLikeRepository _catCommentLikeRepository;
        private ICatCommentRepository _catCommentRepository;
        private ICategoryRepository _categoryRepository;
        private ICatPostImageRepository _catPostImageRepository;
        private ICatPostLikeRepository _catPostLikeRepository;
        private ICatPostRepository _catPostRepository;
        private IDepartmentRepository _departmentRepository;
        private IUniCommentLikeRepository _uniCommentLikeRepository;
        private IUniCommentRepository _uniCommentRepository;
        private IUniPostImageRepository _uniPostImageRepository;
        private IUniPostLikeRepository _uniPostLikeRepository;
        private IUniPostRepository _uniPostRepository;
        private IUniversityRepository _universityRepository;
        private IUserFollowUserRepository _userFollowUserRepository;
        private IUserRepository _userRepository;
        public ICatCommentLikeRepository catCommentLikeRepository =>
            _catCommentLikeRepository = _catCommentLikeRepository ?? new EfCoreCatCommentLikeRepository(_context);

        public ICatCommentRepository catCommentRepository => 
            _catCommentRepository = _catCommentRepository ?? new EfCoreCatCommentRepository(_context);

        public ICategoryRepository categoryRepository => 
            _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public ICatPostImageRepository catPostImageRepository => 
            _catPostImageRepository = _catPostImageRepository ?? new EfCoreCatPostImageRepository(_configuration,_context);

        public ICatPostLikeRepository catPostLikeRepository => 
            _catPostLikeRepository = _catPostLikeRepository ?? new EfCoreCatPostLikeRepository(_context);

        public ICatPostRepository catPostRepository =>
            _catPostRepository = _catPostRepository ?? new EfCoreCatPostRepository(_context); 

        public IDepartmentRepository departmentRepository => 
            _departmentRepository = _departmentRepository ?? new EfCoreDeparmentRepository(_context);

        public IUniCommentLikeRepository uniCommentLikeRepository => 
            _uniCommentLikeRepository = _uniCommentLikeRepository ?? new EfCoreUniCommentLikeRepository(_context);

        public IUniCommentRepository uniCommentRepository => 
            _uniCommentRepository = _uniCommentRepository ?? new EfCoreUniCommentRepository(_context);

        public IUniPostImageRepository uniPostImageRepository => 
            _uniPostImageRepository = _uniPostImageRepository ?? new EfCoreUniPostImageRepository(_configuration,_context);

        public IUniPostLikeRepository uniPostLikeRepository => 
            _uniPostLikeRepository = _uniPostLikeRepository ?? new EfCoreUniPostLikeRepository(_context);

        public IUniPostRepository uniPostRepository => 
            _uniPostRepository = _uniPostRepository ?? new EfCoreUniPostRepository(_context);

        public IUserFollowUserRepository userFollowUserRepository => 
            _userFollowUserRepository = _userFollowUserRepository ?? new EfCoreUserFollowUserRepository(_context);

        public IUserRepository userRepository => 
            _userRepository = _userRepository ?? new EfCoreUserRepository(_context);

        public IUniversityRepository universityRepository => 
            _universityRepository = _universityRepository ?? new EfCoreUniversityRepository(_context);

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}