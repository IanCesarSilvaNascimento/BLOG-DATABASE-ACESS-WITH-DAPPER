using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Users");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(Database.connection);
            var items = repository.Get();
            foreach (var item in items)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        }
    }
}