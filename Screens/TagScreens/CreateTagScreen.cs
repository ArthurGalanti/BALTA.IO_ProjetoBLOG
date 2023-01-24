using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.TagScreens
{
    public class CreateTagScreen
    {
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("### CADASTRO DE TAG ###");
            Console.WriteLine("#######################");
            Console.WriteLine("Nome da tag:");
            var name = Console.ReadLine();
            Console.WriteLine("Slug da tag:");
            var slug = Console.ReadLine();
            var repository = new Repository<Tag>(Database.connection);
            try
            {
                repository.Create(new Tag
                {
                    Name = name,
                    Slug = slug
                });
                Console.WriteLine("Tag cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar a tag!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuTagScreen.Load();
        }
    }
}