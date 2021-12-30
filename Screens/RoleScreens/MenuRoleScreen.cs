namespace Blog.Screens.RoleScreens
{
    public class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de role");
            Console.WriteLine("--------------");
            Console.WriteLine("Selecione as opções abaixo!");
            Console.WriteLine();
            Console.WriteLine("1 - Listar roles");
            Console.WriteLine("2 - Cadastrar roles");
            Console.WriteLine("3 - Atualizar role");
            Console.WriteLine("4 - Excluir role");
            Console.WriteLine();
            Console.WriteLine();
            string? option = Console.ReadLine();

            switch (Convert.ToUInt16(option))
            {
                case 1:
                    ListRoleScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }


}