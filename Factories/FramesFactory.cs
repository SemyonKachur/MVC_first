using UnityEngine;

namespace Pinball_MVC
{
    public class FramesFactory 
    {
        public readonly FramesData _framesData;
       public FramesFactory(FramesData framesData)
        {
            _framesData = framesData;
        }

        public Transform CreateFrame(string name)
        {
            return new GameObject(name).transform;
        }
    }
}
