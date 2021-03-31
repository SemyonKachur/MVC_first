using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Unit/PlayerSettings")]
        public sealed class PlayerData : ScriptableObject
        {
        private GameObject _player;
        public Sprite Sprite;
        [SerializeField] Color _color;
        [SerializeField] private float _size;
        [SerializeField] private Vector2 _position;
        private float _spriteWidth;

        public PlayerData()
        {
            var player = Resources.Load<GameObject>("Prefab/Platform");
            _player = Instantiate(player, player.transform);
            _player.transform.position = Vector2.zero;

            _player.GetComponent<SpriteRenderer>().color = new Color(0.5647059f, 0.5529412f, 0.5607843f, 1.0f);

            Sprite = _player.GetComponent<SpriteRenderer>().sprite;
            _spriteWidth = Sprite.rect.width;
            Scaler spriteScale = new Scaler(_spriteWidth);
            _player.transform.localScale = new Vector3(spriteScale._spriteScale, spriteScale._spriteScale, 1);
        }

        public Color Color => _color;
        public float Speed => _size;
        public Vector2 Position => _position;
        public GameObject Player => _player;
    }
}
