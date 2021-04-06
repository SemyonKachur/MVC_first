using UnityEngine;

namespace Pinball_MVC
{
    public class Scaler
    {
        private float _offset = 0.000643f;

        [SerializeField] private float _scaler = 0.5f;
        private float _scaledSize;
        public float _spriteScale { get;}

        public Scaler(float SpriteRectWidth)
        {
            _scaledSize = Screen.width * _scaler;
            _spriteScale = _scaledSize / SpriteRectWidth;
        }
         public Scaler(float SpriteRectWidth, float offset)
        {
            _scaledSize = Screen.width * _scaler;
            _spriteScale = (_scaledSize / SpriteRectWidth) - (Screen.width * _offset);
        }

    }
}
