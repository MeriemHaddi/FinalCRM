namespace pi.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class meriem5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boncmds",
                c => new
                    {
                        BoncmdId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        reference = c.String(nullable: false, maxLength: 20),
                        prixb = c.Double(nullable: false),
                        prix = c.Double(nullable: false),
                        date = c.DateTime(nullable: false),
                        etat = c.Int(nullable: false),
                        codeqr = c.String(),
                    })
                .PrimaryKey(t => t.BoncmdId);
            
            AddColumn("dbo.lignecmds", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.lignecmds", "FactdevId", c => c.Int());
            AddColumn("dbo.lignecmds", "BoncmdId", c => c.Int());
            AddColumn("dbo.lignecmds", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.factdevs", "reference", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.lignecmds", "prix", c => c.Double(nullable: false));
            CreateIndex("dbo.lignecmds", "ProductId");
            CreateIndex("dbo.lignecmds", "FactdevId");
            CreateIndex("dbo.lignecmds", "BoncmdId");
            CreateIndex("dbo.lignecmds", "UserId");
            AddForeignKey("dbo.lignecmds", "FactdevId", "dbo.factdevs", "FactdevId", cascadeDelete: true);
            AddForeignKey("dbo.lignecmds", "ProductId", "dbo.Products", "idProduct", cascadeDelete: true);
            AddForeignKey("dbo.lignecmds", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.lignecmds", "BoncmdId", "dbo.Boncmds", "BoncmdId", cascadeDelete: true);
            DropColumn("dbo.lignecmds", "id_factdev");
            DropColumn("dbo.lignecmds", "id_user");
        }
        
        public override void Down()
        {
            AddColumn("dbo.lignecmds", "id_user", c => c.Int(nullable: false));
            AddColumn("dbo.lignecmds", "id_factdev", c => c.Int(nullable: false));
            DropForeignKey("dbo.lignecmds", "BoncmdId", "dbo.Boncmds");
            DropForeignKey("dbo.lignecmds", "UserId", "dbo.Users");
            DropForeignKey("dbo.lignecmds", "ProductId", "dbo.Products");
            DropForeignKey("dbo.lignecmds", "FactdevId", "dbo.factdevs");
            DropIndex("dbo.lignecmds", new[] { "UserId" });
            DropIndex("dbo.lignecmds", new[] { "BoncmdId" });
            DropIndex("dbo.lignecmds", new[] { "FactdevId" });
            DropIndex("dbo.lignecmds", new[] { "ProductId" });
            AlterColumn("dbo.lignecmds", "prix", c => c.Single(nullable: false));
            AlterColumn("dbo.factdevs", "reference", c => c.Int(nullable: false));
            DropColumn("dbo.lignecmds", "UserId");
            DropColumn("dbo.lignecmds", "BoncmdId");
            DropColumn("dbo.lignecmds", "FactdevId");
            DropColumn("dbo.lignecmds", "ProductId");
            DropTable("dbo.Boncmds");
        }
    }
}
