using System;
using System.Collections.Generic;
using System.Text;

namespace NumberPuzzleWeb.I.DataAcsess.Model
{
    class GameModel
    {
        public Guid Id { get; set; }
        public int PlayCount { get; set; }
        public string Numbers { get; set; }

        public GameModel()
        {

        }

        public GameModel(Guid id, int playCount, string numbers)
        {
            Id = id;
            PlayCount = playCount;
            Numbers = numbers;
        }
    }
}
