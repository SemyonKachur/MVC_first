using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/PlayerArc")]
    public sealed class PlayerData: ScriptableObject, IUnit
        {
        private GameObject _player;
        public Sprite Sprite;
        [SerializeField] Color _color;
        [SerializeField] private PolygonCollider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField, Range(0, 1000)] private float _speed;
        [SerializeField] private Vector2 _position;

        public Color Color => _color;
        public float Speed => _speed;
        public Vector2 Position => _position;
        public GameObject Player => _player;
        public PolygonCollider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;
    }
}
