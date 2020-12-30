namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCopy",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.ISBN, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ISBN)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ISBN = c.String(nullable: false, maxLength: 13),
                        Title = c.String(nullable: false, maxLength: 100),
                        EditionYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ISBN);
            
            CreateTable(
                "dbo.BookImage",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        BookCopyId = c.Guid(nullable: false),
                        IsCover = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookCopy", t => t.BookCopyId, cascadeDelete: true)
                .Index(t => t.BookCopyId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        IsMale = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Login = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 64),
                        Avatar = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 10),
                        HasReadTermsConditions = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookCopy", "UserId", "dbo.User");
            DropForeignKey("dbo.BookImage", "BookCopyId", "dbo.BookCopy");
            DropForeignKey("dbo.BookCopy", "ISBN", "dbo.Book");
            DropIndex("dbo.BookImage", new[] { "BookCopyId" });
            DropIndex("dbo.BookCopy", new[] { "UserId" });
            DropIndex("dbo.BookCopy", new[] { "ISBN" });
            DropTable("dbo.User");
            DropTable("dbo.BookImage");
            DropTable("dbo.Book");
            DropTable("dbo.BookCopy");
        }
    }
}
