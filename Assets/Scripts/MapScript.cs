using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq; 

public class MapScript : MonoBehaviour
{
    public Vector3 PlayerSpawn;

    public Tilemap Background;

    public Tilemap Walls;

    public Tilemap ForeGround;

    public AudioClip LevelMusic;


    public List<GameObject> KillList;

    public string NextLevel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillList.RemoveAll(z => z == null); 
    }

    public IEnumerator LoadMap()
    {
        yield return null;
        var music = GameManager.Instance.Camera.GetComponent<AudioSource>();
        if (music != null)
        {
            music.clip = LevelMusic; 
            music.Play();
        }
        if (!string.IsNullOrWhiteSpace(NextLevel))
            StartCoroutine(WinCheck()); 
        //For anything that might need the map script to handle. 
    }

    IEnumerator WinCheck()
    {
        while (true)
        {
            if (KillList.Count() == 0)
            {
                yield return new WaitForSeconds(1); 
                if (NextLevel == "Victory")
                    GameManager.Instance.Victory();
                else
                    GameManager.Instance.LoadLevel(NextLevel);
                
                break; 
            }
            yield return null;
        }
    }

    public Vector3Int GetTileFromWorldLocation(Vector3 worldLocation)
    {
        return Background.WorldToCell(worldLocation);
    }

    public bool IsPassable(Vector3 location)
    {
        return IsPassable(GetTileFromWorldLocation(location)); 
    }

    public bool IsPassable(Vector3Int location)
    {
        return !Walls.HasTile(location);
    }
}
