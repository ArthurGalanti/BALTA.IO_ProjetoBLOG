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
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                Load();
                break;
        }
    }
}