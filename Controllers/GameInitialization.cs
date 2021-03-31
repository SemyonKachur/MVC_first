using UnityEngine;

namespace Pinball_MVC
{
    internal sealed class GameInitialization
    {
        public GameInitialization(PlayerData player)
        {
            Camera.main.orthographicSize = Screen.height / 2;

            var playerFactory = new PlayerFactory();
            var framesAndBackground = new FramesAndBackgroundFactory();
        }
    }
}
