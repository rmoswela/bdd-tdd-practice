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

         Assert.That(list.Head, Is.SameAs(list.Tail));
      }

      [Test]
      public void AddTwoElements_ListIsCorrectState()
      {
         var list = new MyLinkedList<int>();

         list.AddFirst(1001);
         list.AddFirst(2001);

         Assert.That(2001, Is.EqualTo(list.Head.Value));
         Assert.That(1001, Is.EqualTo(list.Tail.Value));
         Assert.That(2, Is.EqualTo(list.Count));
         Assert.That(list.Head.Next, Is.SameAs(list.Tail));
      }

      [Test]
      public void AddLast_CheckIfHeadAndTailAreSame_AreEqual()
      {
         var list = new MyLinkedList<int>();
         list.AddLast(45);

         Assert.That(45, Is.EqualTo(list.Head.Value));
         Assert.That(45, Is.EqualTo(list.Tail.Value));
         Assert.That(list.Head, Is.SameAs(list.Tail));
      }

      [Test]
      public void AddLastTwoElements_ListIsCorrectState()
      {
         var list = new MyLinkedList<int>();

         list.AddLast(5005);
         list.AddLast(6006);

         Assert.That(5005, Is.EqualTo(list.Head.Value));
         Assert.That(6006, Is.EqualTo(list.Tail.Value));
         Assert.That(2, Is.EqualTo(list.Count));
         Assert.That(list.Head.Next, Is.SameAs(list.Tail));
      }
   }

   public class MyLinkedList<T>
   {
      public int Count { get; set; }
      public ListNode<T> Head { get; set; }
      public ListNode<T> Tail { get; set; }

      public void AddFirst(T value)
      {
         AddFirst(new ListNode<T> (value));
      }

      public void AddLast(T value)
      {
         AddLast(new ListNode<T>(value));
      }

      private void AddFirst(ListNode<T> node)
      {
         //save head node so we don't lose it
         ListNode<T> temp = Head;
         //point head to new node
         Head = node;
         //insert the rest of the list behind head
         Head.Next = temp;
         Count++;

         if (Count == 1)
         {
            Tail = Head;
         }
      }

      private void AddLast(ListNode<T> node)
      {
         if (Count == 0)
         {
            Head = node;
         }
         else
         {
            Tail.Next = node;
         }
         Tail = node;
         Count++;
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

