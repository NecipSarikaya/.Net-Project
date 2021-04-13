using System.Threading.Tasks;
using AutoMapper;
using entity;
using Microsoft.AspNetCore.Identity;
using webapi.DTO.CatComment;
using webapi.DTO.Category;
using webapi.DTO.CatPost;
using webapi.DTO.Department;
using webapi.DTO.HelpersDTO;
using webapi.DTO.UniComment;
using webapi.DTO.UniDep;
using webapi.DTO.UniPost;
using webapi.DTO.University;
using webapi.DTO.User;

namespace webapi.Helpers
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<CatPost,CatPostForProfileListDTO>()
            .ForMember(l => l.CatName , opt => opt.MapFrom(src=>
                src.Category.Name))
                .ForMember(l => l.CatNameUrl , opt => opt.MapFrom(src=>
                src.Category.NameUrl))
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ReverseMap();
            CreateMap<UniPost,UniPostForProfileListDTO>()
                .ForMember(l => l.UniName , opt => opt.MapFrom(src=>
                src.University.Name))
                .ForMember(l => l.UniNameUrl , opt => opt.MapFrom(src=>
                src.University.NameUrl))
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ReverseMap();
            CreateMap<User,UserForRegisterDTO>().ReverseMap();
            CreateMap<User,UserForProfileDTO>()
                .ForMember(l => l.UniversityName , opt => opt.MapFrom(src=>
                src.University.Name))
                .ForMember(l => l.DepartmentName , opt => opt.MapFrom(src=>
                src.Department.Name))
                .ReverseMap();
            CreateMap<User,UserForUpdateDTO>().ReverseMap();
            CreateMap<User,UserForGuestProfile>().ReverseMap();
            CreateMap<User,UserForFollowList>()
                .ForMember(l => l.ImageUrl , opt => opt.MapFrom(src=>
                "http://localhost:5000/Images/"+src.ImageUrl))
                .ReverseMap();
            CreateMap<User,UserForGuestFollowList>().ReverseMap();
            CreateMap<User,UserForListDTO>()
                .ForMember(l => l.IsBanned , opt => opt.MapFrom(src=>
                src.LockoutEnd == null ?"false":"true"))
                .ReverseMap();

            CreateMap<UniversityDepartment,UniDepForCreateDTO>().ReverseMap();

            CreateMap<Department,DepartmentForCreateDTO>().ReverseMap();
            CreateMap<Department,UniCatDepListDTO>().ReverseMap();
            
            CreateMap<Category,CategoryForCreateDTO>().ReverseMap();
            CreateMap<Category,UniCatDepListDTO>().ReverseMap();

            CreateMap<University,UniversityForCreateDTO>().ReverseMap();
            CreateMap<University,UniCatDepListDTO>().ReverseMap();


            CreateMap<CatPost,CatPostForListDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ForMember(l => l.UserPoint , opt => opt.MapFrom(src=>
                src.User.Point))
                .ForMember(l => l.ImageUrl , opt => opt.MapFrom(src=>
                src.User.ImageUrl))
                .ReverseMap();
            CreateMap<CatPost,CatPostForCreateDTO>().ReverseMap();
            CreateMap<CatPost,CatPostForDetailDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ForMember(l => l.UserId , opt => opt.MapFrom(src=>
                src.User.Id))
                .ForMember(l => l.UserPoint , opt => opt.MapFrom(src=>
                src.User.Point))
                .ForMember(l => l.ImageUrl , opt => opt.MapFrom(src=>
                src.User.ImageUrl))
                .ReverseMap();
            CreateMap<CatPost,CatPostForAdminListDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ReverseMap();

            CreateMap<CatComment,CatCommentForCreateDTO>().ReverseMap();
            CreateMap<CatComment,CatCommentsForListDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ForMember(l => l.UserId , opt => opt.MapFrom(src=>
                src.User.Id))
                .ForMember(l => l.UserPoint , opt => opt.MapFrom(src=>
                src.User.Point))
                .ForMember(l => l.ImageUrl , opt => opt.MapFrom(src=>
                src.User.ImageUrl))
                .ReverseMap();
            CreateMap<CatComment,CatCommentForAdminDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ReverseMap();

            CreateMap<UniPost,UniPostForListDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ForMember(l => l.ImageUrl , opt => opt.MapFrom(src=>
                src.User.ImageUrl))
                .ForMember(l => l.UserPoint , opt => opt.MapFrom(src=>
                src.User.Point))
                .ForMember(l => l.UserId , opt => opt.MapFrom(src=>
                src.User.Id))
                .ReverseMap();
            CreateMap<UniPost,UniPostForCreateDTO>().ReverseMap();
            CreateMap<UniPost,UniPostAdminDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ReverseMap();
            CreateMap<UniPost,UniPostForDetailDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ForMember(l => l.UserPoint , opt => opt.MapFrom(src=>
                src.User.Point))
                .ForMember(l => l.ImageUrl , opt => opt.MapFrom(src=>
                src.User.ImageUrl))
                .ForMember(l => l.UserId , opt => opt.MapFrom(src=>
                src.User.Id))
                .ReverseMap();
            
            CreateMap<UniComment,UniCommentForListDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ForMember(l => l.UserPoint , opt => opt.MapFrom(src=>
                src.User.Point))
                .ForMember(l => l.ImageUrl , opt => opt.MapFrom(src=>
                src.User.ImageUrl))
                .ForMember(l => l.UserId , opt => opt.MapFrom(src=>
                src.User.Id))
                .ReverseMap();
            CreateMap<UniComment,UniCommentForCreateDTO>().ReverseMap();
            CreateMap<UniComment,UniCommentForAdminDTO>()
                .ForMember(l => l.UserName , opt => opt.MapFrom(src=>
                src.User.UserName))
                .ReverseMap();
        }
    }
    
}