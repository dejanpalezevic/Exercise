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
    public class CompanyModelTypeConverter : ITypeConverter<int, CompanyModel>
    {
        private readonly ICompanyService _companyService;

        public CompanyModelTypeConverter(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public CompanyModel Convert(ResolutionContext context)
        {
            var id = (int)context.SourceValue;
            var company = _companyService.GetById(id);
            return Mapper.Map<Company, CompanyModel>(company);
        }
    }
}