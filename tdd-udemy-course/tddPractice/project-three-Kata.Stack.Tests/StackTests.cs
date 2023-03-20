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
}

public class MyStack<T>
{
   public bool IsEmpty
   {
      get { return true; }
   }
}
