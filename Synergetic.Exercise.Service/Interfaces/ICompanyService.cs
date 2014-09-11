using Synergetic.Exercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Service.Interfaces
{
    public interface ICompanyService
    {
        Company GetById(int id);

        IEnumerable<Company> FindAll();

        void Add(Company company);

        void Delete(int id);

        void SaveChanges();
    }
}
