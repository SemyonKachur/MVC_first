﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pinball_MVC
{
    public sealed class CounterInitialization
    {
        public readonly CounterFactory _counterFactory;
        private GameObject _counterGameObject;
        private Text _counterText;
        private RectTransform _counterRectTransform;
        private float _fontSizeScaler = 15.0f;
        public BallController _ballController;

        public CounterInitialization(CounterFactory counterFactory,BallController ballController)
        {
            var canvas = new GameObject("Canvas");
            canvas.AddComponent<Canvas>();
            canvas.transform.localScale = new Vector2(Screen.width, Screen.height);
            canvas.transform.position = Vector2.zero;

            _counterFactory = counterFactory;
            _counterGameObject = _counterFactory.CreateCounter();
            _counterGameObject.transform.parent = canvas.transform;

            _counterText = _counterGameObject.AddComponent<Text>();
            _counterText.text = _counterFactory._counterData.Count.ToString();
            _counterText.font = _counterFactory._counterData.Font;
            _counterText.color = _counterFactory._counterData.Color;
            _counterText.fontSize = Mathf.RoundToInt(Screen.width / _fontSizeScaler);
            _counterText.alignment = TextAnchor.MiddleCenter;

            _counterRectTransform = _counterText.GetComponent<RectTransform>();
            _counterRectTransform.localPosition = Vector2.zero;
            _counterRectTransform.sizeDelta = new Vector2(Screen.width / 10, Screen.width / 10);

            _ballController = ballController;
            _ballController.CountChange += CountChange;
        }

        public void CountChange(int count)
        {
            var counter = Convert.ToInt32(_counterText.text);
            counter -= count;
            _counterText.text = counter.ToString();
        }

    }
}
