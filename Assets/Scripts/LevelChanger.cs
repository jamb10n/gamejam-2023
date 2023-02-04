using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public string NextLevel;
    void OnTriggerEnter2D(Collider2D collision)=>CheckCollision(collision.gameObject.tag);
    void CheckCollision(string tagOfCollision){
        if( tagOfCollision == "Player"){
            GameManager.Instance.LoadLevel(NextLevel);
        }
    }
}
