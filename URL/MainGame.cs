using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using URL.MAP;
using URL.GRID;
using URL.ENTITY;
using URL.Player;
using System.Windows.Input;
using System.Media;
using URL.PathFinding;
using System.IO;
using URL.Enemies;

namespace URL
{
    public partial class MainGame : Form
    {

        SoundPlayer player = new SoundPlayer();
        SoundPlayer suprise = new SoundPlayer();

        protected PictureBox[,] _pbxGridMain = new PictureBox[14, 22];
        protected PictureBox[,] _pbxGridMini = new PictureBox[4, 4];
        protected PictureBox[] _playerHealthGrid = new PictureBox[Character._playerHealth];
        protected PictureBox[] _enemyHealthGrid = new PictureBox[Enemy._enemyHealth];

        bool _bulletCollide = true;

        bool _playerCollision = false;

        protected int[,] _levelPath = new int[4, 4];                    // Path Layout 
        protected char[,,] _3DLevelMapSections = new char[16, 12, 20];  // Map Layout for sections
        protected char[,] _2DlevelMap = new char[50, 82];               // Map Layout for 
        protected char[,] _2DlevelEntity = new char[50, 82];            // Map Layout for 
        protected char[,] _2DlevelPlayerEnemies = new char[50, 82];     // Map Layout for 
        protected char[,] _2DlevelPlayer = new char[50, 82];            // Map Layout for 
        protected char[,] _AStarMap = new char[50, 82];                 // Map Layout for 
        protected char[,] _bulletSectionMap = new char[50, 82];         // Map Layout for 

        public int _yPlayerPosition = 7;
        public int _xPlayerPosition = 11;

        public int _yPlayerPositionMap;
        public int _xPlayerPositionMap;

        public int _yEnemyPosition;
        public int _xEnemyPosition;

        //public int _yPreviousEnemyPositionMap;
        //public int _xPreviousEnemyPositionMap;

        public int _yEnemyPositionMap;
        public int _xEnemyPositionMap;

        public int _yBulletPositionMap;
        public int _xBulletPositionMap;

        public int _yPlayerMiniMapPosition;
        public int _xPlayerMiniMapPosition;

        public int _yEnemyMiniMapPosition;
        public int _xEnemyMiniMapPosition;

        public int _ySectionPositionMap;
        public int _xSectionPositionMap;

        public int _yBulletPosition;
        public int _xBulletPosition;

        public int _chestCompare = 0;

        public int _bulletCount = 0;

        char _zero = Convert.ToChar(0);

        CharacterMove _playerMove = new CharacterMove();
        CharacterCollision _characterCollision = new CharacterCollision();
        Character _player = new Character();

        Enemy _enemy = new Enemy();
        EnemyCollision _enemyCollide = new EnemyCollision();

        public static bool _gameIdle = false;

        bool _keyPressedIsUp;
        bool _keyPressedIsLeft;
        bool _keyPressedIsRight;
        bool _keyPressedIsDown;

        bool _attack = false;

        int _bulletCounter = 1;

        int _yCounterPositionMinus;
        int _yCounterPositionPlus;
        int _xCounterPositionMinus;
        int _xCounterPositionPlus;

        int _yCounterPositionMinusMap;
        int _yCounterPositionPlusMap;
        int _xCounterPositionMinusMap;
        int _xCounterPositionPlusMap;

        bool _sectionSwitch = false;

        bool _enemyCollided = false;




        public MainGame()
        {
            InitializeComponent();

            player.SoundLocation = "music.wav";

            suprise.SoundLocation = "Surprise.wav";
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            GameIdle();

            SetupGrid();

            InitialMapSetup();

            SetupMap();

            SetupPlayer();

            SetupEnemy();

            SetupPlayerStats();

            SetupPlayerHealth();

            SetupEnemyHealth();

        }




        /// <summary>
        /// 
        /// </summary>
        public void SetupGrid()
        {

            InitializeMap _initializeMap = new InitializeMap();

            _initializeMap.InitializeGrid();
            _initializeMap.AddMap3D(_3DLevelMapSections);
            _initializeMap.AddMap2D(_2DlevelMap);
            _initializeMap.AddPath(_levelPath);

            InitializeGrid _initializeGrid = new InitializeGrid();

            _initializeGrid.Grid(_pbxGridMain);
            _initializeGrid.Grid(_pbxGridMini);

            AddGridMain();
            AddGridMini();

        }




