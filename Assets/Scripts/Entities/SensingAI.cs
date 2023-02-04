using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttributeComponent))]
public class SensingAI : BaseAI
{

    GameObject Target; 
    // Start is called before the first frame update
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        AttributeComponent = GetComponent<AttributeComponent>();

        AttributeComponent.OnDeath += () =>
        {
            Destroy(gameObject);
        };
        AttributeComponent.OnDamage += () => { };

        Target = GameManager.Instance.Player; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
            return; 

        if (Vector2.Distance(Target.transform.position, transform.position) < AttributeComponent.AttackDistance + 1)
        {
            MovementController.Attack(); 
        }
        else
            DumbMoveToTarget(Target.transform.position);
    }
}
