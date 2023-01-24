using Dapper.Contrib.Extensions;

namespace BALTA.IO_ProjetoBLOG.Models
{
    [Table("[Tag]")]
    public class Tag
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        [Write(false)]
        public int PostsQuantity { get; set; }
        
    }
}