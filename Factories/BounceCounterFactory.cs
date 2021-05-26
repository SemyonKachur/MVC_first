using UnityEngine;

namespace Pinball_MVC
{
    public sealed class BounceCounterFactory
    {
        public readonly BounceCounterData _bounceCounterData;
        public BounceCounterFactory(BounceCounterData bounceCounterData)
        {
            _bounceCounterData = bounceCounterData;
        }

        public GameObject CreateBounceCounter()
        {
            return new GameObject("BounceCounter");
        }
    }
}