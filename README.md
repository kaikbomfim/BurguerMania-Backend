<div align="center">
    <a href="https://github.com/kaikbomfim/BurguerMania" target="_blank">
        <img src="./public/assets/burguermania.png" 
        alt="Logo" width="800" height="500">
    </a>
</div>

<div align="center">
  <img src="https://readme-typing-svg.demolab.com?font=Fira+Code&size=50&duration=3000&pause=200&color=F7B062FF&center=true&vCenter=true&multiline=true&random=false&width=435&height=100&lines=BurguerMania"> 
</div>

<h2 align="center">API para fornecer o sabor irresistível da perfeição, com dados dos nossos hambúrgueres artesanais que conquistam corações e paladares.</h2>

## **Visão Geral**

**BurguerMania API** é o backend desenvolvido para fornecer informações detalhadas sobre o cardápio de hambúrgueres artesanais da hamburgueria BurguerMania. Esta API foi construída usando **.NET 8** e utiliza **PostgreSQL** como banco de dados para armazenamento das informações.

O backend é responsável por fornecer as informações ao frontend desenvolvido em Angular, disponível no repositório [BurguerMania Frontend](https://github.com/kaikbomfim/BurguerMania).

## **Pré-requisitos**

- **PostgreSQL:** Certifique-se de que o banco de dados PostgreSQL está instalado e rodando.
- **.NET SDK 8.0:** Necessário para rodar o backend e compilar a aplicação.

## **Instruções de Uso**

Para rodar o **BurguerMania API** localmente, siga os passos abaixo:

### 1. Clone este Repositório

    ```bash
    git clone https://github.com/kaikbomfim/BurguerMania-backend.git
    ```

### 2. Acesse o diretório do projeto:

```bash
cd ./BurguerMania-backend
```

### 3. Configure variáveis de ambiente:

Crie um arquivo .env na raiz do projeto com base no arquivo .env.example:

    ```bash
    # Host do banco de dados, geralmente "localhost" em ambiente de desenvolvimento
    DB_HOST=

    # Nome do banco de dados utilizado pela aplicação
    DB_NAME=

    # Nome de usuário do banco de dados
    DB_USERNAME=

    # Senha do banco de dados
    DB_PASSWORD=
    ```

### 4. Instale as dependências do projeto:

```bash
dotnet restore
```

### 5. Atualize o banco de dados:

```bash
dotnet ef database update
```

### 6. Inicie o servidor local:

```bash
dotnet run
```

### 7. Acesse a API

Após iniciar o servidor, a API estará disponível em: http://localhost:5190.

Você pode acessar o Swagger para testar os endpoints da API usando: http://localhost:5190/swagger.

## Comandos Úteis

- **Restaurar dependências:**
  ```bash
   dotnet restore
  ```
- **Atualizar banco de dados:**
  ```bash
  dotnet ef database update
  ```
- **Rodar a aplicação:**
  ```bash
  dotnet run
  ```

## Tecnologias Utilizadas

- **Back-end:** .NET 8 (ASP.NET Core).
- **Banco de Dados:** PostgreSQL.
- **ORM:** Entity Framework Core.
- **Documentação:** Swagger/OpenAPI.
- **Controle de versão:** Git e GitHub.

## Possíveis Melhorias

**Melhorias Técnicas**

- Conteinerizar a aplicação usando Docker para facilitar o deploy e a execução em diferentes ambientes de maneira padronizada.
- Adicionar autenticação e autorização para proteger os endpoints da API.
