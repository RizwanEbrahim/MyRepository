namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Xnames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Answers", "QuestionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("public.Answers", "QuestionId", c => c.Int(nullable: false));
        }
    }
}
