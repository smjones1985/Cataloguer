using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public class CatalogueRecord
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Categories Category { get; set; }

    }
}
