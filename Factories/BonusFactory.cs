using UnityEngine;

namespace Pinball_MVC
{
    public sealed class BonusFactory
    {
        public readonly BonusData _bonusData;

        public BonusFactory(BonusData bonusData)
        {
            _bonusData = bonusData;
        }
        public Transform CreateBonus()
        {
            return new GameObject("Bonus").transform;
        }
    }
}
