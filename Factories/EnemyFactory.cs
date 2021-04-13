using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class EnemyFactory
    {
        private EnemyData _enemyData;

        public EnemyFactory(EnemyData enemy)
        {
            _enemyData = enemy;
        }
    }
}