        /// <summary>
        /// 
        /// </summary>
        public void GameIdle()
        {

            if (_gameIdle == false)
            {
                _tmrInputCheck.Stop();
                _tmrEnemyMovement.Start();
                _tmrMovementCheck.Start();
                if (Questions._itemType == '0')
                {
                    pbx_MainItem.BackColor = Color.Red;
                }
                else if (Questions._itemType == '1')
                {
                    pbx_MainItem.BackColor = Color.Orange;
                }
                else if (Questions._itemType == '2')
                {
                    pbx_MainItem.BackColor = Color.Yellow;
                }
                else if (Questions._itemType == '3')
                {
                    pbx_MainItem.BackColor = Color.AliceBlue;
                }
                else if (Questions._itemType == '4')
                {
                    pbx_MainItem.BackColor = Color.Blue;
                }
                else if (Questions._itemType == '5')
                {
                    pbx_MainItem.BackColor = Color.LawnGreen;
                }
            }
            else
            {
               
                _tmrInputCheck.Start();
                _tmrEnemyMovement.Stop();
                _tmrMovementCheck.Stop();
            }

        }




        /// <summary>
        /// 
        /// </summary>
        public void InitialMapSetup()
        {

            LoadGrid loadGrid = new LoadGrid();
            _2DlevelEntity = loadGrid.LoadEntityGrid(_2DlevelEntity, _2DlevelMap);
            loadGrid.InitializeSectionMap(_2DlevelEntity, _levelPath, _2DlevelMap, _pbxGridMain, _pbxGridMini, _yPlayerMiniMapPosition, _xPlayerMiniMapPosition, _ySectionPositionMap, _xSectionPositionMap);

            _yPlayerMiniMapPosition = loadGrid.AddMiniMapY(_yPlayerMiniMapPosition);
            _xPlayerMiniMapPosition = loadGrid.AddMiniMapX(_xPlayerMiniMapPosition);

            _ySectionPositionMap = loadGrid.AddMiniSectionY(_ySectionPositionMap);
            _xSectionPositionMap = loadGrid.AddMiniSectionX(_xSectionPositionMap);

        }




        /// <summary>
        /// 
        /// </summary>
        public void SetupMap()
        {

            LoadGrid loadGrid = new LoadGrid();
            loadGrid.InitializeSectionMap(_2DlevelEntity, _levelPath, _2DlevelMap, _pbxGridMain, _pbxGridMini, _yPlayerMiniMapPosition, _xPlayerMiniMapPosition, _ySectionPositionMap, _xSectionPositionMap);

            _ySectionPositionMap = loadGrid.AddMiniSectionY(_ySectionPositionMap);
            _xSectionPositionMap = loadGrid.AddMiniSectionX(_xSectionPositionMap);

        }




        /// <summary>
        /// 
        /// </summary>
        public void SetupPlayer()
        {

            _player.InitializePlayer(_ySectionPositionMap, _xSectionPositionMap);
            _yPlayerPositionMap = _player.PlayerPositionMapY(_yPlayerPositionMap);
            _xPlayerPositionMap = _player.PlayerPositionMapX(_xPlayerPositionMap);
            _tmrMovementCheck.Interval = _player.interval;

        }




        /// <summary>
        /// 
        /// </summary>
        public void SetupEnemy()
        {

            _enemy.InitializeEnemy(_2DlevelMap);
            _yEnemyPositionMap = _enemy.EnemyPositionMapY(_yEnemyPositionMap);
            _xEnemyPositionMap = _enemy.EnemyPositionMapX(_xEnemyPositionMap);

            //_yPreviousEnemyPositionMap = _yEnemyPositionMap;
            //_xPreviousEnemyPositionMap = _xEnemyPositionMap;

        }




        /// <summary>
        /// 
        /// </summary>
        public void SetupPlayerStats()
        {

            _BombCount.Text = "Bombs:" + Convert.ToString(Character._bomb);
            _KeyCount.Text = "Keys:" + Convert.ToString(Character._key);
            _ChestCount.Text = "Chests:" + Convert.ToString(Character._chest);
            _CoinCount.Text = "Coins:" + Convert.ToString(Character._coin);

            if (Character._chest > _chestCompare)
            {
                _chestCompare = Character._chest;
                Questions questions = new Questions();
                questions.Show();

                GameIdle();
            }

        }




