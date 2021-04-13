using UnityEngine;

namespace Pinball_MVC
{
        public class StartingBallFactory
    {
        public readonly BallData _ballData;

        public StartingBallFactory(BallData ballData)
        {
            _ballData = ballData;
        }

        public Transform CreateStartingBall()
        {
            return new GameObject("Ball").transform;
        }
    }
}
