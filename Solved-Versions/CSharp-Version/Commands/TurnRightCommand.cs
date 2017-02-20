namespace TurtleRunner.Commands
{
    using TurtleRunner.Models;
    
    public class TurnRightCommand : ICommand
    {
        private readonly int _quantityToTurn;

        public TurnRightCommand(int quantityToTurn)
        {
            _quantityToTurn = quantityToTurn;
        }

        public void ExecuteCommand(Turtle turtle)
        {
            turtle.Angle -= _quantityToTurn;
        }
    }
}