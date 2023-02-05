using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.Animation;

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
    #region Import Sprites

    [MenuItem("AssetImport/Import Sprites")]
    public static void ImportCharacterSprites()
    {
        string direct = "Assets/Resources/Entities";
        var files = Directory.GetFiles(direct)
                .Where(x => new string[] { ".png", ".jpg" }.Contains(Path.GetExtension(x))).ToList();

        foreach (var file in files)
        {
            GenerateAnimations(file);
        }

    }

    static void GenerateAnimations(string file)
    {
        var sprites = AssetDatabase.LoadAllAssetsAtPath(file).Where(z => z is Sprite).Cast<Sprite>().ToList();

        var name = Path.GetFileNameWithoutExtension(file);

        var asset = ScriptableObject.CreateInstance<SpriteLibraryAsset>();

        for (int idx = 0; idx < 8; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "walkleft", $"left{idx}"); 
        }

        for (int idx = 8; idx < 16; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "walkright", $"right{idx}");
        }
        for (int idx = 16; idx < 24; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "walkup", $"up{idx}");
        }
        for (int idx = 24; idx < 32; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "walkdown", $"down{idx}");
        }
        for (int idx = 32; idx < 40; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "attleft", $"atleft{idx}");
        }
        for (int idx = 40; idx < 48; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "attright", $"atright{idx}");
        }
        for (int idx = 48; idx < 56; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "attup", $"atup{idx}");
        }
        for (int idx = 56; idx < 64; idx++)
        {
            asset.AddCategoryLabel(sprites[idx], "attdown", $"atdown{idx}");
        }

        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath("Assets/SpriteLibraries/" + $"{name}Library.asset"));
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.SetDirty(asset);
    }

    #endregion
}
