using UnityEngine;

namespace Pinball_MVC
{
    public sealed class FramesAndBackgroundFactory
    {
        private GameObject _background;
        private GameObject _topFrame;
        private GameObject _rightFrame;
        private GameObject _downFrame;
        private GameObject _leftFrame;
        private GameObject _heart;

        private float _frameThickness = 10.0f;
        private float _heartOffset;

        public FramesAndBackgroundFactory()
        {
            var @object = Resources.Load("Prefab/Background") as GameObject;
            CreateBackground(@object);

            @object = Resources.Load("Prefab/Frame") as GameObject;
            CreateFrames(@object);

            @object = Resources.Load("Prefab/Center") as GameObject;
            CreateHeart(@object);
        }

        private void CreateBackground(GameObject prefab)
        {
            _background = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);

            _background.GetComponent<SpriteRenderer>().color = new Color(0.1058824f, 0.1254902f, 0.1529412f, 1.0f);
            _background.transform.position = new Vector3(0.0f, 0.0f, 1.0f);
            _background.transform.localScale = new Vector2(Screen.width, Screen.height);
        }

        private void CreateFrames(GameObject prefab)
        {
            _topFrame = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _topFrame.name = "TopFrame";
            _topFrame.GetComponent<SpriteRenderer>().color = new Color(0.5647059f, 0.5529412f, 0.5607843f, 1.0f);
            _topFrame.transform.position = new Vector2(0, Screen.height / 2);
            _topFrame.transform.localScale = new Vector2(Screen.width, _frameThickness);

            _rightFrame = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _rightFrame.name = "RightFrame";
            _rightFrame.GetComponent<SpriteRenderer>().color = new Color(0.5647059f, 0.5529412f, 0.5607843f, 1.0f);
            _rightFrame.transform.position = new Vector2(-Screen.width / 2, 0);
            _rightFrame.transform.localScale = new Vector2(_frameThickness, Screen.height);

            _downFrame = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _downFrame.name = "DownFrame";
            _downFrame.GetComponent<SpriteRenderer>().color = new Color(0.5647059f, 0.5529412f, 0.5607843f, 1.0f);
            _downFrame.transform.position = new Vector2(0, -Screen.height / 2);
            _downFrame.transform.localScale = new Vector2(Screen.width, _frameThickness);

            _leftFrame = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _leftFrame.name = "LeftFrame";
            _leftFrame.GetComponent<SpriteRenderer>().color = new Color(0.5647059f, 0.5529412f, 0.5607843f, 1.0f);
            _leftFrame.transform.position = new Vector2(Screen.width / 2, 0);
            _leftFrame.transform.localScale = new Vector2(_frameThickness, Screen.height);
        }

        private void CreateHeart(GameObject prefab) 
        {
            _heart = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _heart.name = "Herat";
            _heart.GetComponent<SpriteRenderer>().color = new Color(0.5647059f, 0.5529412f, 0.5607843f, 1.0f);
            _heart.transform.position = Vector2.zero;

            var scale = Screen.height / Screen.width;
            _heartOffset = scale / 2.5f;

            var Sprite = _heart.GetComponent<SpriteRenderer>().sprite;
            var _spriteWidth = Sprite.rect.width;
            Scaler spriteScale = new Scaler(_spriteWidth);
            _heart.transform.localScale = new Vector3(spriteScale._spriteScale - _heartOffset, spriteScale._spriteScale - _heartOffset, 1);
        }
    }
}
