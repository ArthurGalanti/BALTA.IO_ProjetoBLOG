using BALTA.IO_ProjetoBLOG.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BALTA.IO_ProjetoBLOG.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;
        public CategoryRepository(SqlConnection connection)
        :base(connection)
        => _connection = connection;
        
    public List<Category> GetCategoriesWithPosts()
    {
        var query = @"SELECT
                      [Category].*,
                      COUNT([Post].[CategoryId]) AS PostsQuantity
                      FROM
                      [Category]
                      	LEFT JOIN [Post] ON [Post].[CategoryId] = [Category].[Id]
                      GROUP BY
                      [Category].[Id],
                      [Category].[Name],
                      [Category].[Slug]";

        var categories = _connection.Query<Category>(query).ToList();

        return categories;

    }
        
    }
}