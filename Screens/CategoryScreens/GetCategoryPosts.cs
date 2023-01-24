using System.Text;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.CategoryScreens
{
    public class GetCategoryPosts
    {
        public static void GetPosts()
        {
            Console.Clear();
            Console.WriteLine("### LISTAR POSTS DE UMA CATEGORIA ###");
            Console.WriteLine("#####################################");
            Console.WriteLine("ID da categoria:");
            int.TryParse(Console.ReadLine(), out var category);
            var repository = new PostRepository(Database.connection);
            if (category != 0)
            {
                try
                {
                    var items = repository.GetPostsByCategory(category);
                    if (items.Count() != 0)
                    {
                        var stringTags = new StringBuilder();
                        var listTags = new List<string>();
                        Console.WriteLine($"LISTA DE POSTS DA CATEGORIA: {items.FirstOrDefault().Category.Name}");
                        foreach (var item in items)
                            {
                            stringTags.Clear();
                            listTags = item.Tags.Select(tag => tag.Name).ToList();
                            stringTags.AppendJoin(',', listTags);
                            Console.WriteLine($"ID: {item.Id} - ID do Autor: {item.AuthorId} - Título: {item.Title} - Tags: {stringTags} - Sumário: {item.Summary} - Slug: {item.Slug} - Data de criação: {item.CreateDate.ToString("dd/MM/yyyy")}");
                            }
                    }else
                        Console.WriteLine("Categoria vazia ou não existente!");
                }catch (Exception ex)
                {
                    Console.WriteLine("Não foi possível listar os posts dessa categoria!");
                    Console.WriteLine(ex.Message);
                }
            }else
                Console.WriteLine("Não foi possível listar os posts dessa categoria!");
           
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }
    }
}