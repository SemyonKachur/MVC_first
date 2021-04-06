using UnityEngine;

namespace Pinball_MVC
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private float _horizontal;
        private float _move;
        private IUserInputProxy _horizontalInputProxy;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            Transform unit, IUnit unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _unitData.Speed;
            _move =-_horizontal * speed;
            _unit.transform.Rotate(0, 0, _move);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
        }
    }
}
