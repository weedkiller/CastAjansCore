using System.Collections.Generic;

namespace Calbay.Core.Entities
{
    public class GridDto<T> where T : class, new()
    {
        public List<T> Data { get; set; }

        public int Draw { get; set; }

        public int length { get; set; }

        public int RecordsFiltered { get; set; }

        public int RecordsTotal { get; set; }

    }
}
