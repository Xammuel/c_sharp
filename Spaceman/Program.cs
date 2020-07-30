using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
        Game play = new Game();
        while(play.DidWin() != true && play.DidLose() != true)
        {
            play.Display();
            play.Ask();
        }
        if(play.DidWin() == true)
        {
            Console.WriteLine("*****YOU WON, WELL DONE!*****");
        } else if(play.DidLose() == true)
        {
            Console.WriteLine("YOU LOSE.");
        }
    }
  }
}
