using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.CategoryScreens
{
    public class CreateCategoryScreen
    {
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("### CADASTRO DE CATEGORIA ###");
            Console.WriteLine("#############################");
            Console.WriteLine("Nome da categoria:");
            var name = Console.ReadLine();
            Console.WriteLine("Slug da categoria:");
            var slug = Console.ReadLine();
            var repository = new Repository<Category>(Database.connection);
            try
            {
                repository.Create(new Category
                {
                    Name = name,
                    Slug = slug
                });
                Console.WriteLine("Categoria cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar a categoria!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
    }
}