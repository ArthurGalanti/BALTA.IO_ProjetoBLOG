using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.RoleScreens
{
    public class GetAllRolesScreen
    {
        public static void GetAll()
        {
            Console.Clear();
            Console.WriteLine("### LISTA DE TODOS OS PERFIS ###");
            Console.WriteLine("################################");
            try
            {
                var repository = new Repository<Role>(Database.connection);
                var items = repository.Get();
                foreach (var item in items)
                    Console.WriteLine($"ID: {item.Id} - Nome: {item.Name} - Slug: {item.Slug}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os perfis!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuRoleScreen.Load();
        }
    }
}