using System;
using UnityEngine;

namespace Pinball_MVC
{ 
    public sealed class BonusInitialization : MonoBehaviour, IInitialization
    {
        readonly BonusFactory _bonusFactory;
        private Transform _bonus;
        private float _screenScaler;
        public int _bonusType { get; private set; }
        public BonusInitialization(BonusFactory bonus, int bonusType)
        {
             _bonusFactory = bonus;
            _screenScaler = _bonusFactory._bonusData.BallScreenScaleSize;
            _bonusType = bonusType;
            _bonus = _bonusFactory.CreateBonus();
            _bonus.gameObject.tag = "Bonus";
            _bonus.gameObject.AddComponent<SpriteRenderer>().sprite = _bonusFactory._bonusData.Sprite;
            _bonus.gameObject.AddComponent<BoxCollider2D>();
            _bonus.transform.localScale = new Vector2(Screen.width * _screenScaler, Screen.width * _screenScaler);
            _bonus.transform.position = new Vector2(UnityEngine.Random.Range(-Screen.width / 2, Screen.width / 2), UnityEngine.Random.Range(-Screen.height / 2, Screen.height / 2));

            if (_bonusType == 0)
            {
                CountBonus();
            }
            else if (_bonusType == 1)
            {
                SpeedBonus();
            }
            else if (_bonusType == 2)
            {
                BadCountBonus();
            }
        }

        private void CountBonus()
        {
            _bonus.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            _bonus.gameObject.AddComponent<BonusInitialization>()._bonusType = 0;
        }

        private void SpeedBonus()
        {
            _bonus.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            _bonus.gameObject.AddComponent<BonusInitialization>()._bonusType = 1;
        }

        private void BadCountBonus()
        {
            _bonus.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            _bonus.gameObject.AddComponent<BonusInitialization>()._bonusType = 2;
        }

        public void Initialization()
        {

        }
    }
}
