using EFTransaction.Data;
using EFTransaction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFTransaction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Employee> emp = _dbContext.Employees.ToList();
            // var dept = _dbContext.Departments.Where(x=>x.DepartmentId==)
            if (emp.Count > 0)
            {
                return View(emp);
            }
            return View(emp);
        }

        [HttpGet]
        [Route("Home/Create")]
        public IActionResult CreateEmp()
        {
            var model = new EmployeeCreateViewModel();
            return View();
        }

        [HttpPost]
        [Route("Home/Create")]
        [ValidateAntiForgeryToken] //cross site forgery attacks prevent 
        public async Task<IActionResult> Create(EmployeeCreateViewModel empCreat)
        {
            //DepartmentCreateViewModel deptCreate
            if (ModelState.IsValid)
            {
                var emp = new Employee
                {
                    Id = empCreat.Id,

                    FirstName = empCreat.FirstName,
                    LastName = empCreat.LastName,
                    Gender = empCreat.Gender,
                    Email = empCreat.Email,
                    DateOfBirth = empCreat.DateOfBirth,
                    DateOfJoin = empCreat.DateOfJoin,
                    City = empCreat.City,
                    DepartmentId = empCreat.DepartmentId,
                    Address = empCreat.Address,
                    Designation = empCreat.Designation,
                    PhoneNumber = empCreat.PhoneNumber,
                    Postcode = empCreat.Postcode,
                    ImageUrl = empCreat.ImageUrl,

                };


                string StoredProc = "exec CreateEmp " +
            "@FirstName = '" + emp.FirstName + "'," +
            "@LastName = '" + emp.LastName + "'," +
            "@Gender= '" + emp.Gender + "'," +
            "@ImageUrl= '" + emp.ImageUrl + "'," +
            "@DateOfBirth = '" + emp.DateOfBirth + "'," +
            "@Designation= '" + emp.Designation + "'," +
            "@DateOfJoin= '" + emp.DateOfJoin + "'," +
            "@Email= '" + emp.Email + "'," +
            "@PhoneNumber= '" + emp.PhoneNumber + "'," +
            "@Address= '" + emp.Address + "'," +
            "@City= '" + emp.City + "'," +
            "@Postcode= '" + emp.Postcode + "'," +
            "@DepartmentId= '" + emp.DepartmentId + "'";


              //  using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {

                        using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
                        {
                            DataSet dsEmployee = new DataSet();
                            cmd.CommandText = StoredProc;
                            //  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            // cmd.Transaction = (System.Data.Common.DbTransaction?)transaction;
                            _dbContext.Database.OpenConnection();
                            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter((SqlCommand)cmd);

                            objSqlDataAdapter.Fill(dsEmployee);

                        }
                        //_dbContext.Employees.Add(emp);
                        //_dbContext.SaveChanges();

                        //int id = opt.Id;

                        var dept = new Department
                        {
                            // DepartmentId = empCreat.DepartmentId,

                            DepartmentCode = empCreat.DeptCode,
                            DepartmentName = empCreat.DeptName,

                        };

                        _dbContext.Departments.Add(dept);
                        _dbContext.SaveChanges();


                        //    transaction.Commit();
                        // }
                    }
                    catch (Exception ex)
                    {
                        //transaction.Rollback();
                    }
                }

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}