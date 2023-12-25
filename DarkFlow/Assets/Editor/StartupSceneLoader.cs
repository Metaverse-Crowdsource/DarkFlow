using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using Unity.Services.Authentication;
#if UNITY_EDITOR
using ParrelSync;
#endif

[InitializeOnLoadAttribute]
public static class StartupSceneLoader
{
    static StartupSceneLoader()
    {

#if UNITY_EDITOR
        if (ParrelSync.ClonesManager.IsClone())
        {
            string customArgument = ParrelSync.ClonesManager.GetArgument();
            AuthenticationService.Instance.SwitchProfile($"Clone_{customArgument}_Profile");
            //Debug.Log("_______" + AuthenticationService.Instance.GetPlayerNameAsync());
        }
#endif

        EditorApplication.playModeStateChanged += LoadStartupScene;


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