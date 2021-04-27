using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class EnemyInitialization : IInitialization
    {
        readonly EnemyFactory _enemyFactory;
        private Transform _enemy;
        private float _enemyScreenScaleSize;
        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _enemyScreenScaleSize = _enemyFactory._enemyData.EnemyScreenScaleSize;
            _enemy = _enemyFactory.CreateEnemy();
            _enemy.gameObject.tag = "Obstacle";
            _enemy.gameObject.AddComponent<SpriteRenderer>().sprite = _enemyFactory._enemyData.Sprite;
            _enemy.gameObject.GetComponent<SpriteRenderer>().color = _enemyFactory._enemyData.Color;
            _enemy.gameObject.AddComponent<BoxCollider2D>().sharedMaterial = _enemyFactory._enemyData.Collider.sharedMaterial;
            _enemy.transform.localScale = new Vector2(Screen.width * _enemyScreenScaleSize, Screen.width * _enemyScreenScaleSize);
            _enemy.transform.position = new Vector2(UnityEngine.Random.Range(-Screen.width/2, Screen.width/2), UnityEngine.Random.Range(-Screen.height/2, Screen.height/2));           
        }

        public void Initialization()
        {

        }

    }
}
