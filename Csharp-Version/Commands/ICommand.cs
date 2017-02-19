namespace TurtleRunner.Commands
{
    using TurtleRunner.Models;
    
    public interface ICommand
    {
        void ExecuteCommand(Turtle turtle);
    }
}