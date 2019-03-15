﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URL.Player
{
    class CharacterMove
    {

        public int _yPlayerPositionMove;
        public int _xPlayerPositionMove;
        public int _yPlayerPositionMapMove;
        public int _xPlayerPositionMapMove;


        public void InitializePosition(int _yPlayerPositionMap, int _xPlayerPositionMap, int _yPlayerPosition, int _xPlayerPosition)
        {

             _yPlayerPositionMove = _yPlayerPosition;
             _xPlayerPositionMove = _xPlayerPosition;
             _yPlayerPositionMapMove = _yPlayerPositionMap;
             _xPlayerPositionMapMove = _xPlayerPositionMap;

        }


        public void PositionUp(PictureBox[,] _pbxGridMain, char[,] _2DlevelMap, int _yPlayerPositionMap, int _xPlayerPositionMap, int _yPlayerPosition, int _xPlayerPosition, char _zero)
        {
            if (_2DlevelMap[_yPlayerPositionMap - 1, _xPlayerPositionMap] == '#' || _2DlevelMap[_yPlayerPositionMap - 1, _xPlayerPositionMap] == _zero)
            {

            }

            else
            { 

                _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.Transparent;
                _yPlayerPosition--;
                _yPlayerPositionMap--;

                _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.DeepSkyBlue;
            }

            InitializePosition( _yPlayerPositionMap,  _xPlayerPositionMap,  _yPlayerPosition,  _xPlayerPosition);

            StartinArea(_pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
        }


        public void PositionLeft(PictureBox[,] _pbxGridMain, char[,] _2DlevelMap, int _yPlayerPositionMap, int _xPlayerPositionMap, int _yPlayerPosition, int _xPlayerPosition, char _zero)
        {
            if (_xPlayerPosition > 0)
            {
                if (_2DlevelMap[_yPlayerPositionMap, _xPlayerPositionMap - 1] == '#' || _2DlevelMap[_yPlayerPositionMap, _xPlayerPositionMap - 1] == _zero)
                {



                }

                else
                {
                    _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.Transparent;
                    _xPlayerPosition--;
                    _xPlayerPositionMap--;


                    _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.DeepSkyBlue;

                }

                InitializePosition(_yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition);

                StartinArea(_pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
            }
        }


        public void PositionDown(PictureBox[,] _pbxGridMain, char[,] _2DlevelMap, int _yPlayerPositionMap, int _xPlayerPositionMap, int _yPlayerPosition, int _xPlayerPosition, char _zero)
        {
            if (_yPlayerPosition < 13)
            {
                if (_2DlevelMap[_yPlayerPositionMap + 1, _xPlayerPositionMap] == '#' || _2DlevelMap[_yPlayerPositionMap + 1, _xPlayerPositionMap] == _zero)
                {

                }

                else
                {


                    _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.Transparent;
                    _yPlayerPosition++;
                    _yPlayerPositionMap++;

                    _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.DeepSkyBlue;


                }

                InitializePosition(_yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition);

                StartinArea(_pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
            }
        }


        public void PositionRight(PictureBox[,] _pbxGridMain, char[,] _2DlevelMap, int _yPlayerPositionMap, int _xPlayerPositionMap, int _yPlayerPosition, int _xPlayerPosition, char _zero)
        {

            if (_xPlayerPosition < 21)
            {
                if (_2DlevelMap[_yPlayerPositionMap, _xPlayerPositionMap + 1] == '#' || _2DlevelMap[_yPlayerPositionMap, _xPlayerPositionMap + 1] == _zero)
                {

                }

                else
                {
                    _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.Transparent;
                    _xPlayerPosition++;
                    _xPlayerPositionMap++;

                    _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.DeepSkyBlue;


                }

                InitializePosition(_yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition);

                StartinArea( _pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
            }
        }


        private void StartinArea(PictureBox[,] _pbxGridMain, char[,] _2DlevelMap, int _yPlayerPositionMap, int _xPlayerPositionMap, int _yPlayerPosition, int _xPlayerPosition, char _zero)
        {
            if (_2DlevelMap[_yPlayerPositionMap + 1, _xPlayerPositionMap] == '@' || _2DlevelMap[_yPlayerPositionMap, _xPlayerPositionMap + 1] == '@' || _2DlevelMap[_yPlayerPositionMap - 1, _xPlayerPositionMap] == '@' || _2DlevelMap[_yPlayerPositionMap, _xPlayerPositionMap - 1] == '@')
            {

                for (int _y = 5; _y < 9; _y++)
                {
                    for (int _x = 9; _x < 13; _x++)
                    {
                        _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.DeepSkyBlue;
                        _pbxGridMain[_y, _x].BackColor = Color.Black;
                    }
                }

            }
        }

    }
}
