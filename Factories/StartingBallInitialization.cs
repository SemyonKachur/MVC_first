using UnityEngine;

namespace Pinball_MVC {

    public class StartingBallInitialization : IInitialization
    {
        private BallData _startingBallData;
        private StartingBallFactory _startingBallFactory;
        private Transform _player;
        private Transform _startingBall;
        private float _scaler = 0.1f;
        private float _ballScreenScaleSize;

        public StartingBallInitialization(StartingBallFactory ballFactory, Transform player, Vector2 ballPosition)
        {
            _startingBallFactory = ballFactory;
            _ballScreenScaleSize = _startingBallFactory._ballData.BallScreenScaleSize;
            _player = player;
            _startingBall = _startingBallFactory.CreateStartingBall();
            _startingBall.gameObject.tag = "Ball";
            _startingBall.gameObject.AddComponent<SpriteRenderer>().sprite = _startingBallFactory._ballData.Sprite;
            _startingBall.gameObject.GetComponent<SpriteRenderer>().color = _startingBallFactory._ballData.Color;
            _startingBall.gameObject.AddComponent<CircleCollider2D>().sharedMaterial = _startingBallFactory._ballData.Collider.sharedMaterial;
            _startingBall.gameObject.AddComponent<Rigidbody2D>().sharedMaterial = _startingBallFactory._ballData.Rigidbody.sharedMaterial;
            _startingBall.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            
            Scaler();
        }
        private void Scaler()
        {
            var Sprite = _startingBall.GetComponent<SpriteRenderer>().sprite;
            var _spriteWidth = Sprite.rect.width;
            Scaler spriteScale = new Scaler(_spriteWidth, _scaler,_ballScreenScaleSize);
            _startingBall.transform.localScale = new Vector3(spriteScale._spriteScale, spriteScale._spriteScale, 1);
        }

        public Transform GetBall()
        {
            return _startingBall;
        }
        public void Initialization()
        {

        }
    }
}