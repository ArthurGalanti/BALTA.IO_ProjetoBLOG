using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("### CADASTRO DE POST ###");
            Console.WriteLine("########################");
            Console.WriteLine("Categoria do post (ID):");
            int.TryParse(Console.ReadLine(), out var category);
            Console.WriteLine("Autor do post (ID):");
            int.TryParse(Console.ReadLine(), out var author);
            Console.WriteLine("Título do post:");
            var title = Console.ReadLine();
            Console.WriteLine("Conteúdo do post:");
            var body = Console.ReadLine();
            Console.WriteLine("Sumário do post:");
            var summary = Console.ReadLine();
            Console.WriteLine("Slug do post:");
            var slug = Console.ReadLine();
            
            var repository = new Repository<Post>(Database.connection);
            if(author != 0 && category != 0)
            {
            try
            {
                repository.Create(new Post
                {
                    Title = title,
                    AuthorId = author,
                    CategoryId = category,
                    Summary = summary,
                    Body = body,
                    Slug = slug,
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                });
                Console.WriteLine("Post cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar o post!");
                Console.WriteLine(ex.Message);
            }
            }else
                Console.WriteLine("Não foi possível cadastrar o post! Autor ou categoria inválidos!");

            Console.ReadKey();
            MenuPostScreen.Load();
        }
    }
}