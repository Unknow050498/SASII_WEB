using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Response
/// </summary>
namespace SDLX.DTO
{
    public class Response
    {
        public string redirect { get; set; }
        public string msgErr { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
}