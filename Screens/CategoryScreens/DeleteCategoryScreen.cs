using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("### EXCLUSÃO DE CATEGORIA ###");
            Console.WriteLine("#############################");
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
            Console.WriteLine("Tem certeza que deseja excluí-la? (s) ou (n)");
            char.TryParse(Console.ReadLine(), out var option);
            if (option == 's' || option == 'S')
            {
                try
                {
                    repository.Delete(item);
                    Console.WriteLine("Categoria excluida com sucesso!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Não foi possível excluir a categoria!");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("A categoria não foi excluída!");
            }
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
    }
}