        /// <summary>
        /// 
        /// </summary>
        public void SetupPlayerHealth()
        {
            CharacterHealthGrid characterHealthGrid = new CharacterHealthGrid();
            _playerHealthGrid = characterHealthGrid.AddCharacterHealthGrid(_playerHealthGrid);

            _pnlCharacterHealthGrid.Controls.Clear();
            for (int _y = 0; _y < Character._playerHealth; _y++)
            {

                _pnlCharacterHealthGrid.Controls.Add(_playerHealthGrid[_y]);

            }
        }




        /// <summary>
        /// 
        /// </summary>
        public void SetupEnemyHealth()
        {
            EnemyHealthGrid enemyHealthGrid = new EnemyHealthGrid();
            _enemyHealthGrid = enemyHealthGrid.AddEnemyHealthGrid(_enemyHealthGrid);

            _pnlEnemyHealthGrid.Controls.Clear();
            for (int _y = 0; _y < Enemy._enemyHealth; _y++)
            {

                _pnlEnemyHealthGrid.Controls.Add(_enemyHealthGrid[_y]);

            }
        }




        /// <summary>
        /// 
        /// </summary>
        private void AddGridMain()
        {
            // Y Axis Generation
            for (int _y = 0; _y < 14; _y++)
            {
                // X Axis Generation
                for (int _x = 0; _x < 22; _x++)
                {
                    _GridMainMap.Controls.Add(_pbxGridMain[_y, _x]);
                }
            }

        }




        /// <summary>
        /// 
        /// </summary>
        private void AddGridMini()
        {
            // Y Axis Generation
            for (int _y = 0; _y < 4; _y++)
            {
                // X Axis Generation
                for (int _x = 0; _x < 4; _x++)
                {
                    _GridMiniMap.Controls.Add(_pbxGridMini[_y, _x]);
                }
            }

        }




        /// <summary>
        /// 
        /// </summary>
        public void PlayerSectionSwitch()
        {
            // My Map Is Setup to display the current section plus an external squre of the surrounding sections
            // When the player reaches the end of a section, their position is switched in the display map to show them in the section they are now bordering
            // This initial if statement checks if the player is entering the left bbordering room.
            if (_yPlayerPosition == 0)
            {
                // If this occur the MiniMap Updates to display the Section youre in at the moment
                _yPlayerMiniMapPosition--;
                // The player position on the display gets set to the edge of the screen
                _yPlayerPosition = 12;
                //The Map It setup and displays the new section youre in at that moment
                SetupMap();
            }
            //It repeats this depending on the position the player is at
            else if (_yPlayerPosition == 13)
            {
                _yPlayerMiniMapPosition++;
                _yPlayerPosition = 1;
                SetupMap();
            }
            else if (_xPlayerPosition == 0)
            {
                _xPlayerMiniMapPosition--;
                _xPlayerPosition = 20;
                SetupMap();
            }
            else if (_xPlayerPosition == 21)
            {
                _xPlayerMiniMapPosition++;
                _xPlayerPosition = 1;
                SetupMap();
            }
            //The Player is displayed on the new section
            _pbxGridMini[_yPlayerMiniMapPosition, _xPlayerMiniMapPosition].BackColor = Color.OrangeRed;

        }




        /// <summary>
        /// 
        /// </summary>
        public void EnemySectionSwitch()
        {

            if (_yEnemyPositionMap < 13)
            {
                _yEnemyMiniMapPosition = 0;
            }
            else if (_yEnemyPositionMap < 25)
            {
                _yEnemyMiniMapPosition = 1;
            }
            else if (_yEnemyPositionMap < 37)
            {
                _yEnemyMiniMapPosition = 2;
            }
            else if (_yEnemyPositionMap < 50)
            {
                _yEnemyMiniMapPosition = 3;
            }

            if (_xEnemyPositionMap < 21)
            {
                _xEnemyMiniMapPosition = 0;
            }
            else if (_xEnemyPositionMap < 41)
            {
                _xEnemyMiniMapPosition = 1;
            }
            else if (_xEnemyPositionMap < 61)
            {
                _xEnemyMiniMapPosition = 2;
            }
            else if (_xEnemyPositionMap < 82)
            {
                _xEnemyMiniMapPosition = 3;
            }

            _pbxGridMini[_yEnemyMiniMapPosition, _xEnemyMiniMapPosition].BackColor = Color.DarkOrchid;

        }




