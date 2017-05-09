using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TwitterLikeWebAppWithDotNetCore.Models
{
    public class Followers
    {
        private ICollection<ApplicationUser> _collection;

        public Followers()
        {
            this.Collection = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public ICollection<ApplicationUser> Collection
        {
            get => _collection; set => _collection = value;
        }
    }
}
