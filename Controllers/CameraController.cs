using UnityEngine;

namespace Pinball_MVC 
{
    internal class CameraController : IInitialization
    {
        public readonly Camera _camera;
        public CameraController()
        {
            _camera = Camera.main;
            _camera.orthographicSize = Screen.height / 2;
        }
        public void Initialization()
        {

        }
    }
}
