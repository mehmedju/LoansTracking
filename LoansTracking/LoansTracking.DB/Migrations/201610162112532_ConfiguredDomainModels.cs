namespace LoansTracking.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfiguredDomainModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        Loan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loans", t => t.Loan_Id)
                .Index(t => t.Loan_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Loans", "PaidOff", c => c.Boolean(nullable: false));
            AddColumn("dbo.Loans", "Person_Id", c => c.Int());
            CreateIndex("dbo.Loans", "Person_Id");
            AddForeignKey("dbo.Loans", "Person_Id", "dbo.People", "Id");
            DropColumn("dbo.Loans", "Name");
            DropColumn("dbo.Loans", "Surname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "Surname", c => c.String());
            AddColumn("dbo.Loans", "Name", c => c.String());
            DropForeignKey("dbo.Loans", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Payments", "Loan_Id", "dbo.Loans");
            DropIndex("dbo.Payments", new[] { "Loan_Id" });
            DropIndex("dbo.Loans", new[] { "Person_Id" });
            DropColumn("dbo.Loans", "Person_Id");
            DropColumn("dbo.Loans", "PaidOff");
            DropTable("dbo.People");
            DropTable("dbo.Payments");
        }
    }
}
