using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.RoleScreens
{
    public class CreateRoleScreen
    {
        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("### CADASTRO DE PERFIL ###");
            Console.WriteLine("##########################");
            Console.WriteLine("Nome do perfil:");
            var name = Console.ReadLine();
            Console.WriteLine("Slug do perfil:");
            var slug = Console.ReadLine();
            var repository = new Repository<Role>(Database.connection);
            try
            {
                repository.Create(new Role
                {
                    Name = name,
                    Slug = slug
                });
                Console.WriteLine("Perfil cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar o perfil!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuRoleScreen.Load();
        }
    }
}