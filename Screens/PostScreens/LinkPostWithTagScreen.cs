using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.PostScreens
{
    public class LinkPostWithTagScreen
    {
     public static void LinkWithTag()
        {
            Console.Clear();
            Console.WriteLine("### VINCULAR POST COM TAG ###");
            Console.WriteLine("#############################");
            Console.WriteLine("ID do post:");
            int.TryParse(Console.ReadLine(), out var post);
            Console.WriteLine("ID da tag:");
            int.TryParse(Console.ReadLine(), out var tag);
            var repository = new PostRepository(Database.connection);
            if (post != 0 && tag != 0)
            {
            try
            {
                repository.LinkWithTag(post, tag);
                Console.WriteLine("Vinculo feito com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular!");
                Console.WriteLine(ex.Message);
            }
            }else
                Console.WriteLine("Não foi possível vincular!");

            Console.ReadKey();
            MenuPostScreen.Load();
        }   
    }
}