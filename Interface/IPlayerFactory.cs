using UnityEngine;

namespace Pinball_MVC
{
    public interface IPlayerFactory
    {
        Transform CreatePlayer();
    }
}
