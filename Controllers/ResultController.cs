using School_managment_system.Services;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School_managment_system.Controllers
{
    public class ResultController : ApiController
    {
        [HttpGet]
        public IEnumerable<ResultViewModel> GetResultToStudent(string id)
        {
            return ResultService.GetToStudent(id);
        }

        /* Get results to one course to specific student*/
        [HttpGet]
        public IEnumerable<ResultViewModel> GetResultToStudentToCourse(string courseName, string studentId)
        {
            return ResultService.GetToCourse(courseName, studentId);
        }

        public void Post(List<ResultViewModel> resultViewModels)
        {
            ResultService.Create(resultViewModels);
        }
    }
}
