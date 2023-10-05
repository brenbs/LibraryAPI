using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<int>(type: "INTEGER", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false),
                    Realese = table.Column<int>(type: "INTEGER", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pé da Letra" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "JBC" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "MangaPop" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Intrínseca" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Panini" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "City", "Email", "Name", "Telephone" },
                values: new object[] { 1, "Álvaro Weyne rua Manoel Pereira n°489", "Fortaleza,CE", "brenbs@gmail.com", "Brenda", 85958394 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "City", "Email", "Name", "Telephone" },
                values: new object[] { 2, "Moranguinho, rua Maria n°321", "Horizonte,CE", "manhu@gmail.com", "Emauela", 25656532 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "City", "Email", "Name", "Telephone" },
                values: new object[] { 3, "Damas, rua Professor Costa Mendes n°933", "Fortaleza,CE", "lolo@gmail.com", "Heloísa", 85503593 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "City", "Email", "Name", "Telephone" },
                values: new object[] { 4, "Aldeota, Av.Dom Luís n°5001", "Fortaleza,CE", "tonys@gmail.com", "Antonio", 87894587 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "City", "Email", "Name", "Telephone" },
                values: new object[] { 5, "Álvaro Weyne,Coelho Neto n°400", "Fortaleza,CE", "manel@gmail.com", "Emanuel", 805309245 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Autor", "Name", "PublisherId", "Realese", "Stock" },
                values: new object[] { 1, "Jane Austen", "Orgulho e Preconceito", 1, 1813, 25 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Autor", "Name", "PublisherId", "Realese", "Stock" },
                values: new object[] { 2, "Tatsuki Fujimoto", "Chainsaw Man Vol.1", 5, 2010, 20 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Autor", "Name", "PublisherId", "Realese", "Stock" },
                values: new object[] { 3, "Jane Austen", "Razão e Sensibilidade", 1, 1811, 30 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Autor", "Name", "PublisherId", "Realese", "Stock" },
                values: new object[] { 4, "Antoine de Saint-Exupéry", "O Pequeno Príncipe", 4, 1943, 35 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Autor", "Name", "PublisherId", "Realese", "Stock" },
                values: new object[] { 5, "Neil Gaiman", "Coraline", 4, 2002, 18 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BookId",
                table: "Rentals",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
