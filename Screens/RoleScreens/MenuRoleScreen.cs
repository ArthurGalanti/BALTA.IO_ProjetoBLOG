namespace BALTA.IO_ProjetoBLOG.Screens.RoleScreens
{
    public class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("### GESTÃO DE PERFIS ###");
            Console.WriteLine("########################");
            Console.WriteLine("1. Listar todos os Perfis");
            Console.WriteLine("2. Cadastrar um perfil");
            Console.WriteLine("3. Atualizar um perfil");
            Console.WriteLine("4. Deletar um perfil");
            Console.WriteLine("0. Voltar para o menu inicial");
            int? option = CaptureOption();

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
                case 0:
                    Program.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }

        public static int? CaptureOption()
        {
            int input;                       
            return int.TryParse(Console.ReadLine(), out input) ? (int?)input : null;
        }
        
    }
}