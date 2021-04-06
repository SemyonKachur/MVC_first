using UnityEngine;

namespace Pinball_MVC
{

    public class StartingBallController : MonoBehaviour
    {
        private readonly Transform _player;
        private readonly Transform _mainCamera;
        private readonly Vector3 _offset;

        public StartingBallController(Transform player)
        {
            _player = player;
          

        }

        public void LateExecute(float deltaTime)
        {
            _mainCamera.position = _player.position + _offset;
        }
    }
}
