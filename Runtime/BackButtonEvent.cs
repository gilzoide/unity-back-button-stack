using UnityEngine.Events;

namespace Gilzoide.BackButtonStack
{
    public class BackButtonEvent : ABackButtonHandler
    {
        public UnityEvent OnBackButton = new UnityEvent();

        public override void HandleBackButton()
        {
            OnBackButton.Invoke();
        }
    }
}
