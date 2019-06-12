using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class ExcelImport
    {
        public IFormFile file { get; set; }
    }
}
