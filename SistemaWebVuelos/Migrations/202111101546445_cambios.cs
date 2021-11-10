namespace SistemaWebVuelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Vueloes", newName: "Vuelo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Vuelo", newName: "Vueloes");
        }
    }
}
