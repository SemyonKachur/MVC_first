using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private ListInteractableObject _interactiveObject;
        private GameInitialization _gameInitialization;
        private PlayerData _playerData;

        private void Awake()
        {
            _interactiveObject = new ListInteractableObject();
            _gameInitialization = new GameInitialization(_playerData);
            
            //foreach (var o in _interactiveObject)
            //{
            //    if (o is BadBonus badBonus)
            //    {
            //        badBonus.CaughtPlayer += CaughtPlayer;
            //        badBonus.CaughtPlayer += _displayEndGame.GameOver;
            //        badBonus.CaughtPlayer += delegate (object sender, CaughtPlayerEventArgs args)
            //        { Debug.Log($"Вы проиграли. Вас убил {((GameObject)o).name} {args.Color} цвета"); };
            //    }
            //}
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                //if (interactiveObject is IFlay flay)
                //{
                //    flay.Flay();
                //}
                //if (interactiveObject is IFlicker flicker)
                //{
                //    flicker.Flicker();
                //}
                //if (interactiveObject is IRotation rotation)
                //{
                //    rotation.Rotation();
                //}
            }
        }

        public void Dispose()
        {
            //foreach (var o in _interactiveObject)
            //{
            //    if (o is InteractiveObject interactiveObject)
            //    {
            //        if (o is BadBonus badBonus)
            //        {
            //            badBonus.CaughtPlayer -= CaughtPlayer;
            //            badBonus.CaughtPlayer -= _displayEndGame.GameOver;
            //        }
            //        Destroy(interactiveObject.gameObject);
            //    }
            //}
        }
    }
}
