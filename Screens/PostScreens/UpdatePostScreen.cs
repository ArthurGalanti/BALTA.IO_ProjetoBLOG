using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.PostScreens
{
    public class UpdatePostScreen
    {
        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("### ATUALIZAÇÃO DE POST ###");
            Console.WriteLine("###########################");
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
            Console.WriteLine($"Conteúdo do post: \n {item.Body} \n");
            Console.WriteLine("Novo título do post:");
            item.Title = Console.ReadLine();
            Console.WriteLine("Nova categoria do post (ID):");
            int.TryParse(Console.ReadLine(), out var category);
            item.CategoryId = category;
            Console.WriteLine("Novo conteúdo do post:");
            item.Body = Console.ReadLine();
            Console.WriteLine("Novo sumário do post:");
            item.Summary = Console.ReadLine();
            Console.WriteLine("Novo slug do post:");
            item.Slug = Console.ReadLine();
            item.LastUpdateDate = DateTime.Now;
            if(item.AuthorId != 0 && item.CategoryId != 0)
            {
                try
            {
                repository.Update(item);
                Console.WriteLine("Post atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o post!");
                Console.WriteLine(ex.Message);
            }
            }
            else
                Console.WriteLine("Não foi possível atualizar o post! Autor ou categoria inválidos!");
            Console.ReadKey();
            MenuPostScreen.Load();
        }
    }
}