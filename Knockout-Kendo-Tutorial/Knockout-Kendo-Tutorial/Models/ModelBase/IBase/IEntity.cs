using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knockout_Kendo_Tutorial.Models.ModelBase.IBase
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
