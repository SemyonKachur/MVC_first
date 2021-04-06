using UnityEngine;

namespace Pinball_MVC
{
    public sealed class GameController : MonoBehaviour
    {
        private ListInteractableObject _interactiveObject;
        private GameInitialization _gameInitialization;
        private Controllers _controllers;
        [SerializeField] private Data _data;

        private void Awake()
        {
            _controllers = new Controllers();
            _interactiveObject = new ListInteractableObject();
            _gameInitialization = new GameInitialization(_controllers,_data);            
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        public void Dispose()
        {
            
        }
    }
}
