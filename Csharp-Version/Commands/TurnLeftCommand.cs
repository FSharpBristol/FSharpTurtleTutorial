namespace TurtleRunner.Commands
{
    using TurtleRunner.Models;
    
    public class TurnLeftCommand : ICommand
    {
        private readonly int _quantityToTurn;

        public TurnLeftCommand(int quantityToTurn)
        {
            _quantityToTurn = quantityToTurn;
        }

        public void ExecuteCommand(Turtle turtle)
        {
            turtle.Angle += _quantityToTurn;
        }
    }
}