using UnityEngine;

namespace Pinball_MVC
{

    public class StartingBallController : IExecute
    {
        private readonly Transform _player;
        private readonly Transform _startingBall;
        private float _scaler = 5.625f;

        public StartingBallController(Transform player, Transform startingball)
        {
            _player = player;
            _startingBall = startingball;
            _startingBall.position = new Vector2(0, Screen.width / _scaler);
            _startingBall.transform.parent = _player;
        }
        public void Execute(float deltaTime)
        {

        }
    }
}
