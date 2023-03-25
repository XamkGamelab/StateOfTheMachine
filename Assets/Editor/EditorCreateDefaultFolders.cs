using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorCreateDefaultFolders
{
    private static List<string> folders = new List<string>() {"Animations", "AudioFX", "AnimatorControllers", "Materials", "Models", "Music", "Prefabs", "Scripts", "Scenes", "Sprites", "Textures"};

    //First item in right-click Assets, no validation 
    [MenuItem("Assets/Create Default Assets Folders", false, 1)]
    static void CreateFolders()
    {
        bool b = AssetDatabase.IsValidFolder("Assets/Scripts");
        Debug.Log(b);
        folders.ForEach(folder => 
        {
            if (!AssetDatabase.IsValidFolder("Assets/" + folder))
                AssetDatabase.CreateFolder("Assets", folder);
            else
                Debug.LogWarning(folder + " folder already exists.");
        });
    }
}
