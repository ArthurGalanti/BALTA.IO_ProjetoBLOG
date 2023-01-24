using BALTA.IO_ProjetoBLOG.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BALTA.IO_ProjetoBLOG.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection)
        : base(connection)
        => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"SELECT
                        [User].*,
                        [Role].*
                        FROM
                        [User]
                        LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                        LEFT JOIN [Role] ON [Role].Id = [UserRole].[RoleId]";

            var users = new List<User>();

            _connection.Query<User, Role, User>(
                query, (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");

            return users;
        }

        public void LinkWithRole(int user, int role)
        {
            
            var query = "INSERT INTO [UserRole] VALUES(@user, @role);";
             _connection.Execute(query, new{user, role});
        }
    }
}