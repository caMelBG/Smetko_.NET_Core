using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TwitterLikeWebAppWithDotNetCore.Data;

namespace TwitterLikeWebAppWithDotNetCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170509163512_UserRefactored")]
    partial class UserRefactored
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int?>("AvatarId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("AvatarId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TwitterLikeWebAppWithDotNetCore.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Content");

                    b.Property<string>("FileExtension");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("TwitterLikeWebAppWithDotNetCore.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime?>("PostedOn");

                    b.Property<int>("ReceiverId");

                    b.Property<string>("ReceiverId1");

                    b.Property<int>("SenderId");

                    b.Property<string>("SenderId1");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId1");

                    b.HasIndex("SenderId1");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("TwitterLikeWebAppWithDotNetCore.Models.Tweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ApplicationUserId1");

                    b.Property<string>("ApplicationUserId2");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime?>("PostedOn");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ApplicationUserId1");

                    b.HasIndex("ApplicationUserId2");

                    b.ToTable("Tweet");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser", b =>
                {
                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser")
                        .WithMany("Following")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.Image", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");
                });

            modelBuilder.Entity("TwitterLikeWebAppWithDotNetCore.Models.Message", b =>
                {
                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser", "Receiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverId1");

                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser", "Sender")
                        .WithMany("SendedMessages")
                        .HasForeignKey("SenderId1");
                });

            modelBuilder.Entity("TwitterLikeWebAppWithDotNetCore.Models.Tweet", b =>
                {
                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser")
                        .WithMany("FavouriteTweets")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser")
                        .WithMany("ReTweets")
                        .HasForeignKey("ApplicationUserId1");

                    b.HasOne("TwitterLikeWebAppWithDotNetCore.Models.ApplicationUser")
                        .WithMany("Tweets")
                        .HasForeignKey("ApplicationUserId2");
                });
        }
    }
}
