using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class EnemyFactory
    {
        public readonly EnemyData _enemyData;

        public EnemyFactory(EnemyData enemy)
        {
            _enemyData = enemy;
        }

        public Transform CreateEnemy()
        {
            return new GameObject("Obstacle").transform;
        }
    }
}
