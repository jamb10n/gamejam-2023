using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttributeComponent))]
public class PatrolAI : BaseAI
{
    public float MaxWander;

    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        AttributeComponent = GetComponent<AttributeComponent>();
        SoundEffectController= GetComponent<SoundEffectController>();

        AttributeComponent.OnDeath += () =>
        {
            SoundEffectController.PlaySound("OnDeath");
            Destroy(gameObject);
        };
        AttributeComponent.OnDamage += () => {
            SoundEffectController.PlaySound("OnDamage");
        };

        if (Waypoints.Count == 0) 
        {
            Waypoints.Add(transform.position);
        }
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
                || (MaxWander > 0 && Vector2.Distance(transform.position, Waypoints[CurrentWaypoint]) > MaxWander))
            {
                Target = null;
                WaypointMove();
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

        WaypointMove();
    }
}
