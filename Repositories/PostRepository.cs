using BALTA.IO_ProjetoBLOG.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BALTA.IO_ProjetoBLOG.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection) 
        : base (connection)
        => _connection = connection;

        public List<Post> GetWithTagsAndCategories()
        {
            var query = @"SELECT 
                        [Post].*,
                        [Tag].*,
                        [Category].*
                        FROM 
                        [Post]
                        LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                        LEFT JOIN [Tag] ON [Tag].[Id] = [PostTag].[TagId]
                        LEFT JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]";

            var posts= new List<Post>();

            _connection.Query<Post, Tag, Category, Post>(
            query,(post, tag, category) =>
            {
                var pst = posts.FirstOrDefault(x=> x.Id == post.Id);
                if (pst == null)
                {
                    pst = post;
                    if(tag != null)
                        pst.Tags.Add(tag);
                    posts.Add(pst);
                }else
                    pst.Tags.Add(tag);
                pst.Category = category;

                return post;
            },splitOn: "Id");
            return posts;
        }

        public void LinkWithTag(int post, int tag)
        {
            var query = "INSERT INTO [PostTag] VALUES(@post, @tag);";
             _connection.Execute(query, new{post, tag});
        }

        public List<Post> GetPostsByCategory(int categoryId)
        {
            var query = @"SELECT
                        *
                        FROM
                        [Post]
                        INNER JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
                        WHERE [CategoryId] = @categoryId
                        ";
            var posts = new List<Post>();            
            _connection.Query<Post, Category, Post>(
                query,(post, category) =>
                {
                    post.Category = category;
                    posts.Add(post);
                    return post;
                }
                ,new {@categoryId = categoryId}, splitOn: "Id");
              return posts; 
        }
    }
}