namespace project_three_Kata.Core;
/// <summary>
/// A class that emulates behaviour of a Stack
/// Last In First Out (LIFO)
/// </summary>
public class MyStack<T>
{
   private List<T> _stackList = new List<T>();

   public bool IsEmpty => Count == 0;

   public int Count => _stackList.Count;

   public void Push(T value)
   {
      _stackList.Add(value);
   }

   public void Pop()
   {
      if (IsEmpty)
      {
         throw new InvalidOperationException();
      }
      _stackList.RemoveAt(Count - 1);
   }

   public T Peek()
   {
      return _stackList[Count - 1];
   }
}

