using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public class CatalogueRecord : Record
    {
        public Categories Category { get; set; }

        // Information about the item
        public Guid Id { get; set; }
    }
}
