using BSCHub.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCHub.Application.Contracts.Persistence
{
    public interface IConsultantRepository
    {
        List<Consultant> GetConsultants();
        Consultant? GetConsultant(int id);
    }
}
