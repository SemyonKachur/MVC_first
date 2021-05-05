using System.IO;
using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _backgroundDataPath;
        [SerializeField] private string _framesDataPath;
        [SerializeField] private string _centerDataPath;
        [SerializeField] private string _startingBallDataPath;
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _enemyCounterDataPath;
        [SerializeField] private string _bounceCounterDataPath;
        [SerializeField] private string _BonusDataPath;

        private PlayerData _player;
        private BackgroundData _background;
        private FramesData _frames;
        private CenterData _center;
        private BallData _ball;
        private EnemyData _enemy;
        private EnemyCounterData _enemyCounter;
        private BounceCounterData _bounceCounter;
        private BonusData _bonusData;

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("SO/" + _playerDataPath);
                }
                return _player;
            }
        }
        public BallData Ball
        {
            get
            {
                if (_ball == null)
                {
                    _ball = Load<BallData>("SO/" + _startingBallDataPath);
                }
                return _ball;
            }
        }

        public BackgroundData Background
        {
            get
            {
                if (_background == null)
                {
                    _background = Load<BackgroundData>("SO/BackgroundAndFrames/" + _backgroundDataPath);
                }
                return _background;
            }
        }

        public FramesData Frames
        {
            get
            {
                if (_frames == null)
                {
                    _frames = Load<FramesData>("SO/BackgroundAndFrames/" + _framesDataPath);
                }
                return _frames;
            }
        }

        public CenterData Center
        {
            get
            {
                if (_center == null)
                {
                    _center = Load<CenterData>("SO/BackgroundAndFrames/" + _centerDataPath);
                }
                return _center;
            }
        }

        public EnemyData Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    _enemy = Load<EnemyData>("SO/" + _enemyDataPath);
                }

                return _enemy;
            }
        }

        public EnemyCounterData EnemyCounter
        {
            get
            {
                if (_enemyCounter == null)
                {
                    _enemyCounter = Load<EnemyCounterData>("SO/" + _enemyCounterDataPath);
                }

                return _enemyCounter;
            }
        }

        public BounceCounterData BounceCounter
        {
            get
            {
                if (_bounceCounter == null)
                {
                    _bounceCounter = Load<BounceCounterData>("SO/" + _bounceCounterDataPath);
                }

                return _bounceCounter;
            }
        }

        public BonusData BonusData
        {
            get
            {
                if (_bonusData == null)
                {
                    _bonusData = Load<BonusData>("SO/" + _BonusDataPath);
                }
                return _bonusData;
            }
        }



        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

    }
}
