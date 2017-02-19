namespace TurtleRunner.Commands
{
    using System;
    using TurtleRunner.Models;
    
    public class MoveCommand : ICommand
    {
        private readonly int _quantityToMove;

        public MoveCommand(int quantityToMove)
        {
            _quantityToMove = quantityToMove;
        }

        public void ExecuteCommand(Turtle turtle)
        {
            // Maths I don't fully understand!  Moves the turtle along it's current heading.
            var angleInRads = turtle.Angle * (Math.PI/180.0) * 1.0;

            turtle.XPosition  = (int)Math.Round(turtle.XPosition  + (_quantityToMove * Math.Cos(angleInRads)));
            turtle.YPosition  = (int)Math.Round(turtle.YPosition  + (_quantityToMove * Math.Sin(angleInRads)));
        }
    }
}