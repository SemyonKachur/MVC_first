using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "Bonus", menuName = "Data/Bonus/Bonus")]
    public sealed class BonusData : ScriptableObject
    {
        [SerializeField] private Vector2 _position;
        [SerializeField] private Color _color;
        [SerializeField] float _ballScreenScaleSize;
        [SerializeField] private Sprite _sprite;

        public Vector2 Position => _position;
        public Color Color => _color;
        public float BallScreenScaleSize => _ballScreenScaleSize;
        public Sprite Sprite => _sprite;
    }
}