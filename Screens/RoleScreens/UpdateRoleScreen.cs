using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.RoleScreens
{
    public class UpdateRoleScreen
    {
        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("### ATUALIZAÇÃO DE PERFIL ###");
            Console.WriteLine("#############################");
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

            Console.WriteLine("Novo nome do perfil:");
            item.Name = Console.ReadLine();
            Console.WriteLine("Novo slug do perfil:");
            item.Slug = Console.ReadLine();
            try
            {
                repository.Update(item);
                Console.WriteLine("Perfil atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o perfil!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuRoleScreen.Load();
        }
    }
}