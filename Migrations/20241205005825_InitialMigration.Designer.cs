﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using burguermania_backend.Context;

#nullable disable

namespace burguermania_backend.Migrations
{
    [DbContext(typeof(BurguerManiaDbContext))]
    [Migration("20241205005825_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("burguermania_backend.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Sabor incrível sem abrir mão do veganismo. O hambúrguer perfeito para quem ama comer bem e com consciência!",
                            Name = "X-Vegan",
                            PathImage = "http://localhost:5190/images/burguer.png"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Leve, saudável e delicioso! O hambúrguer ideal para quem busca equilíbrio e sabor na mesma mordida.",
                            Name = "X-Fitness",
                            PathImage = "http://localhost:5190/images/burguer.png"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Para os corajosos e amantes de um hambúrguer generoso! Cada mordida é uma explosão de sabor.",
                            Name = "X-Infarto",
                            PathImage = "http://localhost:5190/images/burguer.png"
                        });
                });

            modelBuilder.Entity("burguermania_backend.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Observation")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("burguermania_backend.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("burguermania_backend.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BaseDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PathImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseDescription = "Pão, hambúrguer vegetal, alface extra, tomate, queijo vegano e maionese vegana.",
                            CategoryId = 1,
                            FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
                            Name = "X-Alface-Premium",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 35.0
                        },
                        new
                        {
                            Id = 2,
                            BaseDescription = "Pão, hambúrguer vegetal, tomate em fatias duplas, queijo vegano e maionese vegana.",
                            CategoryId = 1,
                            FullDescription = "Uma explosão de frescor e sabor em cada mordida! O X-Tomate combina um hambúrguer vegetal temperado com ervas aromáticas e alho, servido em pão artesanal macio. É acompanhado por fatias suculentas de tomate maduro em dobro, queijo vegano cremoso e uma camada suave de maionese de ervas. Finalizado com uma leve pitada de sal marinho e pimenta-do-reino, garantindo uma experiência simples e saborosa.",
                            Name = "X-Tomate",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 22.5
                        },
                        new
                        {
                            Id = 3,
                            BaseDescription = "Pão, hambúrguer vegetal, alface, tomate, abacaxi grelhado e maionese vegana.",
                            CategoryId = 1,
                            FullDescription = "Uma combinação surpreendente que mistura sabores doces e salgados! O X-Frutas apresenta um hambúrguer vegetal grelhado e suculento, servido em pão de brioche artesanal. É complementado por abacaxi grelhado caramelizado, alface fresca e tomate maduro, adicionando uma camada extra de sabor. Para finalizar, uma maionese vegana suave e aromática que equilibra perfeitamente os contrastes de sabor.",
                            Name = "X-Frutas",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 28.0
                        },
                        new
                        {
                            Id = 4,
                            BaseDescription = "Pão integral, hambúrguer de frango, alface, tomate e creme de ricota.",
                            CategoryId = 2,
                            FullDescription = "Leve e equilibrado, o X-Frango-Leve é a escolha perfeita para quem busca sabor e saúde. Feito com um hambúrguer de frango grelhado, temperado com ervas frescas, ele é servido em pão integral. É acompanhado de folhas de alface crocantes, tomate suculento e uma camada generosa de creme de ricota, proporcionando uma experiência cremosa e nutritiva.",
                            Name = "X-Frango-Leve",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 24.0
                        },
                        new
                        {
                            Id = 5,
                            BaseDescription = "Pão integral, hambúrguer de frango, creme de ricota extra e folhas verdes.",
                            CategoryId = 2,
                            FullDescription = "Um hambúrguer refinado e delicioso, o X-Creme-Ricota apresenta um hambúrguer de frango grelhado combinado com creme de ricota extra suave e cremoso. Servido em pão integral macio, ele vem acompanhado de uma seleção de folhas verdes frescas que trazem crocância e frescor. Um toque de azeite extra virgem e pimenta-do-reino completam essa experiência gastronômica leve e sofisticada.",
                            Name = "X-Creme-Ricota",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 26.5
                        },
                        new
                        {
                            Id = 6,
                            BaseDescription = "Pão integral, hambúrguer de frango grelhado, alface e tomate.",
                            CategoryId = 2,
                            FullDescription = "Simplicidade e saúde em um só hambúrguer! O X-Light traz um hambúrguer de frango grelhado com um toque de limão e ervas, servido em pão integral macio. Ele é complementado por alface fresca e tomate maduro, garantindo um sabor leve e equilibrado. Ideal para quem deseja uma refeição prática e saudável.",
                            Name = "X-Light",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 7,
                            BaseDescription = "Pão brioche, hambúrguer duplo, bacon extra, queijo cheddar e maionese especial.",
                            CategoryId = 3,
                            FullDescription = "Uma indulgência irresistível para os amantes de bacon! O X-Duplo-Bacon combina dois hambúrgueres grelhados suculentos com fatias generosas de bacon crocante. Servido em pão brioche macio, ele é finalizado com queijo cheddar derretido e uma maionese especial com um toque de alho. Uma experiência rica e intensa que satisfaz qualquer apetite.",
                            Name = "X-Duplo-Bacon",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 32.0
                        },
                        new
                        {
                            Id = 8,
                            BaseDescription = "Pão brioche, hambúrguer duplo, queijo cheddar derretido e maionese especial.",
                            CategoryId = 3,
                            FullDescription = "Cheio de sabor e cremosidade, o X-Cheddar-Melt é feito com dois hambúrgueres grelhados suculentos e cobertos por uma camada generosa de queijo cheddar derretido. Servido em pão brioche dourado, ele é complementado por uma maionese especial suave e rica, criando uma combinação perfeita de sabores em cada mordida.",
                            Name = "X-Cheddar-Melt",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 9,
                            BaseDescription = "Pão brioche, hambúrguer triplo, bacon crocante, queijo cheddar e maionese especial.",
                            CategoryId = 3,
                            FullDescription = "O maior e mais ousado dos hambúrgueres! O X-Ultra apresenta três hambúrgueres grelhados e suculentos, acompanhados por bacon crocante e queijo cheddar derretido. Servido em pão brioche macio e dourado, ele é finalizado com uma camada generosa de maionese especial. Cada mordida é uma explosão de sabor, perfeita para os mais famintos.",
                            Name = "X-Ultra",
                            PathImage = "http://localhost:5190/images/burguer.png",
                            Price = 35.0
                        });
                });

            modelBuilder.Entity("burguermania_backend.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pendente"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Em Processamento"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Finalizado"
                        });
                });

            modelBuilder.Entity("burguermania_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@burguermania.com",
                            Name = "Administrador BurguerMania",
                            Password = "Admin@123456"
                        },
                        new
                        {
                            Id = 2,
                            Email = "kaikbomfim@burguermania.com",
                            Name = "Kaik Bomfim",
                            Password = "Kaik@102030"
                        });
                });

            modelBuilder.Entity("burguermania_backend.Models.UserOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("burguermania_backend.Models.Order", b =>
                {
                    b.HasOne("burguermania_backend.Models.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("burguermania_backend.Models.OrderProduct", b =>
                {
                    b.HasOne("burguermania_backend.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("burguermania_backend.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("burguermania_backend.Models.Product", b =>
                {
                    b.HasOne("burguermania_backend.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("burguermania_backend.Models.UserOrder", b =>
                {
                    b.HasOne("burguermania_backend.Models.Order", "Order")
                        .WithMany("UserOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("burguermania_backend.Models.User", "User")
                        .WithMany("UserOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("burguermania_backend.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("burguermania_backend.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("UserOrders");
                });

            modelBuilder.Entity("burguermania_backend.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("burguermania_backend.Models.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("burguermania_backend.Models.User", b =>
                {
                    b.Navigation("UserOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
