namespace ConsoleApplication1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ret : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArInvoices",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        InvoiceNotePKey = c.Int(),
                        InvoicePKey = c.Int(),
                        SchedulePKey = c.Int(),
                        ScheduleId = c.String(maxLength: 15),
                        InvoiceDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        CustomerPKey = c.Int(),
                        ClientPKey = c.Int(),
                        InvoiceAmount = c.Decimal(precision: 18, scale: 2),
                        AmountDue = c.Decimal(precision: 18, scale: 2),
                        PayDate = c.DateTime(),
                        ReqOriginal = c.Boolean(nullable: false),
                        OrignialReceived = c.Boolean(nullable: false),
                        PaperworkAlert = c.Boolean(nullable: false),
                        AlertMessage = c.String(maxLength: 150),
                        ReceiptDate = c.DateTime(),
                        StatusPKey = c.Int(),
                        IsShortPay = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Clients", t => t.ClientPKey)
                .ForeignKey("dbo.Customers", t => t.CustomerPKey)
                .ForeignKey("dbo.Invoices", t => t.InvoicePKey)
                .ForeignKey("dbo.InvoiceNotes", t => t.InvoiceNotePKey)
                .ForeignKey("dbo.Schedules", t => t.SchedulePKey)
                .ForeignKey("dbo.Status", t => t.StatusPKey)
                .Index(t => t.ClientPKey)
                .Index(t => t.CustomerPKey)
                .Index(t => t.InvoicePKey)
                .Index(t => t.InvoiceNotePKey)
                .Index(t => t.SchedulePKey)
                .Index(t => t.StatusPKey);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        SchedulePKey = c.Int(),
                        ClientPKey = c.Int(),
                        CustomerPKey = c.Int(),
                        InvoiceNo = c.String(maxLength: 15),
                        PoNumber = c.String(maxLength: 15),
                        InvoiceDate = c.DateTime(),
                        InvoiceAmount = c.Decimal(precision: 18, scale: 2),
                        AdvanceAmount = c.Decimal(precision: 18, scale: 2),
                        PayoutAmount = c.Decimal(precision: 18, scale: 2),
                        StatusPKey = c.Int(),
                        Terms = c.Single(),
                        DiscountAmount = c.Decimal(precision: 18, scale: 2),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Clients", t => t.ClientPKey)
                .ForeignKey("dbo.Customers", t => t.CustomerPKey)
                .ForeignKey("dbo.Status", t => t.StatusPKey)
                .Index(t => t.ClientPKey)
                .Index(t => t.CustomerPKey)
                .Index(t => t.StatusPKey);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        Category = c.Int(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey);
            
            CreateTable(
                "dbo.InvoiceNotes",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        InvoicePKey = c.Int(),
                        Note = c.String(maxLength: 600),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Invoices", t => t.InvoicePKey)
                .Index(t => t.InvoicePKey);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        ScheduleId = c.String(maxLength: 15),
                        ClientPKey = c.Int(),
                        ScheduleInvoicePKey = c.Int(),
                        Status = c.String(maxLength: 10),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        TotalDiscountAmount = c.Decimal(precision: 18, scale: 2),
                        EscrowAmount = c.Decimal(precision: 18, scale: 2),
                        Notes = c.String(maxLength: 600),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Clients", t => t.ClientPKey)
                .Index(t => t.ClientPKey);
            
            CreateTable(
                "dbo.ArReceipts",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        ArInvoicePKey = c.Int(),
                        ClientPKey = c.Int(),
                        CustomerPKey = c.Int(),
                        ReceiptDate = c.DateTime(),
                        ReceiptAmount = c.Decimal(precision: 18, scale: 2),
                        TransactionNo = c.String(maxLength: 15),
                        IsShortPay = c.Boolean(nullable: false),
                        ReceiptType = c.String(maxLength: 50),
                        Notes = c.String(maxLength: 600),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.ArInvoices", t => t.ArInvoicePKey)
                .Index(t => t.ArInvoicePKey);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        Decription = c.String(maxLength: 50),
                        Abbrv = c.String(maxLength: 5),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey);
            
            CreateTable(
                "dbo.EscrowAccounts",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        ClientPKey = c.Int(),
                        ArReceiptPKey = c.Int(),
                        SchedulePKey = c.Int(),
                        UnfactoredPKey = c.Int(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        IsUsable = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.ArReceipts", t => t.ArReceiptPKey)
                .ForeignKey("dbo.Unfactoreds", t => t.UnfactoredPKey)
                .Index(t => t.ArReceiptPKey)
                .Index(t => t.UnfactoredPKey);
            
            CreateTable(
                "dbo.Unfactoreds",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        CustomerPKey = c.Int(),
                        ClientPKey = c.Int(),
                        TransactionNo = c.String(maxLength: 15),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Notes = c.String(maxLength: 600),
                        ReceiptDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey);
            
            CreateTable(
                "dbo.InvoiceAdvances",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        InvoicePKey = c.Int(),
                        Code = c.String(maxLength: 50),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Invoices", t => t.InvoicePKey)
                .Index(t => t.InvoicePKey);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        InvoicePKey = c.Int(),
                        SchedulePKey = c.Int(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Invoices", t => t.InvoicePKey)
                .ForeignKey("dbo.Schedules", t => t.SchedulePKey)
                .Index(t => t.InvoicePKey)
                .Index(t => t.SchedulePKey);
            
            CreateTable(
                "dbo.InvoiceLanes",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        InvoicePKey = c.Int(),
                        Quantity = c.Int(),
                        FromDescription = c.String(maxLength: 150),
                        FromCity = c.String(maxLength: 100),
                        FromState = c.String(maxLength: 2),
                        ToDescription = c.String(maxLength: 150),
                        ToCity = c.String(maxLength: 150),
                        ToState = c.String(maxLength: 2),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        EquipmentTypePKey = c.Int(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypePKey)
                .ForeignKey("dbo.Invoices", t => t.InvoicePKey)
                .Index(t => t.EquipmentTypePKey)
                .Index(t => t.InvoicePKey);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        InvoicePKey = c.Int(),
                        Quantity = c.Int(),
                        Description = c.String(maxLength: 250),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Invoices", t => t.InvoicePKey)
                .Index(t => t.InvoicePKey);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        ClientPKey = c.Int(),
                        PayeePKey = c.Int(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        UpdatedDate = c.DateTime(nullable: false),
                        AgentId = c.Int(),
                    })
                .PrimaryKey(t => t.PKey);
            
            CreateTable(
                "dbo.SchedulePayments",
                c => new
                    {
                        PKey = c.Int(nullable: false, identity: true),
                        SchedulePKey = c.Int(),
                        PaymentTypePkey = c.Int(),
                        PaymentAmount = c.Decimal(precision: 18, scale: 2),
                        PaymentFee = c.Decimal(precision: 18, scale: 2),
                        EscrowAmount = c.Decimal(precision: 18, scale: 2),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PKey)
                .ForeignKey("dbo.Schedules", t => t.SchedulePKey)
                .Index(t => t.SchedulePKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulePayments", "SchedulePKey", "dbo.Schedules");
            DropForeignKey("dbo.InvoiceLines", "InvoicePKey", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceLanes", "InvoicePKey", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceLanes", "EquipmentTypePKey", "dbo.EquipmentTypes");
            DropForeignKey("dbo.InvoiceItems", "SchedulePKey", "dbo.Schedules");
            DropForeignKey("dbo.InvoiceItems", "InvoicePKey", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceAdvances", "InvoicePKey", "dbo.Invoices");
            DropForeignKey("dbo.EscrowAccounts", "UnfactoredPKey", "dbo.Unfactoreds");
            DropForeignKey("dbo.EscrowAccounts", "ArReceiptPKey", "dbo.ArReceipts");
            DropForeignKey("dbo.ArReceipts", "ArInvoicePKey", "dbo.ArInvoices");
            DropForeignKey("dbo.ArInvoices", "StatusPKey", "dbo.Status");
            DropForeignKey("dbo.ArInvoices", "SchedulePKey", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "ClientPKey", "dbo.Clients");
            DropForeignKey("dbo.ArInvoices", "InvoiceNotePKey", "dbo.InvoiceNotes");
            DropForeignKey("dbo.InvoiceNotes", "InvoicePKey", "dbo.Invoices");
            DropForeignKey("dbo.ArInvoices", "InvoicePKey", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "StatusPKey", "dbo.Status");
            DropForeignKey("dbo.Invoices", "CustomerPKey", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "ClientPKey", "dbo.Clients");
            DropForeignKey("dbo.ArInvoices", "CustomerPKey", "dbo.Customers");
            DropForeignKey("dbo.ArInvoices", "ClientPKey", "dbo.Clients");
            DropIndex("dbo.SchedulePayments", new[] { "SchedulePKey" });
            DropIndex("dbo.InvoiceLines", new[] { "InvoicePKey" });
            DropIndex("dbo.InvoiceLanes", new[] { "InvoicePKey" });
            DropIndex("dbo.InvoiceLanes", new[] { "EquipmentTypePKey" });
            DropIndex("dbo.InvoiceItems", new[] { "SchedulePKey" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoicePKey" });
            DropIndex("dbo.InvoiceAdvances", new[] { "InvoicePKey" });
            DropIndex("dbo.EscrowAccounts", new[] { "UnfactoredPKey" });
            DropIndex("dbo.EscrowAccounts", new[] { "ArReceiptPKey" });
            DropIndex("dbo.ArReceipts", new[] { "ArInvoicePKey" });
            DropIndex("dbo.ArInvoices", new[] { "StatusPKey" });
            DropIndex("dbo.ArInvoices", new[] { "SchedulePKey" });
            DropIndex("dbo.Schedules", new[] { "ClientPKey" });
            DropIndex("dbo.ArInvoices", new[] { "InvoiceNotePKey" });
            DropIndex("dbo.InvoiceNotes", new[] { "InvoicePKey" });
            DropIndex("dbo.ArInvoices", new[] { "InvoicePKey" });
            DropIndex("dbo.Invoices", new[] { "StatusPKey" });
            DropIndex("dbo.Invoices", new[] { "CustomerPKey" });
            DropIndex("dbo.Invoices", new[] { "ClientPKey" });
            DropIndex("dbo.ArInvoices", new[] { "CustomerPKey" });
            DropIndex("dbo.ArInvoices", new[] { "ClientPKey" });
            DropTable("dbo.SchedulePayments");
            DropTable("dbo.Payments");
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.InvoiceLanes");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.InvoiceAdvances");
            DropTable("dbo.Unfactoreds");
            DropTable("dbo.EscrowAccounts");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.ArReceipts");
            DropTable("dbo.Schedules");
            DropTable("dbo.InvoiceNotes");
            DropTable("dbo.Status");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Clients");
            DropTable("dbo.ArInvoices");
        }
    }
}
