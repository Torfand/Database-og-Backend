using System;
using System.Collections.Generic;
using System.Text;

namespace Core_og_unit_test
{
    class NumberPuzzleConsoleGame
    {
        private readonly NumberPuzzleModel _model;

        public NumberPuzzleConsoleGame()
        {
            _model = new NumberPuzzleModel();
        }
        public void Run()
        {
            while (true)
            {
                Show();
                Console.WriteLine("Write a 0-8 for the number you want tot movve to the blank space: ");
                var input = Console.ReadLine();
                if (Equals(!int.TryParse(input, out int index))) return;
                _model.Play(index);

            }
        }

        private void Show()
        {
            Console.Clear();
            Console.WriteLine($" 0 1 2  ");
            Console.WriteLine(" ┌─────┐ ");
            Console.WriteLine($" │{_model[0]} {_model[1]} {_model[2]}│");
            Console.WriteLine($"3│{_model[3]} {_model[4]} {_model[5]}│5");
            Console.WriteLine($" │{_model[6]} {_model[7]} {_model[8]}│");
            Console.WriteLine(" └─────┘ ");
            Console.WriteLine("  6 7 8 ");
            Console.WriteLine();
            Console.WriteLine($"You have made {_model.PlayCount} moves.");
            var not = _model.IsSolved ? "" : "not ";
            Console.WriteLine($"you hve {not}solved the puzzle.");
        }
    }
}
