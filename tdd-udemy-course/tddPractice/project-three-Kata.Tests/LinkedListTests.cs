using System;
namespace project_three_Kata.Tests
{
   [TestFixture]
   public class LinkedListTests
   {
      [Test]
      public void CreateNode_SetsValueAndNextIsNull_ReturnsTrue()
      {
         ListNode<int> node = new ListNode<int>(10);

         Assert.That(10, Is.EqualTo(node.Value));
         Assert.IsNull(node.Next);
      }

      [Test]
      public void AddFirst_CheckIfHeadAndTailAreSame_ReturnsTrue()
      {
         MyLinkedList<int> list = new MyLinkedList<int>();
         list.AddFirst(30);

         Assert.That(30, Is.EqualTo(list.Head.Value));
         Assert.That(30, Is.EqualTo(list.Tail.Value));
         Assert.That(list.Head, Is.SameAs(list.Tail));
      }
   }

   public class MyLinkedList<T>
   {
      public ListNode<T> Head { get; set; }
      public ListNode<T> Tail { get; set; }

      public void AddFirst(T value)
      {
         AddFirst(new ListNode<T> (value));
      }

      private void AddFirst(ListNode<T> node)
      {
         Tail = Head = node;
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

