using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.TagScreens
{
    public class DeleteTagScreen
    {
        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("### EXCLUSÃO DE TAG ###");
            Console.WriteLine("#######################");
            Console.WriteLine("Digite o ID da tag:");
            int.TryParse(Console.ReadLine(), out var id);
            Tag item = new Tag();
            var repository = new Repository<Tag>(Database.connection);
            try
            {
            item = repository.Get(id);
            }catch(Exception ex){
                Console.WriteLine("Não foi possível encontrar a tag!");
                Console.WriteLine(ex.Message);
            }

            if (item == null)
            {
                Console.WriteLine("ID inválido ou inexistente!");
                Console.ReadKey();
                MenuTagScreen.Load();
            }
            Console.WriteLine($"Tag selecionada: ID: {item.Id} - Nome: {item.Name} - Slug: {item.Slug}");
            Console.WriteLine("Tem certeza que deseja excluí-la? (s) ou (n)");
            char.TryParse(Console.ReadLine(), out var option);
            if (option == 's' || option == 'S')
            {
                try
                {
                    repository.Delete(item);
                    Console.WriteLine("Tag excluida com sucesso!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Não foi possível excluir a tag!");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("A tag não foi excluída!");
            }
            Console.ReadKey();
            MenuTagScreen.Load();
        }
    }
}