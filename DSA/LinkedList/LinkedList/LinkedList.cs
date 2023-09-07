namespace LinkedList
{
    public interface ILinkedLIst<T>
    {
        int Count { get; }
        void AddFirst(INode<T> value);
        void AddLast(INode<T> value);
        void InsertAfterNodeIndex(INode<T> node, int index);
        void Clear();
        void RemoveLast();
        void RemoveAt(int indexPosition);
        void RemoveFirst();
        void Sort();
        INode<T> FindFirst(T value);
        INode<T>[] FindAll(T value);
        INode<T> Head { get; }
        INode<T> Tail { get; }
        IEnumerable<INode<T>> Node { get; }
    }
    public interface INode<T>
    {
        T Content { get; set; }
        INode<T>? Next();
    }
    
}