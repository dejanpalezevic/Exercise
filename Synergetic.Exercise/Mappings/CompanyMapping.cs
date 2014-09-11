using AutoMapper;
using Synergetic.Exercise.Mappings.TypeConverters;
using Synergetic.Exercise.Model;
using Synergetic.Exercise.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synergetic.Exercise.Mappings
{
    public class CompanyMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<Company, CompanyModel>();
            CreateMap<CompanyModel, Company>().ConvertUsing<CompanyTypeConverter>();
            CreateMap<int, CompanyModel>().ConvertUsing<CompanyModelTypeConverter>();
        }
    }
}