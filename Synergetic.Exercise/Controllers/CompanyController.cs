using AutoMapper;
using Synergetic.Exercise.Model;
using Synergetic.Exercise.Models.Company;
using Synergetic.Exercise.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synergetic.Exercise.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            var companies = _companyService.FindAll();
            var model = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyModel>>(companies);
            return View(model);
        }

        public ActionResult Add()
        {
            var model = new CompanyModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CompanyModel model)
        {
            if (!ModelState.IsValid) return View(model);            
            Mapper.Map<CompanyModel, Company>(model);
            return RedirectToAction("Index");            
        }

        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<int, CompanyModel>(id);
            return View("Add", model);
        }

        [HttpPost]
        public ActionResult Edit(CompanyModel model)
        {
            if (!ModelState.IsValid) return View("Add", model);
            Mapper.Map<CompanyModel, Company>(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _companyService.Delete(id);
            _companyService.SaveChanges();
            return Json("OK");
        }
	}
}