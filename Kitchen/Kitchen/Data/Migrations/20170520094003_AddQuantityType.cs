using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kitchen.Data.Migrations
{
    public partial class AddQuantityType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Meals_DishId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DishProduct_Meals_DishId",
                table: "DishProduct");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Categories",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "DishProduct",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "DishProductId",
                table: "DishProduct",
                newName: "MealProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DishProduct_DishId",
                table: "DishProduct",
                newName: "IX_DishProduct_MealId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Meals_MealId",
                table: "Categories",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishProduct_Meals_MealId",
                table: "DishProduct",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Meals_MealId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_DishProduct_Meals_MealId",
                table: "DishProduct");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Categories",
                newName: "DishId");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "DishProduct",
                newName: "DishId");

            migrationBuilder.RenameColumn(
                name: "MealProductId",
                table: "DishProduct",
                newName: "DishProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DishProduct_MealId",
                table: "DishProduct",
                newName: "IX_DishProduct_DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Meals_DishId",
                table: "Categories",
                column: "DishId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishProduct_Meals_DishId",
                table: "DishProduct",
                column: "DishId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
