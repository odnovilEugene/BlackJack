namespace Prog.Interfaces
{
    public interface ICustomStack<T>
    {
        void Push(T element);
        T Pop();
        void PushAtIndex(T element, int index);
        T PopAtIndex(int index);
        T PeekAtIndex(int index);
    }
}