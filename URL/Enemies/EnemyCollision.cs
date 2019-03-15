using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.Enemies
{

    /// <summary>
    /// 
    /// </summary>
    class EnemyCollision : Enemy
    {

        public bool EnemyCollide(char[,] _bulletSectionMap, int _yEnemyPositionMap, int _xEnemyPositionMap, bool _enemyCollided)
        {

            if (_bulletSectionMap[_yEnemyPositionMap, _xEnemyPositionMap] == 'B')
            {

                _enemyHealth --;
                _enemyCollided = true;

            }
            return _enemyCollided;
        }
        
    }

}
