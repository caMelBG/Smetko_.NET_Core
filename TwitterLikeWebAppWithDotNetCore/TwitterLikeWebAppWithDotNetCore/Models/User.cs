using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterLikeWebAppWithDotNetCore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Tweet> tweets;
        private ICollection<Tweet> reTweets;
        private ICollection<Tweet> favouriteTweets;
        //private ICollection<ApplicationUser> followers;
        private ICollection<ApplicationUser> following;
        private ICollection<Message> sendedMessages;
        private ICollection<Message> receivedMessages;
        //private ICollection<Notification> notifications;

        public ApplicationUser()
        {
            this.tweets = new HashSet<Tweet>();
            this.reTweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<Tweet>();
            //this.followers = new HashSet<ApplicationUser>();
            this.following = new HashSet<ApplicationUser>();
            this.sendedMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            //this.notifications = new HashSet<Notification>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? AvatarId { get; set; }

        public Image Avatar { get; set; }

        public int FollowersId { get; set; }

        public Followers Followers { get; set; }

        public ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

        public ICollection<Tweet> ReTweets
        {
            get { return this.reTweets; }
            set { this.reTweets = value; }
        }

        public ICollection<Tweet> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }

        //public  ICollection<ApplicationUser> Followers
        //{
        //    get { return this.followers; }
        //    set { this.followers = value; }
        //}

        public ICollection<ApplicationUser> Following
        {
            get { return this.following; }
            set { this.following = value; }
        }

        [InverseProperty("Receiver")]
        public ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }

        [InverseProperty("Sender")]
        public ICollection<Message> SendedMessages
        {
            get { return this.sendedMessages; }
            set { this.sendedMessages = value; }
        }

        //public  ICollection<Notification> Notifications
        //{
        //    get { return this.notifications; }
        //    set { this.notifications = value; }
        //}
    }
}
