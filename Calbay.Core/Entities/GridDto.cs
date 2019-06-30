using System;
using System.Collections.Generic;
using System.Text;

namespace Calbay.Core.Entities
{
    public class GridDto<T> where T : class, new()
    {
        public int iTotalRecords { get; set; }

        public List<T> Grid { get; set; }
    }
}
