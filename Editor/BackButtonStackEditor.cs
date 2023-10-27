using UnityEditor;
using UnityEngine;

namespace Gilzoide.BackButtonStack.Editor
{
        [CustomEditor(typeof(BackButtonStack))]
        class BackButtonStackEditor : UnityEditor.Editor
        {
            [SerializeField] private bool foldout = true;

            public override bool RequiresConstantRepaint()
            {
                return Application.isPlaying;
            }

            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                BackButtonStack backButtonStack = (BackButtonStack) target;
                if (Application.isPlaying && backButtonStack.enabled)
                {
                    foldout = EditorGUILayout.Foldout(foldout, "Back Button Handlers");
                    if (foldout)
                    {
                        EditorGUI.indentLevel++;
                        using (new EditorGUI.DisabledScope(true))
                        for (int i = backButtonStack.BackButtonHandlers.Count - 1; i >= 0; i--)
                        {
                            IBackButtonHandler backButtonHandler = backButtonStack.BackButtonHandlers[i];
                            if (backButtonHandler is Object obj)
                            {
                                EditorGUILayout.ObjectField($"{i}", obj, typeof(Object), true);
                            }
                            else
                            {
                                EditorGUILayout.TextField($"{i}", backButtonHandler.ToString());
                            }
                        }
                        EditorGUI.indentLevel--;
                    }
                }
            }
        }
}
