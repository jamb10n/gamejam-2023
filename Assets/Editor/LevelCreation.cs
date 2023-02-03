using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{
    [MenuItem("Level Creation/Create New")]
    public static void CreateNewLevel()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        scene.name = "New Level";

        var mapPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Utility/Map.prefab"); 
        var levelMap = PrefabUtility.InstantiatePrefab(mapPrefab) as GameObject;
        PrefabUtility.UnpackPrefabInstance(levelMap, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

        var gmpre = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");

        PrefabUtility.InstantiatePrefab(gmpre); 
    }
}
