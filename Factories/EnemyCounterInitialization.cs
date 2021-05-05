using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Pinball_MVC
{
    public sealed class EnemyCounterInitialization : IInitialization
    {
        public readonly EnemyCounterFactory _enemyCounterFactory;
        private GameObject _counterGameObject;
        private Text _counterText;
        private RectTransform _counterRectTransform;
        private float _fontSizeScaler = 15.0f;
        public BallController _ballController;
        public event Action<int> BonusInvoke = delegate (int randomBonusNumber) { };

        public EnemyCounterInitialization(EnemyCounterFactory counterFactory,BallController ballController)
        {
            var canvas = new GameObject("Canvas");
            canvas.AddComponent<Canvas>();
            canvas.transform.localScale = new Vector2(Screen.width, Screen.height);
            canvas.transform.position = Vector2.zero;

            _enemyCounterFactory = counterFactory;
            _counterGameObject = _enemyCounterFactory.CreateEnemyCounter();
            _counterGameObject.transform.parent = canvas.transform;

            _counterText = _counterGameObject.AddComponent<Text>();
            _counterText.text = _enemyCounterFactory._enemyCounterData.Count.ToString();
            _counterText.font = _enemyCounterFactory._enemyCounterData.Font;
            _counterText.color = _enemyCounterFactory._enemyCounterData.Color;
            _counterText.fontSize = Mathf.RoundToInt(Screen.width / _fontSizeScaler);
            _counterText.alignment = TextAnchor.LowerCenter;

            _counterRectTransform = _counterText.GetComponent<RectTransform>();
            _counterRectTransform.localPosition = new Vector2(0, -0.45f);
            _counterRectTransform.sizeDelta = new Vector2(Screen.width / 10, Screen.width / 10);

            _ballController = ballController;
            _ballController.EnemyCountChange += CountChange;
        }

        public void CountChange(int count)
        {
            var counter = Convert.ToInt32(_counterText.text);
            counter -= count;
            _counterText.text = counter.ToString();
            if (counter%3 == 0)
            {
                BonusInvoke.Invoke(Random.Range(0,3));
            }
        }

        public void Initialization()
        {

        }

    }
}
