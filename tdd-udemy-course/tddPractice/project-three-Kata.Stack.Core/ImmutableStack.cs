﻿using System;
namespace project_three_Kata.Stack.Core
{
   public class ImmutableStack<T> : IStack<T>
   {
      private sealed class EmptyStack : IStack<T>
      {
         public IStack<T> Push(T value)
         {
            throw new NotImplementedException();
         }

         public IStack<T> Pop()
         {
            throw new NotImplementedException();
         }

         public T Peek()
         {
            throw new NotImplementedException();
         }

         public bool IsEmpty { get; }
      }

      public IStack<T> Push(T value)
      {
         throw new NotImplementedException();
      }

      public IStack<T> Pop()
      {
         throw new NotImplementedException();
      }

      public T Peek()
      {
         throw new NotImplementedException();
      }

      public bool IsEmpty { get; }
   }
}

