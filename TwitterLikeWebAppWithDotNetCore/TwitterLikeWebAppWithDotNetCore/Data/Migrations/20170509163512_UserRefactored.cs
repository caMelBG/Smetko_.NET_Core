using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterLikeWebAppWithDotNetCore.Data.Migrations
{
    public partial class UserRefactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_AspNetUsers_UserId1",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_AspNetUsers_UserId2",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_AspNetUsers_UserId3",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId3",
                table: "Tweet",
                newName: "ApplicationUserId2");

            migrationBuilder.RenameColumn(
                name: "UserId2",
                table: "Tweet",
                newName: "ApplicationUserId1");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Tweet",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tweet_UserId3",
                table: "Tweet",
                newName: "IX_Tweet_ApplicationUserId2");

            migrationBuilder.RenameIndex(
                name: "IX_Tweet_UserId2",
                table: "Tweet",
                newName: "IX_Tweet_ApplicationUserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Tweet_UserId1",
                table: "Tweet",
                newName: "IX_Tweet_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_AspNetUsers_ApplicationUserId",
                table: "Tweet",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_AspNetUsers_ApplicationUserId1",
                table: "Tweet",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_AspNetUsers_ApplicationUserId2",
                table: "Tweet",
                column: "ApplicationUserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_AspNetUsers_ApplicationUserId",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_AspNetUsers_ApplicationUserId1",
                table: "Tweet");

            migrationBuilder.DropForeignKey(
                name: "FK_Tweet_AspNetUsers_ApplicationUserId2",
                table: "Tweet");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId2",
                table: "Tweet",
                newName: "UserId3");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId1",
                table: "Tweet",
                newName: "UserId2");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Tweet",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Tweet_ApplicationUserId2",
                table: "Tweet",
                newName: "IX_Tweet_UserId3");

            migrationBuilder.RenameIndex(
                name: "IX_Tweet_ApplicationUserId1",
                table: "Tweet",
                newName: "IX_Tweet_UserId2");

            migrationBuilder.RenameIndex(
                name: "IX_Tweet_ApplicationUserId",
                table: "Tweet",
                newName: "IX_Tweet_UserId1");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "AspNetUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ApplicationUserId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_AspNetUsers_UserId1",
                table: "Tweet",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_AspNetUsers_UserId2",
                table: "Tweet",
                column: "UserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tweet_AspNetUsers_UserId3",
                table: "Tweet",
                column: "UserId3",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
