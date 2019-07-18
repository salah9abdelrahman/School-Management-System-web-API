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
    public class LevelController : ApiController
    {
        public IEnumerable<LevelViewModel> Get()
        {
            return LevelService.GetAll();

        }


        public LevelViewModel Get(int id)
        {
            return LevelService.GetOne(id);
        }




        public int Post(LevelViewModel levelModel)
        {
            return LevelService.PostOne(levelModel);

        }
        public void Put(int id, LevelViewModel levelModel)
        {
            LevelService.PutOne(id, levelModel);
        }

        public void Delete(int id)
        {
            LevelService.DeleteOne(id);
        }

        public int GetLevelByName(string name)
        {
            return LevelService.GetLevelByName(name);
        }

        public IEnumerable<LevelViewModel> GetLevelsToTeacher(string teacherSnn)
        {
            return LevelService.GetLevelsToTeacher(teacherSnn);
        }
    }
}
