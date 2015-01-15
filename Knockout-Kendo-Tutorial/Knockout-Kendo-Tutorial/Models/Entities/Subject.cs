using Knockout_Kendo_Tutorial.Models.ModelBase.BaseImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout_Kendo_Tutorial.Models.Entities
{
    public class Subject : BaseEntity<string>
    {
        public override string Id { get; set; }
        public string SubjectId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
    }
}