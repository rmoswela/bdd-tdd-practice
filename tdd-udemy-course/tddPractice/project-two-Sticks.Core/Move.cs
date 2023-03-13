namespace project_two_Sticks.Core
{
   public struct Move
   {
      public int SticksTaken { get; }
      public int SticksRemaining { get; }

      public Move(int taken, int remains)
      {
         SticksTaken = taken;
         SticksRemaining = remains;
      }
   }
}

