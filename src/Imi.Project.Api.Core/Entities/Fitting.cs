using Imi.Project.Api.Core.Entities.Base;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class Fitting : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Cap> Caps { get; set; }
    }
}