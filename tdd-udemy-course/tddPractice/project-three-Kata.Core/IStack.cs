namespace project_three_Kata.Core
{
   public interface IStack<T>
   {
      IStack<T> Push(T value);
      IStack<T> Pop();
      T Peek();
      bool IsEmpty { get; }
   }
}

