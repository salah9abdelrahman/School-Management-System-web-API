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
    public class CourseController : ApiController
    {

        public IEnumerable<CourseViewModel> Get()
        {
            return CourseService.GetAll();

        }


        public CourseViewModel Get(int id)
        {
            return CourseService.GetOne(id);
        }




        public int Post(CourseViewModel courseModel)
        {
            return CourseService.PostOne(courseModel);

        }
        public void Put(CourseViewModel courseModel)
        {
            CourseService.PutOne(courseModel);
        }

        public int Delete(int id)
        {
            return CourseService.DeleteOne(id);
        }

        public IEnumerable<CourseViewModel> GetCoursesToTeacher(string ssn)
        {
            return CourseService.GetCoursesToTeacher(ssn);
        }

    }
}
