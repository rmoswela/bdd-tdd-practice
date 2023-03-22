using project_three_Kata.Stack.Core;
namespace project_three_Kata.Stack.Tests
{
   [TestFixture]
   public class ImmutableStackTests
   {
      [Test]
      public void IsEmpty_EmptyStack_ReturnTrue()
      {
         //Arrange
         var emptyStack = ImmutableStack<int>.Empty;
         //Act
         var isEmpty = emptyStack.IsEmpty;
         //Assert
         Assert.That(isEmpty, Is.True);
      }

      [Test]
      public void PeekAndPop_EmptyStack_ThrowsException()
      {
         //Arrange
         var emptyStack = ImmutableStack<int>.Empty;

         //Assert
         Assert.Throws<InvalidOperationException>(() =>
         {
            emptyStack.Peek();
         });
         Assert.Throws<InvalidOperationException>(() =>
         {
            emptyStack.Pop();
         });
      }

      [Test]
      public void PushOnEmptyStackTwoItems_PeekOneElement_ReturnsCorrectValue()
      {
         var stack = ImmutableStack<int>.Empty;
         stack = stack.Push(15);
         stack = stack.Push(30);

         int result = stack.Peek();

         Assert.That(30, Is.EqualTo(result));
      }
   }
}

