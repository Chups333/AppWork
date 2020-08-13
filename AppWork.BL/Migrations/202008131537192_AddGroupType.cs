namespace AppWork.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupType : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.RobotLogs");
        }
    }
}
