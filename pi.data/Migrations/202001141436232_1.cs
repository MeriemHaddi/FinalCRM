namespace pi.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Adress = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.Int(nullable: false),
                        CIN = c.String(maxLength: 8),
                        Email = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        Email1 = c.String(),
                        Password1 = c.String(),
                        UserName1 = c.String(),
                        Salary = c.Int(),
                        Position = c.String(),
                        PointOfSaleId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Comment_CommentId = c.Int(),
                        Post_PostId = c.Int(),
                        PointOfSale_PointOfSaleId = c.Int(),
                        TeleProspection_TeleProspectionId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSale_PointOfSaleId)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSaleId, cascadeDelete: true)
                .ForeignKey("dbo.TeleProspections", t => t.TeleProspection_TeleProspectionId)
                .Index(t => t.PointOfSaleId)
                .Index(t => t.Comment_CommentId)
                .Index(t => t.Post_PostId)
                .Index(t => t.PointOfSale_PointOfSaleId)
                .Index(t => t.TeleProspection_TeleProspectionId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        Text = c.String(),
                        Rating = c.Int(nullable: false),
                        Client_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Client_UserId)
                .Index(t => t.ClientId)
                .Index(t => t.PostId)
                .Index(t => t.Client_UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Date = c.String(),
                        State = c.String(),
                        vue = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Picture = c.String(),
                        Comment_CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.ClientId)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentId)
                .Index(t => t.ClientId)
                .Index(t => t.Comment_CommentId);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sender_id = c.Int(nullable: false),
                        receiver_id = c.Int(nullable: false),
                        message = c.String(),
                        status = c.Int(nullable: false),
                        created_at = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PointOfSales",
                c => new
                    {
                        PointOfSaleId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        State = c.String(),
                        Name = c.String(),
                        Service = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PointOfSaleId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        idProduct = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(maxLength: 25),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        Picture = c.String(),
                        id_Shop = c.Int(),
                        id_Category = c.Int(),
                        In_Quantity = c.Int(nullable: false),
                        Out_Quantity = c.Int(nullable: false),
                        nbrvue = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PointOfSale_PointOfSaleId = c.Int(),
                        Pack_Id_Pack = c.String(maxLength: 128),
                        Usere_Id = c.Int(),
                    })
                .PrimaryKey(t => t.idProduct)
                .ForeignKey("dbo.CategoryProducts", t => t.id_Category)
                .ForeignKey("dbo.Shops", t => t.id_Shop)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSale_PointOfSaleId)
                .ForeignKey("dbo.Packs", t => t.Pack_Id_Pack)
                .ForeignKey("dbo.Useres", t => t.Usere_Id)
                .Index(t => t.id_Shop)
                .Index(t => t.id_Category)
                .Index(t => t.PointOfSale_PointOfSaleId)
                .Index(t => t.Pack_Id_Pack)
                .Index(t => t.Usere_Id);
            
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        id_Category = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.id_Category);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        id_Shop = c.Int(nullable: false, identity: true),
                        shop_name = c.String(),
                        Shop_Location = c.String(),
                        Opening_Time = c.Time(nullable: false, precision: 7),
                        closing_Time = c.Time(nullable: false, precision: 7),
                        altitude = c.Single(nullable: false),
                        longitude = c.Single(nullable: false),
                        Service = c.String(),
                    })
                .PrimaryKey(t => t.id_Shop);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        idAgent = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        post = c.String(),
                        tel = c.Int(nullable: false),
                        id_Shop = c.Int(),
                        role = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.idAgent)
                .ForeignKey("dbo.Shops", t => t.id_Shop)
                .Index(t => t.id_Shop);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourcesId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        PointOfSaleId = c.Int(nullable: false),
                        State = c.String(),
                        Employee_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ResourcesId)
                .ForeignKey("dbo.PointOfSales", t => t.PointOfSaleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Employee_UserId)
                .Index(t => t.PointOfSaleId)
                .Index(t => t.Employee_UserId);
            
            CreateTable(
                "dbo.factdevs",
                c => new
                    {
                        FactdevId = c.Int(nullable: false, identity: true),
                        reference = c.Int(nullable: false),
                        prix = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        etat = c.Int(nullable: false),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FactdevId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.lignecmds",
                c => new
                    {
                        LignecmdId = c.Int(nullable: false, identity: true),
                        id_factdev = c.Int(nullable: false),
                        id_user = c.Int(nullable: false),
                        quantite = c.Int(nullable: false),
                        prix = c.Single(nullable: false),
                        etat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LignecmdId);
            
            CreateTable(
                "dbo.Offre",
                c => new
                    {
                        Id_Offre = c.String(nullable: false, maxLength: 128),
                        Titre = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false),
                        periode = c.String(),
                        date_debut = c.DateTime(nullable: false),
                        date_fin = c.DateTime(nullable: false),
                        Prix = c.Single(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id_Offre);
            
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        Id_Pack = c.String(nullable: false, maxLength: 128),
                        Titre = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false),
                        Periode_Engagement = c.Int(nullable: false),
                        Prix = c.Single(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id_Pack);
            
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        idReclamation = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        Titre = c.String(nullable: false),
                        contenu = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        etat = c.String(),
                        TypeReclamation = c.Int(nullable: false),
                        Urlimage = c.String(),
                        SatisfactionEnum = c.Int(),
                        UserId_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.idReclamation)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        IdResponse = c.Int(nullable: false, identity: true),
                        ResponseDate = c.DateTime(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        idClaim = c.Int(nullable: false),
                        User_UserId = c.Int(),
                        Reclamation_idReclamation = c.Int(),
                    })
                .PrimaryKey(t => t.IdResponse)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Reclamations", t => t.Reclamation_idReclamation)
                .Index(t => t.User_UserId)
                .Index(t => t.Reclamation_idReclamation);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id_Stock = c.Int(nullable: false, identity: true),
                        In_Quantity = c.Int(nullable: false),
                        Out_Quantity = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        id_Shop_id_Shop = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Stock)
                .ForeignKey("dbo.Shops", t => t.id_Shop_id_Shop)
                .Index(t => t.id_Shop_id_Shop);
            
            CreateTable(
                "dbo.TeleProspections",
                c => new
                    {
                        TeleProspectionId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        State = c.String(),
                        Description = c.String(),
                        Priority = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeleProspectionId)
                .ForeignKey("dbo.Users", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Useres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CIN = c.String(maxLength: 8),
                        FName = c.String(),
                        LName = c.String(),
                        StreetName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Role = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Photo = c.String(),
                        EntrepriseTranscripts = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Usere_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Useres", t => t.Usere_Id)
                .Index(t => t.Usere_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        Usere_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Useres", t => t.Usere_Id)
                .Index(t => t.Usere_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Usere_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Useres", t => t.Usere_Id)
                .Index(t => t.Usere_Id);
            
            CreateTable(
                "dbo.OffrePostpayee",
                c => new
                    {
                        Id_Offre = c.String(nullable: false, maxLength: 128),
                        Titre = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false),
                        periode = c.String(),
                        date_debut = c.DateTime(nullable: false),
                        date_fin = c.DateTime(nullable: false),
                        Prix = c.Single(nullable: false),
                        img = c.String(),
                        PrixHorsPack = c.Single(nullable: false),
                        Id_Pack = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id_Offre)
                .ForeignKey("dbo.Packs", t => t.Id_Pack, cascadeDelete: true)
                .Index(t => t.Id_Pack);
            
            CreateTable(
                "dbo.OffrePrepayee",
                c => new
                    {
                        Id_Offre = c.String(nullable: false, maxLength: 128),
                        Titre = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false),
                        periode = c.String(),
                        date_debut = c.DateTime(nullable: false),
                        date_fin = c.DateTime(nullable: false),
                        Prix = c.Single(nullable: false),
                        img = c.String(),
                    })
                .PrimaryKey(t => t.Id_Offre);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OffrePostpayee", "Id_Pack", "dbo.Packs");
            DropForeignKey("dbo.CustomUserRoles", "Usere_Id", "dbo.Useres");
            DropForeignKey("dbo.Products", "Usere_Id", "dbo.Useres");
            DropForeignKey("dbo.CustomUserLogins", "Usere_Id", "dbo.Useres");
            DropForeignKey("dbo.CustomUserClaims", "Usere_Id", "dbo.Useres");
            DropForeignKey("dbo.Users", "TeleProspection_TeleProspectionId", "dbo.TeleProspections");
            DropForeignKey("dbo.TeleProspections", "ClientId", "dbo.Users");
            DropForeignKey("dbo.Stocks", "id_Shop_id_Shop", "dbo.Shops");
            DropForeignKey("dbo.Reclamations", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Responses", "Reclamation_idReclamation", "dbo.Reclamations");
            DropForeignKey("dbo.Responses", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Pack_Id_Pack", "dbo.Packs");
            DropForeignKey("dbo.factdevs", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Resources", "Employee_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "PointOfSaleId", "dbo.PointOfSales");
            DropForeignKey("dbo.Users", "PointOfSale_PointOfSaleId", "dbo.PointOfSales");
            DropForeignKey("dbo.Resources", "PointOfSaleId", "dbo.PointOfSales");
            DropForeignKey("dbo.Products", "PointOfSale_PointOfSaleId", "dbo.PointOfSales");
            DropForeignKey("dbo.Products", "id_Shop", "dbo.Shops");
            DropForeignKey("dbo.Agents", "id_Shop", "dbo.Shops");
            DropForeignKey("dbo.Products", "id_Category", "dbo.CategoryProducts");
            DropForeignKey("dbo.Comments", "Client_UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Users", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "ClientId", "dbo.Users");
            DropForeignKey("dbo.Users", "Comment_CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ClientId", "dbo.Users");
            DropIndex("dbo.OffrePostpayee", new[] { "Id_Pack" });
            DropIndex("dbo.CustomUserRoles", new[] { "Usere_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "Usere_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "Usere_Id" });
            DropIndex("dbo.TeleProspections", new[] { "ClientId" });
            DropIndex("dbo.Stocks", new[] { "id_Shop_id_Shop" });
            DropIndex("dbo.Responses", new[] { "Reclamation_idReclamation" });
            DropIndex("dbo.Responses", new[] { "User_UserId" });
            DropIndex("dbo.Reclamations", new[] { "UserId_UserId" });
            DropIndex("dbo.factdevs", new[] { "UserId_UserId" });
            DropIndex("dbo.Resources", new[] { "Employee_UserId" });
            DropIndex("dbo.Resources", new[] { "PointOfSaleId" });
            DropIndex("dbo.Agents", new[] { "id_Shop" });
            DropIndex("dbo.Products", new[] { "Usere_Id" });
            DropIndex("dbo.Products", new[] { "Pack_Id_Pack" });
            DropIndex("dbo.Products", new[] { "PointOfSale_PointOfSaleId" });
            DropIndex("dbo.Products", new[] { "id_Category" });
            DropIndex("dbo.Products", new[] { "id_Shop" });
            DropIndex("dbo.Posts", new[] { "Comment_CommentId" });
            DropIndex("dbo.Posts", new[] { "ClientId" });
            DropIndex("dbo.Comments", new[] { "Client_UserId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "ClientId" });
            DropIndex("dbo.Users", new[] { "TeleProspection_TeleProspectionId" });
            DropIndex("dbo.Users", new[] { "PointOfSale_PointOfSaleId" });
            DropIndex("dbo.Users", new[] { "Post_PostId" });
            DropIndex("dbo.Users", new[] { "Comment_CommentId" });
            DropIndex("dbo.Users", new[] { "PointOfSaleId" });
            DropTable("dbo.OffrePrepayee");
            DropTable("dbo.OffrePostpayee");
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.Useres");
            DropTable("dbo.TeleProspections");
            DropTable("dbo.Stocks");
            DropTable("dbo.Responses");
            DropTable("dbo.Reclamations");
            DropTable("dbo.Packs");
            DropTable("dbo.Offre");
            DropTable("dbo.lignecmds");
            DropTable("dbo.factdevs");
            DropTable("dbo.Resources");
            DropTable("dbo.Agents");
            DropTable("dbo.Shops");
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.Products");
            DropTable("dbo.PointOfSales");
            DropTable("dbo.Conversations");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
        }
    }
}
