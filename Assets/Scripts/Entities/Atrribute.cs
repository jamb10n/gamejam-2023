using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atrribute : MonoBehaviour
{
    enum faction{
        Enemy,
        NPC
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healing(int hpIncAmmount){
        //Checks health ammout
        int Health= hpIncAmmount + CurrentHitPoints;
        //are we going over the maximum ammount?
        if(Health>MaxHitPoints){
            //set to our maximum then
            CurrentHitPoints=MaxHitPoints;
        }
        else{
            //Set to the new health ammount
            CurrentHitPoints=Health;
        }
    }
    public void healing(int damage){
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

    public int CurrentHitPoints{
        get{return _currentHitPoints;}
        set{_currentHitPoints=value;}
    }
    public int MaxHitPoints{
        get{return _maxHitPoints;}
        set{_maxHitPoints=value;}
    }
    public int AttackPower{
        get{return _attackPower;}
        set{_attackPower=value;}
    }
    public float MovementSpeed{
        get{return _movementSpeed;}
        set{_movementSpeed=value;}
    }


}
