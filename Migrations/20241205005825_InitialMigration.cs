using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace burguermania_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PathImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PathImage = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    BaseDescription = table.Column<string>(type: "text", nullable: false),
                    FullDescription = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PathImage" },
                values: new object[,]
                {
                    { 1, "Sabor incrível sem abrir mão do veganismo. O hambúrguer perfeito para quem ama comer bem e com consciência!", "X-Vegan", "http://localhost:5190/images/burguer.png" },
                    { 2, "Leve, saudável e delicioso! O hambúrguer ideal para quem busca equilíbrio e sabor na mesma mordida.", "X-Fitness", "http://localhost:5190/images/burguer.png" },
                    { 3, "Para os corajosos e amantes de um hambúrguer generoso! Cada mordida é uma explosão de sabor.", "X-Infarto", "http://localhost:5190/images/burguer.png" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Em Processamento" },
                    { 3, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "admin@burguermania.com", "Administrador BurguerMania", "Admin@123456" },
                    { 2, "kaikbomfim@burguermania.com", "Kaik Bomfim", "Kaik@102030" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BaseDescription", "CategoryId", "FullDescription", "Name", "PathImage", "Price" },
                values: new object[,]
                {
                    { 1, "Pão, hambúrguer vegetal, alface extra, tomate, queijo vegano e maionese vegana.", 1, "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.", "X-Alface-Premium", "http://localhost:5190/images/burguer.png", 35.0 },
                    { 2, "Pão, hambúrguer vegetal, tomate em fatias duplas, queijo vegano e maionese vegana.", 1, "Uma explosão de frescor e sabor em cada mordida! O X-Tomate combina um hambúrguer vegetal temperado com ervas aromáticas e alho, servido em pão artesanal macio. É acompanhado por fatias suculentas de tomate maduro em dobro, queijo vegano cremoso e uma camada suave de maionese de ervas. Finalizado com uma leve pitada de sal marinho e pimenta-do-reino, garantindo uma experiência simples e saborosa.", "X-Tomate", "http://localhost:5190/images/burguer.png", 22.5 },
                    { 3, "Pão, hambúrguer vegetal, alface, tomate, abacaxi grelhado e maionese vegana.", 1, "Uma combinação surpreendente que mistura sabores doces e salgados! O X-Frutas apresenta um hambúrguer vegetal grelhado e suculento, servido em pão de brioche artesanal. É complementado por abacaxi grelhado caramelizado, alface fresca e tomate maduro, adicionando uma camada extra de sabor. Para finalizar, uma maionese vegana suave e aromática que equilibra perfeitamente os contrastes de sabor.", "X-Frutas", "http://localhost:5190/images/burguer.png", 28.0 },
                    { 4, "Pão integral, hambúrguer de frango, alface, tomate e creme de ricota.", 2, "Leve e equilibrado, o X-Frango-Leve é a escolha perfeita para quem busca sabor e saúde. Feito com um hambúrguer de frango grelhado, temperado com ervas frescas, ele é servido em pão integral. É acompanhado de folhas de alface crocantes, tomate suculento e uma camada generosa de creme de ricota, proporcionando uma experiência cremosa e nutritiva.", "X-Frango-Leve", "http://localhost:5190/images/burguer.png", 24.0 },
                    { 5, "Pão integral, hambúrguer de frango, creme de ricota extra e folhas verdes.", 2, "Um hambúrguer refinado e delicioso, o X-Creme-Ricota apresenta um hambúrguer de frango grelhado combinado com creme de ricota extra suave e cremoso. Servido em pão integral macio, ele vem acompanhado de uma seleção de folhas verdes frescas que trazem crocância e frescor. Um toque de azeite extra virgem e pimenta-do-reino completam essa experiência gastronômica leve e sofisticada.", "X-Creme-Ricota", "http://localhost:5190/images/burguer.png", 26.5 },
                    { 6, "Pão integral, hambúrguer de frango grelhado, alface e tomate.", 2, "Simplicidade e saúde em um só hambúrguer! O X-Light traz um hambúrguer de frango grelhado com um toque de limão e ervas, servido em pão integral macio. Ele é complementado por alface fresca e tomate maduro, garantindo um sabor leve e equilibrado. Ideal para quem deseja uma refeição prática e saudável.", "X-Light", "http://localhost:5190/images/burguer.png", 20.0 },
                    { 7, "Pão brioche, hambúrguer duplo, bacon extra, queijo cheddar e maionese especial.", 3, "Uma indulgência irresistível para os amantes de bacon! O X-Duplo-Bacon combina dois hambúrgueres grelhados suculentos com fatias generosas de bacon crocante. Servido em pão brioche macio, ele é finalizado com queijo cheddar derretido e uma maionese especial com um toque de alho. Uma experiência rica e intensa que satisfaz qualquer apetite.", "X-Duplo-Bacon", "http://localhost:5190/images/burguer.png", 32.0 },
                    { 8, "Pão brioche, hambúrguer duplo, queijo cheddar derretido e maionese especial.", 3, "Cheio de sabor e cremosidade, o X-Cheddar-Melt é feito com dois hambúrgueres grelhados suculentos e cobertos por uma camada generosa de queijo cheddar derretido. Servido em pão brioche dourado, ele é complementado por uma maionese especial suave e rica, criando uma combinação perfeita de sabores em cada mordida.", "X-Cheddar-Melt", "http://localhost:5190/images/burguer.png", 30.0 },
                    { 9, "Pão brioche, hambúrguer triplo, bacon crocante, queijo cheddar e maionese especial.", 3, "O maior e mais ousado dos hambúrgueres! O X-Ultra apresenta três hambúrgueres grelhados e suculentos, acompanhados por bacon crocante e queijo cheddar derretido. Servido em pão brioche macio e dourado, ele é finalizado com uma camada generosa de maionese especial. Cada mordida é uma explosão de sabor, perfeita para os mais famintos.", "X-Ultra", "http://localhost:5190/images/burguer.png", 35.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
