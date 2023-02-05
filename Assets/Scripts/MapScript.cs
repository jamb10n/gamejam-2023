using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapScript : MonoBehaviour
{
    public Vector3 PlayerSpawn;

    public Tilemap Background;

    public Tilemap Walls;

    public Tilemap ForeGround;

    public AudioClip LevelMusic; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //For anything that might need the map script to handle. 
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
