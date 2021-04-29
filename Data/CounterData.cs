using UnityEngine.UI;
using UnityEngine;

namespace Pinball_MVC
{
    [CreateAssetMenu(fileName = "Counter", menuName = "Data/UI/Counter")]
    public sealed class CounterData : ScriptableObject
    {
        private Text _counter;
        [SerializeField] Color _color;
        [SerializeField] Font _font;
        [SerializeField] Vector2 _position;
        [SerializeField] int _conunt;

        public int Count => _conunt;
        public Color Color => _color;
        public Font Font => _font;
        public Vector2 Position => _position;
        
    }
}
