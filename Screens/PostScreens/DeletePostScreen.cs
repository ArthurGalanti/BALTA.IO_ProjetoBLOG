using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.PostScreens
{
    public class DeletePostScreen
    {
        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("### EXCLUSÃO DE POST ###");
            Console.WriteLine("########################");
            Console.WriteLine("Digite o ID do post:");
            int.TryParse(Console.ReadLine(), out var id);
            Post item = new Post();
            var repository = new Repository<Post>(Database.connection);
            try
            {
            item = repository.Get(id);
            }catch(Exception ex){
                Console.WriteLine("Não foi possível encontrar o post!");
                Console.WriteLine(ex.Message);
            }
            if (item == null)
            {
                Console.WriteLine("ID inválido ou inexistente!");
                Console.ReadKey();
                MenuPostScreen.Load();
            }
            Console.WriteLine($"Post selecionado: ID: {item.Id} - Título: {item.Title} - Sumário: {item.Summary} - Slug: {item.Slug} - Data de criação: {item.CreateDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"ID do Autor: {item.AuthorId} - ID da Categoria: {item.CategoryId}");
            Console.WriteLine($"Conteúdo do post: \n {item.Body}");
            Console.WriteLine("Tem certeza que deseja excluí-lo? (s) ou (n)");
            char.TryParse(Console.ReadLine(), out var option);
            if (option == 's' || option == 'S')
            {
                try
                {
                    repository.Delete(item);
                    Console.WriteLine("Post excluido com sucesso!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Não foi possível excluir o post!");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("O post não foi excluído!");
            }
            Console.ReadKey();
            MenuPostScreen.Load();
        }
    }
}