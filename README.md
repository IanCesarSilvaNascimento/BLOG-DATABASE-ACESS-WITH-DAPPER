
## Models
 Possui modelos de tabelas para serem manipuladas em código.

### Category.cs
  Classe usada como modelo da tabela category do banco de dados Blog.Ademais, têm-se: User.cs; Role.cs; Tag.cs com mesmo intuito.
  
```Code
  using Dapper.Contrib.Extensions;

  namespace Blog.Models{

    [Table("[Category]")]
    public class Category{

        public int Id { get; set; }
        
        public string? Name { get; set; }           

        public string? Slug { get; set; }

    }

}
```

## Repository
  Possui modelos de requisições(Listar, criar, deletar e atualizar) que podem ser feitas para o banco de dados Blog.
  
### Repository.cs
  Classe do tipo generica usada para invocar as requisições desejadas.

```Code
    using Dapper.Contrib.Extensions;
    using Microsoft.Data.SqlClient;

    namespace Blog.Repositories{

      public class Repository<T> where T : class{
          private SqlConnection? connection;

          public Repository(SqlConnection? connection)
                => this.connection = connection;


          public IEnumerable<T> Get()
              => Database.connection.GetAll<T>();


          public void Create(T model)
             => Database.connection.Insert<T>(model);

          public void Update(T model)            
              => Database.connection.Update<T>(model);



           public void Delete(int id){                
              var model = Database.connection.Get<T>(id);
              Database.connection.Delete<T>(model);
          }

      }
  }
```

### DataBase.cs
  Classe para compartilhar a string de conexão com o banco.

```Code
  using Microsoft.Data.SqlClient;

  namespace Blog{

    public class Database{

        public static SqlConnection? connection;

    }
  }
```
## Screen
  Contexto de telas(CategoryScreens,UserScreens,RoleScreens,TagScreens) com intuito de organizar as classes de interação do usuário com o banco.
  
### CategoryScreens
  Contexto de classe category que permite selecionar a requisição deseja, obter os parametros, invocar o reposotorio com os modelos para interagir com o banco.
  
#### MenuCategoryScreen.cs  
```Code

  namespace Blog.Screens.CategoryScreens
  {
      public class MenuCategoryScreen
      {
          public static void Load()
          {
              Console.Clear();
              Console.WriteLine("Gestão de category");
              Console.WriteLine("--------------");
              Console.WriteLine("Selecione as opções abaixo!");
              Console.WriteLine();
              Console.WriteLine("1 - Listar categories");
              Console.WriteLine("2 - Cadastrar categories");
              Console.WriteLine("3 - Atualizar category");
              Console.WriteLine("4 - Excluir category");
              Console.WriteLine();
              Console.WriteLine();
              string? option = Console.ReadLine();

              switch (Convert.ToUInt16(option))
              {
                  case 1:
                      ListCategoryScreen.Load();
                      break;
                  case 2:
                      CreateCategoryScreen.Load();
                      break;
                  case 3:
                      UpdateCategoryScreen.Load();
                      break;
                  case 4:
                      DeleteCategoryScreen.Load();
                      break;
                  default: Load(); break;
              }
          }
      }


  }
```

#### CreateCategoryScreen.cs
```Code
  using Blog.Models;
  using Blog.Repositories;

  namespace Blog.Screens.CategoryScreens
  {
      public class CreateCategoryScreen
      {
          public static void Load()
          {
              Console.Clear();
              Console.WriteLine("Nova Category");
              Console.WriteLine("-------------");
              Console.Write("Nome: ");
              var name = Console.ReadLine();

              Console.Write("Slug: ");
              var slug = Console.ReadLine();

              Create(new Category
              {
                  Name = name,
                  Slug = slug
              });
              Console.ReadKey();
              MenuCategoryScreen.Load();
          }

          public static void Create(Category category)
          {
              try
              {
                  var repository = new Repository<Category>(Database.connection);
                  repository.Create(category);
                  Console.WriteLine("Category cadastrada com sucesso!");
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Não foi possível salvar a Category");
                  Console.WriteLine(ex.Message);
              }
          }
      }
  }
```
#### ListCategoryScreen.cs
```Code
  using Blog.Models;
  using Blog.Repositories;

  namespace Blog.Screens.CategoryScreens
  {
      public static class ListCategoryScreen
      {
          public static void Load()
          {
              Console.Clear();
              Console.WriteLine("Lista de categories");
              Console.WriteLine("-------------");
              List();
              Console.ReadKey();
              MenuCategoryScreen.Load();
          }

          private static void List()
          {
              var repository = new Repository<Category>(Database.connection);
              var items = repository.Get();
              foreach (var item in items)
                  Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
          }
      }
  }
```

