namespace TurtleRunner
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Commands;

    public class Program
    {
        public static void Main(string[] args)
        {
            var turtle = new Turtle();
            var commands = new List<ICommand> 
            {
                new MoveCommand(20),
                new TurnLeftCommand(90),
                new MoveCommand(20),
                new TurnRightCommand(90),
                new SetColourCommand(ColourEnum.Red),
                new MoveCommand(20),
                new TurnRightCommand(90),
                new PenCommand(PenStateEnum.Up),
                new MoveCommand(40)
            };

            foreach(var command in commands)
            {
                command.ExecuteCommand(turtle);
            }
        }
    }
}
