using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniComment
{
    public class UniCommentForAdminDTO
    {
        public int Id { get; set; }
        
        [StringLength(200,MinimumLength=1,ErrorMessage = "Yorum içerik alanı en az 1 en fazla 200 karakterden oluşabilir..")]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsReported { get; set; }
        
        [StringLength(35,MinimumLength=6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakterden oluşabilir..")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Yapılan yorumlar bir gönderi altında yapılması gerekir..")]
        public int UniPostId { get; set; }
        public int DepartmentId { get; set; }
    }
}