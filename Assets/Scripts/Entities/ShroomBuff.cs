using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomBuff : MonoBehaviour
{
    public int incHP;
    
    public int incDEF;
    
    public int incATT;



    void OnTriggerEnter2D(Collider2D collision)=>CheckCollision(collision);

    void CheckCollision(Collider2D collisionObj){
        string mushroomType=gameObject.tag; 
        AttributeComponent currentCollisiion =collisionObj.gameObject.GetComponent(typeof(AttributeComponent)) as AttributeComponent;
        if (currentCollisiion != null){
            switch(mushroomType){
                case "healing":
                    currentCollisiion.healing(incHP);
                break;
                case "attack":
                    currentCollisiion.attBuff(incATT);
                break;
                case "deffence":
                    currentCollisiion.defBuff(incDEF);
                break;
            }
        }
        
    }

}
