using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.TagScreens
{
    public class GetAllTagsScreen
    {
        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("### LISTA DE TODAS AS TAGS ###");
            Console.WriteLine("##############################");
            try
            {
                var repository = new TagRepository(Database.connection);
                var items = repository.GetTagsWithPosts();
                foreach (var item in items)
                    Console.WriteLine($"ID: {item.Id} - Nome: {item.Name} - Slug: {item.Slug} - Posts relacionados: {item.PostsQuantity}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar as tags!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuTagScreen.Load();
        }
    }
}