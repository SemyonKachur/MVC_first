using UnityEngine;

namespace Pinball_MVC 
{
    [CreateAssetMenu(fileName = "Background", menuName = "Data/Background/Background")]
    public sealed class BackgroundData : ScriptableObject
    {
        private BackgroundData _background;
        public Sprite _sprite;
        [SerializeField] Color _color;
        [SerializeField] private Vector3 _position;

        public Color Color => _color;
        public Vector3 Position => _position;
        public Sprite Sprite => _sprite;
    }
}
