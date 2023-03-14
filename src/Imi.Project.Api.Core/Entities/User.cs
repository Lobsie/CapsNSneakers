using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Core.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? HasApprovedTermsAndConditions { get; set; }
        public ICollection<Cap> CapsCollection { get; set; }
        public ICollection<Cap> LikedCaps { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}