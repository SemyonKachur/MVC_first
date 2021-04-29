using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class BallController : MonoBehaviour, IExecute
    {
        private  Transform _player;
        private  Transform _startingBall;
        private float _scaler = 5.625f;


        public event Action<int> CountChange = delegate (int count) { };
        //public BallController(Transform player, Transform startingball)
        //{
        //    _player = player;
        //    _startingBall = startingball;
        //    _startingBall.position = new Vector2(0, Screen.width / _scaler);
        //    _startingBall.transform.parent = _player;
        //}

        public void SetPosition(Transform player, Transform startingball)
        {
            _player = player;
            _startingBall = startingball;
            _startingBall.position = new Vector2(0, Screen.width / _scaler);
            _startingBall.transform.parent = _player;
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

            if (collision.gameObject.tag == "Bonus")
            {
                collision.gameObject.SetActive(false);
                CountChange.Invoke(1);
            }
        }
    }
}
