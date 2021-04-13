using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class EnemyInitialization
    {
        readonly EnemyFactory _enemyFactory;
        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
    }
}
