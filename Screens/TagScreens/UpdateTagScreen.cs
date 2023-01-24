using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.TagScreens
{
    public class UpdateTagScreen
    {
        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("### ATUALIZAÇÃO DE TAG ###");
            Console.WriteLine("##########################");
            Console.WriteLine("Digite o ID da tag:");
            int.TryParse(Console.ReadLine(), out var id);
            Tag item = new Tag();
            var repository = new Repository<Tag>(Database.connection);
            try
            {
            item = repository.Get(id);
            }catch(Exception ex){
                Console.WriteLine("Não foi possível encontrar a tag");
                Console.WriteLine(ex.Message);
            }
            if (item == null)
            {
                Console.WriteLine("ID inválido ou inexistente!");
                Console.ReadKey();
                MenuTagScreen.Load();
            }
            Console.WriteLine($"Tag selecionada: ID: {item.Id} - Nome: {item.Name} - Slug: {item.Slug}");

            Console.WriteLine("Novo nome da tag:");
            item.Name = Console.ReadLine();
            Console.WriteLine("Novo slug da tag:");
            item.Slug = Console.ReadLine();
            try
            {
                repository.Update(item);
                Console.WriteLine("Tag atualizada com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuTagScreen.Load();
        }
    }
}