namespace LoansTracking.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin_User : DbMigration
    {
        public override void Up()
        {
            InsertDefaultAdminUser();
        }

        public override void Down()
        {
        }

        private void InsertDefaultAdminUser()
        {
            //const string query = @"
            //                    INSERT [dbo].[People] SET 
            //                    [FirstName, LastName, DateOfBirth, Gender, Mobile Number, Address, Location, Company, Occupation, Email, Password] = 
            //                        ['admin', 'administrator', '1991-05-03', 'Male', '061/111-222', 'Address 13', 'Sarajevo', 'Mistral', 'Developer', 'admin', 'password']";
            const string query = "insert into People ([FirstName], [LastName], [Gender],[DateOfBirth], [MobileNumber], [Address], [Location], [Company], [Occupation], [Email], [Password])" +
                                    " values ('admin', 'administrator', 'Male', '1991-05-03', '061/483-003', 'Address', 'Sarajevo', 'Mistral', 'Developer', 'admin', 'password')";
            Sql(query);
        }
    }
}
