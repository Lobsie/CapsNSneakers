using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class Cap : EntityBase
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public string Colorway { get; set; }
        public Guid? BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid? FittingId { get; set; }
        public Fitting Fitting { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<User> LikedByUsers { get; set; }
    }
}