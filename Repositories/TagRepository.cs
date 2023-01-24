using BALTA.IO_ProjetoBLOG.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BALTA.IO_ProjetoBLOG.Repositories
{
    public class TagRepository : Repository<Tag>
    {
    private readonly SqlConnection _connection;
        public TagRepository(SqlConnection connection)
        : base(connection)
        => _connection = connection;
    
    public List<Tag> GetTagsWithPosts()
    {
        var query = @"SELECT 
                    [Tag].*,
                    COUNT([PostTag].[TagId]) AS PostsQuantity
                    FROM [Tag]
                        LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                    GROUP BY
                    [Tag].[Id],
                    [Tag].[Name],
                    [Tag].[Slug]";

        var tags = _connection.Query<Tag>(query).ToList();

        return tags;

    }
    }
}