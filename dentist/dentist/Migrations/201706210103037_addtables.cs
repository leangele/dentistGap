namespace dentist.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Identification = c.String(),
                        Age = c.Int(nullable: false),
                        ContactNumber = c.String(),
                        ContactName = c.String(),
                        LastAppointment = c.DateTime(nullable: false),
                        NextAppointment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detail = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatments", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Treatments", new[] { "Patient_Id" });
            DropTable("dbo.Treatments");
            DropTable("dbo.Patients");
        }
    }
}
