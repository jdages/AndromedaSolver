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
            if(knownCells == null)
                knownCells = new List<Cell>();
            Cells = new List<Cell>();
            Symbols = symbols;
            Size = size;
            PropogateEmptyCells(size);
            PopulateKnownCells(knownCells);
        }

        private void PopulateKnownCells(List<Cell> knownCells)
        {
            knownCells.ForEach(a =>
            {
                var cell =
                    Cells.Single(
                        b =>
                            b.Position.Horizontal == a.Position.Horizontal && b.Position.Vertical == a.Position.Vertical);
                cell.Position.Vertical = a.Position.Vertical;
                cell.Position.Horizontal = a.Position.Horizontal;
                cell.Position.Group= a.Position.Group;
                cell.Preconfigured = a.Preconfigured;
                cell.Symbol = a.Symbol;
            });
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
            if (VerticalRowsAreValid() && HorizontalRowsAreValid() && GroupsAreValid())
                return GameStatus.Complete;
            return GameStatus.Broken;
        }

        private bool GroupsAreValid()
        {
            var valid = true;
            foreach(var x in Cells.Select(a=>a.Position.Group).Distinct())
            {
                if (valid)
                {
                    var applicableCells = Cells.Where(a => a.Position.Group == x).ToList();
                    applicableCells.ForEach(a =>
                    {
                        if (applicableCells.Count(b => a.Symbol == b.Symbol) > 1)
                        {
                            valid = false;
                        }
                    });
                }
            }
            return valid;
        }

        private bool HorizontalRowsAreValid()
        {
            var valid = true;
            for (var x = 0; x < Size; x++)
            {
                if (valid)
                {
                    var applicableCells = Cells.Where(a => a.Position.Horizontal == x).ToList();
                    applicableCells.ForEach(a =>
                    {
                        if (applicableCells.Count(b => a.Symbol == b.Symbol) > 1)
                        {
                            valid = false;
                        }
                    });
                }
            }
            return valid;
        }


        private bool VerticalRowsAreValid()
        {
            var valid = true;
            for (var x = 0; x < Size; x++)
            {
                if (valid)
                {
                    var applicableCells = Cells.Where(a => a.Position.Vertical == x).ToList();
                    applicableCells.ForEach(a =>
                    {
                        if (applicableCells.Count(b => a.Symbol == b.Symbol) > 1)
                        {
                            valid = false;
                        }
                    });
                }
            }
            return valid;
        }

        public class GameStatus
        {
            public const string Complete = "Complete";
            public const string Incomplete = "Incomplete";
            public const string Broken = "Broken";
        }
    }


}