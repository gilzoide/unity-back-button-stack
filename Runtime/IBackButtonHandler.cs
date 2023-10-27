namespace Gilzoide.BackButtonStack
{
    public interface IBackButtonHandler
    {
        void HandleBackButton();
    }

    public static class IBackButtonHandlerExtensions
    {
        public static void AddToBackButtonStack(this IBackButtonHandler backButtonHandler)
        {
            BackButtonStack.Instance.AddButtonHandler(backButtonHandler);
        }

        public static void RemoveFromBackButtonStack(this IBackButtonHandler backButtonHandler)
        {
            BackButtonStack.Instance.RemoveButtonHandler(backButtonHandler);
        }
    }
}
