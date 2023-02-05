using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttributeComponent))]
public class RuneScript : MonoBehaviour
{

    public List<GameObject> Trash;

    public AttributeComponent Attribute; 

    // Start is called before the first frame update
    void Start()
    {
        Attribute = GetComponent<AttributeComponent>();
        Attribute.OnDeath += () =>
        {
            foreach(var obj in Trash)
            {
                obj.GetComponent<TrashScript>()?.Fade();
            }
            Destroy(gameObject);
        }; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
