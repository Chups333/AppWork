namespace AppWork.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountZayavoks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        LogZayavokId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogZayavoks", t => t.LogZayavokId, cascadeDelete: true)
                .Index(t => t.LogZayavokId);
            
            CreateTable(
                "dbo.LogZayavoks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomerNameZayavki = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RobotLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogDataTime = c.DateTime(nullable: false),
                        LogText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CountZayavoks", "LogZayavokId", "dbo.LogZayavoks");
            DropIndex("dbo.CountZayavoks", new[] { "LogZayavokId" });
            DropTable("dbo.RobotLogs");
            DropTable("dbo.LogZayavoks");
            DropTable("dbo.CountZayavoks");
        }
    }
}
