using SocialWorkApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorkApp.Application.Contracts.Persistence
{
    public interface IConsultantRepository
    {
        List<Consultant> GetConsultants();
        Consultant? GetConsultant(int id);
    }
}
