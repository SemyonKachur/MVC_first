using UnityEngine;
namespace Pinball_MVC {
    public class CenterFactory
    {
        public readonly CenterData _centerData;

        public CenterFactory(CenterData centerData)
        {
            _centerData = centerData;
        }
        
        public Transform CreateCenter()
        {
            return new GameObject("Center").transform;
        }
    }
}
