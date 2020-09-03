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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Pass = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.RobotLogs");
            DropTable("dbo.LogZayavoks");
        }
    }
}
