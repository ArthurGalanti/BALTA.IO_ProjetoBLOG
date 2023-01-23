using BALTA.IO_ProjetoBLOG.Screens.CategoryScreens;
using BALTA.IO_ProjetoBLOG.Screens.PostScreens;
using BALTA.IO_ProjetoBLOG.Screens.RoleScreens;
using BALTA.IO_ProjetoBLOG.Screens.TagScreens;
using BALTA.IO_ProjetoBLOG.Screens.UserScreens;

internal class Program
{
    private static void Main(string[] args)
    {
        Load();
    }

    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("### GERENCIADOR DO BLOG ###");
        Console.WriteLine("###########################");
        Console.WriteLine("1. Gerenciador de Usuários");
        Console.WriteLine("2. Gerenciador de Perfis");
        Console.WriteLine("3. Gerenciador de Posts");
        Console.WriteLine("4. Gerenciador de Categorias");
        Console.WriteLine("5. Gerenciador de Tags");
        int option;
        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                MenuUserScreen.Load();
                break;
            case 2:
                MenuRoleScreen.Load();
                break;
            case 3:
                MenuPostScreen.Load();
                break;
            case 4:
                MenuCategoryScreen.Load();
                break;
            case 5:
                MenuTagScreen.Load();
                break;
            default:
                Load();
                break;
        }
    }
}