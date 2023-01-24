using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.CategoryScreens
{
    public class UpdateCategoryScreen
    {
        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("### ATUALIZAÇÃO DE CATEGORIA ###");
            Console.WriteLine("################################");
            Console.WriteLine("Digite o ID da categoria:");
            int.TryParse(Console.ReadLine(), out var id);
            Category item = new Category();
            var repository = new Repository<Category>(Database.connection);
            try
            {
            item = repository.Get(id);
            }catch(Exception ex){
                Console.WriteLine("Não foi possível encontrar a categoria!");
                Console.WriteLine(ex.Message);
            }
            if (item == null)
            {
                Console.WriteLine("ID inválido ou inexistente!");
                Console.ReadKey();
                MenuCategoryScreen.Load();
            }
            Console.WriteLine($"Categoria selecionada: ID: {item.Id} - Nome: {item.Name} - Slug: {item.Slug}");
            Console.WriteLine("Novo nome da categoria:");
            item.Name = Console.ReadLine();
            Console.WriteLine("Novo slug da categoria:");
            item.Slug = Console.ReadLine();
            try
            {
                repository.Update(item);
                Console.WriteLine("Categoria atualizada com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a categoria!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
    }
}