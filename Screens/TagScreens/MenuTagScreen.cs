namespace BALTA.IO_ProjetoBLOG.Screens.TagScreens
{
    public class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("### GESTÃO DE TAGS ###");
            Console.WriteLine("######################");
            Console.WriteLine("1. Listar todas as tags");
            Console.WriteLine("2. Cadastrar uma tag");
            Console.WriteLine("3. Atualizar uma tag");
            Console.WriteLine("4. Deletar uma tag");
            Console.WriteLine("0. Voltar para o menu inicial");
            int? option = CaptureOption();

            switch (option)
            {
                case 1:
                    GetAllTagsScreen.GetAll();
                    break;
                case 2:
                    CreateTagScreen.Create();
                    break;
                case 3:
                    UpdateTagScreen.Update();
                    break;
                case 4:
                    DeleteTagScreen.Delete();
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