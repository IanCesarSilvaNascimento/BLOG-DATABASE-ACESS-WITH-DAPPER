using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Role");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
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
            Create(new User
            {
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

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Create(user);
                Console.WriteLine("User cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar user");
                Console.WriteLine(ex.Message);
            }
        }
    }
}