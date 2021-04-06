using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "Center", menuName = "Data/Background/Center")]
    public class CenterData : ScriptableObject
    {
        public Sprite _sprite;
        [SerializeField] Color _color;
        [SerializeField] private Vector2 _position;
        [SerializeField] private CircleCollider2D _collider;

        public Color Color => _color;
        public Vector2 Position => _position;
        public Sprite Sprite => _sprite;
        public CircleCollider2D Collider => _collider;
    }
}
