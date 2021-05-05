using UnityEngine;


namespace Pinball_MVC
{
    public sealed class EnemyCounterFactory
    {
        public readonly EnemyCounterData _enemyCounterData;
        public EnemyCounterFactory(EnemyCounterData enemyCounterData)
        {
            _enemyCounterData = enemyCounterData;
        }

        public GameObject CreateEnemyCounter()
        {
            return new GameObject("EnemyCounter");
        }
    }
    
}
