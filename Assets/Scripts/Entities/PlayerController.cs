using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttributeComponent))]
public class PlayerController : BaseEntityController
{
   
    // Start is called before the first frame update
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        AttributeComponent= GetComponent<AttributeComponent>();

        AttributeComponent.OnDeath += () =>
        {
            transform.DetachChildren(); 
            Destroy(gameObject);
            GameManager.Instance.GameOver(); 
        };
        AttributeComponent.OnDamage += () => { }; 
    }

    // Update is called once per frame
    void Update()
    {
        var movex = Input.GetAxis("Horizontal");
        var movey = Input.GetAxis("Vertical");

        if (movex < 0)
            MovementController.Direction = MovementDirection.Left; 
        else if (movex> 0)
            MovementController.Direction= MovementDirection.Right;

        if (movey < 0)
            MovementController.Direction= MovementDirection.Down;
        else if (movey > 0)
            MovementController.Direction= MovementDirection.Up;

        if (movex == 0 && movey == 0)
            MovementController.Direction = MovementDirection.None;

        //todo; proper attack key. 
        if (Input.GetButtonDown("Jump"))
            MovementController.Attack(); 
    }
}
