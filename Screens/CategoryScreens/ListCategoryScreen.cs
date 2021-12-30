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