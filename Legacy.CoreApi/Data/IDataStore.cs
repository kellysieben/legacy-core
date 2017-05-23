using System.Collections.Generic;

namespace Legacy.CoreApi.Data
{
    public interface IDataStore
    {
        List<object> GetAll { get; }
        void Add(object entry);
        int Count { get; }
        void Clear();
    }
}
