using System;

namespace Intro_til_lagdelinh
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.TurnRight();
            robot.Drive(5);
            robot.TurnAround();

        }
    }
}
