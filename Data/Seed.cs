using burguermania_backend.Models;
namespace burguermania_backend.Data;

public static class Seed {
    public static List<Category> Categories = new List<Category>{
        new Category
        {
            Id = 1,
            Name = "X-Vegan",
            Description = "Sabor incrível sem abrir mão do veganismo. O hambúrguer perfeito para quem ama comer bem e com consciência!",
            PathImage = "http://localhost:5190/images/burguer.png"
        },
        new Category
        {
            Id = 2,
            Name = "X-Fitness",
            Description = "Leve, saudável e delicioso! O hambúrguer ideal para quem busca equilíbrio e sabor na mesma mordida.",
            PathImage = "http://localhost:5190/images/burguer.png"
        },
        new Category
        {
            Id = 3,
            Name = "X-Infarto",
            Description = "Para os corajosos e amantes de um hambúrguer generoso! Cada mordida é uma explosão de sabor.",
            PathImage = "http://localhost:5190/images/burguer.png"
        }
    };

    public static List<Product> Products = new List<Product>{
        new Product
        {
            Id = 1,
            Name = "X-Alface-Premium",
            BaseDescription = "Pão, hambúrguer vegetal, alface extra, tomate, queijo vegano e maionese vegana.",
            FullDescription = "Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.",
            CategoryId = 1, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 35.0
        },
        new Product
        {
            Id = 2,
            Name = "X-Tomate",
            BaseDescription = "Pão, hambúrguer vegetal, tomate em fatias duplas, queijo vegano e maionese vegana.",
            FullDescription = "Uma explosão de frescor e sabor em cada mordida! O X-Tomate combina um hambúrguer vegetal temperado com ervas aromáticas e alho, servido em pão artesanal macio. É acompanhado por fatias suculentas de tomate maduro em dobro, queijo vegano cremoso e uma camada suave de maionese de ervas. Finalizado com uma leve pitada de sal marinho e pimenta-do-reino, garantindo uma experiência simples e saborosa.",
            CategoryId = 1, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 22.5
        },
        new Product
        {
            Id = 3,
            Name = "X-Frutas",
            BaseDescription = "Pão, hambúrguer vegetal, alface, tomate, abacaxi grelhado e maionese vegana.",
            FullDescription = "Uma combinação surpreendente que mistura sabores doces e salgados! O X-Frutas apresenta um hambúrguer vegetal grelhado e suculento, servido em pão de brioche artesanal. É complementado por abacaxi grelhado caramelizado, alface fresca e tomate maduro, adicionando uma camada extra de sabor. Para finalizar, uma maionese vegana suave e aromática que equilibra perfeitamente os contrastes de sabor.",
            CategoryId = 1, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 28.0
        },
        new Product
        {
            Id = 4,
            Name = "X-Frango-Leve",
            BaseDescription = "Pão integral, hambúrguer de frango, alface, tomate e creme de ricota.",
            FullDescription = "Leve e equilibrado, o X-Frango-Leve é a escolha perfeita para quem busca sabor e saúde. Feito com um hambúrguer de frango grelhado, temperado com ervas frescas, ele é servido em pão integral. É acompanhado de folhas de alface crocantes, tomate suculento e uma camada generosa de creme de ricota, proporcionando uma experiência cremosa e nutritiva.",
            CategoryId = 2, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 24.0
        },
        new Product
        {
            Id = 5,
            Name = "X-Creme-Ricota",
            BaseDescription = "Pão integral, hambúrguer de frango, creme de ricota extra e folhas verdes.",
            FullDescription = "Um hambúrguer refinado e delicioso, o X-Creme-Ricota apresenta um hambúrguer de frango grelhado combinado com creme de ricota extra suave e cremoso. Servido em pão integral macio, ele vem acompanhado de uma seleção de folhas verdes frescas que trazem crocância e frescor. Um toque de azeite extra virgem e pimenta-do-reino completam essa experiência gastronômica leve e sofisticada.",
            CategoryId = 2, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 26.5
        },
        new Product
        {
            Id = 6,
            Name = "X-Light",
            BaseDescription = "Pão integral, hambúrguer de frango grelhado, alface e tomate.",
            FullDescription = "Simplicidade e saúde em um só hambúrguer! O X-Light traz um hambúrguer de frango grelhado com um toque de limão e ervas, servido em pão integral macio. Ele é complementado por alface fresca e tomate maduro, garantindo um sabor leve e equilibrado. Ideal para quem deseja uma refeição prática e saudável.",
            CategoryId = 2, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 20.0
        },
        new Product
        {
            Id = 7,
            Name = "X-Duplo-Bacon",
            BaseDescription = "Pão brioche, hambúrguer duplo, bacon extra, queijo cheddar e maionese especial.",
            FullDescription = "Uma indulgência irresistível para os amantes de bacon! O X-Duplo-Bacon combina dois hambúrgueres grelhados suculentos com fatias generosas de bacon crocante. Servido em pão brioche macio, ele é finalizado com queijo cheddar derretido e uma maionese especial com um toque de alho. Uma experiência rica e intensa que satisfaz qualquer apetite.",
            CategoryId = 3, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 32.0
        },
        new Product
        {
            Id = 8,
            Name = "X-Cheddar-Melt",
            BaseDescription = "Pão brioche, hambúrguer duplo, queijo cheddar derretido e maionese especial.",
            FullDescription = "Cheio de sabor e cremosidade, o X-Cheddar-Melt é feito com dois hambúrgueres grelhados suculentos e cobertos por uma camada generosa de queijo cheddar derretido. Servido em pão brioche dourado, ele é complementado por uma maionese especial suave e rica, criando uma combinação perfeita de sabores em cada mordida.",
            CategoryId = 3, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 30.0
        },
        new Product
        {
            Id = 9,
            Name = "X-Ultra",
            BaseDescription = "Pão brioche, hambúrguer triplo, bacon crocante, queijo cheddar e maionese especial.",
            FullDescription = "O maior e mais ousado dos hambúrgueres! O X-Ultra apresenta três hambúrgueres grelhados e suculentos, acompanhados por bacon crocante e queijo cheddar derretido. Servido em pão brioche macio e dourado, ele é finalizado com uma camada generosa de maionese especial. Cada mordida é uma explosão de sabor, perfeita para os mais famintos.",
            CategoryId = 3, 
            PathImage = "http://localhost:5190/images/burguer.png",
            Price = 35.0
        }
    };

    public static List<Status> Status = new List<Status>
    {
        new Status
        {
            Id = 1,
            Name = "Pendente"
        },
        new Status
        {
            Id = 2,
            Name = "Em Processamento"
        },
        new Status
        {
            Id = 3,
            Name = "Finalizado"
        }
    };

    public static List<User> Users = new List<User>
    {
        new User
        {
            Id = 1,
            Name = "Administrador BurguerMania",
            Email = "admin@burguermania.com",
            Password = "Admin@123456" 
        },
        new User
        {
            Id = 2,
            Name = "Kaik Bomfim",
            Email = "kaikbomfim@burguermania.com",
            Password = "Kaik@102030" 
        }
    };
}