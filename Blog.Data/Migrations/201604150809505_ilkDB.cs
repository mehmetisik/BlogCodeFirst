namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilkDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        visualization = c.Int(),
                        Like = c.Int(),
                        Active = c.Boolean(nullable: false),
                        ArticleTypes_ArticleTypeID = c.Int(),
                        Images_ImageID = c.Int(),
                        Users_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleID)
                .ForeignKey("dbo.ArticleTypes", t => t.ArticleTypes_ArticleTypeID)
                .ForeignKey("dbo.Images", t => t.Images_ImageID)
                .ForeignKey("dbo.Users", t => t.Users_UserID)
                .Index(t => t.ArticleTypes_ArticleTypeID)
                .Index(t => t.Images_ImageID)
                .Index(t => t.Users_UserID);
            
            CreateTable(
                "dbo.ArticleTypes",
                c => new
                    {
                        ArticleTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleTypeID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Tag = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        RegisterDate = c.DateTime(),
                        Nick = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        AuthorIs = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Images_ImageID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Images", t => t.Images_ImageID)
                .Index(t => t.Images_ImageID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Articles_ArticleID = c.Int(),
                        Users_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Articles", t => t.Articles_ArticleID)
                .ForeignKey("dbo.Users", t => t.Users_UserID)
                .Index(t => t.Articles_ArticleID)
                .Index(t => t.Users_UserID);
            
            CreateTable(
                "dbo.ArticleImages",
                c => new
                    {
                        ArticleID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleID, t.ImageID })
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.ArticleID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.ArticlesTags",
                c => new
                    {
                        ArticleID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleID, t.TagID })
                .ForeignKey("dbo.Articles", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ArticleID)
                .Index(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Users_UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "Articles_ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "Users_UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "Images_ImageID", "dbo.Images");
            DropForeignKey("dbo.ArticlesTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ArticlesTags", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "Images_ImageID", "dbo.Images");
            DropForeignKey("dbo.ArticleImages", "ImageID", "dbo.Images");
            DropForeignKey("dbo.ArticleImages", "ArticleID", "dbo.Articles");
            DropForeignKey("dbo.Articles", "ArticleTypes_ArticleTypeID", "dbo.ArticleTypes");
            DropIndex("dbo.ArticlesTags", new[] { "TagID" });
            DropIndex("dbo.ArticlesTags", new[] { "ArticleID" });
            DropIndex("dbo.ArticleImages", new[] { "ImageID" });
            DropIndex("dbo.ArticleImages", new[] { "ArticleID" });
            DropIndex("dbo.Comments", new[] { "Users_UserID" });
            DropIndex("dbo.Comments", new[] { "Articles_ArticleID" });
            DropIndex("dbo.Users", new[] { "Images_ImageID" });
            DropIndex("dbo.Articles", new[] { "Users_UserID" });
            DropIndex("dbo.Articles", new[] { "Images_ImageID" });
            DropIndex("dbo.Articles", new[] { "ArticleTypes_ArticleTypeID" });
            DropTable("dbo.ArticlesTags");
            DropTable("dbo.ArticleImages");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Tags");
            DropTable("dbo.Images");
            DropTable("dbo.ArticleTypes");
            DropTable("dbo.Articles");
        }
    }
}
