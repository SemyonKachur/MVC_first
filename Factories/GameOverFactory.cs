using UnityEngine;

namespace Pinball_MVC
{
    public sealed class GameOverFactory
    {
        public readonly GameOverData _gameOverData;

        public GameOverFactory(GameOverData gameOverData)
        {
            _gameOverData = gameOverData;
        }

        public GameObject CreateGameOverMenu()
        {
            return new GameObject("GameOver");
        }
    }
}
