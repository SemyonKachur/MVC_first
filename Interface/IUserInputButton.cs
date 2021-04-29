using System;
namespace Pinball_MVC
{
    public interface IUserInputButton
    {
        event Action<bool> ButtonDown;
        void GetButton();
    }
}
