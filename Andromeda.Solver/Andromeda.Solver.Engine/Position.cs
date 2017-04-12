namespace Andromeda.Solver.Engine
{
    public class Position
    {
        public Position(int horizontal, int vertical, int? group = null)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            if (group.HasValue)
                Group = group.Value;
        }
        public int Horizontal { get; set; }
        public int Vertical { get; set; }
        public int Group { get; set; }
    }
}