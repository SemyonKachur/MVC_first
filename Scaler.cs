using UnityEngine;

namespace Pinball_MVC
{
    public class Scaler
    {

        [SerializeField] private float _scaler = 0.5f;
        private float _scaledSize;
        public float _spriteScale { get;}

        public Scaler(float SpriteRectWidth)
        {
            _scaledSize = Screen.width * _scaler;
            _spriteScale = _scaledSize / SpriteRectWidth;
        }

    }
}
