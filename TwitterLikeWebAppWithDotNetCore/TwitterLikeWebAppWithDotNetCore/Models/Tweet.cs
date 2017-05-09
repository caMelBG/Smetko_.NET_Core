using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterLikeWebAppWithDotNetCore.Models
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }
        
        public int AuthorId { get; set; }

        public User Author { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PostedOn { get; set; }
    }
}
