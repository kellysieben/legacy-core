using System.Collections.Generic;
using Legacy.CoreApi.Controllers;

namespace Legacy.CoreApi.Data
{
    public class InMemoryDataStore : IDataStore
    {
        private static readonly List<object> All = new List<object>();

        public List<object> GetAll => All;

        public int Count => All.Count;

        public void Add(object entry)
        {
            All.Add(entry);
        }

        public void Clear()
        {
            All.Clear();
        }
    }
}
