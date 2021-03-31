using UnityEngine;

namespace Pinball_MVC
{
    public sealed class PlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory()
        {
            _playerData = new PlayerData();
        }

        public Transform CreatePlayer()
        {
            return new GameObject("player").transform;
        }
    }
}
