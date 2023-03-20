namespace project_three_Kata.Tests;

public class StackTests
{
   [Test]
   public void IsStackEmpty_AfterInstantiationOfAStack_ReturnsTrue()
   {
      //Arrange
      var myStack = new MyStack<int>();
      //Act
      bool isEmpty = myStack.IsEmpty;
      //Assert
      Assert.That(isEmpty, Is.True);
   }

   [Test]
   public void Count_AfterPushingOneItem_ReturnsOne()
   {
      var stack = new MyStack<int>();
      int value = 35;

      stack.Push(value);

      Assert.That(1, Is.EqualTo(stack.Count));
   }

   [Test]
   public void Pop_WhenStackIsEmpty_ThrowsException()
   {
      var stack = new MyStack<int>();

      Assert.Throws<InvalidOperationException>(() => { stack.Pop(); });
   }

   [Test]
   public void Peek_AfterPushingThreeItems_ReturnsHeadItem()
   {
      var stack = new MyStack<int>();

      stack.Push(10);
      stack.Push(40);
      stack.Push(100);

      int headValue = stack.Peek();

      Assert.That(100, Is.EqualTo(headValue));
   }

   [Test]
   public void Peek_AfterPushingThreeItemsAndPoppingOne_ReturnsHeadItem()
   {
      var stack = new MyStack<string>();

      stack.Push("Reuben");
      stack.Push("Lame");
      stack.Push("Moswela");
      stack.Pop();

      string headValue = stack.Peek();

      Assert.That("Lame", Is.EqualTo(headValue));
   }
}

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
