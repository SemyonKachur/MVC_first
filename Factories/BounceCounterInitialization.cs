using UnityEngine;
using System;
using UnityEngine.UI;

namespace Pinball_MVC
{
    public sealed class BounceCounterInitialization : IInitialization
    {
        public readonly BounceCounterFactory _bounceCounterFactory;
        private GameObject _counterGameObject;
        private Text _counterText;
        private RectTransform _counterRectTransform;
        private float _fontSizeScaler = 15.0f;
        public BallController _ballController;
        public BounceCounterInitialization(BounceCounterFactory counterFactory, BallController ballController)
        {
            var canvas = GameObject.Find("Canvas");

            _bounceCounterFactory = counterFactory;
            _counterGameObject = _bounceCounterFactory.CreateBounceCounter();
            _counterGameObject.transform.parent = canvas.transform;

            _counterText = _counterGameObject.AddComponent<Text>();
            _counterText.text = _bounceCounterFactory._bounceCounterData.Count.ToString();
            _counterText.font = _bounceCounterFactory._bounceCounterData.Font;
            _counterText.color = _bounceCounterFactory._bounceCounterData.Color;
            _counterText.fontSize = Mathf.RoundToInt(Screen.width / _fontSizeScaler);
            _counterText.alignment = TextAnchor.MiddleCenter;
            
            _counterRectTransform = _counterText.GetComponent<RectTransform>();
            _counterRectTransform.localPosition = Vector2.zero;
            _counterRectTransform.sizeDelta = new Vector2(Screen.width / 8, Screen.width / 10);

            _ballController = ballController;
            _ballController.BounceCountChange += CountChange;
        }
        
        public void CountChange(int count)
        {
            var counter = Convert.ToInt32(_counterText.text);
            counter -= count;
            _counterText.text = counter.ToString();
        }
        public void Initialization()
        {

        }
    }
}