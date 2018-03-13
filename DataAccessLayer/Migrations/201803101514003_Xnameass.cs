namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Xnameass : DbMigration
    {
        public override void Up()
        {
            DropColumn("public.Answers", "AnswerTime");
        }
        
        public override void Down()
        {
            AddColumn("public.Answers", "AnswerTime", c => c.Time(nullable: false));
        }
    }
}
