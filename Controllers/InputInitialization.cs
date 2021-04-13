using UnityEngine;

namespace Pinball_MVC
{
    internal sealed class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private IUserInputButton _pcStartButton;

        public InputInitialization()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _pcInputHorizontal = new MobileInput();
            }
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcStartButton = new PCInputButtons();
        }

        public void Initialization()
        {

        }
        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertival) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        public IUserInputButton GetStartButton()
        {
           return _pcStartButton; 
        }
    }
}