        /// <summary>
        /// 
        /// </summary>
        public void EnemyLoad()
        {
            EnemySectionSwitch();

            if (_yEnemyMiniMapPosition == _yPlayerMiniMapPosition && _xEnemyMiniMapPosition == _xPlayerMiniMapPosition)
            {
                _pbxGridMain[_yEnemyPositionMap - _ySectionPositionMap, _xEnemyPositionMap - _xSectionPositionMap].BackColor = Color.Red;
            }
        }




        /// <summary>
        /// 
        /// </summary>
        public void EnemyTransparent()
        {
            EnemySectionSwitch();

            if (_yEnemyMiniMapPosition == _yPlayerMiniMapPosition && _xEnemyMiniMapPosition == _xPlayerMiniMapPosition)
            {
                _pbxGridMain[_yEnemyPositionMap - _ySectionPositionMap, _xEnemyPositionMap - _xSectionPositionMap].BackColor = Color.Transparent;
            }

        }




        /// <summary>
        /// 
        /// </summary>
        private void EnemyMove()
        {

            if (AStar.map[_yEnemyPositionMap - 1, _xEnemyPositionMap] == '*')
            {
                _2DlevelPlayerEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';
                EnemyTransparent();
                _yEnemyPositionMap--;
            }
            else if (AStar.map[_yEnemyPositionMap + 1, _xEnemyPositionMap] == '*')
            {
                _2DlevelPlayerEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';

                EnemyTransparent();

                _yEnemyPositionMap++;
            }
            else if (AStar.map[_yEnemyPositionMap, _xEnemyPositionMap - 1] == '*')
            {
                _2DlevelPlayerEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';
                EnemyTransparent();
                _xEnemyPositionMap--;
            }
            else if (AStar.map[_yEnemyPositionMap, _xEnemyPositionMap + 1] == '*')
            {
                _2DlevelPlayerEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';
                EnemyTransparent();
                _xEnemyPositionMap++;
            }

        }




        /// <summary>
        /// 
        /// </summary>
        private void EnemyCollided()
        {

            if (_enemyCollided == true)
            {
                SetupEnemyHealth();
                _enemyCollided = false;

                if (Enemy._enemyHealth == 0)
                {
                    _tmrEnemyMovement.Stop();
                    _pbxGridMain[_yEnemyPositionMap - _ySectionPositionMap, _xEnemyPositionMap - _xSectionPositionMap].BackColor = Color.Aqua;
                }
            }

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void _tmrMovementCheck_Tick(object sender, EventArgs e)
        {

            _2DlevelPlayer[_yPlayerPositionMap, _xPlayerPositionMap] = 'P';
            _pbxGridMain[_yPlayerPosition, _xPlayerPosition].BackColor = Color.DeepSkyBlue;


            _playerCollision = _characterCollision.EnemyCollision(_2DlevelPlayerEnemies, _yPlayerPositionMap, _xPlayerPositionMap, _playerCollision);

            if (_playerCollision == true)
            {
                _playerCollision = false;
                SetupPlayerHealth();

                if (Character._playerHealth == 0)
                {
                    _gameIdle = true;
                    GameIdle();
                    _GridMainMap.Controls.Clear();
                    _GridMainMap.BackgroundImage = Image.FromFile("InkedGameOver_LI.jpg");
                    _GridMainMap.Controls.Add(_lblRetry);
                    _lblRetry.Visible = true;
                }
            }

            if (Keyboard.IsKeyDown(Key.W))
            {
                _2DlevelPlayer[_yPlayerPositionMap, _xPlayerPositionMap] = ' ';

                _playerMove.PositionUp(_pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
                _yPlayerPositionMap = _playerMove._yPlayerPositionMapMove;
                _xPlayerPositionMap = _playerMove._xPlayerPositionMapMove;
                _yPlayerPosition = _playerMove._yPlayerPositionMove;
                _xPlayerPosition = _playerMove._xPlayerPositionMove;

                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity, _yPlayerPositionMap, _xPlayerPositionMap);


                    if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }

            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                _2DlevelPlayer[_yPlayerPositionMap, _xPlayerPositionMap] = ' ';

                _playerMove.PositionLeft(_pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
                _yPlayerPositionMap = _playerMove._yPlayerPositionMapMove;
                _xPlayerPositionMap = _playerMove._xPlayerPositionMapMove;
                _yPlayerPosition = _playerMove._yPlayerPositionMove;
                _xPlayerPosition = _playerMove._xPlayerPositionMove;

                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity, _yPlayerPositionMap, _xPlayerPositionMap);

                if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }

            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                _2DlevelPlayer[_yPlayerPositionMap, _xPlayerPositionMap] = ' ';

                _playerMove.PositionDown(_pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
                _yPlayerPositionMap = _playerMove._yPlayerPositionMapMove;
                _xPlayerPositionMap = _playerMove._xPlayerPositionMapMove;
                _yPlayerPosition = _playerMove._yPlayerPositionMove;
                _xPlayerPosition = _playerMove._xPlayerPositionMove;

                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity, _yPlayerPositionMap, _xPlayerPositionMap);

                if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }

            }
            else if (Keyboard.IsKeyDown(Key.D))
            {

                _2DlevelPlayer[_yPlayerPositionMap, _xPlayerPositionMap] = ' ';

                _playerMove.PositionRight(_pbxGridMain, _2DlevelMap, _yPlayerPositionMap, _xPlayerPositionMap, _yPlayerPosition, _xPlayerPosition, _zero);
                _yPlayerPositionMap = _playerMove._yPlayerPositionMapMove;
                _xPlayerPositionMap = _playerMove._xPlayerPositionMapMove;
                _yPlayerPosition = _playerMove._yPlayerPositionMove;
                _xPlayerPosition = _playerMove._xPlayerPositionMove;

                _playerCollision = _characterCollision.ItemCollision(_2DlevelEntity, _yPlayerPositionMap, _xPlayerPositionMap);

                if (_playerCollision == true)
                {
                    SetupPlayerStats();
                }

            }

