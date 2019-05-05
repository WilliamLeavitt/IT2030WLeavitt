namespace EventStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventTypeID = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        Description = c.String(maxLength: 150),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Organizer = c.String(),
                        ContactInfo = c.String(),
                        City = c.String(),
                        State = c.String(),
                        MaxTickets = c.Int(nullable: false),
                        AvailTickets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeID, cascadeDelete: true)
                .Index(t => t.EventTypeID);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EventTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventTypeID", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "EventTypeID" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
        }
    }
}
