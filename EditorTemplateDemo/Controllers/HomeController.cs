using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EditorTemplateDemo.Controllers
{
    using System.Threading.Tasks;
    using Data;
    using Domain;
    using Models.Home;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult> Index()
        {

            var model = await _dbContext.Customers
                .Include(cust => cust.CustomerType)
                .OrderByDescending(cust => cust.Id)
                .Skip(0).Take(10)
                .Select(cust => new CustomerIndexModel
                {
                    Id = cust.Id,
                    Active = cust.IsActive,
                    FullName = cust.LastName + ", " + cust.FirstName + " " + cust.Initial,
                    CustomerType = cust.CustomerType.Description

                }).ToListAsync();

            return View(model);
        }

        public ActionResult Add()
        {
            ViewBag.CustomerTypes = _dbContext.CustomerTypes.ToList();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Add(CustomerAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Initial = model.Initial,
                IsActive = model.IsActive,
                CustomerTypeId = model.CustomerTypeId

            };

            _dbContext.Customers.Add(customer);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CustomerTypes = _dbContext.CustomerTypes.ToList();

            var model = _dbContext.Customers.Where(cust=>cust.Id == id)
                .Select(cust => new CustomerEditModel
            {
                Id = cust.Id,
                FirstName = cust.FirstName,
                LastName = cust.LastName,
                Initial = cust.Initial,
                IsActive = cust.IsActive,
                CustomerTypeId = cust.CustomerTypeId
            }).Single();

            return View(model);


        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var customer = _dbContext.Customers.Find(model.Id);

            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Initial = model.Initial;
            customer.IsActive = model.IsActive;
            customer.CustomerTypeId = model.CustomerTypeId;

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}