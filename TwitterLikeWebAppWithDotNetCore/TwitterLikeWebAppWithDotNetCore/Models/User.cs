using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterLikeWebAppWithDotNetCore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        private ICollection<Tweet> tweets;
        private ICollection<Tweet> reTweets;
        private ICollection<Tweet> favouriteTweets;
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Message> sendedMessages;
        private ICollection<Message> receivedMessages;
        //private ICollection<Notification> notifications;

        public User()
        {
            this.tweets = new HashSet<Tweet>();
            this.reTweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<Tweet>();
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.sendedMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            //this.notifications = new HashSet<Notification>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? AvatarId { get; set; }

        public virtual Image Avatar { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

        public virtual ICollection<Tweet> ReTweets
        {
            get { return this.reTweets; }
            set { this.reTweets = value; }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> Following
        {
            get { return this.following; }
            set { this.following = value; }
        }

        [InverseProperty("Receiver")]
        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        [InverseProperty("Sender")]
        public virtual ICollection<Message> SendedMessages
        {
            get { return this.sendedMessages; }
            set { this.sendedMessages = value; }
        }

        //public virtual ICollection<Notification> Notifications
        //{
        //    get { return this.notifications; }
        //    set { this.notifications = value; }
        //}
    }
}
