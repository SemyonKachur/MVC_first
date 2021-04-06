using UnityEngine;

namespace Pinball_MVC
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        public readonly PlayerData _playerData;
        
        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public Transform CreatePlayer()
        {
            return new GameObject("Player").transform;
        }
    }
}
