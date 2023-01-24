using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.UserScreens
{
    public class LinkUserWithRoleScreen
    {
     public static void LinkWithRole()
        {
            Console.Clear();
            Console.WriteLine("### VINCULAR USUÁRIO COM PERFIL ###");
            Console.WriteLine("###################################");
            Console.WriteLine("ID do usuário:");
            int.TryParse(Console.ReadLine(), out var user);
            Console.WriteLine("ID do perfil:");
            int.TryParse(Console.ReadLine(), out var role);
            var repository = new UserRepository(Database.connection);
            if (user != 0 && role != 0)
            {
            try
            {
                repository.LinkWithRole(user, role);
                Console.WriteLine("Vinculo feito com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular!");
                Console.WriteLine(ex.Message);
            }
            }else
                Console.WriteLine("Não foi possível vincular!");

            Console.ReadKey();
            MenuUserScreen.Load();
        }   
    }
}