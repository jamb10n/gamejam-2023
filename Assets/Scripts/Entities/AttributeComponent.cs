using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum faction{
        Enemy,
        NPC, 
        Player
    };

public delegate void OnDeath();

public delegate void OnDamage(); 

public class AttributeComponent : MonoBehaviour
{

    public int CurrentHitPoints;
    public int MaxHitPoints;
    public int AttackPower;
    public float MovementSpeed;

    public float AttackDistance; 

    public faction Faction; 

    public OnDeath OnDeath;
    public OnDamage OnDamage;   
 
    // Start is called before the first frame update
    void Start()
    {
        CurrentHitPoints = MaxHitPoints; 
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHitPoints <= 0)
        {
            OnDeath(); 
        }
    }

    public void healing(int hpIncAmount){
        //Checks health amount
        CurrentHitPoints += hpIncAmount; 

  
        //are we going over the maximum amount?
        if(CurrentHitPoints>MaxHitPoints){
            //set to our maximum then
            CurrentHitPoints=MaxHitPoints;
        }
    }
    public void damage(int damage){
        //Check our damage
        Debug.Log($"{gameObject.name} has taken {damage} damage"); 

        CurrentHitPoints -= damage;
        OnDamage(); 

        //Damage animation? 
    }

    


}
