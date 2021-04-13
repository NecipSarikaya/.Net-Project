using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webapi.DTO.CatComment;

namespace webapi.DTO.CatPost
{
    public class CatPostForForumListDTO
    {
        public int Id { get; set; }

        [StringLength(100,MinimumLength=1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içerebilir...")]
        public string Title { get; set; }
        
        [StringLength(35,MinimumLength=6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir...")]
        public string UserName { get; set; }
        public string UserId { get; set; }
        public DateTime PublishDate { get; set; }
        [StringLength(250,MinimumLength=1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içerebilir...")]
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public List<CatCommentsForListDTO> CatComments { get; set; }
    }
}