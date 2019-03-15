using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.MAP
{
    class Populate
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_section"></param>
        public void PopulateItems(char[,] _section)
        {
            // The Item Array which favours Coins to the other Items, Increasing their likelyhood of spawning
            char[] _items = new char[] { 'K', 'B', 'C', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$' };
            // The initiaal variables 
            int _percentageFill = 0;
            double _tileFill = 0;
            //The section is sent to this subroutine to count the walkable times used for calculations
            double _sectionSize = CountWalkableTiles(_section);
            //Randomizing the item spawn locations
            Random _rnd = new Random();
            int _randomItem = 0;
            int _randomY = 0;
            int _randomX = 0;
            // The loop which spawns items till it is 5% full
            while (_percentageFill < 5)
            {
                // Calculating Fill Percentage
                _percentageFill = (int)Math.Round((double)(_tileFill / _sectionSize) * 100);
                //Choosing The NExt RAndom Location in the section
                _randomItem = _rnd.Next(0, 20);
                _randomY = _rnd.Next(0, 12);
                _randomX = _rnd.Next(0, 20);
                //Checking if a tile is walkable so that an Item Can Be placed
                if (_section[_randomY, _randomX] == '.')
                {
                    _section[_randomY, _randomX] = _items[_randomItem];
                    _tileFill++;
                }
            }

        }

        private int CountWalkableTiles(char[,] _section)
        {
            int _walkableTiles = 0;

            for (int _y = 0; _y < 12; _y++)
            {
                for (int _x = 0; _x < 20; _x++)
                {
                    if (_section[_y, _x] == '.')
                    {
                        _walkableTiles++;
                    }
                }
            }

            return _walkableTiles;
        }

    }
}
