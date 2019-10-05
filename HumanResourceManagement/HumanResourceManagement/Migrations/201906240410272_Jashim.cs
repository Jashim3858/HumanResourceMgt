namespace HumanResourceManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jashim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        ContractAddress = c.String(),
                        BasicSalary = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        PicUrl = c.String(),
                        Payroll_PayrollID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Payrolls", t => t.Payroll_PayrollID)
                .Index(t => t.DepartmentID)
                .Index(t => t.Payroll_PayrollID);
            
            CreateTable(
                "dbo.Payrolls",
                c => new
                    {
                        PayrollID = c.Int(nullable: false, identity: true),
                        BasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OverTime = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HouserentAllowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransportAllowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DarenessAllowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MedicalAllowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrossSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProvidentFund = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CashAdvanced = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToatalDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeID = c.Int(nullable: false),
                        Employee_EmployeeID = c.Int(),
                        Employee_EmployeeID1 = c.Int(),
                    })
                .PrimaryKey(t => t.PayrollID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID1)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.Employee_EmployeeID1);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        PoastalCode = c.Int(nullable: false),
                        City = c.String(),
                        CountryName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Departments", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Payrolls", "Employee_EmployeeID1", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Payroll_PayrollID", "dbo.Payrolls");
            DropForeignKey("dbo.Payrolls", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Payrolls", new[] { "Employee_EmployeeID1" });
            DropIndex("dbo.Payrolls", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Employees", new[] { "Payroll_PayrollID" });
            DropIndex("dbo.Employees", new[] { "DepartmentID" });
            DropIndex("dbo.Departments", new[] { "LocationID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Locations");
            DropTable("dbo.Payrolls");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
