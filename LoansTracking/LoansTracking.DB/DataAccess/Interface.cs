using System.Linq;

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
