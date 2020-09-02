namespace AppWork.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogZayavoks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomerNameZayavki = c.String(),
                        Status = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RobotLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogDataTime = c.DateTime(nullable: false),
                        LogText = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RobotLogs", "UserId", "dbo.Users");
            DropForeignKey("dbo.LogZayavoks", "UserId", "dbo.Users");
            DropIndex("dbo.RobotLogs", new[] { "UserId" });
            DropIndex("dbo.LogZayavoks", new[] { "UserId" });
            DropTable("dbo.RobotLogs");
            DropTable("dbo.Users");
            DropTable("dbo.LogZayavoks");
        }
    }
}
