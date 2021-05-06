using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class BallController : MonoBehaviour, IExecute
    {
        private  Transform _player;
        private  Transform _startingBall;
        private float _scaler = 5.625f;

        public event Action<int> EnemyCountChange = delegate (int count) { };
        public event Action<int> BounceCountChange = delegate (int count) { };
        public event Action<bool> IsGameOver = delegate (bool isGameOver) { };

        public void SetPosition(Transform player, Transform startingball)
        {
            _player = player;
            _startingBall = startingball;
            _startingBall.gameObject.tag = "Ball";
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
                EnemyCountChange.Invoke(1);
            }

            if (collision.gameObject.tag == "Bonus")
            {
                var bonus = FindObjectOfType<BonusInitialization>();
                if (bonus._bonusType == 0)
                {
                    BounceCountChange.Invoke(-20);
                }
                else if (bonus._bonusType == 1)
                {
                    var _ballVelocity = _startingBall.gameObject.GetComponent<Rigidbody2D>().velocity * 2;
                    _startingBall.GetComponent<Rigidbody2D>().velocity = _ballVelocity;
                }
                else if (bonus._bonusType == 2)
                {
                    BounceCountChange.Invoke(5);
                }
                collision.gameObject.SetActive(false);
                
            }

            if (collision.gameObject.tag == "Bounce")
            {
                BounceCountChange.Invoke(1);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _startingBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            IsGameOver.Invoke(true);
        }
    }
}
