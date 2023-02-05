using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttributeComponent))]
public class GuardAI : BaseAI
{
    public float MaxWander; 

    public GameObject Target; 

    public Vector3 GuardLocation; 
    // Start is called before the first frame update
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        AttributeComponent = GetComponent<AttributeComponent>();
        SoundEffectController = GetComponent<SoundEffectController>();

        AttributeComponent.OnDeath += () =>
        {
            this.SoundEffectController.PlaySound("OnDeath"); 
            Destroy(gameObject);
        };
        AttributeComponent.OnDamage += () => 
        {
            SoundEffectController.PlaySound("OnDamage");
        };

       
        GuardLocation = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            if (Vector2.Distance(Target.transform.position, transform.position) < AttributeComponent.AttackDistance)
            {
                MovementController.Attack();
                SoundEffectController.PlaySound("HAttack"); 
            }
            else if (Vector2.Distance(Target.transform.position, transform.position) > AttributeComponent.SightRange
                || Vector2.Distance(transform.position, GuardLocation) > MaxWander)
            {
                Target = null;
                DumbMoveToTarget(GuardLocation); 
            }
            else
            {
                DumbMoveToTarget(Target.transform.position); 
            }
            return; 
        }
        else
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, AttributeComponent.SightRange);
            Target = colliders.FirstOrDefault(z => z.GetComponent<AttributeComponent>() != null && z.GetComponent<AttributeComponent>()?.Faction != AttributeComponent.Faction)?.gameObject; 
        }
        

        if (transform.position != GuardLocation)
        {
            DumbMoveToTarget(GuardLocation); 
        }
    }
}
