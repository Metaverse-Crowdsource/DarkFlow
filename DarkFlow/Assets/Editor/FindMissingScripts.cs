using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class FindMissingScripts : EditorWindow
{
    [MenuItem("Window/Find Missing Scripts")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FindMissingScripts));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Find Missing Scripts in Selected GameObjects"))
        {
            FindInSelected();
        }
    }

    private static void FindInSelected()
    {
        GameObject[] go = Selection.gameObjects;
        List<GameObject> objectsWithMissingScripts = new List<GameObject>();
        foreach (GameObject g in go)
        {
            Component[] components = g.GetComponents<Component>();
            foreach (Component c in components)
            {
                if (c == null)
                {
                    objectsWithMissingScripts.Add(g);
                    Debug.Log("Missing script found in: " + FullPath(g), g);
                }
            }
        }

        if (objectsWithMissingScripts.Count > 0)
        {
            Debug.Log("Found " + objectsWithMissingScripts.Count + " GameObjects with missing scripts.", objectsWithMissingScripts[0]);
        }
        else
        {
            Debug.Log("No GameObjects with missing scripts found in selection.");
        }
    }

    private static string FullPath(GameObject go)
    {
        return go.transform.parent == null
            ? go.name
            : FullPath(go.transform.parent.gameObject) + "/" + go.name;
    }
}
