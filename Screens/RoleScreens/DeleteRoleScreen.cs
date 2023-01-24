using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.RoleScreens
{
    public class DeleteRoleScreen
    {
        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("### EXCLUSÃO DE PERFIL ###");
            Console.WriteLine("##########################");
            Console.WriteLine("Digite o ID do perfil:");
            int.TryParse(Console.ReadLine(), out var id);
            Role item = new Role();
            var repository = new Repository<Role>(Database.connection);
            try
            {
            item = repository.Get(id);
            }catch(Exception ex){
                Console.WriteLine("Não foi possível encontrar o perfil!");
                Console.WriteLine(ex.Message);
            }
            if (item == null)
            {
                Console.WriteLine("ID inválido ou inexistente!");
                Console.ReadKey();
                MenuRoleScreen.Load();
            }
            Console.WriteLine($"Perfil selecionado: ID: {item.Id} - Nome: {item.Name} - Slug: {item.Slug}");
            Console.WriteLine("Tem certeza que deseja excluí-lo? (s) ou (n)");
            char.TryParse(Console.ReadLine(), out var option);
            if (option == 's' || option == 'S')
            {
                try
                {
                    repository.Delete(item);
                    Console.WriteLine("Perfil excluido com sucesso!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Não foi possível excluir o perfil!");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("O perfil não foi excluído!");
            }
            Console.ReadKey();
            MenuRoleScreen.Load();
        }
    }
}