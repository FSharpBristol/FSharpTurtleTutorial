namespace TurtleRunner.Commands
{
    using TurtleRunner.Models;
    
    public class SetColourCommand : ICommand
    {
        private readonly ColourEnum _colour;

        public SetColourCommand(ColourEnum colour)
        {
            _colour = colour;
        }

        public void ExecuteCommand(Turtle turtle)
        {
            turtle.Colour = _colour;
        }
    }
}