using UnityEngine;

namespace Pinball_MVC
{
    public sealed class GameController : MonoBehaviour
    {
        private ListInteractableObject _interactiveObject;
        private GameInitialization _gameInitialization;
        private Controllers _controllers;
        [SerializeField] private Data _data;
        [SerializeField] private int _count;
        public int Count => _count;

        private void Awake()
        {
            _controllers = new Controllers();
            _interactiveObject = new ListInteractableObject();
            _gameInitialization = new GameInitialization(_controllers,_data);
            _count = _data.Counter.Count;
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
