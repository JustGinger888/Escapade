using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using URL.GRID;
using System.Media;

namespace URL.Player
{
    partial class Character
    {

        public static int _bomb;
        public static int _key;
        public static int _chest;
        public static int _coin;


        public int interval = 100;
        public int _yPlayerPosition;
        public int _xPlayerPosition;
        char _zero = Convert.ToChar(0);

        public static int _playerHealth = 20;


        public void InitializePlayer(int _ySectionPositionMap, int _xSectionPositionMap)
        {

            _yPlayerPosition = _ySectionPositionMap + 7;
            _xPlayerPosition  = _xSectionPositionMap + 11;

        }


        public int PlayerPositionMapY(int _yPlayerPositionMap)
        {

            _yPlayerPositionMap = _yPlayerPosition;
            return _yPlayerPositionMap;

        }


        public int PlayerPositionMapX(int _xPlayerPositionMap)
        {

            _xPlayerPositionMap = _xPlayerPosition;
            return _xPlayerPositionMap;

        }

    }

}
