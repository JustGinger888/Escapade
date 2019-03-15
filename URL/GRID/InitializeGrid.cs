using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URL.GRID
{
    class InitializeGrid
    {



        protected int _mapYLineLoad = 0;
        protected int _mapXLineLoad = 0;

        protected int _gridMaxYSize;
        protected int _gridMaxXSize;
        protected int _gridDrawYCo;
        protected int _gridDrawXCo;
        protected int _gridSizeYCo;
        protected int _gridSizeXCo;
        protected int _gridDrawXCoNewLine;
        protected int _gridCurrentGridBuilding = 0;




        private PictureBox[,] GridSetup(PictureBox[,] _pbxgrid)
        {

            if (_gridCurrentGridBuilding == 0)
            {

                _gridMaxYSize = 14;
                _gridMaxXSize = 22;

                _gridDrawYCo = 5;
                _gridDrawXCo = 12;

                _gridSizeYCo = 22;
                _gridSizeXCo = 23;

                _gridDrawXCoNewLine = 12;

                _gridCurrentGridBuilding++;

                _pbxgrid = new PictureBox[_gridMaxYSize, _gridMaxXSize];

            }

            else if (_gridCurrentGridBuilding == 1)
            {

                _gridMaxYSize = 4;
                _gridMaxXSize = 4;

                _gridDrawYCo = 5;
                _gridDrawXCo = 5;

                _gridSizeYCo = 26;
                _gridSizeXCo = 26;

                _gridDrawXCoNewLine = 5;

                _gridCurrentGridBuilding++;

                _pbxgrid = new PictureBox[_gridMaxYSize, _gridMaxXSize];

            }

            return _pbxgrid;

        }



        public PictureBox[,] Grid(PictureBox[,] _pbxgrid)
        {


            GridSetup(_pbxgrid);

            // Y Axis Generation
            for (int y = 0; y < _gridMaxYSize; y++)
            {
                // X Axis Generation
                for (int x = 0; x < _gridMaxXSize; x++)
                {

                    _pbxgrid[y, x] = new PictureBox();
                    _pbxgrid[y, x].Location = new System.Drawing.Point(_gridDrawXCo, _gridDrawYCo);
                    _pbxgrid[y, x].Size = new System.Drawing.Size(_gridSizeXCo, _gridSizeYCo);
                    _pbxgrid[y, x].SizeMode = PictureBoxSizeMode.StretchImage;
                    //_pbxgrid[y, x].BorderStyle = BorderStyle.Fixed3D;
                    //_GridArrayTemp[y, x].BackColor = Color.DarkBlue;

                    //Controls.Add(_GridArrayTemp[y, x]);
                    _gridDrawXCo += _gridSizeXCo;

                }

                _gridDrawXCo = _gridDrawXCoNewLine;
                _gridDrawYCo += _gridSizeYCo;

            }




            return _pbxgrid;

        }




        /*/
        public void PlayableMapLoader()
        {

            //PlayableMapWriter();

            using (StreamReader reader = new StreamReader("LayoutGrid.txt"))
            {

                while (!reader.EndOfStream)
                {

                    string csvline = reader.ReadLine();

                    foreach (string value in csvline.Split(','))
                    {

                        //_playerMiniMapPosYco = 3;
                        //playerMiniMapPosXco = 3;

                        if (value == "1")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Green;

                        }

                        else if (value == "2")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Blue;

                        }

                        else if (value == "3")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Black;

                        }

                        else if (value == "4")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Red;

                        }

                        else if (value == "8")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Yellow;

                        }


                        _mapXLineLoad++;

                    }

                    _mapYLineLoad++;
                    _mapXLineLoad = 0;

                }
            }

        }
        */




    }
}
