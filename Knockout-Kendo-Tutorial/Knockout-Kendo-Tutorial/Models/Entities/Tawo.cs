using Knockout_Kendo_Tutorial.Models.ModelBase.BaseImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout_Kendo_Tutorial.Models.Entities
{
    public abstract class Tawo : AuditableEntity<string>
    {
        public override string Id { get; set; }
        public string TawoId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Knockout_Kendo_Tutorial.Models.Enums.Gender Gender { get; set; }
        public string GenderStr { get { return this.Gender.ToString(); } }
        public string Address { get; set; }
    }
}