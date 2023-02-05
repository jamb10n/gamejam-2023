using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AttributeComponent))]
public class MovementController : MonoBehaviour
{
    public AttributeComponent Attributes;

    public Animator Animator; 

    public int attackCooldownTime; 

    MovementDirection direction;
    public MovementDirection Direction {
        get { return direction; }
        set
        {
            if (value != MovementDirection.None)
                FacingDirection = value;
            direction = value;

        } }

    public MovementDirection FacingDirection; 

    // Start is called before the first frame update
    void Start()
    {
        Attributes = GetComponent<AttributeComponent>();
        attackCooldownTime = 0; 
        Animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //can do nothing if in attack cooldown. 
        if (attackCooldownTime > 0)
        {
            attackCooldownTime--;
            return; 
        }
        Animator.SetBool("IsAttacking", false); 
        switch (Direction) 
        {
            case MovementDirection.Up:
                Animator.SetBool("IsWalking", true);
                Animator.SetInteger("Direction", 1); 
                transform.position += new Vector3(0, Attributes.MovementSpeed,  0) * Time.deltaTime; 
                break; 
                
            case MovementDirection.Down:
                Animator.SetBool("IsWalking", true);
                Animator.SetInteger("Direction", 3);
                transform.position += new Vector3(0, -Attributes.MovementSpeed,  0) * Time.deltaTime;
                break; 
            case MovementDirection.Left:
                Animator.SetBool("IsWalking", true);
                Animator.SetInteger("Direction", 0);
                transform.position += new Vector3(-Attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                break; 
            case MovementDirection.Right:
                Animator.SetBool("IsWalking", true);
                Animator.SetInteger("Direction", 2);
                transform.position += new Vector3(Attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                break;
                
            case MovementDirection.None:  
            default:
                Animator.SetBool("IsWalking", false);
                break;

        }
    }

    public void Attack()
    {
        if (attackCooldownTime > 0)
            return; 


       var hits =  Physics2D.BoxCastAll(transform.position, new Vector2(1, 1), 0, FacingDirection.VectorFromDirection(), Attributes.AttackDistance); 
        foreach(var hit in hits)
        {
            var attribute = hit.rigidbody.gameObject.GetComponent<AttributeComponent>();
            if (attribute.Faction != Attributes.Faction)
            {
                attribute.damage(Attributes.AttackPower); 
            }
        }
        if (hits.Length > 0)
        {
            attackCooldownTime = Attributes.AttackCooldown; 
        }
        Animator.SetBool("IsAttacking", true); 
    }
}
