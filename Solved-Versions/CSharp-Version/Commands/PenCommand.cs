namespace TurtleRunner.Commands
{
    using TurtleRunner.Models;
    
    public class PenCommand : ICommand
    {
        private readonly PenStateEnum _penState;

        public PenCommand(PenStateEnum penState)
        {
            _penState = penState;
        }

        public void ExecuteCommand(Turtle turtle)
        {
            turtle.PenState = _penState;
        }
    }
}