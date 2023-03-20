namespace project_three_Kata.Tests;

public class StackTests
{
   [Test]
   public void IsStackEmpty_EmptyStack_ReturnsTrue()
   {
      //Arrange
      var myStack = new MyStack<int>();
      //Act
      bool isEmpty = myStack.IsEmpty;
      //Assert
      Assert.That(isEmpty, Is.True);
   }

   [Test]
   public void Count_PushOneItem_ReturnsOne()
   {
      var stack = new MyStack<int>();
      int value = 35;

      stack.Push(value);

      Assert.That(1, Is.EqualTo(stack.Count));
   }
}

public class MyStack<T>
{
   public bool IsEmpty => Count == 0;

   public int Count { get; private set; }

   public void Push(T value)
   {
      Count++;
   }
}
