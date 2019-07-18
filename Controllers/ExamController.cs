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
    public class ExamController : ApiController
    {

        public IEnumerable<ExamViewModel> Get()
        {
            return ExamService.GetAll();

        }


        public ExamViewModel Get(int id)
        {
            return ExamService.GetOne(id);
        }




        public int Post(ExamViewModel examViewModel)
        {
            return ExamService.PostOne(examViewModel);

        }
        public void Put(ExamViewModel examViewModel)
        {
            ExamService.PutOne(examViewModel);
        }

        public void Delete(int id)
        {
            ExamService.DeleteOne(id);
        }
    }
}
