using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoansTracking.DB.DataAccess
{
    public interface Interface<Entity>
    {
        AppContext BaseContext();
        IQueryable<Entity> Get();
        Entity Get(int id);
        void Insert(Entity entity);
        void Update(Entity entity, int id);
        void Delete(int id);
    }
}
