using System.Text;
using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.PostScreens
{
    public class GetAllPostsScreen
    {
       public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("### LISTA DE TODOS OS POSTS ###");
            Console.WriteLine("###############################");
                var repository = new PostRepository(Database.connection);
            try
            {
                var items = repository.GetWithTagsAndCategories();
                var stringTags = new StringBuilder();
                var listTags = new List<string>();
                foreach (var item in items)
                {
                stringTags.Clear();
                listTags = item.Tags.Select(tag => tag.Name).ToList();
                if(!listTags.Any()) listTags.Add("Nenhuma");
                stringTags.AppendJoin(',', listTags);
                Console.WriteLine($"ID: {item.Id} - ID do Autor: {item.AuthorId} - Categoria: {item.Category.Name} - Título: {item.Title} - Tags: {stringTags} - Sumário: {item.Summary} - Slug: {item.Slug} - Data de criação: {item.CreateDate.ToString("dd/MM/yyyy")}");}
            }catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os posts!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuPostScreen.Load();
        }
    }
}