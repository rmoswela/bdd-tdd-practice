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
}

public class MyStack<T>
{
   public bool IsEmpty => Count == 0;

   public int Count { get; private set; }

   public void Push(T value)
   {
      Count++;
   }

   public void Pop()
   {
      if (IsEmpty)
         throw new InvalidOperationException();
   }
}
