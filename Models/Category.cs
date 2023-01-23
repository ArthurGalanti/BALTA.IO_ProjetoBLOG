using Dapper.Contrib.Extensions;

namespace BALTA.IO_ProjetoBLOG.Models
{
    [Table("[Category]")]
    public class Category
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

    }
}