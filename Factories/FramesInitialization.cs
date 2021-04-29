using UnityEngine;
namespace Pinball_MVC
{
    public class FramesInitialization : IInitialization
    {
        private readonly FramesFactory _framesFactory;
        private readonly FramesData _framesData;
        private Transform _topFrame;
        private Transform _rightFrame;
        private Transform _downFrame;
        private Transform _leftFrame;

        private float _frameWide = 10.0f;

        public FramesInitialization(FramesFactory framesFactory)
        {
            _framesFactory = framesFactory;
            TopFrameCreate();
            RightFrameCreate();
            DownFrameCreate();
            LeftFrameCreate();
        }

        private void TopFrameCreate()
        {
            _topFrame = _framesFactory.CreateFrame("TopFrame");
            _topFrame.position = new Vector2(0, Screen.height / 2);
            _topFrame.gameObject.AddComponent<SpriteRenderer>().sprite = _framesFactory._framesData.Sprite;
            _topFrame.gameObject.GetComponent<SpriteRenderer>().color = _framesFactory._framesData.Color;
            _topFrame.gameObject.AddComponent<BoxCollider2D>().sharedMaterial = _framesFactory._framesData.Collider.sharedMaterial;
            _topFrame.transform.localScale = new Vector2(Screen.width, _frameWide);
        }
        private void RightFrameCreate()
        {
            _rightFrame = _framesFactory.CreateFrame("RightFrame");
            _rightFrame.position = new Vector2(Screen.width/2, 0);
            _rightFrame.gameObject.AddComponent<SpriteRenderer>().sprite = _framesFactory._framesData.Sprite;
            _rightFrame.gameObject.GetComponent<SpriteRenderer>().color = _framesFactory._framesData.Color;
            _rightFrame.gameObject.AddComponent<BoxCollider2D>().sharedMaterial = _framesFactory._framesData.Collider.sharedMaterial;
            _rightFrame.transform.localScale = new Vector2(_frameWide, Screen.height);
        }
        private void DownFrameCreate()
        {
            _downFrame = _framesFactory.CreateFrame("DownFrame");
            _downFrame.position = new Vector2(0, -Screen.height/2);
            _downFrame.gameObject.AddComponent<SpriteRenderer>().sprite = _framesFactory._framesData.Sprite;
            _downFrame.gameObject.GetComponent<SpriteRenderer>().color = _framesFactory._framesData.Color;
            _downFrame.gameObject.AddComponent<BoxCollider2D>().sharedMaterial = _framesFactory._framesData.Collider.sharedMaterial;
            _downFrame.transform.localScale = new Vector2(Screen.width, _frameWide);
        }
        private void LeftFrameCreate()
        {
            _leftFrame = _framesFactory.CreateFrame("LeftFrame");
            _leftFrame.position = new Vector2(-Screen.width/2, 0);
            _leftFrame.gameObject.AddComponent<SpriteRenderer>().sprite = _framesFactory._framesData.Sprite;
            _leftFrame.gameObject.GetComponent<SpriteRenderer>().color = _framesFactory._framesData.Color;
            _leftFrame.gameObject.AddComponent<BoxCollider2D>().sharedMaterial = _framesFactory._framesData.Collider.sharedMaterial;
            _leftFrame.transform.localScale = new Vector2(_frameWide, Screen.height);
        }

        public void Initialization()
        {

        }


    }
}
