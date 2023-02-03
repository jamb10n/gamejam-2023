using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AssetImport : MonoBehaviour
{
    [MenuItem("AssetImport/Load Prefabs")]
    public static void LoadPrefabs()
    {
        using (var gameManagerobj = new PrefabUtility.EditPrefabContentsScope("Assets/Prefabs/GameManager.prefab"))
        {
            var prefabs = new List<PrefabDefinition>();

            var directories = Directory.GetDirectories("Assets/Prefabs");
            foreach (var d in directories)
            {
                var files = Directory.GetFiles(d).Where(x => Path.GetExtension(x) == ".prefab").ToList();
                foreach (var f in files)
                {
                    Debug.Log(f);
                    var name = Path.GetFileNameWithoutExtension(f);
                    prefabs.Add(new PrefabDefinition()
                    {
                        Name = name,
                        Prefab = (GameObject)AssetDatabase.LoadAssetAtPath(f, typeof(GameObject)),
                        Type = Path.GetFileName(d)
                    });
                }
            }

            var gamemanager = gameManagerobj.prefabContentsRoot.GetComponent<GameManager>();
            gamemanager.Prefabs = prefabs;

        }
    }

    [MenuItem("AssetImport/Load Scenes")]
    public static void LoadScenes()
    {
        var filesall = new List<string>();
        using (var gameManagerobj = new PrefabUtility.EditPrefabContentsScope("Assets/Prefabs/GameManager.prefab"))
        {
            var gamemanager = gameManagerobj.prefabContentsRoot.GetComponent<GameManager>();
            gamemanager.Scenes = new List<string>(); 
            var directories = Directory.GetDirectories("Assets");
            foreach (var d in directories)
            {
                var files = Directory.GetFiles(d).Where(x => Path.GetExtension(x) == ".unity").ToList();
                foreach (var f in files)
                {
                    filesall.Add(f); 
                    gamemanager.Scenes.Add(Path.GetFileNameWithoutExtension(f)); 
                }
            }

                
        }

        //now need to make sure Unity loads the scenes into the game. 

        List<EditorBuildSettingsScene> scenes = new List<EditorBuildSettingsScene>();
        var menu = filesall.FirstOrDefault(z => Path.GetFileName(z) == "MainMenu.unity");
        if (menu != null)
        {
            scenes.Add(new EditorBuildSettingsScene(menu, true));
            filesall.Remove(menu);
        }
        foreach (var f in filesall)
            scenes.Add(new EditorBuildSettingsScene(f, true)); 
        EditorBuildSettings.scenes = scenes.ToArray();
         
    }
        
}
