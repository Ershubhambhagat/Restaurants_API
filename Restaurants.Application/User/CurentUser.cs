using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.User;

public class CurentUser(string id,string Email,IEnumerable<string>Roles)
{
    public bool IsInRoles(string Roles)=>Roles.Contains(id);
}
