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
        int tmpHP = CurrentHitPoints + hpIncAmount; 

  
        //are we going over the maximum amount?
        if(tmpHP>MaxHitPoints){
            //set to our maximum then
            CurrentHitPoints=MaxHitPoints;
        }
    }
    public void defBuff(int defIncAmount){
        //Checks health amount
        int tempDEF = DeffPoints + defIncAmount; 

  
        //are we going over the maximum amount?
        if(tempDEF>MaxDeffPoints){
            //set to our maximum then
            DeffPoints=tempDEF;
        }
    }
    public void attBuff(int attIncAmount){
        //Checks health amount
        int tmpAtt = AttackPower + attIncAmount; 

  
        //are we going over the maximum amount?
        if(tmpAtt>MaxAttackPower){
            //set to our maximum then
            AttackPower=tmpAtt;
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
