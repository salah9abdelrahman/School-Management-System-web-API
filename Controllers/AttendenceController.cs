using School_managment_system.Services;
using School_managment_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace School_managment_system.Controllers
{

    public class AttendenceController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(AttendenceService.GetAll());
        }
        public IEnumerable<AttendenceViewModel> GetAttendencesToOneStudent(string id)
        {
            return AttendenceService.GetAttendencesToStudent(id);
        }

        public void Post(AttendenceViewModel attendenceViewModel)
        {
            AttendenceService.ChangeAttendenceState(attendenceViewModel);
        }

        public void PostList(List<AttendenceViewModel> attendenceViewModel)
        {
            AttendenceService.PostListOfAttendenceState(attendenceViewModel);
        }

    }
}
