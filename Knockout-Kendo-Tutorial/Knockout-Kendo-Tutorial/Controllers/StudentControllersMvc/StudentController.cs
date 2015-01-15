using Knockout_Kendo_Tutorial.Models.Entities;
using Knockout_Kendo_Tutorial.Models.Repositories.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Knockout_Kendo_Tutorial.Controllers.StudentControllersMvc
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
















































        public JsonResult GetStudents(string keyword, string start, string end)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string aa = start.Substring(0, 24);
                    string bb = end.Substring(0, 24);

                    DateTime startDate = DateTime.ParseExact(aa,
                              "ddd MMM d yyyy HH:mm:ss",
                              CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(bb,
                              "ddd MMM d yyyy HH:mm:ss",
                              CultureInfo.InvariantCulture);

                    List<Estudyante> ret = new List<Estudyante>();

                    client.BaseAddress = new Uri("http://localhost:16051");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("api/student").Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        if (string.IsNullOrEmpty(keyword))
                        {
                            ret = response.Content.ReadAsAsync<List<Estudyante>>().Result.Where(a=>a.CreatedOn >= startDate && a.CreatedOn <= endDate).ToList();
                        }
                        else
                        {
                            ret = response.Content.ReadAsAsync<List<Estudyante>>().Result.Where(a => a.FirstName.ToLower().Contains(keyword.ToLower()) ||
                                a.LastName.ToLower().Contains(keyword.ToLower()) ||
                                a.MiddleName.ToLower().Contains(keyword.ToLower()) ||
                                a.Address.ToLower().Contains(keyword.ToLower()) ||
                                a.GenderStr.ToLower().Contains(keyword.ToLower())).ToList().Where(a => a.CreatedOn >= startDate && a.CreatedOn <= endDate).ToList();
                        }
                    }

                    return Json(ret, JsonRequestBehavior.AllowGet);
                } 
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public JsonResult CreateStudent(string model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:16051");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    bool ret = false;


                    Estudyante estudyante = Newtonsoft.Json.JsonConvert.DeserializeObject<Estudyante>(model);

                    HttpResponseMessage response = client.PostAsJsonAsync("api/student", estudyante).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        ret = response.Content.ReadAsAsync<Boolean>().Result;
                    }

                    return Json(ret, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public JsonResult GetStartDate()
        {
            StudentRepository repo = new StudentRepository();

            var students = repo.RetrieveAll();
            var selectMin = students.Result.Min(a => a.CreatedOn);

            string minDate = selectMin.ToString("M/dd/yyyy");

            return Json(minDate, JsonRequestBehavior.AllowGet);
        }
    }
}