#### UpdateCategoryScreen.cs
 ```Code
  using Blog.Models;
  using Blog.Repositories;

  namespace Blog.Screens.CategoryScreens
  {
      public class UpdateCategoryScreen
      {
          public static void Load()
          {
              Console.Clear();
              Console.WriteLine("Atualizando uma category");
              Console.WriteLine("-------------");
              Console.Write("Id: ");
              string? id = Console.ReadLine();

              Console.Write("Nome: ");
              string? name = Console.ReadLine();

              Console.Write("Slug: ");
              string? slug = Console.ReadLine();

              Update(new Category
              {
                  Id = Convert.ToUInt16(id),
                  Name = name,
                  Slug = slug
              });
              Console.ReadKey();
              MenuCategoryScreen.Load();
          }

          public static void Update(Category category)
          {
              try
              {
                  var repository = new Repository<Category>(Database.connection);
                  repository.Update(category);
                  Console.WriteLine("Category atualizada com sucesso!");
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Não foi possível atualizar a category");
                  Console.WriteLine(ex.Message);
              }
          }
      }
  }
```
#### DeleteCategoryScreen.cs
```Code
  using Blog.Models;
  using Blog.Repositories;

  namespace Blog.Screens.CategoryScreens
  {
      public class DeleteCategoryScreen
      {
          public static void Load()
          {
              Console.Clear();
              Console.WriteLine("Excluir uma category");
              Console.WriteLine("-------------");
              Console.Write("Qual o id da category que deseja exluir? ");
              string? id = Console.ReadLine();

              Delete(Convert.ToUInt16(id));
              Console.ReadKey();
              MenuCategoryScreen.Load();
          }

          public static void Delete(int id)
          {
              try
              {
                  var repository = new Repository<Category>(Database.connection);
                  repository.Delete(id);
                  Console.WriteLine("Category exluída com sucesso!");
              }
              catch (Exception ex)
              {
                  Console.WriteLine("Não foi possível exluir a category");
                  Console.WriteLine(ex.Message);
              }
          }
      }
  }
```
### Program.cs
  Classe principal que inicializa o algoritmo, a conexão com o banco e a primeira tela de interação com o usuário.

```Code
  using Blog.Screens.CategoryScreens;
  using Blog.Screens.TagScreens;
  using Microsoft.Data.SqlClient;

  namespace Blog{

      public class Program{

          private const string CONNECTION_STRING = @"Server=localhost,1433;Database=blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

          static void Main(String[] args){

              Database.connection = new SqlConnection(CONNECTION_STRING);

              Database.connection.Open();

                  GeneralMenu();

              Console.ReadKey();
              Database.connection.Close();

          }

          public static void GeneralMenu(){

              Console.Clear();
              Console.WriteLine();
              Console.WriteLine("--------------");
              Console.WriteLine("Selecione as opções abaixo!");
              Console.WriteLine();
              Console.WriteLine("1 - Menu tags");
              Console.WriteLine("2 - Menu Users");
              Console.WriteLine("3 - Menu Categories");
              Console.WriteLine("4 - Menu Roles");
              Console.WriteLine();
              Console.WriteLine();
              string? option = Console.ReadLine();

              switch (Convert.ToUInt16(option))
              {
                  case 1: 
                      MenuTagScreen.Load();
                      break;
                  case 2:
                      MenuUserScreen();
                      break;
                  case 3:
                      MenuCategoryScreen.Load();
                      break;
                  case 4:
                      MenuRoleScreen();
                      break;
                  default: GeneralMenu(); break;
              }

          }


      }
  }       
```


# Utilização 
 Adicione o pacote Dapper no algoritmo através do comando abaixo: 
```Code
dotnet add package Dapper
```

 Para executar , digite o comando abaixo no terminal: (Lembre-se que você deve criar o banco de dados com as tabelas e colunas semelhantes ao contexto de modelos)
```Code
dotnet run
```

