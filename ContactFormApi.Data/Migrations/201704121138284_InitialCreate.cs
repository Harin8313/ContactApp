namespace ContactFormApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactInformations", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ContactInformations", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactInformations", "PhoneNumber", c => c.String(maxLength: 10));
            AlterColumn("dbo.ContactInformations", "Email", c => c.String());
        }
    }
}
