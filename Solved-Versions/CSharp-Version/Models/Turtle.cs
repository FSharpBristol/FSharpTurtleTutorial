namespace TurtleRunner.Models
{
    public class Turtle
    {
        public Turtle()
        {
            XPosition = 0;
            YPosition = 0;
            Angle = 90; // Facing up
            PenState = PenStateEnum.Down;
            Colour = ColourEnum.Black;
        }

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public int Angle { get; set; }

        public PenStateEnum PenState { get; set; }

        public ColourEnum Colour { get; set; }
    }
}
