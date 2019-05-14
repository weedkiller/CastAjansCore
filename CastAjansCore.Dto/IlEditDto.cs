using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CastAjansCore.Dto
{
    public class IlEditDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Adi { get; set; }
    }
}
