using Dapper.FluentMap.Dommel.Mapping;
using Qualite.Ingenieria.Domain.Entities.Users;
using System.Diagnostics.CodeAnalysis;

namespace Qualite.Ingenieria.Data.DapperMapper.Users
{
    [ExcludeFromCodeCoverage]
    public class UserMap : DommelEntityMap<User>
    {
        public UserMap()
        {
            ToTable("USER");
            Map(u => u.Id).ToColumn("Id").IsKey();
            Map(u => u.Email).ToColumn("Email");
            Map(u => u.Name).ToColumn("Name");
            Map(u => u.Username).ToColumn("Username");
            Map(u => u.Password).ToColumn("Password");
            Map(u => u.CreatedOn).ToColumn("CreatedOn");
            Map(u => u.RoleId).ToColumn("Role_Id");
        }
    }
}
