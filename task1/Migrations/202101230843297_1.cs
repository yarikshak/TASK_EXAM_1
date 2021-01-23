﻿namespace task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitude = c.Int(nullable: false),
                        Longitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Employee",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 128),
                    CityId = c.Int(nullable: false),
                    Specialization = c.String(),
                    FavoriteVideogame = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", x => x.CityId)
                .Index(x => x.CityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employee");
            DropTable("dbo.City");
        }
    }
}
