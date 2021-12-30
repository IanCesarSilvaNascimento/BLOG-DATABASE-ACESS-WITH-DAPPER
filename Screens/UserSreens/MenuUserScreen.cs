
namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de User");
            Console.WriteLine("--------------");
            Console.WriteLine("Selecione as opções abaixo!");
            Console.WriteLine();
            Console.WriteLine("1 - Listar User");
            Console.WriteLine("2 - Cadastrar User");
            Console.WriteLine("3 - Atualizar User");
            Console.WriteLine("4 - Excluir User");
            Console.WriteLine();
            Console.WriteLine();
            string? option = Console.ReadLine();

            switch (Convert.ToUInt16(option))
            {
                case 1:
                    ListUserScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }


}