namespace WebApplicationLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batteries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Displays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mobiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Camera = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Image = c.String(),
                        ProducerId = c.Int(nullable: false),
                        BatteryId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batteries", t => t.BatteryId, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .Index(t => t.ProducerId)
                .Index(t => t.BatteryId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RAMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScreenTechnologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 128),
                        Salt = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Mobiles", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.Mobiles", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Mobiles", "BatteryId", "dbo.Batteries");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Mobiles", new[] { "ColorId" });
            DropIndex("dbo.Mobiles", new[] { "BatteryId" });
            DropIndex("dbo.Mobiles", new[] { "ProducerId" });
            DropTable("dbo.Users");
            DropTable("dbo.ScreenTechnologies");
            DropTable("dbo.Roles");
            DropTable("dbo.RAMs");
            DropTable("dbo.OS");
            DropTable("dbo.Producers");
            DropTable("dbo.Mobiles");
            DropTable("dbo.Displays");
            DropTable("dbo.Colors");
            DropTable("dbo.Batteries");
        }
    }
}
