using UnityEngine;

namespace Gilzoide.BackButtonStack
{
    /// <summary>
    /// Abstract class for implementing ESC/Back button handlers with automatic registration in the singleton <see cref="BackButtonStack"/>.
    /// </summary>
    /// <remarks>
    /// Object will be added to the stack in its <c>OnEnable</c> message and removed in <c>OnDisable</c>.
    /// </remarks>
    /// <seealso cref="IBackButtonHandler"/>
    public abstract class ABackButtonHandler : MonoBehaviour, IBackButtonHandler
    {
        protected virtual void OnEnable()
        {
            this.AddToBackButtonStack();
        }

        protected virtual void OnDisable()
        {
            this.RemoveFromBackButtonStack();
        }

        public abstract void HandleBackButton();
    }
}
