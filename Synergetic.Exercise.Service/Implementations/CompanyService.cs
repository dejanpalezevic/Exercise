using Synergetic.Exercise.Data.Interfaces;
using Synergetic.Exercise.Model;
using Synergetic.Exercise.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IEnumerable<Company> FindAll()
        {
            return _companyRepository.FindAll();
        }

        public Company GetById(int id)
        {
            return _companyRepository.Get(id);
        }
        
        public void Add(Company company)
        {
            _companyRepository.Add(company);
        }

        public void Delete(int id)
        {
            _companyRepository.Delete(GetById(id));
        }

        public void SaveChanges()
        {
            _companyRepository.SaveChanges();
        }
    }
}
