using UnityEngine;
using UnityEngine.UI;

namespace Pinball_MVC
{
    [CreateAssetMenu (fileName = "GameOver", menuName = "Data/UI/GameOver")]
    public sealed class GameOverData : ScriptableObject
    {
        [SerializeField] Text _gameOverText;
        [SerializeField] Color _color;
        [SerializeField] Font _font;
        [SerializeField] Vector2 _position;
        [SerializeField] bool _isGameOver;

        public bool IsGameOver => _isGameOver;
        public Color Color => _color;
        public Font Font => _font;
        public Vector2 Position => _position;
        public Text GameOverText => _gameOverText;
    }
}
