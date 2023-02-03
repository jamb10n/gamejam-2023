using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttributeComponent))]
public class MovementController : MonoBehaviour
{
    public AttributeComponent Attributes; 


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
    }

    // Update is called once per frame
    void Update()
    {
        switch (Direction) 
        {
            case MovementDirection.Up:
                transform.position += new Vector3(0, Attributes.MovementSpeed,  0) * Time.deltaTime; 
                break; 
                
            case MovementDirection.Down:
                transform.position += new Vector3(0, -Attributes.MovementSpeed,  0) * Time.deltaTime;
                break; 
            case MovementDirection.Left:
                transform.position += new Vector3(-Attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                break; 
            case MovementDirection.Right:
                transform.position += new Vector3(Attributes.MovementSpeed, 0, 0) * Time.deltaTime;
                break;
                
            case MovementDirection.None:   
            default: break;

        }
    }

    public void Attack()
    {
       var hits =  Physics2D.BoxCastAll(transform.position, new Vector2(1, 1), 0, FacingDirection.VectorFromDirection(), Attributes.AttackDistance); 
        foreach(var hit in hits)
        {
            var attribute = hit.rigidbody.gameObject.GetComponent<AttributeComponent>();
            if (attribute.Faction != Attributes.Faction)
            {
                attribute.damage(Attributes.AttackPower); 
            }
        }

    }
}
