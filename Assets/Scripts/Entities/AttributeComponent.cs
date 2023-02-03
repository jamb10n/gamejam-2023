using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeComponent : MonoBehaviour
{

    public int CurrentHitPoints;
    public int MaxHitPoints;
    public int AttackPower;
    public float MovementSpeed;

    enum faction{
        Enemy,
        NPC
    };
    // Start is called before the first frame update
    void Start()
    {
        CurrentHitPoints = MaxHitPoints; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healing(int hpIncAmount){
        //Checks health amount
        int Health= hpIncAmount + CurrentHitPoints;
        //are we going over the maximum amount?
        if(Health>MaxHitPoints){
            //set to our maximum then
            CurrentHitPoints=MaxHitPoints;
        }
        else{
            //Set to the new health amount
            CurrentHitPoints=Health;
        }
    }
    public void damage(int damage){
        //Check our damage
        int Health= CurrentHitPoints - damage;
        if(Health <= 0){
            // raise a game over alert
            
        }
        else{
            //set our new health to the damaged amount
            CurrentHitPoints=Health;
            //raise animation
        }
    }

    


}
