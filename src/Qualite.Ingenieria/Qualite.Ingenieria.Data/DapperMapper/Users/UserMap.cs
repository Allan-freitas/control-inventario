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
            ToTable("User");
            Map(u => u.Id).ToColumn("Id").IsKey();
            Map(u => u.Email).ToColumn("Email");
            Map(u => u.Name).ToColumn("Name");
            Map(u => u.Password).ToColumn("Password");
        }
    }
}
