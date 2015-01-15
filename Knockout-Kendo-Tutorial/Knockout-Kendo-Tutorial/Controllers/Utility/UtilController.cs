using Knockout_Kendo_Tutorial.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knockout_Kendo_Tutorial.Controllers.Utility
{
    public class UtilController : ApiController
    {
        public HttpResponseMessage GetGenders() 
        {
            var genders = Enum.GetValues(typeof(Gender))
               .Cast<Gender>()
               .Select(e => new
               {
                   Value = e,
                   Text = e.ToString().Replace("_", " ")
               });

            System.Web.Mvc.SelectList ret = new System.Web.Mvc.SelectList(genders, "Value", "Text");

            return Request.CreateResponse<System.Web.Mvc.SelectList>(HttpStatusCode.OK, ret);
        }
    }
}
