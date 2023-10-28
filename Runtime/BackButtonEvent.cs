using UnityEngine.Events;

namespace Gilzoide.BackButtonStack
{
    /// <summary>
    /// Implements ESC/Back button handling using a <see cref="UnityEvent"/>, with automatic registration in the singleton <see cref="BackButtonStack"/>.
    /// </summary>
    /// <remarks>
    /// Object will be added to the stack in its <c>OnEnable</c> message and removed in <c>OnDisable</c>.
    /// </remarks>
    /// <seealso cref="IBackButtonHandler"/>
    public class BackButtonEvent : ABackButtonHandler
    {
        public UnityEvent OnBackButton = new UnityEvent();

        public override void HandleBackButton()
        {
            OnBackButton.Invoke();
        }
    }
}
