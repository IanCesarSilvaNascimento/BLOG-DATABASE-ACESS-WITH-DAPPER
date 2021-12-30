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