            if (_attack == false)
            {
                _yBulletPositionMap = _yPlayerPositionMap;
                _xBulletPositionMap = _xPlayerPositionMap;
                _yBulletPosition = _yPlayerPosition;
                _xBulletPosition = _xPlayerPosition;

                if (Keyboard.IsKeyDown(Key.Right))
                {
                    _attack = true;
                    _keyPressedIsRight = true;

                    _tmrBulletCheck.Start();

                }
                else if (Keyboard.IsKeyDown(Key.Left))
                {
                    _attack = true;
                    _keyPressedIsLeft = true;

                    _tmrBulletCheck.Start();
                }
                else if (Keyboard.IsKeyDown(Key.Up))
                {
                    _attack = true;
                    _keyPressedIsUp = true;

                    _tmrBulletCheck.Start();
                }
                else if (Keyboard.IsKeyDown(Key.Down))
                {
                    _attack = true;
                    _keyPressedIsDown = true;

                    _tmrBulletCheck.Start();
                }

            }
            PlayerSectionSwitch();

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrEnemyMovement_Tick(object sender, EventArgs e)
        {

            _2DlevelPlayerEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = 'E';
            EnemyMove();
            EnemyLoad();
            EnemyCollided();

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrInputCheck_Tick(object sender, EventArgs e)
        {

            GameIdle();

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrBulletCheck_Tick(object sender, EventArgs e)
        {
            // Ensuring that the player is not out of bounds and can fire a projectile in the game
            if (_yPlayerPosition > 0 && _yPlayerPosition < 14 && _xPlayerPosition > 0 && _xPlayerPosition < 22)
            {
                //Setting up the initial variables for the bullet
                _yCounterPositionMinusMap = _yBulletPositionMap - _bulletCounter;
                _yCounterPositionPlusMap = _yBulletPositionMap + _bulletCounter;
                _xCounterPositionMinusMap = _xBulletPositionMap - _bulletCounter;
                _xCounterPositionPlusMap = _xBulletPositionMap + _bulletCounter;
                _yCounterPositionMinus = _yBulletPosition - _bulletCounter;
                _yCounterPositionPlus = _yBulletPosition + _bulletCounter;
                _xCounterPositionMinus = _xBulletPosition - _bulletCounter;
                _xCounterPositionPlus = _xBulletPosition + _bulletCounter;
                // Where,Depending on the input key, The bullet is displayed
                if (_bulletCounter <= 3)
                {
                    //Checking Which key has been pressed
                    if (_keyPressedIsUp == true)
                    {

                        if (_2DlevelMap[_yCounterPositionMinusMap, _xBulletPositionMap] != '.' || _2DlevelEntity[_yCounterPositionMinusMap, _xBulletPositionMap] != _zero)
                        {
                            _bulletCollide = true;
                        }
                        else
                        {
                            _bulletSectionMap[_yCounterPositionMinusMap, _xBulletPositionMap] = 'B';

                            if (_yCounterPositionMinus == -1)
                            {
                                _bulletCollide = true;
                            }
                            else if (_yCounterPositionMinus == 0)
                            {
                                //_pbxGridMain[_yCounterPositionMinus, _xBulletPosition].BackColor = Color.WhiteSmoke;
                                _pbxGridMain[_yCounterPositionMinus, _xBulletPosition].BackColor = Color.Transparent;

                                _bulletCollide = true;
                            }
                            else
                            {
                                _pbxGridMain[_yCounterPositionMinus, _xBulletPosition].BackColor = Color.WhiteSmoke;
                            }

                            if (_bulletCounter > 1)
                            {
                                _pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                            }
                        }

                    }
                    else if (_keyPressedIsRight == true)
                    {

                        if (_2DlevelMap[_yBulletPositionMap, _xCounterPositionPlusMap] != '.' || _2DlevelEntity[_yBulletPositionMap, _xCounterPositionPlusMap] != _zero)
                        {
                            _bulletCollide = true;
                        }
                        else
                        {
                            _bulletSectionMap[_yBulletPositionMap, _xCounterPositionPlusMap] = 'B';

                            if (_xCounterPositionPlus >= 22)
                            {
                                _bulletCollide = true;
                            }
                            else if (_xCounterPositionPlus == 21)
                            {
                                //_pbxGridMain[_yBulletPosition, _xCounterPositionPlus].BackColor = Color.WhiteSmoke;
                                _pbxGridMain[_yBulletPosition, _xCounterPositionPlus].BackColor = Color.Transparent;

                                _bulletCollide = true;
                            }
                            else
                            {
                                _pbxGridMain[_yBulletPosition, _xCounterPositionPlus].BackColor = Color.WhiteSmoke;
                            }

                            if (_bulletCounter > 1)
                            {
                                _pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                            }
                        }
                    }
                    else if (_keyPressedIsLeft == true)
                    {

                        if (_2DlevelMap[_yBulletPositionMap, _xCounterPositionMinusMap] != '.' || _2DlevelEntity[_yBulletPositionMap, _xCounterPositionMinusMap] != _zero)
                        {
                            _bulletCollide = true;
                        }
                        else
                        {
                            _bulletSectionMap[_yBulletPositionMap, _xCounterPositionMinusMap] = 'B';
                            if (_xCounterPositionMinus == -1)
                            {
                                _bulletCollide = true;
                            }
                            else if (_xCounterPositionMinus == 0)
                            {
                                //_pbxGridMain[_yBulletPosition, _xCounterPositionMinus].BackColor = Color.WhiteSmoke;
                                _pbxGridMain[_yBulletPosition, _xCounterPositionMinus].BackColor = Color.Transparent;

                                _bulletCollide = true;
                            }
                            else
                            {
                                _pbxGridMain[_yBulletPosition, _xCounterPositionMinus].BackColor = Color.WhiteSmoke;
                            }

                            if (_bulletCounter > 1)
                            {
                                _pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                            }
                        }
                    }
                    else if (_keyPressedIsDown == true)
                    {

                        if (_2DlevelMap[_yCounterPositionPlusMap, _xBulletPositionMap] != '.' || _2DlevelEntity[_yCounterPositionPlusMap, _xBulletPositionMap] != _zero)
                        {
                            _bulletCollide = true;
                        }
                        else
                        {
                            _bulletSectionMap[_yCounterPositionPlusMap, _xBulletPositionMap] = 'B';

                            if (_yCounterPositionPlus == 14)
                            {
                                _bulletCollide = true;
                            }
                            else if (_yCounterPositionPlus == 13)
                            {
                                //_pbxGridMain[_yCounterPositionPlus, _xBulletPosition].BackColor = Color.WhiteSmoke;
                                _pbxGridMain[_yCounterPositionPlus, _xBulletPosition].BackColor = Color.Transparent;

                                _bulletCollide = true;
                            }
                            else
                            {
                                _pbxGridMain[_yCounterPositionPlus, _xBulletPosition].BackColor = Color.WhiteSmoke;
                            }

                            if (_bulletCounter > 1)
                            {
                                _pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                            }

                        }
                    }
                    //The bullet incriments to be displayed one tile further
                    _bulletCounter++;
                }
                //Where the bullet reaches an end and becomes transparent
                else if (_bulletCounter == 4)
                {
                    //Clearing the bullet depending on direction
                    if (_keyPressedIsUp == true)
                    {
                        _keyPressedIsUp = false;
                        _attack = false;

                        _pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                    }
                    else if (_keyPressedIsRight == true)
                    {
                        _keyPressedIsRight = false;
                        _attack = false;

                        _pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                    }
                    else if (_keyPressedIsLeft == true)
                    {
                        _keyPressedIsLeft = false;
                        _attack = false;

                        _pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                    }
                    else if (_keyPressedIsDown == true)
                    {
                        _keyPressedIsDown = false;
                        _attack = false;

                        _pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                    }
                    //Saying that the bullet did not collide with any object
                    _bulletCollide = false;
                    _bulletCounter = 1;
                    //checking if the bullet has colided with an enemy in before dissapearing completely
                    _enemyCollided = _enemyCollide.EnemyCollide(_bulletSectionMap, _yEnemyPositionMap, _xEnemyPositionMap, _enemyCollided);
                    //Clearing the bullet array and allowing for another one to be fired
                    Array.Clear(_bulletSectionMap, 0, _bulletSectionMap.Length);
                    //Stoping the timer which conrols the bullet
                    _tmrBulletCheck.Stop();
                }
                //Logic which dictates what happens when bullets collide with other objects
                if (_bulletCollide == true)
                {

                    if (_keyPressedIsUp == true)
                    {
                        _keyPressedIsUp = false;
                        _attack = false;

                        if (_yCounterPositionMinus == -1)
                        {

                        }
                        else if (_yCounterPositionMinus == 0)
                        {
                            _pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                        }
                        else
                        {
                            _pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                        }
                    }
                    else if (_keyPressedIsRight == true)
                    {
                        _keyPressedIsRight = false;
                        _attack = false;
                        if (_xCounterPositionPlus == 22)
                        {

                        }
                        else if (_xCounterPositionPlus == 19)
                        {
                            _pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                        }
                        else
                        {
                            _pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                        }
                    }
                    else if (_keyPressedIsLeft == true)
                    {
                        _keyPressedIsLeft = false;
                        _attack = false;

                        if (_xCounterPositionMinus == -1)
                        {

                        }
                        else if (_xCounterPositionMinus == 0)
                        {
                            _pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                        }
                        else
                        {
                            _pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                        }
                    }
                    else if (_keyPressedIsDown == true)
                    {
                        _keyPressedIsDown = false;
                        _attack = false;

                        if (_yCounterPositionPlus == 14)
                        {

                        }
                        else if (_yCounterPositionPlus == 14)
                        {
                            _pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                        }
                        else
                        {
                            _pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                        }
                    }

                    _enemyCollided = _enemyCollide.EnemyCollide(_bulletSectionMap, _yEnemyPositionMap, _xEnemyPositionMap, _enemyCollided);
                    Array.Clear(_bulletSectionMap, 0, _bulletSectionMap.Length);

                    _bulletCollide = false;

                    _bulletCounter = 1;
                    _tmrBulletCheck.Stop();
                }



            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _tmrAStar_Tick(object sender, EventArgs e)
        {
            _AStarMap = _enemy.AStarPathMapWriter(_2DlevelMap, _AStarMap, _2DlevelEntity, _2DlevelPlayerEnemies, _2DlevelPlayer);
            AStar.map = _AStarMap;
            AStar.PathFinder(_yPlayerPositionMap, _xPlayerPositionMap, _yEnemyPositionMap, _xEnemyPositionMap);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _lblRetry_Click(object sender, EventArgs e)
        {

            Application.Restart();


        }
    }
}