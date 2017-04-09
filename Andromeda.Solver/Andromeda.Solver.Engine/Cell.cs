namespace Andromeda.Solver.Engine
{
    public class Cell
    {
        public Cell(Position position, bool preconfigured, int? symbol = null)
        {
            Position = position;
            Preconfigured = preconfigured;
            if (symbol.HasValue)
                Symbol = symbol.Value;
        }
        public int? Symbol { get; set; }
        public Position Position { get; set; }
        public bool Preconfigured { get; set; }
    }
}