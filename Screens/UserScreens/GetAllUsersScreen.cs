using System.Text;
using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.UserScreens
{
    public class GetAllUsersScreen
    {
        public static void GetAll()
        {
        Console.Clear();
        Console.WriteLine("### LISTA DE TODOS OS USUÁRIOS ###");
        Console.WriteLine("##################################");
        var repository = new UserRepository(Database.connection);
        var items = new List<User>();
        try
            {
            items = repository.GetWithRoles();
            var stringRoles = new StringBuilder();
            var listRoles = new List<string>();
            foreach (var item in items)
            {
                stringRoles.Clear();
                listRoles = item.Roles.Select(role => role.Name).ToList();
                if(!listRoles.Any()) listRoles.Add("Nenhum");
                stringRoles.AppendJoin(", ", listRoles);
                Console.WriteLine($"ID: {item.Id} - Nome: {item.Name} - Email: {item.Email} - Roles: {stringRoles}");
            }
            }catch(Exception ex){
                Console.WriteLine("Não foi possível listar os usuários!");
                Console.WriteLine(ex.Message);
            }
        Console.ReadKey();
        MenuUserScreen.Load();
        }
    }
}