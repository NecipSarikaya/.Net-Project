using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entity
{
    public class UniPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int LikeCount { get; set; }
        public bool IsPopular { get; set; }
        public bool IsVisible { get; set; }
        public bool IsReported { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<UniComment> UniComments { get; set; }
    }
}