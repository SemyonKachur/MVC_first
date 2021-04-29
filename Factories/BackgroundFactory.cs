using UnityEngine;

namespace Pinball_MVC
{
    public class BackgroundFactory 
    {
        public readonly BackgroundData _backgroundData;

        public BackgroundFactory(BackgroundData backgroundData)
        {
            _backgroundData = backgroundData;
        }

        public Transform CreateBackground()
        {
            return new GameObject("Background").transform;
        }
    }
}
