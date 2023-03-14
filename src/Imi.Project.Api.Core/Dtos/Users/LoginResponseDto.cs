using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Dtos.Users
{
    public class LoginResponseDto
    {
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
