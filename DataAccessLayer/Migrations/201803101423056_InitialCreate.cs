namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answerlist = c.String(),
                        QuestionId = c.Int(nullable: false),
                        AnswerDate = c.DateTime(nullable: false),
                        AnswerTime = c.Time(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "public.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionTitle = c.String(),
                        QuestionDescription = c.String(),
                        AnswerCount = c.Int(nullable: false),
                        IsAnswered = c.Boolean(nullable: false),
                        QuestionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Answers", "QuestionId", "public.Questions");
            DropIndex("public.Answers", new[] { "QuestionId" });
            DropTable("public.Questions");
            DropTable("public.Answers");
        }
    }
}
