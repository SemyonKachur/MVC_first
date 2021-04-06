using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "Ball", menuName = "Data/Unit/Ball")]
    public class BallData : ScriptableObject, IUnit
    {
        public Sprite Sprite;
        [SerializeField] Color _color;
        [SerializeField] private CircleCollider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField, Range(0, 1000)] private float _speed;
        [SerializeField] private Vector2 _position;

        public Color Color => _color;
        public float Speed => _speed;
        public Vector2 Position => _position;
        public CircleCollider2D Collider => _collider;
        public Rigidbody2D Rigidbody => _rigidbody;
    }
}
