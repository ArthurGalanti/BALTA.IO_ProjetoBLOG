using Microsoft.Data.SqlClient;

namespace BALTA.IO_ProjetoBLOG
{
    public static class Database
    {
        public static SqlConnection connection = new SqlConnection(@"Server=DEVELOPMENT;Database=Blog;Integrated Security=True;TrustServerCertificate=True");
    }
}