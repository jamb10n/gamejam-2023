using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<PrefabDefinition> Prefabs; 

    public Dictionary<string, GameObject> PrefabsDict;

    public List<string> Scenes;

    public GameObject Player;

    public GameUIScript GameUI; 

    /// <summary>
    /// Main camera the game has running, for easy access. 
    /// </summary>
    public Camera Camera; 

    public MapScript Map; 


    // Start is called before the first frame update
    void Start()
    {
        //Only one Gamemanager at a time. 
        if (Instance != null)
        {
            Destroy(gameObject);
            return; 
        }
        GameUI = GetComponentInChildren<GameUIScript>();
        Instance= this;
        DontDestroyOnLoad(gameObject); //one GameManager always. 

        PrefabsDict = new Dictionary<string, GameObject>();
        foreach (var prefab in Prefabs)
        {
            PrefabsDict.Add(prefab.Name, prefab.Prefab); 
        }

        if (Camera == null)
        {
            //create new camera here since we somehow lost the old one. 
            Camera = Instantiate(PrefabsDict["Camera"]).GetComponent<Camera>();
            DontDestroyOnLoad(Camera);
        }
        //remove when we have a menu. 
        //StartGame();
        StartCoroutine(LevelLoad("MainMenu")); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadLevel(string level)
    {
        StartCoroutine(LevelLoad(level));
    }

    public static void StartNewGame()
    {
        GameManager.Instance.StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(NewGame());
    }

    private IEnumerator LevelLoad(string level) 
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single); 
        yield return null; 
        Map = FindObjectOfType<MapScript>();
        yield return StartCoroutine(Map.LoadMap()); 

        if (Player != null)
            Player.transform.position = Map.PlayerSpawn; 
    }

    IEnumerator NewGame()
    {
        yield return null;

        if (Player!= null) 
        {
            Player.transform.DetachChildren();
            Destroy(Player);
            yield return null;
        }
        if (Camera == null) 
        {
            //create new camera here since we somehow lost the old one. 
            Camera = Instantiate(PrefabsDict["Camera"]).GetComponent<Camera>();
            DontDestroyOnLoad(Camera);
        }
        Player = Instantiate(PrefabsDict["Player"]); 
        DontDestroyOnLoad(Player);
        Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Camera.transform.position.z);
        Camera.transform.SetParent(Player.transform); 
        yield return null;
        yield return StartCoroutine(LevelLoad("Level1"));          
        GameUI.ClearScreens(); 
    }

    public void GameOver()
    {
        GameUI.ShowGameOver();
       // Debug.LogError("Game over not yet implemented"); 
    }

    public void Victory()
    {
        GameUI.ShowVictoryScreen();
    }
}
