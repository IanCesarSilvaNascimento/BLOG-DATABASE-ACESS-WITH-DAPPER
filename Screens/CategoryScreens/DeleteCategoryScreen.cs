using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma category");
            Console.WriteLine("-------------");
            Console.Write("Qual o id da category que deseja exluir? ");
            string? id = Console.ReadLine();

            Delete(Convert.ToUInt16(id));
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.connection);
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