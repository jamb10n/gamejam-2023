using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttributeComponent))]
[RequireComponent(typeof(SoundEffectController))]
public class PlayerController : BaseEntityController
{
   
    // Start is called before the first frame update
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        AttributeComponent= GetComponent<AttributeComponent>();
        SoundEffectController = GetComponent<SoundEffectController>();

        AttributeComponent.OnDeath += () =>
        {
            SoundEffectController.PlaySound("OnDeath"); 
            transform.DetachChildren(); 
            Destroy(gameObject);
            GameManager.Instance.GameOver(); 
        };
        AttributeComponent.OnDamage += () => 
        {
            SoundEffectController.PlaySound("OnDamage"); 
        }; 
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
        {
            MovementController.Attack();
            SoundEffectController.PlaySound("HAttack"); 
        }
    }
}
