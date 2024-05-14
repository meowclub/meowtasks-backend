using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowTasksBackend.DTO.Requests
{
    public class MeowUserLoginRequestDTO
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
