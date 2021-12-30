using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;

namespace Blog.Screens.RoleScreens
{
    public class DeleteRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma role");
            Console.WriteLine("-------------");
            Console.Write("Qual o id da role que deseja exluir? ");
            string? id = Console.ReadLine();

            Delete(Convert.ToUInt16(id));
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.connection);
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