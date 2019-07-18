using School_managment_system.Models;
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
    public class LoginController : ApiController
    {
        
        public int Post(Login login)
        {
            using(var context = new FinalSchool())
            {
                var _student = context.Students.FirstOrDefault(x => x.StudentId == login.SNN && x.Password == login.Password);
                if(_student != null)
                {
                    var studentView = StudentService.GetOne(_student.StudentId);

                    return 1;
                }
                var _teacher = context.Teachers.FirstOrDefault(x => x.TeacherId == login.SNN && x.Password == login.Password);
                if (_teacher != null)
                {

                    return 2;
                }
                var _parent = context.Parents.FirstOrDefault(x => x.ParentSNN == login.SNN && x.Password == login.Password);
                if (_parent != null)
                {
                    return 3;
                }
                var _admin = context.Admins.FirstOrDefault(x => x.SNN == login.SNN && x.Password == login.Password);
                if (_admin != null)
                {
                    return 4;
                }
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
