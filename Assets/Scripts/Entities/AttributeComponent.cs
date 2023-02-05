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
    public int MaxAttackPower;
    public int DeffPoints;
    public int MaxDeffPoints;
    public float MovementSpeed;
    public float AttackDistance;

    /// <summary>
    /// How far the AI can see. 
    /// </summary>
    public float SightRange; 

    /// <summary>
    /// How long between attacks before the entity can attack again. 
    /// </summary>
    public int AttackCooldown; 

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
            OnDeath?.Invoke(); 
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
    public void defBuff(int defIncAmount){
        DeffPoints += defIncAmount; 
        //are we going over the maximum amount?
        if(DeffPoints>MaxDeffPoints){
            //set to our maximum then
            DeffPoints=MaxDeffPoints;
        }
        else{
            

        }
    }
    public void attBuff(int attIncAmount){
        //Checks health amount
        AttackPower +=attIncAmount; 
        //are we going over the maximum amount?
        if(AttackPower>MaxAttackPower){
            //set to our maximum then
            AttackPower=MaxAttackPower;
        }
    }

    public void damage(int damage){
        //Check our damage
        int tempDMG = damage - DeffPoints;
        if(tempDMG > 0){
            CurrentHitPoints-= tempDMG;
        }
        OnDamage?.Invoke(); 

        //Damage animation? 
    }

    


}
