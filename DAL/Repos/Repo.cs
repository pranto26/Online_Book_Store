using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class Repo
    {
        internal OBSContext db;
        internal Repo()
        {
            db = new OBSContext();
        }
    }
}
