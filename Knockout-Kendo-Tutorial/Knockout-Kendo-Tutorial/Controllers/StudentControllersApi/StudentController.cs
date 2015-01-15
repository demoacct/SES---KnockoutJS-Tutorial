using Knockout_Kendo_Tutorial.Models.Entities;
using Knockout_Kendo_Tutorial.Models.Repositories.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Knockout_Kendo_Tutorial.Controllers.StudentControllersApi
{
    public class StudentController : ApiController
    {
        private StudentRepository studentRepo;
        public StudentController()
        {
            this.studentRepo = new StudentRepository();
        }

        public HttpResponseMessage GetAll()
        {
            try
            {
                var all = this.studentRepo.RetrieveAll();
                HttpResponseMessage ret = Request.CreateResponse<List<Estudyante>>(HttpStatusCode.OK, all.Result);

                return ret;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public HttpResponseMessage Post([FromBody] Estudyante model)
        {
            try
            {
                var create = this.studentRepo.Create(model);
                return Request.CreateResponse<Boolean>(HttpStatusCode.OK, create.Result);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
