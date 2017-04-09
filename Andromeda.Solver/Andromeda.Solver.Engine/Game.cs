using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Andromeda.Solver.Engine
{
    public class Game
    {

        public int Symbols { get; private set; }
        public int Groups { get; private set; }
        public int Size { get; private set; }
        public List<Cell> Cells { get; set; }
        public Game(int size, int symbols, List<Cell> knownCells)
        {
            if(knownCells == null) knownCells = new List<Cell>();
            Cells = new List<Cell>();
            Symbols = symbols;
            Size = size;
            PropogateEmptyCells(size);

        }

        private void PropogateEmptyCells(int size)
        {
            for (var x = 0; x < size; x++)
                for (var y = 0; y < size; y++)
                {
                    Cells.Add(new Cell(new Position(x, y), false));
                }
        }

        public string GetStatus()
        {
            if (Cells.Any(a => !a.Symbol.HasValue))
                return GameStatus.Incomplete;
            throw new NotImplementedException();

        }
        public class GameStatus
        {
            public const string Complete = "Complete";
            public const string Incomplete = "Incomplete";
            public const string Broken = "Broken";
        }
    }


}