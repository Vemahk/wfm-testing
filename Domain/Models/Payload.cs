using System.Collections;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Payload<TObject> : Payload, IEnumerable<TObject>
        where TObject : new()
    {
        private readonly List<TObject> _list = new List<TObject>();

        public int Count => _list.Count;
        public TObject this[int i]
        {
            get => _list[i];
            set => _list[i] = value;
        }

        public void Add(TObject obj)
        {
            _list.Add(obj);
        }

        public IEnumerator<TObject> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Payload
    {
        protected Payload()
        {
        }
    }
}