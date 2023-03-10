namespace BALTA.IO_ProjetoBLOG.Screens.PostScreens
{
    public class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("### GESTÃO DE POSTS ###");
            Console.WriteLine("#######################");
            Console.WriteLine("1. Listar todos os posts");
            Console.WriteLine("2. Cadastrar um post");
            Console.WriteLine("3. Atualizar um post");
            Console.WriteLine("4. Deletar um post");
            Console.WriteLine("5. Vincular um post com uma tag");
            Console.WriteLine("0. Voltar para o menu inicial");
            int? option = CaptureOption();

            switch (option)
            {
                case 1:
                    GetAllPostsScreen.GetAll();
                    break;
                case 2:
                    CreatePostScreen.Create();
                    break;
                case 3:
                    UpdatePostScreen.Update();
                    break;
                case 4:
                    DeletePostScreen.Delete();
                    break;
                case 5:
                    LinkPostWithTagScreen.LinkWithTag();
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