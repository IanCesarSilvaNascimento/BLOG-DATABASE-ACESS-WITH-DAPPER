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