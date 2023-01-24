using System.Security.Cryptography;
using System.Text;
using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        private static readonly string saltkey = "4ae86923609337bb1062fcd05da577a952779054117ce8fbb8b6a585bf7afa27c1fc969257faa76ccc13ed658236be98033a2fcda55822b14a1d38f38f169558";

        public static void Update()
        {
            Console.Clear();
            Console.WriteLine("### ATUALIZAÇÃO DE USUÁRIOS ###");
            Console.WriteLine("###############################");
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
            Console.WriteLine($"Perfil selecionado: ID: {item.Id} - Nome: {item.Name} - Email: {item.Email}");
            Console.WriteLine("Novo nome do usuário:");
            item.Name = Console.ReadLine();
            Console.WriteLine("Novo email do usuário:");
            item.Email = Console.ReadLine();
            Console.WriteLine("Nova senha do usuário:");
            item.PasswordHash = CreateSHA512(Console.ReadLine() + saltkey);
            Console.WriteLine("Nova bio do usuário:");
            item.Bio = Console.ReadLine();
            Console.WriteLine("Nova imagem do usuário(url):");
            item.Image = Console.ReadLine();
            Console.WriteLine("Novo slug do usuário:");
            item.Slug = Console.ReadLine();
            try
            {
                repository.Update(item);
                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário!");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static string CreateSHA512(string strData)
        {
            var message = Encoding.UTF8.GetBytes(strData);
            using (var alg = SHA512.Create())
            {
                string hex = "";

                var hashValue = alg.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                return hex;
            }
        }
    }
}