using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniPost
{
    public class ProfilePagedPosts{
        public PageInfo PageInfo { get; set; }
        public List<UniPostForProfileListDTO> Posts { get; set; }
    }
    public class UniPostForProfileListDTO
    {
        public int Id { get; set; }

        [StringLength(100,MinimumLength = 1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içerebilir..")]
        public string Title { get; set; }
        
        [StringLength(250,MinimumLength = 1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içerebilir..")]
        public string Content { get; set; }

        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 25 karakter içerebilir..")]
        public string UserName { get; set; }

        [StringLength(35,MinimumLength = 1,ErrorMessage = "Üniversite adı alanı en az 1 en fazla 35 karakter içerebilir..")]
        public string UniName { get; set; }
        
        [StringLength(35,MinimumLength = 1,ErrorMessage = "Üniversite url en az 1 en fazla 35 karakter içerebilir..")]
        public string UniNameUrl { get; set; }
        public int LikeCount { get; set; }
        public bool AlreadyLiked { get; set; }
        public bool isVisible { get; set; }
        public DateTime PublishDate { get; set; }
    }
}