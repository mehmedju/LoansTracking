namespace LoansTracking.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
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

            const string query = "insert into People ([FirstName], [LastName], [Gender],[DateOfBirth], [MobileNumber], [Address], [Location], [Company], [Occupation], [Email], [Password])" +
                                    " values ('admin', 'administrator', 'Male', '1991-05-03', '061/483-003', 'Address', 'Sarajevo', 'Mistral', 'Developer', 'admin', 'cGFzc3dvcmQ=')";
            Sql(query);
        }
    }
}
