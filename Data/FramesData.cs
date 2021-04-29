using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "Frames", menuName = "Data/Background/Frames")]
    public class FramesData : ScriptableObject
    {
        public Sprite _sprite;
        [SerializeField] Color _color;
        [SerializeField] private Vector2 _position;
        [SerializeField] private BoxCollider2D _collider;

        public Color Color => _color;
        public Vector2 Position => _position;
        public Sprite Sprite => _sprite;
        public BoxCollider2D Collider => _collider;
    }
}
