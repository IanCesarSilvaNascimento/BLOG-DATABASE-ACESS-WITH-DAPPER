using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;

namespace Blog.Screens.UserScreens
{
    public class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um user");
            Console.WriteLine("-------------");
            Console.Write("Qual o id do user que deseja exluir? ");
            string? id = Console.ReadLine();

            Delete(Convert.ToUInt16(id));
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.connection);
                repository.Delete(id);
                Console.WriteLine("User exluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir o user");
                Console.WriteLine(ex.Message);
            }
        }
    }
}