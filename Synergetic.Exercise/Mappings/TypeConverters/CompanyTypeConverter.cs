using AutoMapper;
using Synergetic.Exercise.Model;
using Synergetic.Exercise.Models.Company;
using Synergetic.Exercise.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synergetic.Exercise.Mappings.TypeConverters
{
    public class CompanyTypeConverter : ITypeConverter<CompanyModel, Company>
    {
        private readonly ICompanyService _companyService;

        public CompanyTypeConverter(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public Company Convert(ResolutionContext context)
        {
            var model = (CompanyModel)context.SourceValue;
            Company company;
            if (model.Id > 0)
            {
                company = _companyService.GetById(model.Id);
            }
            else
            {
                company = new Company();
                _companyService.Add(company);
            }
            MapCompanyFromModel(company, model);
            _companyService.SaveChanges();
            return company;
        }

        private void MapCompanyFromModel(Company company, CompanyModel model)
        {
            company.Name = model.Name;
            company.Description = model.Description;
        }
    }
}