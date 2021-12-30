using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma tag");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            string? id = Console.ReadLine();

            Console.Write("Nome: ");
            string? name = Console.ReadLine();

            Console.Write("Slug: ");
            string? slug = Console.ReadLine();

            Update(new Tag
            {
                Id = Convert.ToUInt16(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}