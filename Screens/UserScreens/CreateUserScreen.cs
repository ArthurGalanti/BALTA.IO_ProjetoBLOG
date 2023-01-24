using System.Security.Cryptography;
using System.Text;
using BALTA.IO_ProjetoBLOG.Models;
using BALTA.IO_ProjetoBLOG.Repositories;

namespace BALTA.IO_ProjetoBLOG.Screens.UserScreens
{
    public class CreateUserScreen
    {
        private static readonly string saltkey = "4ae86923609337bb1062fcd05da577a952779054117ce8fbb8b6a585bf7afa27c1fc969257faa76ccc13ed658236be98033a2fcda55822b14a1d38f38f169558";

        public static void Create()
        {
            Console.Clear();
            Console.WriteLine("### CADASTRO DE USUÁRIO ###");
            Console.WriteLine("###########################");
            Console.WriteLine("Nome do usuário:");
            var name = Console.ReadLine();
            Console.WriteLine("Email do usuário:");
            var email = Console.ReadLine();
            Console.WriteLine("Senha do usuário:");
            var password = Console.ReadLine();
            Console.WriteLine("Bio do usuário:");
            var bio = Console.ReadLine();
            Console.WriteLine("Imagem do usuário(url):");
            var image = Console.ReadLine();
            Console.WriteLine("Slug do usuário:");
            var slug = Console.ReadLine();
            var repository = new Repository<User>(Database.connection);
            try
            {
                repository.Create(new User
                {
                    Name = name,
                    Email = email,
                    PasswordHash = CreateSHA512(password + saltkey),
                    Bio = bio,
                    Image = image,
                    Slug = slug
                });
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível cadastrar o usuário!");
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