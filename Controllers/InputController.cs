namespace Pinball_MVC
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputButton _startButton;

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, IUserInputButton inputStartButton)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _startButton = inputStartButton;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _startButton.GetButton();
        }
    }
}
