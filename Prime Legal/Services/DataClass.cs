using Prime_Legal.DataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Legal.Services
{
    public class DataClass : PrimeLegalEstateEntities
    {
        public static PrimeLegalEstateEntities context = null;

        public DataClass() : base() { }

        public static PrimeLegalEstateEntities GetContext()
        {
            if (context == null)
            {
                context = new PrimeLegalEstateEntities();
            }
            return context;
        }
    }
}
