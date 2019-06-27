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
    public class StudentController : ApiController
    {
        public int Post(StudentViewModel studentViewModel)
        {
            return StudentService.Create(studentViewModel);

        }

        public int Put(StudentViewModel studentViewModel)
        {
            return StudentService.Edit(studentViewModel);
        }

        public void Delete(int id)
        {
            StudentService.Delete(id);
        }

        public IEnumerable<StudentViewModel> Get()
        {
            return StudentService.GetAll();
        }


        public StudentViewModel Get(int id)
        {
            return StudentService.GetOne(id);
        }
    }
}
