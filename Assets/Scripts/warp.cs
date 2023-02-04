using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warp : MonoBehaviour
{
    public string nextLevel;
    void OnTriggerEnter2D(Collider2D collision)=>CheckCollision(collision.gameObject.tag);
    void CheckCollision(string tester){
        if( tester == "Player"){
            GameManager.Instance.LoadLevel(nextLevel);
        }
    }
}
