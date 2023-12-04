using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Dtos;
using NHNT.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using NHNT.Constants;

namespace NHNT.Controllers
{
    public class DepartmentController : ControllerCustom
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index(int page, int limit)
        {
            return View();
        }

        public IActionResult MyDepartment()
        {
            return View();
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            return View(_departmentService.GetById(id));
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("[controller]/[action]")]
        public IActionResult Register([FromForm] DepartmentRegisDto departmentDto)
        {
            try
            {
                departmentDto.UserId = GetUserPartial().Id;
                _departmentService.register(departmentDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View();
        }


        [HttpGet("[controller]/[action]")]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult Page([FromForm] int page, [FromForm] int limit, string search)
        {
            if (search == null) search = "";
            DepartmentDto query = new DepartmentDto();
            return Ok(_departmentService.List(page, limit, search, query, default(DateTime), default(DateTime)));
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult AdminReview()
        {
            return View();
        }

        [HttpPost("[controller]/[action]/{id}")]
        public IActionResult Update([FromForm] DepartmentUpdateDto departmentDto, int id)
        {
            try
            {
                _departmentService.Update(id, departmentDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult ListDepartment(int page, int limit, string search, DateTime start_date = default(DateTime), DateTime end_date = default(DateTime))
        {
            if (search == null) search = "";
            DepartmentDto query = new DepartmentDto(DepartmentStatus.ACCEPTED);
            var departments = _departmentService.List(page, limit, search, query, start_date, end_date);
            var total = _departmentService.Count();

            ListDepartmentDto result = new ListDepartmentDto(departments, total);
            return Json(result);

        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult FindByUser([FromRoute] int id)
        {
            var departments = _departmentService.FindByUserId(id);
            return Json(departments);
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Me()
        {
            var user = GetUserPartial();
            var departments = _departmentService.FindByUserId(userId: user.Id);
            return Json(data: departments);
        }

        [Authorize(RoleConfig.ADMIN)]
        [HttpPost("[controller]/[action]")]
        public IActionResult AdminSearchReview([FromForm] int pageIndex, [FromForm] int pageSize, [FromForm] DepartmentDto dto)
        {
            return Ok(_departmentService.Search(pageIndex, pageSize, dto, default(DateTime), default(DateTime)));
        }

        [Authorize(RoleConfig.ADMIN)]
        [HttpPost("[controller]/[action]")]
        public IActionResult Confirm([FromForm] int id, [FromForm] int status)
        {
            return Ok(new DepartmentDto(_departmentService.Confirm(id, status)));
        }
    }
}
