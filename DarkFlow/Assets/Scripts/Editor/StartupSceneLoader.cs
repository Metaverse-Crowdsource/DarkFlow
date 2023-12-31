using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

namespace DarkFlow.Editor
{
    [InitializeOnLoadAttribute]
    public static class StartupSceneLoader
    {
        static StartupSceneLoader()
        {
            //EditorApplication.playModeStateChanged += LoadStartupScene;
        }

        static void LoadStartupScene(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingEditMode)
            {
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            }

            if (state == PlayModeStateChange.EnteredPlayMode)
            {
                if (EditorSceneManager.GetActiveScene().buildIndex != 0 && EditorSceneManager.GetActiveScene().name != "systemTest")
                {
                    EditorSceneManager.LoadScene(0);

                }
            }
        }
    }
}