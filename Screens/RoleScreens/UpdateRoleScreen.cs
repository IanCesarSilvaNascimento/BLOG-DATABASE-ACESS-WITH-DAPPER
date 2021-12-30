using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public class UpdateRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma role");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            string? id = Console.ReadLine();

            Console.Write("Nome: ");
            string? name = Console.ReadLine();

            Console.Write("Slug: ");
            string? slug = Console.ReadLine();

            Update(new Role
            {
                Id = Convert.ToUInt16(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();

            MenuRoleScreen.Load();
        }

        public static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.connection);
                repository.Update(role);
                Console.WriteLine("Role atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a role");
                Console.WriteLine(ex.Message);
            }
        }
    }
}