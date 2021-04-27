using System;
using UnityEngine;

namespace Pinball_MVC
{
    public class BallController : MonoBehaviour, IExecute
    {
        private readonly Transform _player;
        private readonly Transform _startingBall;
        private float _scaler = 5.625f;

        public event Action<int> CountChange = delegate (int count) { };
        public BallController(Transform player, Transform startingball)
        {
            _player = player;
            _startingBall = startingball;
            _startingBall.position = new Vector2(0, Screen.width / _scaler);
            _startingBall.transform.parent = _player;
            _startingBall.gameObject.AddComponent<BallController>();
        }
        public void Execute(float deltaTime)
        {
            
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                collision.gameObject.SetActive(false);
                CountChange.Invoke(1);
            }
        }
    }
}
