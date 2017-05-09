using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterLikeWebAppWithDotNetCore.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(256)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PostedOn { get; set; }

        public int SenderId { get; set; }

        public User Sender { get; set; }

        public int ReceiverId { get; set; }

        public User Receiver { get; set; }
    }
}
