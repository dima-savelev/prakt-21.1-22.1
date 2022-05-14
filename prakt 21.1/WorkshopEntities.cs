using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt_21._1
{
    public partial class WorkshopEntities : DbContext
    {
        private static WorkshopEntities context;
        public static WorkshopEntities GetContext()
        {
            if (context == null)
            {
                context = new WorkshopEntities();
            }
            return context;
        }
    }
}
