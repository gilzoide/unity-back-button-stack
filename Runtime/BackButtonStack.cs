using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.BackButtonStack
{
    public class BackButtonStack : MonoBehaviour
    {
        public static BackButtonStack Instance => _instance != null ? _instance : (_instance = CreateInstance());
        private static BackButtonStack _instance;

        private static BackButtonStack CreateInstance()
        {
            var gameObject = new GameObject(nameof(BackButtonStack));
            DontDestroyOnLoad(gameObject);
            return gameObject.AddComponent<BackButtonStack>();
        }

        public IReadOnlyList<IBackButtonHandler> BackButtonHandlers => _backButtonHandlers;
        private readonly List<IBackButtonHandler> _backButtonHandlers = new();

        private void Update()
        {
            if (_backButtonHandlers.Count <= 0)
            {
                enabled = false;
                return;
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                _backButtonHandlers[_backButtonHandlers.Count - 1].HandleBackButton();
            }
        }

        public void AddButtonHandler(IBackButtonHandler handler)
        {
            Debug.Assert(!_backButtonHandlers.Contains(handler), "Trying to add back button handler again, which is not permitted.");
            _backButtonHandlers.Add(handler);
            enabled = true;
        }

        public void RemoveButtonHandler(IBackButtonHandler handler)
        {
            _backButtonHandlers.Remove(handler);
            enabled = _backButtonHandlers.Count > 0;
        }
    }
}
