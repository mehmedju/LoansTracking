namespace LoansTracking.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Loans",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            PaidOff = c.Boolean(nullable: false),
            //            Amount = c.Double(nullable: false),
            //            DueDate = c.DateTime(nullable: false),
            //            PersonLoanedFrom_Id = c.Int(),
            //            PersonLoanedTo_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.People", t => t.PersonLoanedFrom_Id)
            //    .ForeignKey("dbo.People", t => t.PersonLoanedTo_Id)
            //    .Index(t => t.PersonLoanedFrom_Id)
            //    .Index(t => t.PersonLoanedTo_Id);
            
            //CreateTable(
            //    "dbo.Payments",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Date = c.DateTime(nullable: false),
            //            AmountPaid = c.Double(nullable: false),
            //            Loan_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Loans", t => t.Loan_Id)
            //    .Index(t => t.Loan_Id);
            
            //CreateTable(
            //    "dbo.People",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(),
            //            LastName = c.String(),
            //            DateOfBirth = c.DateTime(nullable: false),
            //            Gender = c.String(),
            //            MobileNumber = c.String(),
            //            Address = c.String(),
            //            Location = c.String(),
            //            Company = c.String(),
            //            Occupation = c.String(),
            //            Email = c.String(),
            //            Password = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Notes",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Title = c.String(),
            //            Text = c.String(unicode: false, storeType: "text"),
            //            Person_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.People", t => t.Person_Id)
            //    .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
        //    DropForeignKey("dbo.Notes", "Person_Id", "dbo.People");
        //    DropForeignKey("dbo.Loans", "PersonLoanedTo_Id", "dbo.People");
        //    DropForeignKey("dbo.Loans", "PersonLoanedFrom_Id", "dbo.People");
        //    DropForeignKey("dbo.Payments", "Loan_Id", "dbo.Loans");
        //    DropIndex("dbo.Notes", new[] { "Person_Id" });
        //    DropIndex("dbo.Payments", new[] { "Loan_Id" });
        //    DropIndex("dbo.Loans", new[] { "PersonLoanedTo_Id" });
        //    DropIndex("dbo.Loans", new[] { "PersonLoanedFrom_Id" });
        //    DropTable("dbo.Notes");
        //    DropTable("dbo.People");
        //    DropTable("dbo.Payments");
        //    DropTable("dbo.Loans");
        }
    }
}
