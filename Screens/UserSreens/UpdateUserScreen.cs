using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um User");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            string? id = Console.ReadLine();

            Console.Write("Name: ");
            var name = Console.ReadLine();

           
            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("PasswordHash: ");
            var passwordhash = Console.ReadLine();

            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            Console.Write("Image: ");
            var image = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new User
            {
                Id = Convert.ToUInt16(id),
                Name = name,
                Email = email,
                PasswordHash = passwordhash,
                Bio = bio,
                Image = image,
                Slug = slug
            });
            Console.ReadKey();

            MenuUserScreen.Load();
        }

        public static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Update(user);
                Console.WriteLine("User atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o User");
                Console.WriteLine(ex.Message);
            }
        }
    }
}