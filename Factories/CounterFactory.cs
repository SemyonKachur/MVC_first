using UnityEngine;


namespace Pinball_MVC
{
    public sealed class CounterFactory
    {
        public readonly CounterData _counterData;
        public CounterFactory(CounterData counterData)
        {
            _counterData = counterData;
        }

        public GameObject CreateCounter()
        {
            return new GameObject("Counter");
        }
    }
    
}
