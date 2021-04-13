using UnityEngine;

namespace Pinball_MVC
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private readonly IUnit _ballData;

        //private readonly
        private float _horizontal;
        private float _move;
        public bool _isGameStarted { get; private set; } = false;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputButton _inputStartButton;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            Transform unit, IUnit unitData,IUnit ballData, IUserInputButton inputStartButton)
        {
            _unit = unit;
            _ballData = ballData;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _inputStartButton = inputStartButton;
            _inputStartButton.ButtonDown += StartButtonPress;

        }

        private void StartButtonPress(bool isStartButtonPressed)
        {
            _isGameStarted = isStartButtonPressed;
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

            if (_isGameStarted)
            {
                var ballspeed = _ballData.Speed;
                var ball = GameObject.FindWithTag("Ball");

                ball.transform.parent = null;
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
                rb.simulated = true;
                rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                rb.interpolation = RigidbodyInterpolation2D.Interpolate;
                rb.AddForce(ball.transform.up * ballspeed, ForceMode2D.Impulse);

                _isGameStarted = false;
            }
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
        }
    }
}
