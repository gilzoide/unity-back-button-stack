using UnityEngine;

namespace Gilzoide.BackButtonStack
{
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
