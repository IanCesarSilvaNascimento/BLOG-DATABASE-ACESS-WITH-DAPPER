
namespace Blog.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de category");
            Console.WriteLine("--------------");
            Console.WriteLine("Selecione as opções abaixo!");
            Console.WriteLine();
            Console.WriteLine("1 - Listar categories");
            Console.WriteLine("2 - Cadastrar categories");
            Console.WriteLine("3 - Atualizar category");
            Console.WriteLine("4 - Excluir category");
            Console.WriteLine();
            Console.WriteLine();
            string? option = Console.ReadLine();

            switch (Convert.ToUInt16(option))
            {
                case 1:
                    ListCategoryScreen.Load();
                    break;
                case 2:
                    CreateCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }


}