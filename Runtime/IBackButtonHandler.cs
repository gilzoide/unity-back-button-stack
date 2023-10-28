namespace Gilzoide.BackButtonStack
{
    /// <summary>Interface implemented by objects that handle the ESC/Back button.</summary>
    /// <seealso cref="BackButtonStack"/>
    public interface IBackButtonHandler
    {
        void HandleBackButton();
    }

    public static class IBackButtonHandlerExtensions
    {
        /// <summary>Alias for <c>BackButtonStack.Instance.AddButtonHandler(backButtonHandler)</c></summary>
        /// <seealso cref="BackButtonStack.AddButtonHandler"/>
        public static void AddToBackButtonStack(this IBackButtonHandler backButtonHandler)
        {
            BackButtonStack.Instance.AddButtonHandler(backButtonHandler);
        }

        /// <summary>Alias for <c>BackButtonStack.Instance.RemoveButtonHandler(backButtonHandler)</c></summary>
        /// <seealso cref="BackButtonStack.RemoveButtonHandler"/>
        public static void RemoveFromBackButtonStack(this IBackButtonHandler backButtonHandler)
        {
            BackButtonStack.Instance.RemoveButtonHandler(backButtonHandler);
        }
    }
}
