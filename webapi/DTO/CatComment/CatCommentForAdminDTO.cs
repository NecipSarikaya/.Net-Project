using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.CatComment
{
    public class CatCommentForAdminDTO
    {
        public int Id { get; set; }

        [StringLength(200,MinimumLength=1,ErrorMessage="Yorum içerik adı alanı en az 1 en fazla 200 karakter içerebilir..")]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsReported { get; set; }
        
        [StringLength(35,MinimumLength=6,ErrorMessage="Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }
        public int CatPostId { get; set; }
    }
}