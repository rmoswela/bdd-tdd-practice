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
   }
}

