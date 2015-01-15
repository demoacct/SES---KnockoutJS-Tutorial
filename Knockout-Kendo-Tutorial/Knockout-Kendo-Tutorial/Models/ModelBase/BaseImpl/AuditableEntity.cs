using Knockout_Kendo_Tutorial.Models.ModelBase.IBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Knockout_Kendo_Tutorial.Models.ModelBase.BaseImpl
{
    public abstract class AuditableEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedOn { get; set; }
    }
}