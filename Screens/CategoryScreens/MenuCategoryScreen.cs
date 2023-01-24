namespace BALTA.IO_ProjetoBLOG.Screens.CategoryScreens
{
    public class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("### GESTÃO DE CATEGORIAS ###");
            Console.WriteLine("############################");
            Console.WriteLine("1. Listar todas as categorias");
            Console.WriteLine("2. Cadastrar uma categoria");
            Console.WriteLine("3. Atualizar uma categoria");
            Console.WriteLine("4. Deletar uma categoria");
            Console.WriteLine("5. Listar os posts de uma categoria");
            Console.WriteLine("0. Voltar para o menu inicial");
            int? option = CaptureOption();

            switch (option)
            {
                case 1:
                    GetAllCategoriesScreen.GetAll();
                    break;
                case 2:
                    CreateCategoryScreen.Create();
                    break;
                case 3:
                    UpdateCategoryScreen.Update();
                    break;
                case 4:
                    DeleteCategoryScreen.Delete();
                    break;
                case 5:
                    GetCategoryPosts.GetPosts();
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