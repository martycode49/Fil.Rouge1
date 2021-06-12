namespace Fil.Rouge.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Civility = c.String(),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Phone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgentParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAgent = c.Int(nullable: false),
                        Datecreate = c.DateTime(),
                        QuestionQty = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.IdAgent, cascadeDelete: true)
                .Index(t => t.IdAgent);
            
            CreateTable(
                "dbo.ParticipantDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        QuizQuestionId = c.Int(nullable: false),
                        QuizParticipId = c.Int(nullable: false),
                        QuizValidAnswer = c.Int(nullable: false),
                        QuizQstart = c.DateTime(),
                        QuizQend = c.DateTime(),
                        QuizCommentPart = c.String(),
                        QuizFreeAnswer = c.String(),
                        QuizValidFreeAnswer = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgentParticipants", t => t.QuizId, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.QuizParticipId, cascadeDelete: true)
                .ForeignKey("dbo.Quizs", t => t.QuizQuestionId, cascadeDelete: true)
                .Index(t => t.QuizId)
                .Index(t => t.QuizQuestionId)
                .Index(t => t.QuizParticipId);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        UserId = c.Int(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeLastQuiz = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        SubSubject = c.String(),
                        QuestionType = c.String(),
                        Question = c.String(),
                        Rep1 = c.String(),
                        Rep2 = c.String(),
                        Rep3 = c.String(),
                        Rep4 = c.String(),
                        Level = c.Int(nullable: false),
                        Validquestion = c.Int(nullable: false),
                        CommentFalse = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParticipantDatas", "QuizQuestionId", "dbo.Quizs");
            DropForeignKey("dbo.ParticipantDatas", "QuizParticipId", "dbo.Participants");
            DropForeignKey("dbo.ParticipantDatas", "QuizId", "dbo.AgentParticipants");
            DropForeignKey("dbo.AgentParticipants", "IdAgent", "dbo.Agents");
            DropIndex("dbo.ParticipantDatas", new[] { "QuizParticipId" });
            DropIndex("dbo.ParticipantDatas", new[] { "QuizQuestionId" });
            DropIndex("dbo.ParticipantDatas", new[] { "QuizId" });
            DropIndex("dbo.AgentParticipants", new[] { "IdAgent" });
            DropTable("dbo.Quizs");
            DropTable("dbo.Participants");
            DropTable("dbo.ParticipantDatas");
            DropTable("dbo.AgentParticipants");
            DropTable("dbo.Agents");
        }
    }
}
