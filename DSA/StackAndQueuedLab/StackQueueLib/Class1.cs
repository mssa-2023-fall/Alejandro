using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StackQueue
{
    public class AlexStack<T>
    {
        private LinkedList<T> _list = new LinkedList<T> ();
        public void Push(T node)=> _list.AddFirst(node);
        public T Pop()
        {
            
            if (this._list.Count == 0) throw new IndexOutOfRangeException();
            var temp = _list.First.Value;
            _list.RemoveFirst();
            return temp;
        }
        public T? Peek() => _list.First != null ? _list.First.Value : default(T);
        public void ClearStack()
        {   
            _list.Clear();
        }
        public int Count => _list.Count;
    }
}