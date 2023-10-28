using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.BackButtonStack
{
    public class BackButtonStack : MonoBehaviour
    {
        #region Singleton

        /// <summary>Get or create the singleton instance.</summary>
        public static BackButtonStack Instance => _instance != null ? _instance : (_instance = CreateInstance());
        private static BackButtonStack _instance;

        /// <returns>BackButtonStack instance with its GameObject marked with <see cref="DontDestroyOnLoad"/></returns>
        private static BackButtonStack CreateInstance()
        {
            var gameObject = new GameObject(nameof(BackButtonStack));
            DontDestroyOnLoad(gameObject);
            return gameObject.AddComponent<BackButtonStack>();
        }

        #endregion

        /// <summary>Read-only view of the ESC/Back button handlers registered in the stack.</summary>
        public IReadOnlyList<IBackButtonHandler> BackButtonHandlers => _backButtonHandlers;
        private readonly List<IBackButtonHandler> _backButtonHandlers = new List<IBackButtonHandler>();

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

        /// <summary>
        /// Add the given handler to the top of the stack.
        /// Adding an object that was already registered is not supported.
        /// </summary>
        /// <param name="handler">ESC/Back button handler</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="handler"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when <paramref name="handler"/> is already present in the stack.</exception>
        public void AddButtonHandler(IBackButtonHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (_backButtonHandlers.Contains(handler))
            {
                throw new InvalidOperationException("Trying to add an object that is already registered.");
            }
            _backButtonHandlers.Add(handler);
            enabled = true;
        }

        /// <summary>
        /// Remove the given handler from anywhere in the stack.
        /// </summary>
        /// <remarks>
        /// Passing an object that was not registered is a no-op.
        /// </remarks>
        /// <param name="handler">ESC/Back button handler</param>
        public void RemoveButtonHandler(IBackButtonHandler handler)
        {
            int index = _backButtonHandlers.LastIndexOf(handler);
            if (index >= 0)
            {
                _backButtonHandlers.RemoveAt(index);
                enabled = _backButtonHandlers.Count > 0;
            }
        }
    }
}
