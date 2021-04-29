using UnityEngine;

namespace Pinball_MVC
{
    public sealed class BackgroundInitialzation : IInitialization
    {
        private readonly BackgroundFactory _backgroundFactory;
        private readonly BackgroundData _backgroundData;
        private Transform _background;

        public BackgroundInitialzation(BackgroundFactory backgroundFactory, Vector3 backgroundPosition)
        {
            _backgroundFactory = backgroundFactory;
            _background = _backgroundFactory.CreateBackground();
            _background.position = backgroundPosition;
            _background.gameObject.AddComponent<SpriteRenderer>().sprite = _backgroundFactory._backgroundData.Sprite;
            _background.gameObject.GetComponent<SpriteRenderer>().color = _backgroundFactory._backgroundData.Color;
            //_background.gameObject.GetComponent<SpriteRenderer>().color = _backgroundFactory._backgroundData.Color; Œœﬂ“‹ Õ≈ –¿¡Œ“¿≈“
            _background.transform.localScale = new Vector2(Screen.width, Screen.height);
        }

        public void Initialization()
        {

        }
    }
}
