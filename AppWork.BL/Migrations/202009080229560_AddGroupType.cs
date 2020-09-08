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
                        ShotOpisanie = c.String(),
                        FullOpisanie = c.String(),
                        Iniciator = c.String(),
                        Ispolnitel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rabotnikis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        Login = c.String(),
                        Online = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RobotLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogDataTime = c.DateTime(nullable: false),
                        LogText = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RobotLogs");
            DropTable("dbo.Rabotnikis");
            DropTable("dbo.LogZayavoks");
        }
    }
}
