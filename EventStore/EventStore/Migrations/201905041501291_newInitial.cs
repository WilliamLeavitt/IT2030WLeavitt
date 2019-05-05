namespace EventStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        EventId = c.Int(nullable: false),
                        Tickets = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "EventId", "dbo.Events");
            DropIndex("dbo.Carts", new[] { "EventId" });
            DropTable("dbo.Carts");
        }
    }
}
