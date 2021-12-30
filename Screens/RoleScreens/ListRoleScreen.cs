using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categories");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Role>(Database.connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}