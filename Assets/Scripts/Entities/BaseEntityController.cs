using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(AttributeComponent))]
public class BaseEntityController : MonoBehaviour
{

    public MovementController MovementController;
    public AttributeComponent AttributeComponent;
    public SoundEffectController SoundEffectController; 
    // Start is called before the first frame update
    void Start()
    {
        MovementController = GetComponent<MovementController>();
        AttributeComponent = GetComponent<AttributeComponent>();

        AttributeComponent.OnDeath += () =>
        {
            Destroy(gameObject);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
