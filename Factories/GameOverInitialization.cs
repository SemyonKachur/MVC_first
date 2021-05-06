using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pinball_MVC
{
    public sealed class GameOverInitialization : IInitialization
    {
        public readonly GameOverFactory _gameOverFactory;
        private GameObject _gameOverGameObject;
        private Text _gameOverText;
        private RectTransform _gameOverRectTransform;
        private float _fontSizeScaler = 5.0f;
        private bool _isGameOver = false;

        private GameObject _bounceCounter;
        private GameObject _enemyCounter;
        private Transform _player;
        private BallController _ballController;
        private BounceCounterInitialization _bounceCounterInitialization;
        private EnemyCounterInitialization _enemyCounterInitialization;

        public bool IsGameOver
        {
            get
            {
                return _isGameOver;
            }
            set
            {
                _isGameOver = value;
                if (IsGameOverChanged != null)
                {
                    GameOverBoolChanged();
                }
            }
        }

        public event Action IsGameOverChanged = delegate () { };

        public GameOverInitialization(GameOverFactory gameOverFactory, BallController ballController,
                                      GameObject bounceCounter, GameObject enemyCounter, Transform player, 
                                      BounceCounterInitialization bounceCounterInitialization, EnemyCounterInitialization enemyCounterInitialization)
        {
            _gameOverFactory = gameOverFactory;
            _ballController = ballController;
            _player = player;
            _enemyCounter = enemyCounter;
            _bounceCounter = bounceCounter;
            _bounceCounterInitialization = bounceCounterInitialization;
            _enemyCounterInitialization = enemyCounterInitialization;

            var canvas = GameObject.Find("Canvas");
            _gameOverGameObject = _gameOverFactory.CreateGameOverMenu();
            _gameOverGameObject.transform.parent = canvas.transform;

            _gameOverText = _gameOverGameObject.gameObject.AddComponent<Text>();
            _gameOverText.text = "Game Over!";
            _gameOverText.font = _gameOverFactory._gameOverData.Font;
            _gameOverText.color = _gameOverFactory._gameOverData.Color;
            _gameOverText.fontSize = Mathf.RoundToInt(Screen.width / 8);
            _gameOverText.alignment = TextAnchor.MiddleCenter;

            _gameOverRectTransform = _gameOverText.GetComponent<RectTransform>();
            _gameOverRectTransform.localPosition = Vector2.zero;
            _gameOverRectTransform.sizeDelta = new Vector2(Screen.width, Screen.width / _fontSizeScaler);
            _gameOverRectTransform.gameObject.SetActive(false);

            _ballController.IsGameOver += ChangeIsGameOverBool;
            _bounceCounterInitialization.IsGameOver += ChangeIsGameOverBool;
            _enemyCounterInitialization.Victory += ChangeIsGameOverBoolForWin;
        }

        private void GameOverBoolChanged()
        {
            if(_isGameOver == true)
            {
                _gameOverGameObject.gameObject.SetActive(true);
                _enemyCounter.gameObject.SetActive(false);
                _bounceCounter.gameObject.SetActive(false);
                _ballController.gameObject.SetActive(false);
                _player.gameObject.SetActive(false);
            }
        }
        private void ChangeIsGameOverBool(bool isGameOver)
        {
            IsGameOver = isGameOver;
        }

        private void ChangeIsGameOverBoolForWin(string victoryText,bool isGameOver)
        {
            IsGameOver = isGameOver;
            _gameOverGameObject.gameObject.GetComponent<Text>().text = victoryText;
        }
        public void Initialization()
        {

        }
    }
}
