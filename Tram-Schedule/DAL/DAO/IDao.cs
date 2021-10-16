using System.Collections.Generic;

namespace Tram_Schedule.DAL.DAO
{
    public interface IDao<T>
    {
        DatabaseContext Context { get; set; }

        void Add(T instance);

        void Update(T instance);

        void Delete(T instance);

        T Read(string name);

        List<T> ReadAll();
    }
}
