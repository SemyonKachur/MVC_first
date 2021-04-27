using UnityEngine;

namespace Pinball_MVC
{

    public sealed class CenterInitialization : IInitialization
    {
        public readonly CenterFactory _centerFactory;
        private Transform _center;
        private float _offset = 0.4f;

        public CenterInitialization(CenterFactory centerFactory, Vector2 position)
        {
            _centerFactory = centerFactory;
            _center = _centerFactory.CreateCenter();
            _center.gameObject.AddComponent<SpriteRenderer>().sprite = _centerFactory._centerData.Sprite;
            _center.gameObject.GetComponent<SpriteRenderer>().color = _centerFactory._centerData.Color;
            _center.gameObject.AddComponent<CircleCollider2D>().sharedMaterial = _centerFactory._centerData.Collider.sharedMaterial;
            _center.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;

            Scaler();
        }

        private void Scaler()
        {
            var Sprite = _center.GetComponent<SpriteRenderer>().sprite;
            var _spriteWidth = Sprite.rect.width;
            Scaler spriteScale = new Scaler(_spriteWidth, _offset);
            _center.transform.localScale = new Vector3(spriteScale._spriteScale, spriteScale._spriteScale, 1);
        }

        public void Initialization()
        {

        }
    }
}
