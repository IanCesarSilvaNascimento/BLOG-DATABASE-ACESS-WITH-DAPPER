using Blog.Screens.CategoryScreens;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

namespace Blog{

    public class Program{

        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
            
        static void Main(String[] args){
            
            Database.connection = new SqlConnection(CONNECTION_STRING);

            Database.connection.Open();

                GeneralMenu();

            Console.ReadKey();
            Database.connection.Close();
            
        }

        public static void GeneralMenu(){

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("Selecione as opções abaixo!");
            Console.WriteLine();
            Console.WriteLine("1 - Menu tags");
            Console.WriteLine("2 - Menu Users");
            Console.WriteLine("3 - Menu Categories");
            Console.WriteLine("4 - Menu Roles");
            Console.WriteLine();
            Console.WriteLine();
            string? option = Console.ReadLine();

            switch (Convert.ToUInt16(option))
            {
                case 1: 
                    MenuTagScreen.Load();
                    break;
                // case 2:
                //     MenuUserScreen();
                    // break;
                case 3:
                    MenuCategoryScreen.Load();
                    break;
                // case 4:
                //     MenuRoleScreen();
                //     break;
                default: GeneralMenu(); break;
            }

        }

    
    }
}       