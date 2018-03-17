namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMiddleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Answers", "NoOfVotes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Answers", "NoOfVotes");
        }
    }
}
