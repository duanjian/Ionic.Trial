using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Backend.EF.Repository
{
   

    public class TrialContext : DbContext
    {
        public TrialContext()
            : base("name=TrialContext")
        {

        }

        //public virtual IDbSet<Todo> Tasks { get; set; }


    }
}
