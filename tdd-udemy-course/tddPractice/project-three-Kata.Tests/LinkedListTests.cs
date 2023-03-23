using System;
namespace project_three_Kata.Tests
{
   [TestFixture]
   public class LinkedListTests
   {
      [Test]
      public void CreateNode_SetsValueAndNextIsNull()
      {
         ListNode<int> node = new ListNode<int>(10);

         Assert.That(10, Is.EqualTo(node.Value));
         Assert.IsNull(node.Next);
      }
   }


   public class ListNode<T>
   {
      public ListNode(T value)
      {
         Value = value;
      }

      public ListNode<T> Next { get; set; }
      public T Value { get; set; }
   }
}

