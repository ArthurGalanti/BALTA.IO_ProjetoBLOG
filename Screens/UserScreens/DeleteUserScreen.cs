using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.UserScreens
{
    public class DeleteUserScreen
    {
        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("### EXCLUSÃO DE USUÁRIO ###");
            Console.WriteLine("###########################");
            Console.WriteLine("Digite o ID do usuário:");
            int.TryParse(Console.ReadLine(), out var id);
            User item = new User();
            var repository = new Repository<User>(Database.connection);
            try
            {
            item = repository.Get(id);
            }catch(Exception ex){
                Console.WriteLine("Não foi possível encontrar o usuário!");
                Console.WriteLine(ex.Message);
            }

            if (item == null)
            {
                Console.WriteLine("ID inválido ou inexistente!");
                Console.ReadKey();
                MenuUserScreen.Load();
            }
            Console.WriteLine($"Usuário selecionado: ID: {item.Id} - Nome: {item.Name} - Email: {item.Email}");
            Console.WriteLine("Tem certeza que deseja excluí-lo? (s) ou (n)");
            char.TryParse(Console.ReadLine(), out var option);
            if (option == 's' || option == 'S')
            {
                try
                {
                    repository.Delete(item);
                    Console.WriteLine("Usuário excluido com sucesso!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Não foi possível excluir o usuário!");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("O usuário não foi excluido!");
            }
            Console.ReadKey();
            MenuUserScreen.Load();
        }
    }
}