using System;
using UnityEngine;

namespace Pinball_MVC
{
    public sealed class PCInputButtons : IUserInputButton
    {
        public event Action<bool> ButtonDown = delegate (bool button) { };

        public void GetButton()
        {
            ButtonDown.Invoke(Input.GetButtonDown("Jump"));
        }
    }
}
