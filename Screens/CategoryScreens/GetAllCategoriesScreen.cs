using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.CategoryScreens
{
    public class GetAllCategoriesScreen
    {
        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("### LISTA DE TODAS AS CATEGORIAS ###");
            Console.WriteLine("####################################");
            try
            {
                var repository = new CategoryRepository(Database.connection);
                var items = repository.GetCategoriesWithPosts();
                foreach (var item in items)
                    Console.WriteLine($"ID: {item.Id} - Nome: {item.Name} - Slug: {item.Slug} - Posts relacionados: {item.PostsQuantity}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar as categorias!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
    }
}