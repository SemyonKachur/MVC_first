using UnityEngine;

namespace Pinball_MVC
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private readonly PlayerFactory _playerFactory;
        private Transform _player;

        public PlayerInitialization(PlayerFactory playerFactory, Vector2 positionPlayer)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
            _player.position = positionPlayer;
            _player.gameObject.AddComponent<SpriteRenderer>().sprite = _playerFactory._playerData.Sprite;
            _player.gameObject.GetComponent<SpriteRenderer>().color = _playerFactory._playerData.Color;

            _player.gameObject.AddComponent<PolygonCollider2D>();
            _player.gameObject.GetComponent<PolygonCollider2D>().points = _playerFactory._playerData.Collider.points;
            _player.gameObject.GetComponent<PolygonCollider2D>().sharedMaterial = _playerFactory._playerData.Collider.sharedMaterial;

            SpriteScaler();
        }

        public void Initialization()
        {

        }

        private void SpriteScaler()
        {
            var Sprite = _player.GetComponent<SpriteRenderer>().sprite;
            var _spriteWidth = Sprite.rect.width;
            Scaler spriteScale = new Scaler(_spriteWidth);
            _player.transform.localScale = new Vector3(spriteScale._spriteScale, spriteScale._spriteScale, 1);
        }

        public Transform GetPlayer()
        {
            return _player.transform;
        }
        
    }
}
