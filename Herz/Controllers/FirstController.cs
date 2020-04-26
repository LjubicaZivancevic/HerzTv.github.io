using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Herz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Herz.Controllers
{
    
    public class FirstController : Controller
    {
        private readonly IConfiguration configuration;
        public FirstController(IConfiguration config) {
            this.configuration = config;
        }
        private HerzTvContext _context;

        public FirstController(HerzTvContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnectionString");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand comm = new SqlCommand("select count(*) from User ");
            var count = (int)comm.ExecuteScalar();
            ViewData["TotalData"] = count;
            connection.Close();
            return View(_context.User.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}