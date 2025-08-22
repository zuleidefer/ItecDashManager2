using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItecDashManager.Domain.Entities.User;

    public class User
    {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public long MediaId { get; set; }
   

}
